using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ServerHost {
    class Program {
        protected static void login() {//Login Code
            String username = "";
            String password = "";

            while(username != "admin" && password != "mywins13") {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("\t\tEnter Username : ");
                username = Console.ReadLine();

                Console.Write("\t\tEnter Password : ");
                password = Console.ReadLine();

                if(username == "admin" && password == "mywins13") {
                    Console.Title = "College Library Management Database Server 1.0 - Logged In";
                    getCommands();
                }

                else
                    Console.WriteLine("\t\tInvalid Login Credentials");
                Console.ReadLine();
            }
        }
        protected static void getCommands() {//Establish Commands
                ServiceHost host = new ServiceHost(typeof(Server.DatabaseServer));
                Console.Clear();
                String input = "";

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("\t\tWELCOME TO CLMS DATABASE SERVER");
                Console.WriteLine();

                while(input != "poweroff") {//Loops until Poweroff
                    Console.Write("\t\tEnter Command : ");
                    input = Console.ReadLine().ToLower();
                    switch(input) {
                        case "start":
                            host = new ServiceHost(typeof(Server.DatabaseServer));
                            host.Open();
                            Console.WriteLine("\t\tServer Connection Established @ " + DateTime.Now.ToString());
                            Console.WriteLine();
                            break;
                        case "state":
                            Console.WriteLine("\t\tServer Connection " + host.State);
                            Console.WriteLine();
                            break;
                        case "stop":
                            host.Close();
                            Console.WriteLine("\t\tServer Connection Closed @ " + DateTime.Now.ToString());
                            Console.WriteLine();
                            break;
                        case "clear":
                            Console.Clear();
                            Console.WriteLine();
                            break;
                        case "poweroff":
                            host.Close();
                            break;
                        case "address":
                            foreach(Uri address in host.BaseAddresses)
                                Console.WriteLine("\t\tListening on " + address);
                            Console.WriteLine();
                            break;
                        default:
                            Console.WriteLine("\t\tInvalid Command");
                            Console.WriteLine();
                            break;              
                    }
            }
        }
        static void Main(string[] args) {
            Console.Title = "College Library Management Database Server 1.0 - Not Logged In";
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            login();

        }
    }
}
