using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Collections.ObjectModel;
using System.Diagnostics;

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

        public List<string> createIndex(string path)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            List<string> ret = new List<string>();
            header = new byte[8];
            FileStream reader = new FileStream(path, FileMode.Open, FileAccess.Read);
            using (GZipStream zipStream = new GZipStream(reader, CompressionMode.Decompress))
            {
                zipStream.Read(header, 0, header.Length);
                manifest = new byte[BitConverter.ToInt32(header, 4)];
                zipStream.Read(manifest, 0, manifest.Length);
                List<int> contents = new List<int>();
                for (int i = 0; i < BitConverter.ToInt32(header, 0); i++)
                {
                    byte[] id = new byte[72];
                    byte[] size = new byte[4];
                    System.Buffer.BlockCopy(manifest, i*76, id, 0, id.Length);
                    System.Buffer.BlockCopy(manifest, i*76+72, size, 0, size.Length);
                    contents.Add(BitConverter.ToInt32(size, 0));
                }

                foreach (int length in contents)
                {
                    byte[] nameLength = new byte[4];
                    byte[] trash = new byte[1024];
                    zipStream.Read(trash, 0, 72);
                    zipStream.Read(nameLength, 0, nameLength.Length);
                    byte[] name = new byte[BitConverter.ToInt32(nameLength, 0)];
                    zipStream.Read(trash, 0, 20);
                    zipStream.Read(name, 0, name.Length);
                    ret.Add(Encoding.Unicode.GetString(name));
                    int notNeededBytes = length - (20 + 72 + nameLength.Length + name.Length);
                    int counter = (notNeededBytes + trash.Length - 1) / trash.Length;
                    for (int i = 0; i < counter; i++)
                    {
                        if (i == counter - 1)
                        {
                            zipStream.Read(trash, 0, (length-(i*trash.Length))-(20+72+nameLength.Length+name.Length));
                        }
                        else
                        {
                            zipStream.Read(trash, 0, trash.Length);
                        }
                    }
                    
                }
                zipStream.Close();
            }
            watch.Stop();
            Logger.Log("Creating Index with " + ret.Count + " Items took: " + watch.ElapsedMilliseconds + "ms", Logger.Level.DIAGNOSTIC);
            return ret;
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
    }
}
