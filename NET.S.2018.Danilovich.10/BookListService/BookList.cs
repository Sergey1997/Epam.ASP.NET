using System;
using System.Collections.Generic;
using BookLogic;
using BookStorageLogic;
using Logging;

namespace BookListService
{
    /// <summary>   Interface for finding books in Book List predicate. </summary>
    public interface IPredicate
    {
        bool IsFind(Book book);
    }

    public class BookList
    {
        private NLogger logger;

        #region Constructors
        public BookList(NLogger logger)
        {
            //ILogger - custom exceptions
            //change to IEnumerable
            Books = new List<Book>();
            this.logger = logger;
        }
        #endregion

        #region Fields

        /// <summary>   Gets or sets the books. </summary>
        /// <value> The books. </value>
        private List<Book> Books { get; set; }

        #endregion

        #region Methods

        /// <summary>   Adds a book. </summary>
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <param name="book"> The book. </param>
        public void AddBook(Book book)
        {
            if (book == null)
            {
                logger.WriteError($"{nameof(book)} is null");
                throw new ArgumentNullException($"{nameof(book)} is null");
            }

            Books.Add(book);
            logger.WriteInfo($"{nameof(book)} added to list");

        }

        /// <summary>   Removes the book described by book. </summary>
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <exception cref="ArgumentException">        Thrown when one or more arguments have
        ///                                             unsupported or illegal values. </exception>
        /// <param name="book"> The book. </param>
        public void RemoveBook(Book book)
        {
            if (book == null)
            {
                logger.WriteError($"{nameof(book)} is null");
                throw new ArgumentNullException($"{nameof(book)} cant be a null");
            }

            int index = Books.IndexOf(book);
            if (index != -1)
            {
                Books.RemoveAt(index);
                logger.WriteInfo($"{nameof(book)} removed from list");

            }
            else
            {
                logger.WriteError($"{nameof(book)} is not found");
                throw new ArgumentException($"{nameof(book)} is not found");
            }
        }
        
        /// <summary>   Searches for the first book by tag. </summary>
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <param name="predicate">    The predicate. </param>
        /// <returns>   The found book by tag. </returns>
        public Book FindBookByTag(IPredicate predicate)
        {
            if (predicate == null)
            {
                logger.WriteError($"{nameof(predicate)} is null");
                throw new ArgumentNullException($"{nameof(predicate)} cant be a null");
            }

            Book book = Books[0];

            for (int i = 0; i < Books.Count; i++)
            {
                if (predicate.IsFind(book))
                {
                    logger.WriteInfo($"{nameof(book)} was found");
                    return book;
                }
            }

            logger.WriteInfo($"{nameof(book)} wasn't found");
            return null;
        }
        
        /// <summary>   Sort books by tag. </summary>
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <param name="comparer"> The comparer. </param>
        public void SortBooksByTag(IComparer<Book> comparer)
        {
            if (comparer != null)
            {
                Books.Sort(comparer);
                logger.WriteInfo($"{nameof(Books)} successfully sorted");
            }
            else
            {
                logger.WriteError($"{nameof(comparer)} is null");
                throw new ArgumentNullException($"{nameof(comparer)} cant be a null");
            }
        }
        
        /// <summary>   Saves the books into storage. </summary>
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <param name="storage">  The storage. </param>
        public void SaveBooksIntoStorage(IBookStorage storage)
        {
            if (storage == null)
            {
                logger.WriteError($"{nameof(storage)} is null");
                throw new ArgumentNullException($"{nameof(storage)} cant be a null");
            }

            storage.SaveBooks(Books);
            logger.WriteInfo($"Books added to {nameof(storage)}");
        }
        #endregion
    }
}
