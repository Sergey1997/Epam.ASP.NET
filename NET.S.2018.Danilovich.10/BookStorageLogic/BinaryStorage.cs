using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BookLogic;
using NLog;

namespace BookStorageLogic
{
    public interface IBookStorage
    {
        //implement readBooks(List<Book> books)
        void SaveBooks(List<Book> books);//Change List<Book> to IEnumerable<Book>
    }

    public class BinaryStorage : IBookStorage
    {
        /// <summary>   Constructor of file. </summary>
        /// <exception cref="FileNotFoundException">    Thrown when the requested file is not present. </exception>
        /// <param name="path"> Full pathname of the file. </param>
        public BinaryStorage(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"{path} is not found");
            }
            //change path to config
            Path = path;
        }
        
        /// <summary>   Gets the full pathname of the file. </summary>
        /// <value> The full pathname of the file. </value>
        private string Path { get; }

        /// <summary>   Saves the books in file. </summary>
        /// <param name="books">    The books. </param>
        public void SaveBooks(List<Book> books)
        {
            using (FileStream fileStream = new FileStream(Path, FileMode.Open, FileAccess.ReadWrite))
            using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
            {
                binaryWriter.Write(books.Count);

                foreach (Book book in books)
                {
                    WriteBook(book, binaryWriter);
                }
            }
        }
        
        /// <summary>   Writes a book in the binary file. </summary>
        /// <param name="book">         The book. </param>
        /// <param name="binaryWriter"> The binary writer. </param>
        public void WriteBook(Book book, BinaryWriter binaryWriter)
        {
            binaryWriter.Write(book.ISBN);
            binaryWriter.Write(book.Author);
            binaryWriter.Write(book.NumberOfPages);
            binaryWriter.Write(book.Title);
            binaryWriter.Write(book.Publisher);
            binaryWriter.Write(book.NumberOfPages);
            binaryWriter.Write(book.Price);
        }
        
        /// <summary>   Reads a book from the binary file. </summary>
        /// <param name="binaryReader"> The binary reader. </param>
        /// <returns>   The book. </returns>
        public Book ReadBook(BinaryReader binaryReader)
        {
            string isbn = binaryReader.ReadString();
            string author = binaryReader.ReadString();
            string title = binaryReader.ReadString();
            string publisher = binaryReader.ReadString();
            uint year = binaryReader.ReadUInt32();
            uint numberOfPages = binaryReader.ReadUInt32();
            double price = binaryReader.ReadDouble();

            return new Book(isbn, author, title, publisher, year, numberOfPages, price);
        }
    }
}
