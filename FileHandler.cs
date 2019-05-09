using System;
using System.IO;
using System.Collections.Generic;

namespace MilitaryCommunications
{
    public class FileHandler
    {
        FileStream stream;
        StreamWriter writer;
        StreamReader reader;

        private const string path = "Data.txt";

        public FileHandler(){}

        public List<string> ReadFile()
        {
            stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            reader = new StreamReader(stream);
            List<string> listToReturn = new List<string>();

            while (!reader.EndOfStream)
            {
                listToReturn.Add(reader.ReadLine());
            }

            reader.Close();
            stream.Close();

            return listToReturn;
        }

        public List<string> ReadFile(string path)
        {
            stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            reader = new StreamReader(stream);
            List<string> listToReturn = new List<string>();

            while (!reader.EndOfStream)
            {
                listToReturn.Add(reader.ReadLine());
            }

            reader.Close();
            stream.Close();

            return listToReturn;
        }

        public void WriteFile(List<string> listToWrite)
        {
            stream = new FileStream(path, FileMode.Append, FileAccess.Write);
            writer = new StreamWriter(stream);

            foreach(string line in listToWrite)
            {
                writer.WriteLine(line);
            }

            writer.Close();
            stream.Close();
        }

        public void WriteFile(string line)
        {
            stream = new FileStream(path, FileMode.Append, FileAccess.Write);
            writer = new StreamWriter(stream);

            writer.WriteLine(line);

            writer.Close();
            stream.Close();
        }

        public void CreateFile(string filename)
        {
            stream = new FileStream(filename, FileMode.Create, FileAccess.Write);
            writer = new StreamWriter(stream);

            writer.WriteLine("Created on {0}", DateTime.Now);

            writer.Close();
            stream.Close();
        }

    }
}
