using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace DDDemo
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Serialize();
            Deserialize();
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
        }

        static void Serialize()
        {
            // Create a hashtable of values that will eventually be serialized.
            DirectoryInfo dir = new DirectoryInfo(@"C:\Documents and Settings\passchum\My Documents\Downloads");
            Dictionary<string, long> fileDir = new Dictionary<string, long>();
            List<FileInfo> files = new List<FileInfo>();
            files.AddRange(dir.GetFiles());
            foreach (FileInfo item in files)
            {
                fileDir.Add(item.FullName, item.Length);
            }
            //files.Add(new FileInfo(@"C:\Documents and Settings\passchum\My Documents\Downloads\20111128_Vortrag_CIAMmyIAM.ppt"));
            //files.Add(new FileInfo(@"C:\Documents and Settings\passchum\My Documents\Downloads\1536143_851.jpeg"));
            //files.Add(new FileInfo(@"C:\Documents and Settings\passchum\My Documents\Downloads\DeAssignment PL_UNo_signed.pdf"));

            // To serialize the hashtable and its key/value pairs,  
            // you must first open a stream for writing. 
            // In this case, use a file stream.
            FileStream fs = new FileStream("DataFile.dat", FileMode.Create);

            // Construct a BinaryFormatter and use it to serialize the data to the stream.
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, fileDir);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
        }

        static void Deserialize()
        {
            // Declare the hashtable reference.
            List<FileInfo> addresses = null;
            Dictionary<string, long> files = null;

            // Open the file containing the data that you want to deserialize.
            FileStream fs = new FileStream("DataFile.dat", FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                // Deserialize the hashtable from the file and 
                // assign the reference to the local variable.
                //addresses = (List<FileInfo>)formatter.Deserialize(fs);
                files = (Dictionary<string, long>)formatter.Deserialize(fs);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }

            
        }
    }
}
