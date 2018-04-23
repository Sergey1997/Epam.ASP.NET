using System;
using System.IO;
using System.Linq;
using System.Text;
using Task2.Solution;

namespace Task_2
{
    public class RandomCharsFileGenerator : RandomRepositoryGenerator
    {
        public RandomCharsFileGenerator(string workspaceDirectory, string fileExtension) : base(workspaceDirectory, fileExtension)
        {

        }

        public override byte[] GenerateFileContent(int contentLength)
        {
            string temp = RandomString(contentLength);

            byte[] bytes = Encoding.Unicode.GetBytes(temp);

            return bytes;
        }

        private string RandomString(int Size)
        {
            var random = new Random();

            const string input = "abcdefghijklmnopqrstuvwxyz0123456789";

            var chars = Enumerable.Range(0, Size).Select(x => input[random.Next(0, input.Length)]);

            return new string(chars.ToArray());
        }
    }
}