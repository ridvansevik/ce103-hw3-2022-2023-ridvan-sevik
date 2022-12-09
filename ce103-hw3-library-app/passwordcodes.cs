using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce103_hw3_library_app
{
    internal class passwordcodes
    {


        public void password()
        {
            const string pass = "a";
            string temppass;

            Console.Write(@"
╦ ╦┬ ┬┌─┐┌┬┐  ╦┌─┐  ╦ ╦┌─┐┬ ┬┬─┐  ╔═╗┌─┐┌─┐┌─┐┬ ┬┌─┐┬─┐┌┬┐  ╔═╗┬┬─┐
║║║├─┤├─┤ │   ║└─┐  ╚╦╝│ ││ │├┬┘  ╠═╝├─┤└─┐└─┐││││ │├┬┘ ││  ╚═╗│├┬┘
╚╩╝┴ ┴┴ ┴ ┴   ╩└─┘   ╩ └─┘└─┘┴└─  ╩  ┴ ┴└─┘└─┘└┴┘└─┘┴└──┴┘  ╚═╝┴┴└─
");

            int right = 3;

            for (int i = 0; i < right; i++)
            {
                Console.Write("Password: ");
                temppass = Console.ReadLine();

                if (temppass == pass)
                {

                    Console.WriteLine("Access granted.");
                    Console.ReadKey(true);
                    contentofthemenu menuu = new contentofthemenu();
                    menuu.Start();
                }
                else
                {

                    Console.WriteLine("Access denied.");
                    Console.WriteLine("Press any key");

                    Console.ReadKey(true);


                    if (i == 2)
                    {
                        Console.WriteLine("You aren't the one who can reach to this application");
                        Console.WriteLine("Press any key");
                        Console.ReadKey(true);
                        Environment.Exit(0);
                    }
                }

            }
        }
    }
}
