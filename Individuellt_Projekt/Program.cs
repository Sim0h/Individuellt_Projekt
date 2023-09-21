using System.Runtime.InteropServices;

namespace Individuellt_Projekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (pinOK == true)
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
            bool meny = true;
            int saldo = 0, deposit, withdraw;
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

        public static void Application()
        {

        }
    }
}

/* bool meny = true;
            int saldo = 0, dePosit, withDraw;
            while (meny == true)
            {
                try
                {


                Start:
                    Console.WriteLine("Välkommen till din Bank. Vad vill du göra idag?");
                    Console.WriteLine("1. Sätt in pengar ");
                    Console.WriteLine("2. Ta ut pengar ");
                    Console.WriteLine("3. Kontrollera Saldo ");
                    Console.WriteLine("4. Avsluta programmet ");
                    int userInput = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();

                    switch (userInput)
                    {
                        case 1:
                            Console.WriteLine("Hur mycket vill du sätta in? ");
                            dePosit = Convert.ToInt32(Console.ReadLine());
                            saldo += dePosit;
                            Console.Clear();
                            break;

                        case 2:
                            Console.WriteLine("Hur mycket vill du ta ut? ");
                            withDraw = Convert.ToInt32(Console.ReadLine());

                            if (withDraw > saldo)
                            {
                                Console.WriteLine("Det finns inte tillräckligt på Saldot");
                            }
                            else
                            {
                                saldo = saldo - withDraw;
                                Console.WriteLine(" Vänligen ta dina pengar");
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case 3:
                            Console.WriteLine($"Du har {saldo}kr på ditt konto.");
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case 4:
                            meny = false;
                            break;

                        case 5:
                            Console.WriteLine("Vänligen välj ett av alternativen");
                            goto Start;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            while (meny == false)
            {
                Console.WriteLine("Välkommen åter");
                Console.ReadKey();
                Environment.Exit(0);
            }*/