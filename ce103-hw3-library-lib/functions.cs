using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ce103_hw3_library_lib
{
    public class functions
    {
        contentofthemenu runmenu = new contentofthemenu();

        public void addBook()
        {
            Console.Clear();
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string filename = Path.Combine(path, "library.dat");

            Book book = new Book();
            Console.WriteLine("Please enter the book id: ");
            book.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter book title: ");
            book.Title = Console.ReadLine();
            Console.WriteLine("Please enter the book year");
            book.Year = Console.ReadLine();
            Console.WriteLine("Please enter the book pages");
            book.Pages = Console.ReadLine();
            Console.WriteLine("Please enter the book abstract");
            book.Abstract = Console.ReadLine();
            Console.WriteLine("Please enter the book tags");
            book.Tags = Console.ReadLine();
            Console.WriteLine("Please enter the book Publisher");
            book.Publishers = Console.ReadLine();
            Console.WriteLine("Please enter the book price");
            book.Price = Console.ReadLine();
            Console.WriteLine("Please enter the book rackno");
            book.Rackno = Console.ReadLine();
            Console.WriteLine("Please enter the book rowno");
            book.Rawno = Console.ReadLine();
            Console.WriteLine("Please enter the book status");
            book.Status = Console.ReadLine();
            Console.WriteLine("Please enter the book url");
            book.Url = Console.ReadLine();
            Console.WriteLine("Please enter the book city");
            book.City = Console.ReadLine();
            Console.WriteLine("Please enter the book editors");
            book.Editors = Console.ReadLine();
            Console.WriteLine("Please enter the book description: ");
            book.Description = Console.ReadLine();
            Console.WriteLine("Please enter the book author: ");
            book.Authors.Add(Console.ReadLine());
            Console.WriteLine("Please enter the book category: ");
            book.Categories.Add(Console.ReadLine());
            Console.WriteLine("Please enter the book edition: ");
            book.Edition = Console.ReadLine();
            Console.WriteLine("Please enter the book given date: ");
            book.Given = Console.ReadLine();


            byte[] bookBytes = Book.BookToByteArrayBlock(book);
            FileUtility.AppendBlock(bookBytes, filename);
            runmenu.Start();

        }
        public void listbook()
        {
            Console.Clear();


            int i = 1;
            using (StreamReader sr = new StreamReader(File.Open("library.dat", FileMode.Open)))
            {
                string datlength = sr.ReadLine();
                sr.Close();
                do
                {
                    string path = AppDomain.CurrentDomain.BaseDirectory;
                    string filename = Path.Combine(path, "library.dat");


                    byte[] bookWrittenBytes = FileUtility.ReadBlock(i, Book.BOOK_DATA_BLOCK_SIZE, filename);
                    Book bookWrittenObject = Book.ByteArrayBlockToBook(bookWrittenBytes);

                    if (bookWrittenObject != null)
                    {

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine("Book number : " + i);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine("ID : " + bookWrittenObject.Id + "  Title : " + bookWrittenObject.Title + "  Year : " + bookWrittenObject.Year + "  Pages : " + bookWrittenObject.Pages + "  Abstract : " + bookWrittenObject.Abstract + "  Tags : " + bookWrittenObject.Tags);
                        Console.WriteLine("Publishers : " + bookWrittenObject.Publishers + "  Price : " + bookWrittenObject.Price + "  Rackno : " + bookWrittenObject.Rackno + "  Rawno : " + bookWrittenObject.Rawno + "  Status : " + bookWrittenObject.Status);
                        Console.WriteLine("Url : " + bookWrittenObject.Url + "  City : " + bookWrittenObject.City + "  Editors : " + bookWrittenObject.Editors + "  Description : " + bookWrittenObject.Description + "  Authors : " + bookWrittenObject.Authors[0]);
                        Console.WriteLine("Categories : " + bookWrittenObject.Categories[0]);
                        Console.WriteLine("Edition : " + bookWrittenObject.Edition + "Given : " + bookWrittenObject.Given);
                    }
                    i++;

                } while (i < (((datlength.Length) / (Book.BOOK_DATA_BLOCK_SIZE)) + 1));

                Console.ReadKey(true);

                runmenu.Start();

            }
        }
        public void deletebook()
        {
            Book delet = new Book();

            string path = AppDomain.CurrentDomain.BaseDirectory;
            string filename = Path.Combine(path, "library.dat");
            Console.Clear();

            int numberofthebook;
            Console.WriteLine("Please enter number of book which do you want to delete: ");
            numberofthebook= Convert.ToInt32(Console.ReadLine());

            //delet.Id = Convert.ToInt32(Console.ReadLine());

            FileUtility.DeleteBlock(numberofthebook, Book.BOOK_DATA_BLOCK_SIZE, filename);

            runmenu.Start();

        }
        public void editbook()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string filename = Path.Combine(path, "library.dat");

            Console.Clear();
            int booknumber;
            Console.WriteLine("Please enter number of the book which do you want to edit: ");
            booknumber = Convert.ToInt32(Console.ReadLine());

            Book book = new Book();
            Console.WriteLine("Please enter the book id: ");
            book.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the book title: ");
            book.Title = Console.ReadLine();
            Console.WriteLine("Please enter the book year");
            book.Year = Console.ReadLine();
            Console.WriteLine("Please enter the book pages");
            book.Pages = Console.ReadLine();
            Console.WriteLine("Please enter the book abstract");
            book.Abstract = Console.ReadLine();
            Console.WriteLine("Please enter the book tags");
            book.Tags = Console.ReadLine();
            Console.WriteLine("Please enter the book Publisher");
            book.Publishers = Console.ReadLine();
            Console.WriteLine("Please enter the book price");
            book.Price = Console.ReadLine();
            Console.WriteLine("Please enter the book rackno");
            book.Rackno = Console.ReadLine();
            Console.WriteLine("Please enter the book rowno");
            book.Rawno = Console.ReadLine();
            Console.WriteLine("Please enter the book status");
            book.Status = Console.ReadLine();
            Console.WriteLine("Please enter the book url");
            book.Url = Console.ReadLine();
            Console.WriteLine("Please enter the book city");
            book.City = Console.ReadLine();
            Console.WriteLine("Please enter the book editors");
            book.Editors = Console.ReadLine();
            Console.WriteLine("Please enter the book description: ");
            book.Description = Console.ReadLine();
            Console.WriteLine("Please enter the book author: ");
            book.Authors.Add(Console.ReadLine());
            Console.WriteLine("Please enter the book category: ");
            book.Categories.Add(Console.ReadLine());
            Console.WriteLine("Please enter the book edition: ");
            book.Edition = Console.ReadLine();
            Console.WriteLine("Please enter the book given date: ");
            book.Given = Console.ReadLine();

            byte[] bookBytes = Book.BookToByteArrayBlock(book);
            FileUtility.UpdateBlock(bookBytes, booknumber, Book.BOOK_DATA_BLOCK_SIZE, filename);

            runmenu.Start();

        }
        public void DeleteDat()
        {
            Console.Clear();
            if (File.Exists("library.dat"))
            {
                FileUtility.DeleteFile("library.dat");
                Console.WriteLine("All Books are deleted.");
            }
            else
            {
                Console.WriteLine("Library file couldn't found." + "/n");
            }
            Console.WriteLine("Press any key to return to Book Menu.");
            Console.ReadKey(true);

            runmenu.Start();
        }
        public void searchbook()
        {
            int i = 1;
            if (File.Exists("library.dat"))
            {
                Console.Write("Please enter name or ID of the book which do you want to find: ");
                var search = Console.ReadLine();
                if (ConversionUtility.IsNumeric(search) == false)
                {
                    using (StreamReader sr = new StreamReader(File.Open("library.dat", FileMode.Open)))
                    {
                        Console.Clear();
                        string myfile = sr.ReadLine();
                        sr.Close();
                        do
                        {
                            string path = AppDomain.CurrentDomain.BaseDirectory;
                            string filename = Path.Combine(path, "library.dat");


                            byte[] bookWrittenBytes = FileUtility.ReadBlock(i, Book.BOOK_DATA_BLOCK_SIZE, filename);
                            Book bookWrittenObject = Book.ByteArrayBlockToBook(bookWrittenBytes);

                            if (bookWrittenObject != null && (bookWrittenObject.Title.Contains(search)))
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.WriteLine("Book number : " + i);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.WriteLine("ID : " + bookWrittenObject.Id + "  Title : " + bookWrittenObject.Title + "  Year : " + bookWrittenObject.Year + "  Pages : " + bookWrittenObject.Pages + "  Abstract : " + bookWrittenObject.Abstract + "  Tags : " + bookWrittenObject.Tags);
                                Console.WriteLine("Publishers : " + bookWrittenObject.Publishers + "  Price : " + bookWrittenObject.Price + "  Rackno : " + bookWrittenObject.Rackno + "  Rawno : " + bookWrittenObject.Rawno + "  Status : " + bookWrittenObject.Status);
                                Console.WriteLine("Url : " + bookWrittenObject.Url + "  City : " + bookWrittenObject.City + "  Editors : " + bookWrittenObject.Editors + "  Description : " + bookWrittenObject.Description + "  Authors : " + bookWrittenObject.Authors[0]);
                                Console.WriteLine("Categories : " + bookWrittenObject.Categories[0]);
                                Console.WriteLine("Edition : " + bookWrittenObject.Edition + " Given : " + bookWrittenObject.Given);
                            }
                            i++;

                        } while (i < (((myfile.Length) / (Book.BOOK_DATA_BLOCK_SIZE)) + 1));
                        Console.WriteLine("Press any key to return...");
                        Console.ReadKey(true);
                        runmenu.Start();
                    }
                }
                else
                {
                    int searchint = Convert.ToInt32(search);

                    using (StreamReader sr = new StreamReader(File.Open("library.dat", FileMode.Open)))
                    {
                        Console.Clear();
                        string myfile = sr.ReadLine();
                        sr.Close();
                        do
                        {
                            string path = AppDomain.CurrentDomain.BaseDirectory;
                            string filename = Path.Combine(path, "library.dat");


                            byte[] bookWrittenBytes = FileUtility.ReadBlock(i, Book.BOOK_DATA_BLOCK_SIZE, filename);
                            Book bookWrittenObject = Book.ByteArrayBlockToBook(bookWrittenBytes);

                            if (bookWrittenObject != null && (bookWrittenObject.Id.Equals(searchint)))
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.WriteLine("Book number : " + i);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.WriteLine("ID : " + bookWrittenObject.Id + "  Title : " + bookWrittenObject.Title + "  Year : " + bookWrittenObject.Year + "  Pages : " + bookWrittenObject.Pages + "  Abstract : " + bookWrittenObject.Abstract + "  Tags : " + bookWrittenObject.Tags);
                                Console.WriteLine("Publishers : " + bookWrittenObject.Publishers + "  Price : " + bookWrittenObject.Price + "  Rackno : " + bookWrittenObject.Rackno + "  Rawno : " + bookWrittenObject.Rawno + "  Status : " + bookWrittenObject.Status);
                                Console.WriteLine("Url : " + bookWrittenObject.Url + "  City : " + bookWrittenObject.City + "  Editors : " + bookWrittenObject.Editors + "  Description : " + bookWrittenObject.Description + "  Authors : " + bookWrittenObject.Authors[0]);
                                Console.WriteLine("Categories : " + bookWrittenObject.Categories[0]);
                                Console.WriteLine("Edition : " + bookWrittenObject.Edition + " Given : " + bookWrittenObject.Given);
                            }
                            i++;

                        } while (i < (((myfile.Length) / (Book.BOOK_DATA_BLOCK_SIZE)) + 1));
                        Console.WriteLine("Press any key to return...");
                        Console.ReadKey(true);
                        runmenu.Start();
                    }
                }
            }
            else { Console.Clear(); Console.WriteLine("Library file couldn't found."); }

            Console.WriteLine("Press any key to return...");
            Console.ReadKey(true);
            runmenu.Start();
        }
        public void BorrowBook()
        {
            if (File.Exists("library.dat"))
            {
                string path = AppDomain.CurrentDomain.BaseDirectory;
                string filename = Path.Combine(path, "library.dat");
                Console.Clear();
                int booknumber;
                string student;
                string date;
                Console.Write("Please enter number of book which do you want to borrow: ");
                booknumber = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nWhat is the name of student who got the book: ");
                student = Console.ReadLine();
                Console.Write("\nDate: ");
                date = Console.ReadLine();


                using (StreamReader sr = new StreamReader(File.Open("library.dat", FileMode.Open)))
                {
                    string datalength = sr.ReadLine();
                    sr.Close();

                    byte[] bookWrittenBytesforBorrow = FileUtility.ReadBlock(booknumber, Book.BOOK_DATA_BLOCK_SIZE, filename);
                    Book bookWrittenObject = Book.ByteArrayBlockToBook(bookWrittenBytesforBorrow);


                    if (bookWrittenObject != null)
                    {
                        Book book = new Book();
                        book = bookWrittenObject;
                        book.Status = "Borrowed by student: " + student;
                        book.Given = "Given date: " + date;
                        byte[] bookBytes = Book.BookToByteArrayBlock(book);

                        FileUtility.UpdateBlock(bookBytes, booknumber, Book.BOOK_DATA_BLOCK_SIZE, filename);
                    }

                    Console.WriteLine("Press any key to return...");
                    Console.ReadKey(true);
                    runmenu.Start();
                }
            }
            else
            { 
                Console.Clear();
                Console.WriteLine("Library file couldn't found."); 
            }
            Console.WriteLine("Press any key to return...");
            Console.ReadKey(true);
            runmenu.Start();

        }
        public void ReturnBook()
        {
            if (File.Exists("library.dat"))
            {
                string path = AppDomain.CurrentDomain.BaseDirectory;
                string filename = Path.Combine(path, "library.dat");
                Console.Clear();
                int booknumber;
                string bookname;
                Console.Write("Please enter number of book which do you want to return: ");
                booknumber = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nWhat is book name: ");
                bookname = Console.ReadLine();


                using (StreamReader sr = new StreamReader(File.Open("library.dat", FileMode.Open)))
                {
                    string datalength = sr.ReadLine();
                    sr.Close();

                    byte[] bookWrittenBytesforBorrow = FileUtility.ReadBlock(booknumber, Book.BOOK_DATA_BLOCK_SIZE, filename);
                    Book bookWrittenObject = Book.ByteArrayBlockToBook(bookWrittenBytesforBorrow);


                    if (bookWrittenObject != null)
                    {
                        Book book = new Book();

                        book = bookWrittenObject;
                        book.Status = "Returned by a student ";

                        byte[] bookBytes = Book.BookToByteArrayBlock(book);

                        FileUtility.UpdateBlock(bookBytes, booknumber, Book.BOOK_DATA_BLOCK_SIZE, filename);
                    }
                    else
                    {
                        Console.WriteLine("The book couldn't found");
                        Console.ReadKey(true);
                        runmenu.Start();
                    }
                }

                Console.WriteLine("Press any key to return...");
                Console.ReadKey(true);
                runmenu.Start();
            }
            else { Console.Clear(); Console.WriteLine("Library file couldn't found."); }
            Console.WriteLine("Press any key to return...");
            Console.ReadKey(true);
            runmenu.Start();
        }
        public void addcategories()
        {
            category catego = new category();
            Console.Clear();
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string filename = Path.Combine(path, "categories.dat");

            Console.WriteLine("Please enter book title: ");
            catego.Categories.Add(Console.ReadLine());

            byte[] categoBytes = category.BookToByteArrayBlock(catego);
            FileUtility.AppendBlock(categoBytes, filename);
            Console.WriteLine("Succesfully");
            Console.ReadKey(true);
            runmenu.Start();


        }
        public void deletecategories()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string filename = Path.Combine(path, "categories.dat");
            Console.Clear();
            int catnumber;
            Console.WriteLine("Please enter number of category which do you want to delete: ");
            catnumber = Convert.ToInt32(Console.ReadLine());
          
            FileUtility.DeleteBlock(catnumber, category.CATEGORY_DATA_BLOCK_SIZE, filename);
            Console.WriteLine("Succesfully");
            Console.ReadKey(true);
            runmenu.Start();
        }
        public void editcategories()
        {
            category catego = new category();
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string filename = Path.Combine(path, "categories.dat");
            Console.Clear();
            int catnumber;
            Console.WriteLine("Please enter number of category which do you want to edit: ");
            catnumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please enter new book title: ");
            catego.Categories.Add(Console.ReadLine());
            

            byte[] catBytes = category.BookToByteArrayBlock(catego);
            FileUtility.UpdateBlock(catBytes, catnumber, category.CATEGORY_DATA_BLOCK_SIZE, filename);
            Console.WriteLine("Succesfully");
            Console.ReadKey(true);
            runmenu.Start();
        }
        public void listcategories()
        {
            Console.Clear();

            int i = 1;
            using (StreamReader sr = new StreamReader(File.Open("categories.dat", FileMode.Open)))
            {
                string datlength = sr.ReadLine();
                sr.Close();
                do
                {
                    string path = AppDomain.CurrentDomain.BaseDirectory;
                    string filename = Path.Combine(path, "categories.dat");


                    byte[] categoriesWrittenBytes = FileUtility.ReadBlock(i, category.CATEGORY_DATA_BLOCK_SIZE, filename);
                    category categoriesWrittenObject = category.ByteArrayBlockToBook(categoriesWrittenBytes);

                    if (categoriesWrittenObject != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine("Category number : " + i);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine(categoriesWrittenObject.Categories[0]);
                    }
                    i++;
                } while (i < (((datlength.Length) / (category.CATEGORY_DATA_BLOCK_SIZE)) + 1));

                Console.ReadKey(true);

                runmenu.Start();
            }
        }
        public void Deletecategoryfiles()
        {
            FileUtility.DeleteFile("categories.dat");
            Console.Clear();
            Console.WriteLine("Succesfully");
            Console.WriteLine("Press any key");
            Console.ReadKey(true);

            runmenu.Start();
        }
    }
}
