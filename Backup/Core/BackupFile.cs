using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.IO.Compression;

namespace Backup.Core
{
    class BackupFile
    {
        public byte[] GUID = new byte[72];
        byte[] NameLength = new byte[4];
        byte[] AttributesLength = new byte[4];
        byte[] SizeLength = new byte[4];
        byte[] DateCreatedLength = new byte[4];
        byte[] DateEditLength = new byte[4];
        byte[] DataLength = new byte[4];
        //96 Bytes Header
        byte[] Name;
        byte[] Attributes;
        byte[] Size;
        byte[] DateCreated;
        byte[] DateEdit;
        byte[] Data;
        private List<byte[]> file;

        public int Length
        {
            get { 
                return (
                96+
                Name.Length+
                Attributes.Length+
                Size.Length+
                DateCreated.Length+
                DateEdit.Length+
                Data.Length); 
            }
        }

        public List<byte[]> File
        {
            get { return file; }
            set { file = value; }
        }

        public BackupFile ()
        {
            
        }

        public void BuildFile(FileInfo fileInfo)
        {
            GUID = Encoding.Unicode.GetBytes(Guid.NewGuid().ToString());
            Name = Encoding.Unicode.GetBytes(fileInfo.FullName.ToString());
            Attributes = Encoding.Unicode.GetBytes(((int)fileInfo.Attributes).ToString());            
            Size = Encoding.Unicode.GetBytes(fileInfo.Length.ToString());
            DateCreated = Encoding.Unicode.GetBytes(fileInfo.CreationTime.ToString());
            DateEdit = Encoding.Unicode.GetBytes(fileInfo.LastWriteTime.ToString());
            Data = new byte[(int)fileInfo.Length];
            try
            {
                using (FileStream reader = new FileStream(fileInfo.FullName, FileMode.Open, FileAccess.Read))
                {
                    reader.Read(Data, 0, (int)fileInfo.Length);
                    reader.Close();
                }
            }
            catch (IOException ex)
            {
                Logger.Log(ex.Message, Logger.Level.ERROR);
            }
            
            NameLength = BitConverter.GetBytes(Name.Length);
            AttributesLength = BitConverter.GetBytes(Attributes.Length);
            SizeLength = BitConverter.GetBytes(Size.Length);
            DateCreatedLength = BitConverter.GetBytes(DateCreated.Length);
            DateEditLength = BitConverter.GetBytes(DateEdit.Length);
            DataLength = BitConverter.GetBytes(Data.Length);

            File = new List<byte[]>();
            File.Add(GUID);
            File.Add(NameLength);
            File.Add(AttributesLength);
            File.Add(SizeLength);
            File.Add(DateCreatedLength);
            File.Add(DateEditLength);
            File.Add(DataLength);
            File.Add(Name);
            File.Add(Attributes);
            File.Add(Size);
            File.Add(DateCreated);
            File.Add(DateEdit);
            File.Add(Data);
        }

        public string restore(FileStream reader, DirectoryInfo dest)
        {
            reader.Read(GUID, 0, GUID.Length);
            reader.Read(NameLength, 0, NameLength.Length);
            reader.Read(AttributesLength, 0, AttributesLength.Length);
            reader.Read(SizeLength, 0, SizeLength.Length);
            reader.Read(DateCreatedLength, 0, DateCreatedLength.Length);
            reader.Read(DateEditLength, 0, DateEditLength.Length);
            reader.Read(DataLength, 0, DataLength.Length);
            Name = new byte[BitConverter.ToInt32(NameLength, 0)];
            Attributes = new byte[BitConverter.ToInt32(AttributesLength, 0)];
            Size = new byte[BitConverter.ToInt32(SizeLength, 0)];
            DateCreated = new byte[BitConverter.ToInt32(DateCreatedLength, 0)];
            DateEdit = new byte[BitConverter.ToInt32(DateEditLength, 0)];
            Data = new byte[BitConverter.ToInt32(DataLength, 0)];
            reader.Read(Name, 0, Name.Length);
            reader.Read(Attributes, 0, Attributes.Length);
            reader.Read(Size, 0, Size.Length);
            reader.Read(DateCreated, 0, DateCreated.Length);
            reader.Read(DateEdit, 0, DateEdit.Length);
            reader.Read(Data, 0, Data.Length);

            string fullName = Encoding.Unicode.GetString(Name);
            string fileName = Path.GetFileName(fullName);
            string[] directorys = fullName.Split(Path.DirectorySeparatorChar);
            DirectoryInfo newDir = dest;
            foreach (string dir in directorys)
            {
                if (dir != directorys[0] && dir != fileName)
                {
                    newDir = newDir.CreateSubdirectory(dir);
                }
            }

            FileInfo file = new FileInfo(newDir.FullName + Path.DirectorySeparatorChar + fileName);
            using (FileStream writer = new FileStream(file.FullName, FileMode.Create, FileAccess.ReadWrite))
            {
                writer.Write(Data, 0, Data.Length);
                writer.Close();
            }
            file.Attributes = (FileAttributes)int.Parse(Encoding.Unicode.GetString(Attributes));
            file.CreationTime = DateTime.Parse(Encoding.Unicode.GetString(DateCreated));
            file.LastWriteTime = DateTime.Parse(Encoding.Unicode.GetString(DateEdit));
            return fullName;
        }
    }
}
