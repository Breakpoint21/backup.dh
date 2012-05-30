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

namespace Backup.Core
{
    class RestoreBuilder
    {
        byte[] header;
        byte[] manifest;
        public RestoreBuilder()
        {

        }

        public void RestoreBackup(string path, DirectoryInfo destination)
        {
            FileInfo tempFile = Decompress(path);
            int itemCount;
            header = new byte[8];
            using (FileStream reader = new FileStream(tempFile.FullName, FileMode.Open, FileAccess.Read))
            {
                reader.Read(header, 0, 8);
                itemCount = BitConverter.ToInt32(header, 0);
                manifest = new byte[BitConverter.ToInt32(header, 4)];
                reader.Read(manifest, 0, manifest.Length);
                for (int i = 0; i < itemCount; i++)
                {
                    BackupFile f = new BackupFile();
                    f.restore(reader, destination);
                }
                reader.Close();
            }
            tempFile.Delete();
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

        private FileInfo Decompress(string path)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            FileInfo zipFile = new FileInfo(path);
            FileInfo tempFile = new FileInfo(Path.GetTempFileName());

            FileStream compressedStream = zipFile.OpenRead();
            FileStream decompressedStream = tempFile.OpenWrite();

            using (GZipStream zipStrem = new GZipStream(compressedStream, CompressionMode.Decompress))
            {
                zipStrem.CopyTo(decompressedStream);
                zipStrem.Close();
            }
            compressedStream.Close();
            decompressedStream.Close();

            watch.Stop();
            Logger.Log("Decompress file took: " + watch.ElapsedMilliseconds + "ms (" + (zipFile.Length/1024) + " bytes)", Logger.Level.DIAGNOSTIC);
            return tempFile;
        }

        internal void RestoreSelectedFiles(FileInfo BackupFile, DirectoryInfo RestoreDestination, Dictionary<FileInfo, long> SelectedFiles)
        {
            //Create Dictorary which holds the offset for every File
            Dictionary<FileInfo, long> index = createIndex(BackupFile.FullName);
            Dictionary<string, long> offsetIndex = new Dictionary<string, long>();
            long offset = 0;
            foreach (KeyValuePair<FileInfo, long> item in index)
            {
                offsetIndex.Add(item.Key.Name, offset);
                offset += item.Value;
            }

            FileInfo tempFile = Decompress(BackupFile.FullName);
            header = new byte[8];
            using (FileStream reader = new FileStream(tempFile.FullName, FileMode.Open, FileAccess.Read))
            {
                //Read Header and Manifest
                reader.Read(header, 0, 8);
                manifest = new byte[BitConverter.ToInt32(header, 4)];
                reader.Read(manifest, 0, manifest.Length);
                //Read and Restore each selected File
                foreach (KeyValuePair<FileInfo, long> file in SelectedFiles)
                {
                    long pos = offsetIndex[file.Key.Name];
                    reader.Seek((header.Length + manifest.Length + pos), SeekOrigin.Begin);
                    BackupFile f = new BackupFile();
                    f.restore(reader, RestoreDestination);
                }
                reader.Close();
            }
            tempFile.Delete();
        }
    }
}
