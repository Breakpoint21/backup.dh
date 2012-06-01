using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Backup.Core
{
	class BackupBuilder
	{
		private FileInfo destination;
		private BackgroundWorker worker;
        private List<FileInfo> filesToBackup;

		byte[] header;
		byte[] manifest;

		public BackupBuilder()
		{
			
		}

		public bool BuildBackup(List<FileInfo> files, FileInfo destination)
		{
            FilesToBackup = files;
            Destination = destination;
            StringBuilder summary = new StringBuilder();
            List<BackupFile> byteFiles = new List<BackupFile>();
            List<FileInfo> toRemove = new List<FileInfo>();
            //
			Stopwatch watch = new Stopwatch();
			watch.Start();
            //
            BuildByteFiles(byteFiles, toRemove);
            manifest = buildManifest(byteFiles);
			string tempFile = Path.GetTempFileName();
			
            try
            {
                //Building Header, first 4Byte Number of Files, last 4 Byte Lenght of Manifest
                header = new byte[8];
                System.Buffer.BlockCopy(BitConverter.GetBytes(byteFiles.Count), 0, header, 0, 4);
                System.Buffer.BlockCopy(BitConverter.GetBytes(manifest.Length), 0, header, 4, 4);

                using (FileStream fs = new FileStream(tempFile, FileMode.Open, FileAccess.Write))
                {
                    fs.Write(header, 0, header.Length);
                    fs.Write(manifest, 0, manifest.Length);
                    double progress = 0;
                    foreach (BackupFile byteFile in byteFiles)
                    {
                        foreach (byte[] item in byteFile.File)
                        {
                            fs.Write(item, 0, item.Length);
                        }
                        progress += (100 / (double) byteFiles.Count);
                        Worker.ReportProgress((int)progress);
                    }
                    fs.Close();
                }
                AppendSavedFiles(summary);
                Worker.ReportProgress(0);
            }
            catch (Exception ex)
            {
                Logger.Log("Error while creating Backup Container" + ex.Message, Logger.Level.ERROR);
                //Cleanup when File was written
                if (new FileInfo(tempFile).Exists)
                {
                    new FileInfo(tempFile).Delete();
                }
                Worker.ReportProgress(0);
                return false;
            }
			watch.Stop();
			Logger.Log("Build Temp file took: " + watch.ElapsedMilliseconds + "ms (Size: " + new FileInfo(tempFile).Length / 1024 + "KB)", Logger.Level.DIAGNOSTIC);
            bool ret = Compress(tempFile);
            AppendSummary(destination, summary, toRemove);
			return ret;
		}

        private void AppendSavedFiles(StringBuilder summary)
        {
            foreach (FileInfo file in FilesToBackup)
            {
                summary.AppendLine(file.FullName);
            }
            summary.AppendLine();
            summary.AppendFormat("Number of saved Files: {0}", FilesToBackup.Count);
        }

        private void BuildByteFiles(List<BackupFile> byteFiles, List<FileInfo> toRemove)
        {
            Worker.ReportProgress(0);
            double progress = 0;
            foreach (FileInfo file in FilesToBackup)
            {
                BackupFile f = new BackupFile();
                if (f.BuildFile(file))
                {
                    byteFiles.Add(f);
                }
                else
                {
                    toRemove.Add(file);
                }
                progress += (100 / (double)FilesToBackup.Count);
                Worker.ReportProgress((int)progress);
            }
            foreach (FileInfo file in toRemove)
            {
                FilesToBackup.Remove(file);
            }
            Worker.ReportProgress(0);
        }

        /// <summary>
        /// Builds the Summery, when Saving the File is finsihed
        /// </summary>
        /// <param name="destination">Destination of the backup File</param>
        /// <param name="summary">StringBuilder to append</param>
        /// <param name="toRemove">List of Files which couldn't be saved</param>
        private void AppendSummary(FileInfo destination, StringBuilder summary, List<FileInfo> toRemove)
        {
            destination.Refresh();
            summary.AppendLine();
            summary.AppendLine("Errors:");
            foreach (FileInfo file in toRemove)
            {
                summary.AppendLine(file.FullName);
            }
            summary.AppendLine();
            summary.AppendFormat("Size of Backup Container: {0} KB", destination.Length / 1024);
            BackupController ctrl = BackupController.getInstance();
            ctrl.Summary = summary.ToString();
        }

        private byte[] buildManifest(List<BackupFile> byteFiles)
        {
            byte[] ret;
            Dictionary<FileInfo, long> manifest = new Dictionary<FileInfo, long>();
            //Saving the Size of the original File
            for (int i = 0; i < FilesToBackup.Count; i++)
            {
                manifest.Add(FilesToBackup[i], byteFiles[i].Length);
            }
            //Serialing the Dictonary to a byte[] which will later be written into the backup container
            using (MemoryStream memStr = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                try
                {
                    formatter.Serialize(memStr, manifest);
                }
                catch (SerializationException e)
                {
                    Logger.Log(e.Message, Logger.Level.ERROR);
                }
                ret = new byte[memStr.Length];
                memStr.Seek(0, SeekOrigin.Begin);
                memStr.Read(ret, 0, ret.Length);
                memStr.Close();
            }
            return ret;
        }

		private bool Compress(string tempFile)
		{
			Stopwatch watch = new Stopwatch();
			watch.Start();
			FileInfo temp = new FileInfo(tempFile);
            try
            {
                FileStream inFile = temp.OpenRead();
                FileStream outFile = new FileStream(Destination.FullName, FileMode.Create, FileAccess.Write);
                using (GZipStream zip = new GZipStream(outFile, CompressionMode.Compress))
                {
                    byte[] block = new byte[inFile.Length / 100];

                    while (inFile.Position < inFile.Length)
                    {
                        inFile.Read(block, 0, block.Length);
                        zip.Write(block, 0, block.Length);
                        if (Worker != null)
                        {
                            Worker.ReportProgress((int)(((double)inFile.Position / (double)inFile.Length) * 100));
                        }
                    }
                    zip.Close();
                }
                inFile.Close();
                outFile.Close();
            }
            catch (Exception ex)
            {
                Logger.Log("Error while compressing the Backup File. Message: " + ex.Message, Logger.Level.ERROR);
                Worker.ReportProgress(0);
                return false;
            }
			watch.Stop();
			Logger.Log("Compress file took: " + watch.ElapsedMilliseconds + "ms (" + (temp.Length/1024) + " bytes)", Logger.Level.DIAGNOSTIC);
			temp.Delete();
            return true;
		}

        #region properties
        public List<FileInfo> FilesToBackup
        {
            get { return filesToBackup; }
            set { filesToBackup = value; }
        }

        public BackgroundWorker Worker
        {
            get { return worker; }
            set { worker = value; }
        }

        public FileInfo Destination
        {
            get { return destination; }
            set { destination = value; }
        }
        #endregion
    }
}
