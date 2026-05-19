// Imports //
using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

// Explaning The System //
Console.WriteLine("Welcome to The Bank, Although We are living in a Simulation but still, How can I help you Today...");

// Account List For The Json //
List<Account> accounts = new List<Account>();

// Giving The Info to Json //
if (File.Exists("account.json"))
{
    string existingJson = File.ReadAllText("account.json");

    try
    {
        accounts = JsonSerializer.Deserialize<List<Account>>(existingJson) ?? new List<Account>();
    }
    catch
    {
        accounts = new List<Account>();
    }
}

Account acc = new Account();

// Main System Loop //
while (true)
{
    Console.WriteLine("1. Make a New Account [y/n] : ");
    string c1 = Console.ReadLine();

    int i = 0;

    while (i != 1)
    {
        if (c1 == "y")
        {
            acc = new Account(); // ✔ ensure new account each time

            Console.WriteLine("Enter your First Name : ");
            string name_ = Console.ReadLine();
            acc.Name = string.IsNullOrEmpty(name_) ? "John" : name_;

            Console.WriteLine("Enter your Last Name : ");
            string lastname_ = Console.ReadLine();
            acc.LastName = string.IsNullOrEmpty(lastname_) ? "Kaisen" : lastname_;

            string fullname = acc.Name + " " + acc.LastName;
            acc.Name = fullname;

            Console.WriteLine("Enter your Password : ");
            string pass_ = Console.ReadLine();
            acc.Password = string.IsNullOrEmpty(pass_) ? "0123456789" : pass_;

            Console.WriteLine("Your Name is " + acc.Name);
            Console.WriteLine("Your Password is " + acc.Password);

            accounts.Add(acc);

            i++;
        }
        else
        {
            break;
        }
    }

    if (c1 == "n")
    {
        Console.WriteLine("Alright, Your Other Option is,");
        Console.WriteLine("2. Access Account [y/n] : ");
        string c2 = Console.ReadLine();

        if (c2 == "y")
        {
            Console.WriteLine("Please, Enter Your Full Name : ");
            string name_ = Console.ReadLine();

            Console.WriteLine("Please Enter Your Password : ");
            string pass_ = Console.ReadLine();

            // SEARCH IN LIST
            Account foundAcc = null;

            foreach (Account a in accounts)
            {
                if (a.Name == name_ && a.Password == pass_)
                {
                    foundAcc = a;
                    break;
                }
            }

            if (foundAcc != null)
            {
                Console.WriteLine(" ~~ Login in Successful ~~ ");
                Console.WriteLine("What Do You Want to Do Now, Sir : ");
                Console.WriteLine("1. Check Balance, 2. Deposit, 3. Withdrawl [1/2/3] : ");
                string c3 = Console.ReadLine();

                if (c3 == "1")
                {
                    Console.WriteLine(foundAcc.Balance);
                }
                else if (c3 == "2")
                {
                    Console.WriteLine("Enter Deposit Amount : ");
                    double amount = double.Parse(Console.ReadLine());
                    foundAcc.Deposit(amount);
                    Console.WriteLine("Balance : " + foundAcc.Balance);
                }
                else if (c3 == "3")
                {
                    Console.WriteLine("Enter Withdrawl Amount : ");
                    double amount = double.Parse(Console.ReadLine());
                    foundAcc.Withdraw(amount);
                    Console.WriteLine("Balance : " + foundAcc.Balance);
                }
                else
                {
                    Console.WriteLine("Okay See You, Sir");
                    break;
                }
            }
            else
            {
                Console.WriteLine("Intruder He is Trying to Steal Money");
                break;
            }
        }
        else if (c2 == "n")
        {
            Console.WriteLine("Okay See You, Sir");
            break;
        }
    }

    // Saving in Json //
    string json = JsonSerializer.Serialize(accounts);
    File.WriteAllText("account.json", json);
}
