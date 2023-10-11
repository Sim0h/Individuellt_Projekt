using System.Globalization;
using System.Net.Mime;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;

namespace Individuellt_Projekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] Users = new string[5] { "simon", "anas", "tobias", "johanna", "pär" };
            string[] pinCode = new string[5] { "111", "222", "333", "444", "555" };

            decimal[][] accountBalance =
            {
                new decimal[] { 21250, 15000 },
                new decimal[] { 25350, 10000, 5000, 250000 },
                new decimal[] { 150000 },
                new decimal[] { 30256, 20000, 1000 },
                new decimal[] { 80000, 20000 }
            };
            string[][] accountNames = {
                new string[] { "1. Lönekonto", "2. Sparkonto" },
                new string[] { "1. Lönekonto", "2. Sparkonto", "3. Resekonto", "4. Pensionskonto" },
                new string[] { "1. Sparkonto" },
                new string[] { "1. Lönekonto", "2. Hyreskonto", "3. Sparande" },
                new string[] { "1. Lönekonto", "2. Fritidskonto" }
            };

            int numberOfTries = 2;
            string loggedInUser = "";
            bool inloggad = false;
            while (inloggad == false)
            {
                Console.WriteLine("------- Välkommen till SUT23 Bank -------");
                Console.WriteLine("Vänligen skriv ditt användarnamn");
                string InputUsername = Console.ReadLine().ToLower();
                int userIndex = Array.IndexOf(Users, InputUsername);

                if (userIndex != -1)
                {
                    Console.WriteLine("Användare Godkänd.");
                    Console.WriteLine("Vänligen skriv din PIN-kod:");
                    string userInputPin = Console.ReadLine();

                    while (numberOfTries > 0)
                    {
                        if (pinCode[userIndex] == userInputPin)
                        {
                            Console.WriteLine("Pinkod Godkänd.");
                            Console.WriteLine("Tryck enter för att gå vidare.");
                            loggedInUser = Users[userIndex];
                            inloggad = true;
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Fel PIN-kod!");
                            Console.WriteLine("{0} Försök kvar", numberOfTries);
                            Console.WriteLine("Försök igen: ");
                            userInputPin = Console.ReadLine();
                            numberOfTries--;
                        }

                        while (numberOfTries == 0)
                        {
                            Console.WriteLine("Max antal försök uppnåt. Vänligen starta om programmet för att logga in igen.");
                            Console.ReadKey();
                            Environment.Exit(0);
                            break;
                        }
                    }

                }

                while (inloggad == true)
                {
                    Console.Clear();
                    Console.WriteLine("Välkommen {0}! Vad vill du göra? ", loggedInUser);
                    Console.WriteLine("1. Se över dina konton och saldo ");
                    Console.WriteLine("2. Överföring mellan konton ");
                    Console.WriteLine("3. Ta ut pengar ");
                    Console.WriteLine("4. Logga ut. ");

                    int userInputmenu = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();

                    switch (userInputmenu)
                    {
                        case 1:
                            ShowAccountBalance(loggedInUser, accountNames[userIndex], accountBalance[userIndex]); 
                            break;
                        case 2:
                            TransferBetweenAccounts(loggedInUser, accountNames[userIndex], accountBalance[userIndex]);
                            break;
                        case 3:
                            WithdrawFromAccount(loggedInUser, accountNames[userIndex], accountBalance[userIndex], pinCode, Users);
                            break;
                        case 4:
                            Console.WriteLine("Du har loggat ut. Välkommen åter!");
                            inloggad = false;
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        default:
                            Console.WriteLine("Ogiltligt val.\nVänligen klicka enter för gå tillbaka till huvudmenyn." );
                            Console.ReadKey();
                            Console.Clear();
                            break;

                    }
                }

            }

        }



        public static void ShowAccountBalance(string user, string[] accountNames, decimal[] accountBalances)
        {
            // Metod presenterar inloggad användares konton och summan på dessa konton. 
            Console.WriteLine($"Konton för {user}:");
            for (int i = 0; i < accountNames.Length; i++)
            {
                Console.WriteLine($"{accountNames[i]}: {accountBalances[i]}kr.");
            }
            Console.WriteLine("Vänligen klicka Enter för att gå vidare.");
            Console.ReadKey();
            

        }

        public static void WithdrawFromAccount(string user, string[] accountNames, decimal[] accountBalances , string[] pinCode , string[] Users)
        {
            // metoden använder sig av metoden ShowAccountBalance för att presentera användarens konton samt kunna göra urtag. 
            Console.WriteLine($"Ta ut pengar för {user}:");

            
            ShowAccountBalance(user, accountNames, accountBalances);
            
            Console.WriteLine("Välj konto att ta ut pengar från: ");
            int sourceIndex = Convert.ToInt32(Console.ReadLine()) -1;

            Console.WriteLine("Ange summa att ta ut: ");
            decimal withdrawAmount = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Ange din PIN-kod för att bekräfta: ");
            string pinConfirmation = Console.ReadLine();
            
            int userIndex = Array.IndexOf(Users, user);

            // kontrollerar flera moment för att kunna göra ett urtag, finns tillräckligt med saldo? var PIN-kod ok? valt konto? 

            if (userIndex != -1 && pinConfirmation == pinCode[userIndex] &&
                sourceIndex >= 0 && sourceIndex < accountBalances.Length &&
                accountBalances[sourceIndex] >= withdrawAmount)
            {
                accountBalances[sourceIndex] -= withdrawAmount;
                Console.WriteLine($"Uttag av {withdrawAmount} lyckat!");
                Console.WriteLine($"Nytt saldo på {accountNames[sourceIndex]}: {accountBalances[sourceIndex]}");
                Console.ReadKey();
                
            }
            else
            {
                Console.WriteLine("Ogiltigt uttag. Kontrollera dina val, saldo och PIN-kod.");
            }
            Console.WriteLine("Vänligen klicka Enter för komma till huvudmenyn.");
            Console.ReadKey();
        }

        public static void TransferBetweenAccounts(string user, string[] accountNames, decimal[] accountBalances)
        {
            /* likt för att ta ut gäller samma förutsättningar för att kunna flytta emellan konton. 
            Anropar tidigare medtod ShowAccountBalance för att visa användaren hur mycket det finns på deras konto */
            Console.WriteLine($"Överföring mellan konton för {user}:");
                        
            ShowAccountBalance(user, accountNames, accountBalances);

            Console.WriteLine("Välj konto att flytta pengar från: ");
            int sourceIndex = int.Parse(Console.ReadLine()) - 1;

            Console.WriteLine("Välj konto att flytta pengarna till: ");
            int targetIndex = int.Parse(Console.ReadLine()) - 1;

            Console.WriteLine("Ange summa att flytta: ");
            decimal transferAmount = decimal.Parse(Console.ReadLine());
               // Kontrollerar så att det finns pengar att föra över                     
              if (sourceIndex >= 0 && sourceIndex < accountBalances.Length &&
                  targetIndex >= 0 && targetIndex < accountBalances.Length &&  
                  accountBalances[sourceIndex] >= transferAmount)  
              {
                   accountBalances[sourceIndex] -= transferAmount;
                   accountBalances[targetIndex] += transferAmount;
                   Console.WriteLine("Överföring lyckad!"); 
                   Console.WriteLine($"Nytt saldo på {accountNames[sourceIndex]}: {accountBalances[sourceIndex]}kr.\nNytt saldo på {accountNames[targetIndex]}: {accountBalances[targetIndex]}kr.");  
              }
              else
              {
                 Console.WriteLine("Ogiltig överföring. Kontrollera dina val och saldo.");
                    
              }
            Console.WriteLine("Vänligen klicka Enter för komma till huvudmenyn.");
            Console.ReadKey();
            
        }



    }
}




        



