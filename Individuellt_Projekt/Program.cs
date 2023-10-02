using System.Globalization;
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
                new decimal[] { 2000, 1000, 500 },
                new decimal[] { 2000, 1000, 500 },
                new decimal[] { 1500 },
                new decimal[] { 3000, 200, 100 },
                new decimal[] { 800, 200 }
            };
            string[][] accountNames = {
                new string[] { "1. Lönekonto", "2. Sparkonto" },
                new string[] { "1. Lönekonto", "2. Sparkonto", "3. Resekonto" },
                new string[] { "1. Sparkonto" },
                new string[] { "1. Lönekonto", "2. Hyreskonto", "3. Sparande" },
                new string[] { "1. Lönekonto", "2. Fritidskonto" }
            };

            int numberOfTries = 2;
            string loggedInUser = null;
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
                            break;
                        }
                    }

                }

                while (inloggad == true)
                {
                    Console.Clear();
                    Console.WriteLine("Välkommen {0}! Vad vill du göra? ", loggedInUser);
                    Console.WriteLine("1. Se över dina konton och saldo ");
                    Console.WriteLine("2. Överförning mellan konton ");
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
                            WithdrawFromAccount(loggedInUser, accountNames[userIndex], accountBalance[userIndex]);
                            break;
                        case 4:
                            Console.WriteLine("Du har loggat ut. Välkommen åter!");
                            inloggad = false;
                            Console.ReadKey();
                            Console.Clear();
                            break;

                    }
                }

            }

        }



        public static void ShowAccountBalance(string user, string[] accountNames, decimal[] accountBalances)
        {
            Console.WriteLine($"Konton för {user}:");
            for (int i = 0; i < accountNames.Length; i++)
            {
                Console.WriteLine($"{accountNames[i]}: {accountBalances[i]}");
            }
            Console.ReadKey();

        }

        public static void WithdrawFromAccount(string user, string[] accountNames, decimal[] accountBalances)
        {

            Console.WriteLine($"Ta ut pengar för {user}:");

            // Visa användaren sina konton
            ShowAccountBalance(user, accountNames, accountBalances);
            
            Console.WriteLine("Välj konto att ta ut pengar från: ");
            int sourceIndex = int.Parse(Console.ReadLine()) - 1;

            Console.WriteLine("Ange summa att ta ut: ");
            decimal withdrawAmount = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Ange din PIN-kod för att bekräfta: ");
            string pinConfirmation = Console.ReadLine();

            int userIndex = Array.IndexOf(Users, user);

            if (userIndex != -1 && pinConfirmation == pinCode[userIndex] &&
                sourceIndex >= 0 && sourceIndex < accountBalances.Length &&
                accountBalances[sourceIndex] >= withdrawAmount)
            {
                accountBalances[sourceIndex] -= withdrawAmount;
                Console.WriteLine($"Uttag av {withdrawAmount} lyckat!");
                Console.WriteLine($"Nytt saldo på {accountNames[sourceIndex]}: {accountBalances[sourceIndex]}");
            }
            else
            {
                Console.WriteLine("Ogiltigt uttag. Kontrollera dina val, saldo och PIN-kod.");
            }

        }

        public static void TransferBetweenAccounts(string user, string[] accountNames, decimal[] accountBalances)
        {
            Console.WriteLine($"Överföring mellan konton för {user}:");

            // Visa användaren sina konton
            ShowAccountBalance(user, accountNames, accountBalances);

            Console.Write("Välj konto att ta pengar från: ");
            int sourceIndex = int.Parse(Console.ReadLine()) - 1;

            Console.Write("Välj konto att flytta pengarna till: ");
            int targetIndex = int.Parse(Console.ReadLine()) - 1;

            Console.Write("Ange summa att flytta: ");
            decimal transferAmount = decimal.Parse(Console.ReadLine());

            if (sourceIndex >= 0 && sourceIndex < accountBalances.Length &&
                targetIndex >= 0 && targetIndex < accountBalances.Length &&
                accountBalances[sourceIndex] >= transferAmount)
            {
                accountBalances[sourceIndex] -= transferAmount;
                accountBalances[targetIndex] += transferAmount;
                Console.WriteLine("Överföring lyckad!");
            }
            else
            {
                Console.WriteLine("Ogiltig överföring. Kontrollera dina val och saldo.");
            }
            Console.ReadKey();
        }



    }
}




        



