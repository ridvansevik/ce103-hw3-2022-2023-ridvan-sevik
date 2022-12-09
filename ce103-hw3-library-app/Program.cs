using System;
using System.IO;
using System.Text;
using ce103_hw3_library_lib;

namespace ce103_hw3_library_app
{
    public class Program
    {
        public static void Main()
        {
            {
                passwordcodes passwordcodes = new passwordcodes();
                passwordcodes.password();
            }

            {
                Console.Clear();
                contentofthemenu menuu = new contentofthemenu();
                menuu.Start();
            }
        }
    }
}



             