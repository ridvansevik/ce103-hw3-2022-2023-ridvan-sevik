using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ce103_hw3_library_lib
{
    public class Book
    {

        #region Public Constants
        public const int ID_LENGTH = 4;

        public const int TITLE_MAX_LENGTH = 100;
        public const int YEAR_MAX_LENGTH = 20;
        public const int PAGES_MAX_LENGTH = 20;
        public const int ABSTRACT_MAX_LENGTH = 500;
        public const int TAGS_MAX_LENGTH = 50;
        public const int STATUS_MAX_LENGTH = 100;
        public const int CITY_MAX_LENGTH = 30;
        public const int EDITION_MAX_LENGTH = 50;
        public const int EDITORS_MAX_LENGTH = 50;
        public const int PUBLISHERS_MAX_LENGTH = 100;
        public const int URL_MAX_LENGTH = 100;
        public const int PRICE_MAX_LENGTH = 20;
        public const int RACKNO_MAX_LENGTH = 10;
        public const int RAWNO_MAX_LENGTH = 10;
        public const int DESCRIPTION_MAX_LENGTH = 300;
        public const int GIVEN_MAX_LENGTH = 30;
        

        public const int AUTHORS_MAX_COUNT = 5;
        public const int AUTHORS_NAME_MAX_LENGTH = 100;

        public const int CATEGORY_MAX_COUNT = 5;
        public const int CATEGORY_NAME_MAX_LENGTH = 100;

        public const int BOOK_DATA_BLOCK_SIZE = ID_LENGTH +
                                                GIVEN_MAX_LENGTH +
                                                TITLE_MAX_LENGTH +
                                                YEAR_MAX_LENGTH +
                                                PAGES_MAX_LENGTH +
                                                ABSTRACT_MAX_LENGTH +
                                                TAGS_MAX_LENGTH +
                                                STATUS_MAX_LENGTH +
                                                CITY_MAX_LENGTH +
                                                EDITION_MAX_LENGTH +
                                                EDITORS_MAX_LENGTH +
                                                PUBLISHERS_MAX_LENGTH +
                                                URL_MAX_LENGTH +
                                                PRICE_MAX_LENGTH +
                                                RACKNO_MAX_LENGTH +
                                                RAWNO_MAX_LENGTH +
                                                DESCRIPTION_MAX_LENGTH +
                                                (AUTHORS_MAX_COUNT * AUTHORS_NAME_MAX_LENGTH) +
                                                (CATEGORY_MAX_COUNT * CATEGORY_NAME_MAX_LENGTH);
        #endregion

        #region Private Fields
        private int _id;
        private string _title;
        private string _description;
        private string _year;
        private string _pages;
        private string _abstract;
        private string _tags;
        private string _status;
        private string _city;
        private string _edition;
        private string _editors;
        private string _publishers;
        private string _url;
        private string _price;
        private string _rackno;
        private string _rawno;
        private string _given;
        private List<string> _authors;
        private List<string> _categories;
        #endregion

        #region Public Properties
        public int Id { get { return _id; } set { _id = value; } }
        public string Title { get { return _title; } set { _title = value; } }
        public string Year { get { return _year; } set { _year = value; } }
        public string Pages { get { return _pages; } set { _pages = value; } }
        public string Abstract { get { return _abstract; } set { _abstract = value; } }
        public string Tags { get { return _tags; } set { _tags = value; } }
        public string Status { get { return _status; } set { _status = value; } }
        public string City { get { return _city; } set { _city = value; } }
        public string Edition { get { return _edition; } set { _edition = value; } }
        public string Editors { get { return _editors; } set { _editors = value; } }
        public string Publishers { get { return _publishers; } set { _publishers = value; } }
        public string Url { get { return _url; } set { _url = value; } }
        public string Price { get { return _price; } set { _price = value; } }
        public string Rackno { get { return _rackno; } set { _rackno = value; } }
        public string Rawno { get { return _rawno; } set { _rawno = value; } }
        public string Description { get { return _description; } set { _description = value; } }
        public string Given { get { return _given; } set { _given = value; } }
        public List<string> Authors { get { return _authors; } set { _authors = value; } }
        public List<string> Categories { get { return _categories; } set { _categories = value; } }
        #endregion

        #region Constructors
        public Book()
        {
            _authors = new List<string>();
            _categories = new List<string>();
        }
        #endregion

        #region Utility Methods
        public static byte[] BookToByteArrayBlock(Book book)
        {
            int index = 0;

            byte[] dataBuffer = new byte[BOOK_DATA_BLOCK_SIZE];

            #region copy book id
            byte[] idBytes = ConversionUtility.IntegerToByteArray(book.Id);
            Array.Copy(idBytes, 0, dataBuffer, index, idBytes.Length);
            index += Book.ID_LENGTH;
            #endregion

            #region copy book title
            byte[] titleBytes = ConversionUtility.StringToByteArray(book.Title);
            Array.Copy(titleBytes, 0, dataBuffer, index, titleBytes.Length);
            index += Book.TITLE_MAX_LENGTH;
            #endregion

            #region copy book year
            byte[] yearBytes = ConversionUtility.StringToByteArray(book.Year);
            Array.Copy(yearBytes, 0, dataBuffer, index, yearBytes.Length);
            index += Book.YEAR_MAX_LENGTH;
            #endregion

            #region copy book pages
            byte[] pagesBytes = ConversionUtility.StringToByteArray(book.Pages);
            Array.Copy(pagesBytes, 0, dataBuffer, index, pagesBytes.Length);
            index += Book.PAGES_MAX_LENGTH;
            #endregion

            #region copy book abstract
            byte[] abstractBytes = ConversionUtility.StringToByteArray(book.Abstract);
            Array.Copy(abstractBytes, 0, dataBuffer, index, abstractBytes.Length);
            index += Book.ABSTRACT_MAX_LENGTH;
            #endregion

            #region copy book tags
            byte[] tagsBytes = ConversionUtility.StringToByteArray(book.Tags);
            Array.Copy(tagsBytes, 0, dataBuffer, index, tagsBytes.Length);
            index += Book.TAGS_MAX_LENGTH;
            #endregion

            #region copy book status
            byte[] statusBytes = ConversionUtility.StringToByteArray(book.Status);
            Array.Copy(statusBytes, 0, dataBuffer, index, statusBytes.Length);
            index += Book.STATUS_MAX_LENGTH;
            #endregion

            #region copy book city
            byte[] cityBytes = ConversionUtility.StringToByteArray(book.City);
            Array.Copy(cityBytes, 0, dataBuffer, index, cityBytes.Length);
            index += Book.CITY_MAX_LENGTH;
            #endregion

            #region copy book edition
            byte[] editionBytes = ConversionUtility.StringToByteArray(book.Edition);
            Array.Copy(editionBytes, 0, dataBuffer, index, editionBytes.Length);
            index += Book.EDITION_MAX_LENGTH;
            #endregion

            #region copy book editors
            byte[] editorsBytes = ConversionUtility.StringToByteArray(book.Editors);
            Array.Copy(editorsBytes, 0, dataBuffer, index, editorsBytes.Length);
            index += Book.EDITORS_MAX_LENGTH;
            #endregion

            #region copy book publishers
            byte[] publishersBytes = ConversionUtility.StringToByteArray(book.Publishers);
            Array.Copy(publishersBytes, 0, dataBuffer, index, publishersBytes.Length);
            index += Book.PUBLISHERS_MAX_LENGTH;
            #endregion

            #region copy book url
            byte[] urlBytes = ConversionUtility.StringToByteArray(book.Url);
            Array.Copy(urlBytes, 0, dataBuffer, index, urlBytes.Length);
            index += Book.URL_MAX_LENGTH;
            #endregion

            #region copy book price
            byte[] priceBytes = ConversionUtility.StringToByteArray(book.Price);
            Array.Copy(priceBytes, 0, dataBuffer, index, priceBytes.Length);
            index += Book.PRICE_MAX_LENGTH;
            #endregion

            #region copy book rackno
            byte[] racknoBytes = ConversionUtility.StringToByteArray(book.Rackno);
            Array.Copy(racknoBytes, 0, dataBuffer, index, racknoBytes.Length);
            index += Book.RACKNO_MAX_LENGTH;
            #endregion

            #region copy book rawno
            byte[] rawnoBytes = ConversionUtility.StringToByteArray(book.Rawno);
            Array.Copy(rawnoBytes, 0, dataBuffer, index, rawnoBytes.Length);
            index += Book.RAWNO_MAX_LENGTH;
            #endregion

            #region copy book given
            byte[] givenBytes = ConversionUtility.StringToByteArray(book.Given);
            Array.Copy(givenBytes, 0, dataBuffer, index, givenBytes.Length);
            index += Book.GIVEN_MAX_LENGTH;
            #endregion

            #region copy book description
            byte[] descBytes = ConversionUtility.StringToByteArray(book.Description);
            Array.Copy(descBytes, 0, dataBuffer, index, descBytes.Length);
            index += Book.DESCRIPTION_MAX_LENGTH;
            #endregion

            #region copy book authors
            byte[] authorBytes = ConversionUtility.StringListToByteArray(book.Authors,
                                                                            Book.AUTHORS_MAX_COUNT,
                                                                            Book.AUTHORS_NAME_MAX_LENGTH);
            Array.Copy(authorBytes, 0, dataBuffer, index, authorBytes.Length);
            index += authorBytes.Length; //Here we can use also Book.AUTHORS_MAX_COUNT * Book.AUTHORS_NAME_MAX_LENGTH
            #endregion


            #region copy book categories
            byte[] categoryBytes = ConversionUtility.StringListToByteArray(book.Categories,
                                                                            Book.CATEGORY_MAX_COUNT,
                                                                            Book.CATEGORY_NAME_MAX_LENGTH);
            Array.Copy(categoryBytes, 0, dataBuffer, index, categoryBytes.Length);
            index += categoryBytes.Length; //Here we can use also Book.CATEGORY_MAX_COUNT * Book.CATEGORY_NAME_MAX_LENGTH
            #endregion

            if (index != dataBuffer.Length)
            {
                throw new ArgumentException("Index and DataBuffer Size Not Matched");
            }

            return dataBuffer;
        }

        public static Book ByteArrayBlockToBook(byte[] byteArray)
        {

            Book book = new Book();

            if (byteArray.Length != BOOK_DATA_BLOCK_SIZE)
            {
                throw new ArgumentException("Byte Array Size Not Match with Constant Data Block Size");
            }

            int index = 0;

            //byte[] dataBuffer = new byte[BOOK_DATA_BLOCK_SIZE];

            #region copy book id
            byte[] idBytes = new byte[Book.ID_LENGTH];
            Array.Copy(byteArray, index, idBytes, 0, idBytes.Length);
            book.Id = ConversionUtility.ByteArrayToInteger(idBytes);

            index += Book.ID_LENGTH;
            #endregion

            #region copy book title
            byte[] titleBytes = new byte[Book.TITLE_MAX_LENGTH];
            Array.Copy(byteArray, index, titleBytes, 0, titleBytes.Length);
            book.Title = ConversionUtility.ByteArrayToString(titleBytes);

            index += Book.TITLE_MAX_LENGTH;
            #endregion

            #region copy book year
            byte[] yearBytes = new byte[Book.YEAR_MAX_LENGTH];
            Array.Copy(byteArray, index, yearBytes, 0, yearBytes.Length);
            book.Year = ConversionUtility.ByteArrayToString(yearBytes);

            index += Book.YEAR_MAX_LENGTH;
            #endregion

            #region copy book pages
            byte[] pagesBytes = new byte[Book.PAGES_MAX_LENGTH];
            Array.Copy(byteArray, index, pagesBytes, 0, pagesBytes.Length);
            book.Pages = ConversionUtility.ByteArrayToString(pagesBytes);

            index += Book.PAGES_MAX_LENGTH;
            #endregion

            #region copy book abstract
            byte[] abstractBytes = new byte[Book.ABSTRACT_MAX_LENGTH];
            Array.Copy(byteArray, index, abstractBytes, 0, abstractBytes.Length);
            book.Abstract = ConversionUtility.ByteArrayToString(abstractBytes);

            index += Book.ABSTRACT_MAX_LENGTH;
            #endregion

            #region copy book tags
            byte[] tagsBytes = new byte[Book.TAGS_MAX_LENGTH];
            Array.Copy(byteArray, index, tagsBytes, 0, tagsBytes.Length);
            book.Tags = ConversionUtility.ByteArrayToString(tagsBytes);

            index += Book.TAGS_MAX_LENGTH;
            #endregion

            #region copy book status
            byte[] statusBytes = new byte[Book.STATUS_MAX_LENGTH];
            Array.Copy(byteArray, index, statusBytes, 0, statusBytes.Length);
            book.Status = ConversionUtility.ByteArrayToString(statusBytes);

            index += Book.STATUS_MAX_LENGTH;
            #endregion

            #region copy book city
            byte[] cityBytes = new byte[Book.CITY_MAX_LENGTH];
            Array.Copy(byteArray, index, cityBytes, 0, cityBytes.Length);
            book.City = ConversionUtility.ByteArrayToString(cityBytes);

            index += Book.CITY_MAX_LENGTH;
            #endregion

            #region copy book edition
            byte[] editionBytes = new byte[Book.EDITION_MAX_LENGTH];
            Array.Copy(byteArray, index, editionBytes, 0, editionBytes.Length);
            book.Edition = ConversionUtility.ByteArrayToString(editionBytes);

            index += Book.EDITION_MAX_LENGTH;
            #endregion

            #region copy book editors
            byte[] editorsBytes = new byte[Book.EDITORS_MAX_LENGTH];
            Array.Copy(byteArray, index, editorsBytes, 0, editorsBytes.Length);
            book.Editors = ConversionUtility.ByteArrayToString(editorsBytes);

            index += Book.EDITORS_MAX_LENGTH;
            #endregion

            #region copy book publishers
            byte[] publishersBytes = new byte[Book.PUBLISHERS_MAX_LENGTH];
            Array.Copy(byteArray, index, publishersBytes, 0, publishersBytes.Length);
            book.Publishers = ConversionUtility.ByteArrayToString(publishersBytes);

            index += Book.PUBLISHERS_MAX_LENGTH;
            #endregion

            #region copy book url
            byte[] urlBytes = new byte[Book.URL_MAX_LENGTH];
            Array.Copy(byteArray, index, urlBytes, 0, urlBytes.Length);
            book.Url = ConversionUtility.ByteArrayToString(urlBytes);

            index += Book.URL_MAX_LENGTH;
            #endregion

            #region copy book price
            byte[] priceBytes = new byte[Book.PRICE_MAX_LENGTH];
            Array.Copy(byteArray, index, priceBytes, 0, priceBytes.Length);
            book.Price = ConversionUtility.ByteArrayToString(priceBytes);

            index += Book.PRICE_MAX_LENGTH;
            #endregion

            #region copy book rackno
            byte[] racknoBytes = new byte[Book.RACKNO_MAX_LENGTH];
            Array.Copy(byteArray, index, racknoBytes, 0, racknoBytes.Length);
            book.Rackno = ConversionUtility.ByteArrayToString(racknoBytes);

            index += Book.RACKNO_MAX_LENGTH;
            #endregion

            #region copy book rawno
            byte[] rawnoBytes = new byte[Book.RAWNO_MAX_LENGTH];
            Array.Copy(byteArray, index, rawnoBytes, 0, rawnoBytes.Length);
            book.Rawno = ConversionUtility.ByteArrayToString(rawnoBytes);

            index += Book.RAWNO_MAX_LENGTH;
            #endregion

            #region copy book given
            byte[] givenBytes = new byte[Book.GIVEN_MAX_LENGTH];
            Array.Copy(byteArray, index, givenBytes, 0, givenBytes.Length);
            book.Given = ConversionUtility.ByteArrayToString(givenBytes);

            index += Book.GIVEN_MAX_LENGTH;
            #endregion

            #region copy book description
            byte[] descBytes = new byte[Book.DESCRIPTION_MAX_LENGTH];
            Array.Copy(byteArray, index, descBytes, 0, descBytes.Length);
            book.Description = ConversionUtility.ByteArrayToString(descBytes);

            index += Book.DESCRIPTION_MAX_LENGTH;
            #endregion

            #region copy book authors

            byte[] authorBytes = new byte[Book.AUTHORS_MAX_COUNT * Book.AUTHORS_NAME_MAX_LENGTH];

            Array.Copy(byteArray, index, authorBytes, 0, authorBytes.Length);

            book.Authors = ConversionUtility.ByteArrayToStringList(authorBytes,
                                                                            Book.AUTHORS_MAX_COUNT,
                                                                            Book.AUTHORS_NAME_MAX_LENGTH);

            index += authorBytes.Length;
            #endregion


            #region copy book categories
            byte[] categoryBytes = new byte[Book.CATEGORY_MAX_COUNT * Book.CATEGORY_NAME_MAX_LENGTH];

            Array.Copy(byteArray, index, categoryBytes, 0, categoryBytes.Length);

            book.Categories = ConversionUtility.ByteArrayToStringList(categoryBytes,
                                                                            Book.CATEGORY_MAX_COUNT,
                                                                            Book.CATEGORY_NAME_MAX_LENGTH);

            index += categoryBytes.Length;
            #endregion

            if (index != byteArray.Length)
            {
                throw new ArgumentException("Index and DataBuffer Size Not Matched");
            }

            if (book.Id == 0)
            {
                return null;
            }
            else
            {
                return book;
            }

        }
        #endregion
    }
}


     
