using System;
using System.Collections.Generic;
namespace ATM_account
{
    public class Account
    {
        public static Account CurrentUser;
        public static List<Account> lstAccount = new List<Account>();

        public string username;
        private string password;
        private int balance;
        public static int Count = 0;
        static Account()
        {
            Count = 0;
        }
        public Account( string name , string pass , int bal )
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
        public int Balance
        {
            get
            {
                return balance;
            }
        }
        public static bool Authorize( string a , string b )
        {
            Console.WriteLine( "Authorizing..." );
            for ( int index = 0 ; index < lstAccount.Count ; index++ )
                if ( a == lstAccount[ index ].username && b == lstAccount[ index ].password )
                {
                    Console.WriteLine( "Authorize confirmed! welcome back, user." );
                    CurrentUser = lstAccount[ index ];
                    return true;
                }
            Console.WriteLine( "Invalid account or password." );
            return false;
        }
        public static Account GetAccount( string username )
        {
            for ( int index = 0 ; index < lstAccount.Count ; index++ )
            {
                if ( lstAccount[ index ].username == username )
                {
                    return lstAccount[ index ];
                }
            }
            return null;
        }
    }
}
