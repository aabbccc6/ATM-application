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
            Count++;
        }
        public bool Draw( int money )
        {
            if ( money > this.balance || money < 0 )
            {
                return false;
            }
            else
            {
                this.balance -= money;
                return true;
            }
        }
        public bool Save( int money )
        {
            if ( money >= 10000 || money < 0 )
            {
                return false;
            }
            else
            {
                this.balance += money;
                return true;
            }
        }
        public bool Trans( Account to , int money )
        {
            if ( this.balance >= money && money >= 0 && money < 10000 )
            {
                this.balance -= money;
                to.balance += money;
                return true;
            }
            else
            {
                return false;
            }
        }
        public int Balance
        {
            get
            {
                return balance;
            }
        }
        public static bool Authorize( string username , string password )
        {
            Console.WriteLine( "Authorizing..." );
            for ( int index = 0 ; index < lstAccount.Count ; index++ )
                if ( username == lstAccount[ index ].username && password == lstAccount[ index ].password )
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
