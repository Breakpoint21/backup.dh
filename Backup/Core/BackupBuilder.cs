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
				Console.WriteLine(Process.GetCurrentProcess().PrivateMemorySize64);
				f.BuildFile(file);
				byteFiles.Add(f);
			}

			string tempFile = Path.GetTempFileName();
			manifest = new byte[byteFiles.Count * 76];
			for (int i = 0; i < byteFiles.Count; i++)                
			{
				BackupFile byteFile = byteFiles[i];
				System.Buffer.BlockCopy(byteFile.GUID, 0, manifest, i*76, byteFile.GUID.Length);
				System.Buffer.BlockCopy(BitConverter.GetBytes(byteFile.Length), 0, manifest, (i*76)+72, 4);
			}
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
					//if (Worker != null)
					//{
					//    Worker.ReportProgress((int)100 /byteFiles.Count);
					//}
				}
				fs.Close();
				Console.WriteLine(Process.GetCurrentProcess().PrivateMemorySize64);
			}
			watch.Stop();
			Logger.Log("Build Temp file took: " + watch.ElapsedMilliseconds + "ms", Logger.Level.DIAGNOSTIC);
			Compress(tempFile);
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
				int progress = 1;

				while (inFile.Position < inFile.Length)
				{
					inFile.Read(block, 0, block.Length);
					zip.Write(block, 0, block.Length);
					if (Worker != null)
					{
						Worker.ReportProgress((int) (((double)inFile.Position/(double)inFile.Length)*100));
					}
				}
                //BinaryFormatter formatter = new BinaryFormatter();
                //try
                //{
                //    formatter.Serialize(zip, FilesToBackup);
                //}
                //catch (SerializationException e)
                //{
                //    Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                //    throw;
                //}
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
