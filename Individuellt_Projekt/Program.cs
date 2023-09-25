using System.Runtime.InteropServices;

namespace Individuellt_Projekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //if (pinOK == true)
            {
                Menu();
            }
        }

        public static void User()
        {
            string[] Users = new string[5] { "Admin", "Moderator", "Simon", "Alice", "Gud" };
            int[] pinCode = new int[5];


        }
        
        public static void Menu()
        {
            bool menu = true;
            int saldo = 0, deposit, withdraw;
            while (menu == true)
            {
                Console.WriteLine("Vad vill du göra? ");
                Console.WriteLine("1. Sätt in pengar ");
                Console.WriteLine("2. Ta ut pengar ");
                Console.WriteLine("3. Kontrollera Saldo ");
                Console.WriteLine("4. Logga ut. ");
                Console.WriteLine("5. Avsluta programmet. ");
                int userInput = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (userInput)
                {
                    case 1:
                        Console.WriteLine("Hur mycket vill du sätta in? ");
                        deposit = Convert.ToInt32(Console.ReadLine());
                        saldo += deposit;
                        break;
                    case 2:

                        Console.WriteLine("Hur mycket vill du ta ut?");
                        withdraw = Convert.ToInt32(Console.ReadLine());
                        if (withdraw > saldo)
                        {
                            Console.WriteLine("Det finns inte tillräckligt på Saldot");
                        }
                        else
                        {
                            saldo = saldo - withdraw;
                            Console.WriteLine("Vändligen ta dina pengar");

                        }
                        break;

                    case 3:
                        Console.WriteLine("Du har {0}kr på ditt konto", saldo);
                        break;

                    case 4:
                        Console.WriteLine("Du har loggat ut. Välkommen åter!");
                        Console.ReadKey();
                        Console.Clear();
                        User();
                        break;

                }
            }

        }

        public static void Application()
        {

        }
    }
}

