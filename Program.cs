using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Application
{
    public delegate void PinChange(string s);
    public delegate void AccBlock(string s);
    public class Bank
    {
        #region PasswordEntry
        public static string PasswordEntry()
        {
            string pass = "";
            //Console.WriteLine("Enter your Password:");
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Enter)
                    if (key.Key != ConsoleKey.Backspace)
                    {
                        pass += key.KeyChar;
                        Console.Write("*");
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        pass = pass.Remove(pass.Length - 1);
                        Console.WriteLine("Value is :" + pass);
                    }
                    else
                    {
                        pass = pass.Remove(pass.Length - 1);
                        Console.Write("\b \b");

                    }

            }
            while (key.Key != ConsoleKey.Enter);
            //Console.WriteLine();
            //Console.WriteLine("Password Entered By you is :"+pass);
            //Console.Read();
            return pass;

        }
        #endregion
        
        public int accountcount = 0;

        public static Account[] account = new Account[10];
        //{
        // new Account("121", "pankaj Jhamnani", 12345, 10000, "Savings", 500),
        // new Account("122", "abcd", 12345, 12000, "Savings", 500),
        // new Account("123", "manish bhatia", 12345, 15000, "Savings", 500),
        // new Account("124", "Nitin Banswani", 12345, 17000, "Savings", 500),
        // new Account("125", "abcdef", 12345, 100, "Savings", 500),
        // new Account("126", "pankaj Jhamnani", 12345, 10000, "Savings", 500),
        // new Account("127", "abcd", 12345, 12000, "Savings", 500),
        // new Account("128", "manish bhatia", 12345, 15000, "Savings", 500),
        // new Account("129", "Nitin Banswani", 12345, 17000, "Savings", 500),
        // new Account("130", "abcdef", 12345, 100, "Savings", 500),
        //};
        public static event AccBlock AccountBlock;
        public static event PinChange PinChangeNotify;
        //account[accountcount++] = new Account("121", "pankaj Jhamnani", 12345, 10000, "Savings", 500);
        // account[accountcount++] = new Account("122", "abcd", 12345, 12000, "Savings", 500);
        // account[accountcount++] = new Account("123", "manish bhatia", 12345, 15000, "Savings", 500);
        // account[accountcount++] = new Account("124", "Nitin Banswani", 12345, 17000, "Savings", 500);
        // account[accountcount++] = new Account("125", "abcdef", 12345, 100, "Savings", 500);
        public static void NotifyUserBlockAccount(string s)
        {
            Console.WriteLine(s);
        }
        public static void NotifyUser(string s)
        {
            Console.WriteLine(s);
        }
        public Account GetAccountWindow(string actype, string acno)
        {
            Boolean flag = false;
            Boolean flagpin = true;
            Account obj = null;
            //Console.WriteLine("Welcome Customer");
            //Console.WriteLine("Enter your Account Details:");
            //Console.WriteLine("Account Type:");
            // string actype = Console.ReadLine();
            // Console.WriteLine("Account Number:");
            //string acno = Console.ReadLine();

            #region For Loop to Check for Account
            for (int i = 0; i < 10; i++)
            {
                if (account[i].AccountNumber == acno)
                {
                    obj = account[i];
                    flag = true;
                    return obj;
                }
            }
            #endregion

            return obj;
            }
        public Account GetAccount(string actype, string acno)
        {
            Boolean flag = false;
            Boolean flagpin = true;
            Account obj = null;
            //Console.WriteLine("Welcome Customer");
            //Console.WriteLine("Enter your Account Details:");
            //Console.WriteLine("Account Type:");
            // string actype = Console.ReadLine();
            // Console.WriteLine("Account Number:");
            //string acno = Console.ReadLine();

            #region For Loop to Check for Account
            for (int i = 0; i < 10; i++)
            {
                if (account[i].AccountNumber == acno)
                {
                    obj = account[i];
                    flag = true;
                }
            }
            #endregion

            if (flag == false)//Account Not Found
            {
                //Console.WriteLine("Sorry Your Account Does Not Exists with us");
                //Console.WriteLine("Contact nearest Branch to Open an account");
                return obj;
            }


            else//Account Found!!
            {
                //Console.WriteLine("Hello! " + obj.AccountName);
                int countpin = 3;
                do
                {
                    //Console.WriteLine("Account PIN:");
                    //acpin = Console.ReadLine();
                    string acpin = PasswordEntry();

                    //Console.WriteLine(acpin);

                    if (acpin != obj.Pin.ToString()) //Matching Account Pin to authenticate
                    {
                        countpin--;
                        flagpin = false;
                        //Console.WriteLine("\nYour Pin Number is Not Matching!!");
                        // Console.WriteLine("Now, I doubt u!!, But then too you have {0} more chances \n", countpin);
                    }
                    else countpin = 0;


                } while ((countpin != 0) && (flagpin == false));
                if (countpin == 0)
                {

                    //AccountBlock += new AccBlock(NotifyUserBlockAccount);
                    //AccountBlock +=new AccBlock(NotifyUser);
                    //AccountBlock("Sorry Account Blocked for 24 Hours!!!"));
                    Parallel.Invoke(() =>
                        {
                            NotifyUser("Account Blocked SMS");
                        },
                    () =>
                    {
                        NotifyUserBlockAccount("Account Blocked Email");
                    }
                );

                    return obj;
                }
                return obj;
            }
        }
        static void Main(string[] args)
        {

            #region Initialisations and Declarations
            string actype = "Savings";
            string acno;
            
            int bankchoice;
            Current c1 = null;
            Bank b11 = new Bank();
            string acpin;
            int minbal = 0;
            Boolean flag = false;
            
           
            Account obj = null;
            Savings s1 = null;
            int acamt;
            int choice = 1;
            #endregion

            Console.WriteLine("Hello! Welcome to our Atm Services");

            while (choice != 3)
            {
                Console.WriteLine("Enter your choice to use our services");
                Console.WriteLine("Enter 1 for Using as a customer");
                Console.WriteLine("Enter 2 for Using as Bank Staff");
                Console.WriteLine("Enter 3 Exit");

                choice = int.Parse(Console.ReadLine());

                //User Has selected to use services as Customer with account with Bank

                if (choice == 1)
                {
                    Console.WriteLine("Enter Your Account Type");
                    string actype1 = Console.ReadLine();
                    Console.WriteLine("Enter Your Account Number");
                    string acno1 = Console.ReadLine();


                    obj = b11.GetAccount(actype1,acno1);
                    
                    if (obj == null)
                    {
                        Console.WriteLine("Failure!!");
                    }
                    else
                    {
                        //countpin = 0;
                        Console.WriteLine("\n Enter Your Choice of Banking:");
                        Console.WriteLine("1. Balance Check");
                        Console.WriteLine("2. Amount Withdraw");
                        Console.WriteLine("3. Amount Deposit");
                        Console.WriteLine("4. Change Pin");
                        Console.WriteLine("5. Use your account to pay Bills and Mobile Recharge");

                        bankchoice = int.Parse(Console.ReadLine());

                        #region BalanceCheck By User
                        if (bankchoice == 1)
                        {
                            int Balanceretrieve = obj.CheckBalance(obj.AccountNumber);
                            Console.WriteLine("Available Balance is {0} ", Balanceretrieve);
                        }
                        #endregion

                        #region Withdraw Request By User
                        if (bankchoice == 2)
                        {
                            Console.WriteLine("Enter Amount to be Withdrawn");
                            acamt = int.Parse(Console.ReadLine());
                            if (actype == "Savings")
                                obj.WithdrawAmt(obj.AccountNumber, acamt);
                            else
                                obj.WithdrawAmt(obj.AccountNumber, acamt);
                        }
                        #endregion

                        #region Deposit Request By user
                        if (bankchoice == 3)
                        {
                            Console.WriteLine("Enter Amount to be deposited");
                            acamt = int.Parse(Console.ReadLine());
                            obj.DepositAmt(obj.AccountNumber, acamt);
                        }
                        #endregion

                        #region Pin Change Request
                        if (bankchoice == 4)
                        {
                            Console.WriteLine("Enter your New Pin");
                            //obj.Pin = int.Parse(Console.ReadLine());
                            obj.Pin = int.Parse(PasswordEntry());
                            PinChangeNotify += new PinChange(NotifyUser);
                            PinChangeNotify("Pin Changed!!!");

                        }
                        #endregion

                        #region Bill Payments
                        if (bankchoice == 5)
                        {
                            Console.WriteLine("Enter Details of Mobile phone for which you need to Pay Bill/Recharge");
                            Console.WriteLine("Enter Mobile Number:");
                            string mobtemp = Console.ReadLine();
                            Console.WriteLine("Enter Amount to be paid:");
                            int amount = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter you Pin to confirm:");
                            //int temppin = int.Parse(Console.ReadLine());
                            int temppin = int.Parse(PasswordEntry());
                            Boolean flag1 = obj.WithdrawAmt(obj.AccountNumber, amount);
                            if (flag1)
                                Console.WriteLine("Your Payment to Mobile Number {0} is Successful!! Thanks for using our Services", mobtemp);




                        }


                        #endregion

                    }//1st else end

                    //}while (countpin != 0 || acpin == obj.Pin.ToString()) ;





                }//2nd else end here


                //Outer If

                else if (choice == 2)
                {
                    //Using Services As Bank Staff to add Account..

                    string ch = "yes";

                    while (ch == "yes")
                    {
                        Console.WriteLine("Do you wish to Add a Customer to Bank?");
                        ch = Console.ReadLine();
                        if (ch == "yes")
                        {


                            Console.WriteLine("Enter Details to add new Customers");
                            Console.WriteLine("Account Number:");
                            string acno1 = Console.ReadLine();
                            Console.WriteLine("Account Holder's Name:");
                            string acname = Console.ReadLine();
                            Console.WriteLine("Account type:");
                            string actype1 = Console.ReadLine();
                            Console.WriteLine("Enter Starting Balance:");
                            int bal = int.Parse(Console.ReadLine());

                            Console.WriteLine("set Pin for Customer:");
                            int pin1 = int.Parse(Console.ReadLine());
                            if (actype1 == "savings")//Checking for Minimum Balance
                            {
                                Console.WriteLine("Enter Minimum Balance for Customer");
                                minbal = int.Parse(Console.ReadLine());
                            }
                            else //OverDraft Amount
                            {
                                Console.WriteLine("Enter Overdraft Amount");
                                minbal = int.Parse(Console.ReadLine());
                            }
                            account[b11.accountcount] = new Account(acno1, acname, pin1, bal, actype1, minbal);
                            b11.accountcount = b11.accountcount + 1;
                            
                        }
                        //else
                        //{
                        //    //Console.WriteLine("Thanks For using Our Application.");
                        //}
                    }
                }
                else
                { Console.WriteLine("Thanks for using our Application"); }


            }
        }
    }
}
