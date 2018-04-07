using System;
using System.Drawing;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLogic
{
    public class Book : IComparable, IComparable<Book>, IEquatable<Book>, IFormattable
    {
        // validation fields - maybe method ValidateHelper
        // implementation iFormattable
        // isbn - maybe struct of fields
        // 
        #region Fields
        private string isbn;
        private string author;
        private string title;
        private string publisher;
        private double price;
        #endregion

        #region Constructors
        /// <summary>   Constructor of Book. </summary>
        /// <param name="isbn">             The isbn. </param>
        /// <param name="author">           The author. </param>
        /// <param name="publisher">        The publisher. </param>
        /// <param name="year">             The year. </param>
        /// <param name="numberOfPages">    Number of pages. </param>
        /// <param name="price">            The price. </param>
        public Book(string isbn, string author, string title, string publisher, uint year, uint numberOfPages, double price)
        {
            ISBN = isbn;
            Author = author;
            Publisher = publisher;
            Title = title;
            Year = year;
            NumberOfPages = numberOfPages;
            Price = price;
        }

        #endregion

        #region Propertiest
        /// <summary>   Gets or sets the isbn. </summary>
        /// <exception cref="ArgumentException">    Thrown when one or more arguments have unsupported or
        ///                                         illegal values. </exception>
        /// <value> The isbn field of Book. </value>
        public string ISBN
        {
            get { return isbn; }
            private set { isbn = value ?? throw new ArgumentException($"{ (nameof(value))} doesnt correct"); }
        }
        
        /// <summary>   Gets or sets the author. </summary>
        /// <exception cref="ArgumentException">    Thrown when one or more arguments have unsupported or
        ///                                         illegal values. </exception>
        /// <value> The author field of Book. </value>
        public string Author
        {
            get { return author; }
            private set { author = value ?? throw new ArgumentException($"{ (nameof(value))} doesnt correct"); }
        }
        
        /// <summary>   Gets or sets the title. </summary>
        /// <exception cref="ArgumentException">    Thrown when one or more arguments have unsupported or
        ///                                         illegal values. </exception>
        /// <value> The title. </value>
        public string Title
        {
            get { return author; }
            private set { title = value ?? throw new ArgumentException($"{ (nameof(value))} doesnt correct"); }
        }

        /// <summary>   Gets or sets the publisher. </summary>
        /// <exception cref="ArgumentException">    Thrown when one or more arguments have unsupported or
        ///                                         illegal values. </exception>
        /// <value> The publisher field of Book. </value>
        public string Publisher
        {
            get { return publisher; }
            private set { publisher = value ?? throw new ArgumentException($"{ (nameof(value))} doesnt correct"); }
        }
        
        /// <summary>   Auto-property, Gets or sets the year. </summary>
        /// <value> The year. </value>
        public uint Year { get; private set; }
        
        /// <summary>   Gets or sets the number of pages. </summary>
        /// <value> The total number of pages of Book. </value>
        public uint NumberOfPages { get; private set; }

        /// <summary>   Gets or sets the price. </summary>
        /// <exception cref="ArgumentException">    Thrown when one or more arguments have unsupported or
        ///                                         illegal values. </exception>
        /// <value> The price of Book. </value>
        public double Price
        {
            get
            {
                return price;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{ (nameof(value))} must not be less than zero");
                }

                price = value;
            }
        }

        #endregion
        #region Implementations
        /// <summary>
        /// Implentation of CompareTo method of interface IComparable
        /// </summary>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        /// <param name="obj">  An object to compare with this instance. </param>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has
        /// these meanings: Value Meaning Less than zero This instance precedes <paramref name="obj" />
        /// in the sort order. Zero This instance occurs in the same position in the sort order as
        /// <paramref name="obj" />. Greater than zero This instance follows <paramref name="obj" /> in
        /// the sort order.
        /// </returns>
        public int CompareTo(object obj)
        {
            if (obj is Book book)
            {
                return this.Price.CompareTo(book.Price);
            }
            else
            {
                throw new Exception($"{(nameof(obj))} cant be compared");
            }
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="book"> An object to compare with this object. </param>
        /// <returns>
        /// <see langword="true" /> if the current object is equal to the <paramref name="other" />
        /// parameter; otherwise, <see langword="false" />.
        /// </returns>
        public bool Equals(Book book)
        {
            if (book is null)
            {
                return false;
            }

            if (ReferenceEquals(this, book))
            {
                return true;
            }

            //сравнение 
            return ISBN == book.ISBN;
        }
        
        /// <summary>
        /// Implentation of CompareTo method of interface IComparable<Book>
        /// </summary>
        /// <param name="book"> An object to compare with this instance. </param>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has
        /// these meanings: Value Meaning Less than zero This instance precedes <paramref name="other" />
        /// in the sort order.  Zero This instance occurs in the same position in the sort order as
        /// <paramref name="other" />. Greater than zero This instance follows <paramref name="other" />
        /// in the sort order.
        /// </returns>
        public int CompareTo(Book book)
        {
            if (book is null)
            {
                return 1;
            }

            if (ReferenceEquals(this, book))
            {
                return 0;
            }

            return Price.CompareTo(book.Price);
        }

        /// <summary>   Serves as the default hash function. </summary>
        /// <returns>   A hash code for the current object. </returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return this.ToString("G", CultureInfo.CurrentCulture);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            string defaultFormat = "G";

            if (format == null)
            {
                format = defaultFormat;
            }

            if (formatProvider == null)
            {
                formatProvider = CultureInfo.CurrentCulture;
            }

            format = format.ToUpper();

            string generalFormat =
                "ISBN,AUT,TT,PB,PBY,PG,PR";
            string shortFormat =
                "AUT,TT";

            if (format == "G")
                format = generalFormat;

            if (format == "S")
                format = shortFormat;


            string[] fmtParts = format.Split(',');

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < fmtParts.Length; i++)
            {
                if (i != 0)
                {
                    result.Append(", ");
                }

                switch (fmtParts[i])
                {
                    case "ISBN":
                        result.Append(ISBN.ToString());
                        break;
                    case "AUT":
                        result.Append(Author.ToString(formatProvider));
                        break;
                    case "TT":
                        result.Append(Title.ToString(formatProvider));
                        break;
                    case "PB":
                        result.Append(Publisher.ToString(formatProvider));
                        break;
                    case "PBY":
                        result.Append(Year.ToString(formatProvider));
                        break;
                    case "PG":
                        result.Append($"P.{NumberOfPages.ToString(formatProvider)}");
                        break;
                    case "PR":
                        result.Append(Price.ToString(formatProvider));
                        break;
                    default:
                        throw new FormatException($"{fmtParts[i]} format is not supported");
                }
            }

            return result.ToString();

        }
        #endregion
    }
}
