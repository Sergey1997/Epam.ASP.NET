using System;
using System.IO;
using Task2.Solution;

namespace Task_2
{
    public class RandomBytesFileGenerator : RandomRepositoryGenerator
    {
        public RandomBytesFileGenerator(string workspaceDirectory, string fileExtension) : base(workspaceDirectory, fileExtension)
        {

        }

        public override byte[] GenerateFileContent(int contentLength)
        {
            var random = new Random();

            var fileContent = new byte[contentLength];

            random.NextBytes(fileContent);

            return fileContent;
        }
    }
}