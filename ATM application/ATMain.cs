using System;
using System.Threading;
using ATM_account;
using System.Collections.Generic;

namespace Normal
{
    class ATM
    {
        static Account CurrentUser;
        static List<Account> lstAccount = new List<Account>();

        static void Main( string[] args )
        {
            AccountInit();
            ATMain();
        }
        static void AccountInit()
        {
            Account a1 = new Account( "aabbccc6" , "123" , 500 );
            lstAccount.Add( a1 );

            Account a2 = new Account( "aabbccc7" , "111" , 200 );
            lstAccount.Add( a2 );
        }
        static void ATMain()
        {
            Console.WriteLine( "Welcome to ATM System Alpha Build v0.16" );
            Console.WriteLine( "1.Sign in 2.Sign up" );
incorrect:
            string input = Console.ReadLine();
            int choice = 0;
            bool result = int.TryParse( input , out choice );
            if ( result )
            {
                switch ( choice )
                {
                    case 1:
                        SignIn();
                        break;
                    case 2:
                        SignUp();
                        break;
                    default:
                        Console.WriteLine( "Incorrect input!" );
                        goto incorrect;
                }
            }
            else
            {
                Console.WriteLine( "Incorrect input!" );
                ATMain();
            }
        }
        static void SignIn()
        {
            Console.WriteLine( "Enter your account" );
            string username = Console.ReadLine();
            Console.WriteLine( "Enter your password" );
            string password = Console.ReadLine();
            Authorize( username , password );
        }
        static void Authorize( string a , string b )
        {
            Console.WriteLine( "Authorizing..." );
            for ( int index = 0 ; index < lstAccount.Count ; index++ )
                if ( a == lstAccount[ index ].username && b == lstAccount[ index ].password )
                {
                    Console.WriteLine( "Authorize confirmed! welcome back, user." );
                    CurrentUser = lstAccount[ index ];
                    MainMenu();
                }
            Console.WriteLine( "Invalid account or password." );
            ATMain();
        }
        static Account GetAccount( string username )
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
        static void SignUp()
        {
            Console.WriteLine( "Please input your new account." );
            string S_UserName = Console.ReadLine();
            if ( GetAccount( S_UserName ) == null )
            {
                Console.WriteLine( "Please input your password." );
                string S_Password = Console.ReadLine();
                Account a = new Account( S_UserName , S_Password , 0 );
                Console.WriteLine( "Please wait..." );
                lstAccount.Add( a );
                Console.WriteLine( "Complete! now returning..." );
                ATMain();
            }
            else
            {
                Console.WriteLine( "This username is already exist" );
                SignUp();
            }
        }
        static void MainMenu()
        {
            //Sync();
            N_Balance();
            Alarm();
            Console.WriteLine( "Please choose one you wanna do:" );
            Console.WriteLine( "1.Deposit" );
            Console.WriteLine( "2.Withdrawal" );
            Console.WriteLine( "3.Transfer" );
            Console.WriteLine( "4.Exit" );
incorrect:
            string input = Console.ReadLine();
            int choice = 0;
            bool result = int.TryParse( input , out choice );
            if ( result )
            {
                switch ( choice )
                {
                    case 1:
                        Deposit();
                        break;
                    case 2:
                        Withdrawal();
                        break;
                    case 3:
                        Transfer();
                        break;
                    case 4:
                        LogOut();
                        break;
                    default:
                        Console.WriteLine( "incorrect input!" );
                        goto incorrect;
                }
            }
            else
            {
                Console.WriteLine( "Incorrect input!" );
                goto incorrect;
            }
        }
        static void Deposit()
        {
            Console.WriteLine( "How much do you wang to deposit?" );
            string input = Console.ReadLine();
            int plus = 0;
            bool result = int.TryParse( input , out plus );
            if ( result )
            {
                if ( plus <= 0 )
                {
                    Console.WriteLine( "Incorrect input!" );
                    Deposit();
                }
                Console.WriteLine( "Please put the cash in the cash box" );
                Console.WriteLine( "Please wait,validating bill" );
                CurrentUser.Deposit( plus );
                Console.WriteLine( "Success, now returning..." );
            }
            else
            {
                Console.WriteLine( "incorrect input" );
                Deposit();
            }
            MainMenu();
        }
        static void Withdrawal()
        {
            Console.WriteLine( "Choose how much you wanna withdraw:" );
            Console.WriteLine( "1.100" );
            Console.WriteLine( "2.300" );
            Console.WriteLine( "3.500" );
            Console.WriteLine( "4.800" );
incorrect:
            string input = Console.ReadLine();
            int choice = 0;
            bool result = int.TryParse( input , out choice );
            if ( result )
            {
                switch ( choice )
                {
                    case 1:
                        CurrentUser.Withdraw( 100 );
                        Withdraw();
                        break;
                    case 2:
                        CurrentUser.Withdraw( 300 );
                        Withdraw();
                        break;
                    case 3:
                        CurrentUser.Withdraw( 500 );
                        Withdraw();
                        break;
                    case 4:
                        CurrentUser.Withdraw( 800 );
                        Withdraw();
                        break;
                    default:
                        Console.WriteLine( "incorrect input!" );
                        goto incorrect;
                }
            }
            else
            {
                Console.WriteLine( "Incorrect input!" );
                goto incorrect;
            }
        }
        static void Withdraw()
        {
            Console.WriteLine( "Withdraw sequence in progress..." );
            Console.WriteLine( "Please take your money" );
            Console.WriteLine( "Success, do you want withdraw more money?" );
            Console.WriteLine( "1.Yes 2.No" );
incorrect:
            string input = Console.ReadLine();
            int choice = 0;
            bool result = int.TryParse( input , out choice );
            if ( result )
            {
                switch ( choice )
                {
                    case 1:
                        Withdrawal();
                        break;
                    case 2:
                        Console.WriteLine( "Returning..." );
                        MainMenu();
                        break;
                    default:
                        Console.WriteLine( "incorrect input!" );
                        goto incorrect;
                }
            }
            else
            {
                Console.WriteLine( "Incorrect input!" );
                goto incorrect;
            }
        }
        static void Transfer()
        {
            Console.WriteLine( "Input the account you wanna transfer:" );
            string input = Console.ReadLine();
            Account toUser = GetAccount( input );
            if ( toUser != null )
            {
                if ( toUser.username == CurrentUser.username )
                {
                    Console.WriteLine( "You cannot transfer money to yourself!" );
                    MainMenu();
                }
incorrect:
                Console.WriteLine( "Input the money you wanna transfer:" );
                string input2 = Console.ReadLine();
                int MoneyCount = 0;
                bool result = int.TryParse( input2 , out MoneyCount );
                if ( result )
                {
                    if ( MoneyCount <= 0 )
                    {
                        Console.WriteLine( "Incorrect input!" );
                        goto incorrect;
                    }
                    Console.WriteLine( "Processing..." );
                    CurrentUser.Withdraw( MoneyCount );
                    toUser.Deposit( MoneyCount );
                    Console.WriteLine( "Success, now returning..." );
                }
                else
                {
                    Console.WriteLine( "Incorrect input!" );
                    Transfer();
                }
            }
            else
            {
                Console.WriteLine( "account is not exist." );
                MainMenu();
            }
            MainMenu();
        }
        static void LogOut()
        {
            Console.WriteLine( "Thank you for using!" );
            Console.Write( "Wiping user data..." );
            Console.WriteLine( "done!" );
            ATMain();
        }
        static void N_Balance()
        {
            Console.WriteLine( "Your account balance is {0}" , CurrentUser.balance );
        }
        static void Alarm()
        {
            if ( CurrentUser.balance < 0 )
                Console.WriteLine( "Your account balance is lower than 0!!!please return it later." );
        }
        //static void Sync()
        //{
        //    for ( int index = 0 ; index < lstAccount.Count ; index++ )
        //    {
        //        if ( lstAccount[ index ].username == CurrentUser.username )
        //        {
        //            lstAccount[ index ] = CurrentUser;
        //        }
        //    }
        //}
    }
}