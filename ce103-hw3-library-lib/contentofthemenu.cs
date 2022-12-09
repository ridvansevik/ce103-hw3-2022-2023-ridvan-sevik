using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce103_hw3_library_lib
{
    public class contentofthemenu
    {

        public void Start()
        {

            RunMainMenu();
        }
        public void RunMainMenu()
        {
            functions function= new functions();
            
            string prompt = @"
            __   ____ ___  ____ ___  ____ _      ___  ____ ____ 
            | |  |___\| .\ | . \|  \ | . \||_/\  |  \ | . \| . \
            | |__| /  | .<_|  <_| . \|  <_| __/  | . \| __/| __/
            |___/|/   |___/|/\_/|/\_/|/\_/|/     |/\_/|/   |/   
            ";

            string[] options = { "Books Menu","Categories Menu","About", "Options","Delete Category File", "Exit" };
            mainmenucodes mainmenu = new mainmenucodes(prompt, options);
            int SelectedIndex = mainmenu.Run();

            switch (SelectedIndex)
            {
                case 0:
                    BookMenu();
                    break;
                case 1:
                    CategoriesMenu();
                    break;

                case 2:
                    about();
                    break;

                case 3:
                    settings();
                    break;
                case 4:
                    function.Deletecategoryfiles();
                    break;
                case 5:
                    Exit();
                    break;

            }

        }
        private void BookMenu()
        {
            string prompt = "";
            string[] options = { "Add Book", "Delete Book", "Edit Book", "List Book", "Search Book", "Delete All Files", "Borrow Book", "Return Book", "Go Back" };
            mainmenucodes mainmenu = new mainmenucodes(prompt, options);
            int SelectedIndex = mainmenu.Run();


            switch (SelectedIndex)
            {
                case 0:
                    Console.Clear();
                    functions add = new functions();
                    add.addBook();
                    RunMainMenu();
                    break;

                case 1:
                    Console.Clear();
                    functions delete = new functions();
                    delete.deletebook();
                    break;

                case 2:
                    Console.Clear();
                    functions edit = new functions();
                    edit.editbook();
                    break;

                case 3:
                    Console.Clear();
                    functions list = new functions();
                    list.listbook();
                    RunMainMenu();
                    break;

                case 4:
                    Console.Clear();
                    functions searchbook = new functions();
                    searchbook.searchbook();
                    break;
                case 5:
                    Console.Clear();
                    functions deleteall = new functions();
                    deleteall.DeleteDat();
                    break;
                case 6: 
                    Console.Clear();
                    functions borrowbook = new functions();
                    borrowbook.BorrowBook();
                    break;
                case 7:
                    Console.Clear();
                    functions returnbook= new functions();
                    returnbook.ReturnBook();
                    break;
                case 8:
                    RunMainMenu();
                    break;
                
            }
        }
        private void CategoriesMenu()
        {
            string prompt = "";
            string[] options = { "Add categories", "Delete categories", "Edit categories", "List categories", "Go Back"};
            mainmenucodes mainmenu = new mainmenucodes(prompt, options);
            int SelectedIndex = mainmenu.Run();


            switch (SelectedIndex)
            {
                case 0:
                    Console.Clear();
                    functions addcategories = new functions();
                    addcategories.addcategories();
                    break;

                case 1:
                    Console.Clear();
                    functions deletecategories = new functions();
                    deletecategories.deletecategories();
                    break;

                case 2:
                    Console.Clear();
                    functions editcategories = new functions();
                    editcategories.editcategories();
                    break;

                case 3:
                    Console.Clear();
                    functions listcategories = new functions();
                    listcategories.listcategories();
                    RunMainMenu();
                    break;

                case 4:
                    RunMainMenu();
                    break;

            }
        }
        private void settings()
        {
            string prompt = "";
            string[] options = { "change color", "go back" };
            mainmenucodes mainmenu = new mainmenucodes(prompt, options);
            int SelectedIndex = mainmenu.Run();

            switch (SelectedIndex)
            {
                case 0:
                    Console.Clear();
                    Console.WriteLine("This application cannot change color for now");
                    Console.WriteLine("Press any key to go main menu");
                    Console.ReadKey();
                    settings();
                    break;
                case 1:
                    RunMainMenu();
                    break;
            }

        }
        private void about()
        {
            Console.Clear();
            Console.WriteLine("Someone who wants to take 100 points");
            Console.WriteLine("Press any key to go back");
            Console.ReadKey(true);
            RunMainMenu();
        }
        private void Exit()
        {
            Console.WriteLine("Press any key to exit");
            Console.ReadKey(true);
            Environment.Exit(0);
        }
    }
}
