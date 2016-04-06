using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_account
{
    public class Account
    {
        public string username;
        public string password;
        public int balance;
        public static int Count = 0;
        static Account()
        {
            Count = 0;
        }
        public Account(string name,string pass,int bal)
        {
            this.username = name;
            this.password = pass;
            this.balance = bal;
            Console.WriteLine( "profile created" );
            Count++;
        }
        public void Withdraw( int money )
        {
            this.balance -= money;
        }
        public void Deposit( int money )
        {
            this.balance += money;
        }
    }
}
