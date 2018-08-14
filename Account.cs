using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Application
{
    public class Account
    {
        public string AccountNumber;
        public string AccountName;
        public int Pin;
        public int Balance;
        public int OptionalBalance;
        
        public string AccountType;
        public Account(string accno,string accname,int pin,int bal,string acctype="Savings",int optbal = 500)
        {
            AccountNumber=accno;
            AccountName=accname;
            this.Pin=pin;
            Balance=bal;
            AccountType=acctype;
            OptionalBalance = optbal;
        }
        public int CheckBalance(string AccNumber)
        {
            return this.Balance;
        }
        public int DepositAmt(string AccNumber, int Amt)
        {
            this.Balance = this.Balance + Amt;
            return this.Balance;
        }
        public static void PinChange()
        {
            
        }
        public Boolean WithdrawAmt(string AccNumber, int Amt)
        {
            if (AccountType == "Savings")
            {
                if ((Balance - Amt) < OptionalBalance)
                    Console.WriteLine("Sorry Amount will violate minimum balance requirements");
                return false;
            }
            else
            {
                if ((Balance - Amt) < 0)
                    if ((Balance - Amt - OptionalBalance) < 0)
                    {
                        Console.WriteLine("Sorry! Low Balance");
                        return false;
                    }
                    else Console.WriteLine("Withdrawing with use of OverDraft");

            }
            if (CheckBalance(AccNumber) < Amt)
            {
                
                Console.WriteLine("Sorry Balance is Less than your Amount");
                return false;
            }
            else
            {
                Balance = Balance - Amt;
                Console.WriteLine("Transaction Successful");
                Console.WriteLine("Amount Withdrawn :" + Amt);
                Console.WriteLine("Available Balance:" + CheckBalance(AccNumber));
                return true;
            }
          
               
        }
    }
    class Savings : Account
    {
        int MinBalance;
        public Savings(string accno, string accname, int pin, int bal, string acctype, int minbal)
            : base(accno, accname, pin, bal, acctype,1000)
        {
            MinBalance = minbal;
            //this.Balance=this.Balance+MinBalance;
        }
        public void SavingsWithdraw(string accno, int amt)
        {
            if ((this.Balance - MinBalance) < amt)
                Console.WriteLine("Sorry, Amount withdraw will lead to Minimum Balance issue");
            else
                base.WithdrawAmt(accno, amt);
        }

    }
    class Current : Account
    {
        int OverDraft;
        public Current(string accno, string accname, int pin, int bal, string acctype, int overdraft)
            : base(accno, accname, pin, bal, acctype,1000)
        {
            OverDraft = overdraft;

        }
        public void CurrentWithdraw(string accno, int amt)
        {
            if (this.Balance < amt)
            {Console.WriteLine("Amount is greater than Account Balance");
            if ((this.Balance + OverDraft) > amt)
            {
                Console.WriteLine("You need to use OverDraft Money?");
                Console.WriteLine("Do you want to proceed?");
                string response = Console.ReadLine();
                if (response == "yes")
                    this.Balance = this.Balance + OverDraft;
                else
                    Console.WriteLine("Come Again Soon");
            }
            else
                Console.WriteLine("Sorry,your amount is even greater than overdraft added");
               
            }
            else
                WithdrawAmt(accno,amt);
        }
    }

}
