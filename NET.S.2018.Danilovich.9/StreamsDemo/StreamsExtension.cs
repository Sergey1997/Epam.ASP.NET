using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace StreamsDemo
{
    // C# 6.0 in a Nutshell. Joseph Albahari, Ben Albahari. O'Reilly Media. 2015
    // Chapter 15: Streams and I/O
    // Chapter 6: Framework Fundamentals - Text Encodings and Unicode
    // https://msdn.microsoft.com/ru-ru/library/system.text.encoding(v=vs.110).aspx

    public static class StreamsExtension
    {
        #region Public members

        #region TODO: Implement by byte copy logic using class FileStream as a backing store stream .

        public static int ByByteCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            FileStream source = new FileStream(sourcePath, FileMode.Open, FileAccess.Read);
            byte[] byteSource = new byte[source.Length];
            source.Read(byteSource, 0, byteSource.Length);
            source.Dispose();
            
            FileStream destination = new FileStream(destinationPath, FileMode.OpenOrCreate, FileAccess.Write);
            destination.Write(byteSource, 0, byteSource.Length);
            int totalBytes = (int)destination.Length;
            destination.Dispose();

            return totalBytes;
        }

        #endregion

        #region TODO: Implement by byte copy logic using class MemoryStream as a backing store stream.

        public static int InMemoryByByteCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            StreamReader reader = new StreamReader(sourcePath);
            byte[] block = Encoding.UTF8.GetBytes(reader.ReadToEnd());
            reader.Dispose();
            int totalBytes = 0;
            using (MemoryStream memoryStream = new MemoryStream(block, 0, block.Length))
            {
                memoryStream.Write(block, 0, block.Length);
                byte[] newArray = memoryStream.ToArray();
                memoryStream.Dispose();
                char[] array = Encoding.UTF8.GetChars(newArray);
                StreamWriter streamWriter = new StreamWriter(destinationPath);
                streamWriter.Write(array);
                totalBytes = newArray.Length;
                streamWriter.Close();
            }

            return totalBytes;
        }

        #endregion

        #region TODO: Implement by block copy logic using FileStream buffer.

        public static int ByBlockCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            int totalBytes = 0;

            using (FileStream source = new FileStream(sourcePath, FileMode.Open))
            {
                byte[] block = new byte[source.Length];
                source.Read(block, 0, block.Length);
                using (FileStream destination = new FileStream(destinationPath, FileMode.Open))
                {
                    destination.Write(block, 0, block.Length);
                    totalBytes = (int)destination.Length;
                }
            }

            return totalBytes;
        }

        #endregion

        #region TODO: Implement by block copy logic using MemoryStream.

        public static int InMemoryByBlockCopy(string sourcePath, string destinationPath)
        {
            // TODO: Use InMemoryByByteCopy method's approach
            throw new NotImplementedException();
        }

        #endregion

        #region TODO: Implement by block copy logic using class-decorator BufferedStream.

        public static int BufferedCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            int totalBytes = 0;
            
            FileStream source = File.OpenRead(sourcePath);
            byte[] block = new byte[source.Length];
            source.Read(block, 0, block.Length);

            using (FileStream destination = new FileStream(destinationPath, FileMode.Open,FileAccess.Write))
            {
                using (BufferedStream buffer = new BufferedStream(destination, (int)source.Length))
                {
                    buffer.Write(block, 0, block.Length);
                    totalBytes = (int)destination.Length;
                }
            }

            return totalBytes;
        }

        #endregion

        #region TODO: Implement by line copy logic using FileStream and classes text-adapters StreamReader/StreamWriter

        public static int ByLineCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            string[] str = File.ReadAllLines(sourcePath);
            File.WriteAllLines(destinationPath, str);
            byte[] bytes = File.ReadAllBytes(destinationPath);
            return bytes.Length;
        }

        #endregion

        #region TODO: Implement content comparison logic of two files 

        public static bool IsContentEquals(string sourcePath, string destinationPath)
        {
            bool resultOfEqual = File.ReadAllBytes(sourcePath).SequenceEqual(File.ReadAllBytes(destinationPath));

            return resultOfEqual;
        }

        #endregion

        #endregion

        #region Private members

        #region TODO: Implement validation logic

        private static void InputValidation(string sourcePath, string destinationPath)
        {
            if (sourcePath == null || destinationPath == null)
            {
                throw new ArgumentNullException("Path doesnt found");
            }

            if (!File.Exists(sourcePath))
            {
                throw new FileNotFoundException($"{(nameof(sourcePath))} doesnt found");
            }
        }

        #endregion

        #endregion
    }
}