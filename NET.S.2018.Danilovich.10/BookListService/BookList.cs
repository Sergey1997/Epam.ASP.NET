using System;
using System.Collections.Generic;
using BookLogic;
using BookStorageLogic;

namespace BookListService
{
    /// <summary>   Interface for finding books in Book List predicate. </summary>
    public interface IPredicate
    {
        bool IsFind(Book book);
    }

    public class BookList
    {
        #region Constructors
        public BookList()
        {
            //ILogger - custom exceptions
            //change to IEnumerable
            Books = new List<Book>();
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
                throw new ArgumentNullException($"{nameof(book)} is null");
            }

            Books.Add(book);
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
                throw new ArgumentNullException($"{nameof(book)} cant be a null");
            }

            int index = Books.IndexOf(book);
            if (index != -1)
            {
                Books.RemoveAt(index);
            }
            else
            {
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
                throw new ArgumentNullException($"{nameof(predicate)} cant be a null");
            }

            for (int i = 0; i < Books.Count; i++)
            {
                Book book = Books[i];

                if (predicate.IsFind(book))
                {
                    return book;
                }
            }

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
            }
            else
            {
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
                throw new ArgumentNullException($"{nameof(storage)} cant be a null");
            }

            storage.SaveBooks(Books);
        }
        #endregion
    }
}
