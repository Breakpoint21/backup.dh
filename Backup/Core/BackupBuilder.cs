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
		byte[] header;
		byte[] manifest;

		public BackupBuilder()
		{
			
		}

		public void BuildBackup(List<FileInfo> files, FileInfo destination)
		{
            FilesToBackup = files;
			Stopwatch watch = new Stopwatch();
			watch.Start();
			Destination = destination;
			List<BackupFile> byteFiles = new List<BackupFile>();
            
			foreach (FileInfo file in files)
			{
				BackupFile f = new BackupFile();
				f.BuildFile(file);
				byteFiles.Add(f);
			}
            manifest = buildManifest(files, byteFiles);
			string tempFile = Path.GetTempFileName();
            //Header = 4Byte Number of Files 4Byte Size of Manifest -> 8Byte
			header = new byte[8];
			System.Buffer.BlockCopy(BitConverter.GetBytes(byteFiles.Count), 0, header, 0, 4);
			System.Buffer.BlockCopy(BitConverter.GetBytes(manifest.Length), 0, header, 4, 4);

			using (FileStream fs = new FileStream(tempFile, FileMode.Open, FileAccess.Write))
			{
				fs.Write(header, 0, header.Length);
				fs.Write(manifest, 0, manifest.Length);
				foreach (BackupFile byteFile in byteFiles)
				{
					
					foreach (byte[] item in byteFile.File)
					{
						fs.Write(item, 0, item.Length);
					}
				}
				fs.Close();
				Console.WriteLine(Process.GetCurrentProcess().PrivateMemorySize64);
			}
			watch.Stop();
			Logger.Log("Build Temp file took: " + watch.ElapsedMilliseconds + "ms", Logger.Level.DIAGNOSTIC);
			Compress(tempFile);
		}

        private byte[] buildManifest(List<FileInfo> files, List<BackupFile> byteFiles)
        {
            byte[] ret;
            Dictionary<FileInfo, long> manifest = new Dictionary<FileInfo, long>();
            for (int i = 0; i < files.Count; i++)
            {
                manifest.Add(files[i], byteFiles[i].Length);
            }
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

		private void Compress(string tempFile)
		{
			Stopwatch watch = new Stopwatch();
			watch.Start();
			FileInfo temp = new FileInfo(tempFile);
			FileStream inFile = temp.OpenRead();
			FileStream outFile = new FileStream(Destination.FullName, FileMode.Create, FileAccess.Write);
			using (GZipStream zip = new GZipStream(outFile, CompressionMode.Compress))
			{
                byte[] block = new byte[inFile.Length/100];

				while (inFile.Position < inFile.Length)
				{
					inFile.Read(block, 0, block.Length);
					zip.Write(block, 0, block.Length);
					if (Worker != null)
					{
						Worker.ReportProgress((int) (((double)inFile.Position/(double)inFile.Length)*100));
					}
				}
				zip.Close();
			}
			inFile.Close();
			outFile.Close();

			watch.Stop();
			Logger.Log("Compress file took: " + watch.ElapsedMilliseconds + "ms (" + (temp.Length/1024) + " bytes)", Logger.Level.DIAGNOSTIC);
			temp.Delete();
		}
	}
}
