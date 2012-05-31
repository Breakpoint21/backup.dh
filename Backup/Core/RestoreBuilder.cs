using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace Backup.Core
{
    class RestoreBuilder
    {
        byte[] header;
        byte[] manifest;
        public RestoreBuilder()
        {

        }

        public bool RestoreBackup(string path, DirectoryInfo destination, BackgroundWorker worker)
        {
            StringBuilder summary = new StringBuilder();
            FileInfo tempFile = Decompress(path, worker);
            if (tempFile == null)
            {
                return false;
            }
            int itemCount;
            header = new byte[8];
            try
            {
                using (FileStream reader = new FileStream(tempFile.FullName, FileMode.Open, FileAccess.Read))
                {
                    reader.Read(header, 0, 8);
                    itemCount = BitConverter.ToInt32(header, 0);
                    manifest = new byte[BitConverter.ToInt32(header, 4)];
                    reader.Read(manifest, 0, manifest.Length);
                    for (int i = 0; i < itemCount; i++)
                    {
                        BackupFile f = new BackupFile();
                        summary.AppendLine(f.restore(reader, destination));
                        worker.ReportProgress((int)(((double)i / (double)itemCount) * 100));
                    }
                    reader.Close();
                    summary.AppendLine();
                    summary.AppendLine("Number of Files: " + itemCount);
                    summary.AppendFormat("Size of all restored Files: {0} KB", (tempFile.Length / 1024));
                }
                tempFile.Delete();
            }
            catch (Exception ex)
            {
                Logger.Log("Error while restoring complete Backup. Message: " + ex.Message, Logger.Level.ERROR);
                return false;
            }
            RestoreController ctrl = RestoreController.getInstance();
            ctrl.Summary = summary.ToString();
            return true;
        }

        public Dictionary<FileInfo, long> createIndex(string path)
        {
            Dictionary<FileInfo, long> files = null;
            Stopwatch watch = new Stopwatch();
            watch.Start();
            header = new byte[8];
            FileStream reader = new FileStream(path, FileMode.Open, FileAccess.Read);
            using (GZipStream zipStream = new GZipStream(reader, CompressionMode.Decompress))
            {
                zipStream.Read(header, 0, header.Length);
                manifest = new byte[BitConverter.ToInt32(header, 4)];
                zipStream.Read(manifest, 0, manifest.Length);
                
                using (MemoryStream memStr = new MemoryStream(manifest))
                {
                    memStr.Write(manifest, 0, manifest.Length);
                    memStr.Seek(0, SeekOrigin.Begin);
                    try
                    {
                        BinaryFormatter formatter = new BinaryFormatter();

                        files = (Dictionary<FileInfo, long>)formatter.Deserialize(memStr);
                    }
                    catch (SerializationException e)
                    {
                        Logger.Log(e.Message, Logger.Level.ERROR);
                    }
                    finally
                    {
                        memStr.Close();
                    }
                }
                zipStream.Close();
            }
            watch.Stop();
            Logger.Log("Creating Index with " + files.Count + " Items took: " + watch.ElapsedMilliseconds + "ms", Logger.Level.DIAGNOSTIC);
            
            return files;
        }

        private FileInfo Decompress(string path, BackgroundWorker worker)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            FileInfo zipFile = new FileInfo(path);
            FileInfo tempFile = new FileInfo(Path.GetTempFileName());
            try
            {
                FileStream compressedStream = zipFile.OpenRead();
                FileStream decompressedStream = tempFile.OpenWrite();

                using (GZipStream zipStrem = new GZipStream(compressedStream, CompressionMode.Decompress))
                {
                    byte[] block = new byte[compressedStream.Length / 100];

                    while (compressedStream.Position < compressedStream.Length)
                    {
                        zipStrem.Read(block, 0, block.Length);
                        decompressedStream.Write(block, 0, block.Length);
                        if (worker != null)
                        {
                            worker.ReportProgress((int)(((double)compressedStream.Position / (double)compressedStream.Length) * 100));
                        }
                    }
                    zipStrem.Close();
                }
                compressedStream.Close();
                decompressedStream.Close();
                worker.ReportProgress(0);
            }
            catch (Exception ex)
            {
                Logger.Log("Error while Decompressing File. Message: " + ex.Message, Logger.Level.ERROR);
                if (tempFile.Exists)
                {
                    tempFile.Delete();
                }
                return null;
            }
            watch.Stop();
            Logger.Log("Decompress file took: " + watch.ElapsedMilliseconds + "ms (" + (zipFile.Length/1024) + " bytes)", Logger.Level.DIAGNOSTIC);
            return tempFile;
        }

        internal bool RestoreSelectedFiles(FileInfo BackupFile, DirectoryInfo RestoreDestination, Dictionary<FileInfo, long> SelectedFiles, BackgroundWorker worker)
        {
            //Create Dictorary which holds the offset for every File
            Dictionary<FileInfo, long> index = createIndex(BackupFile.FullName);
            Dictionary<string, long> offsetIndex = new Dictionary<string, long>();
            StringBuilder summary = new StringBuilder();
            long offset = 0;
            foreach (KeyValuePair<FileInfo, long> item in index)
            {
                offsetIndex.Add(item.Key.Name, offset);
                offset += item.Value;
            }

            FileInfo tempFile = Decompress(BackupFile.FullName, worker);
            if (tempFile == null)
            {
                return false;
            }
            header = new byte[8];
            try
            {
                using (FileStream reader = new FileStream(tempFile.FullName, FileMode.Open, FileAccess.Read))
                {
                    //Read Header and Manifest
                    reader.Read(header, 0, 8);
                    manifest = new byte[BitConverter.ToInt32(header, 4)];
                    reader.Read(manifest, 0, manifest.Length);
                    //Read and Restore each selected File
                    int it = 0;
                    foreach (KeyValuePair<FileInfo, long> file in SelectedFiles)
                    {
                        long pos = offsetIndex[file.Key.Name];
                        reader.Seek((header.Length + manifest.Length + pos), SeekOrigin.Begin);
                        BackupFile f = new BackupFile();
                        f.restore(reader, RestoreDestination);
                        summary.AppendLine(file.Key.FullName);
                        worker.ReportProgress((int)(100 * ((double)it / (double)SelectedFiles.Count)));
                        it++;
                    }
                    reader.Close();
                    summary.AppendLine();
                    summary.AppendFormat("Number of restored Files: {0}", SelectedFiles.Count);
                }
                tempFile.Delete();
                RestoreController ctrl = RestoreController.getInstance();
                ctrl.Summary = summary.ToString();
            }
            catch (Exception ex)
            {
                Logger.Log("Error while restoring selected Files. Message: " + ex.Message, Logger.Level.ERROR);
                return false;
            }
            return true;
        }
    }
}
