using System;
using System.Threading;
using ATM_account;
using System.Collections.Generic;

namespace Normal
{
    class ATM
    {
        static Account CurrentUser;
        static int CurrentUserID;
        static Account ToUser;
        static int ToUserID;
        static List<Account> lstAccount = new List<Account>();
        static string username;
        static string password;
        static int MoneyCount;
        static void Main( string[] args )
        {
            AccountInit();
            ATMain();
        }
        private static void AccountInit()
        {
            Account a1 = new Account();
            a1.username = "aabbccc6";
            a1.password = "123";
            a1.balance = 100;
            lstAccount.Add( a1 );

            Account a2 = new Account();
            a2.username = "aabbccc7";
            a2.password = "111";
            a2.balance = 200;
            lstAccount.Add( a2 );
        }
        static void ATMain()
        {
            Console.WriteLine( "Welcome to ATM System Alpha Build v0.15" );
            Thread.Sleep( 50 );
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
            username = Console.ReadLine();
            Console.WriteLine( "Enter your password" );
            password = Console.ReadLine();
            Authorize();
        }
        static void Authorize()
        {
            Console.WriteLine( "Authorizing..." );
            Thread.Sleep( 800 );
            for ( int index = 0 ; index < lstAccount.Count ; index++ )
                if ( username == lstAccount[ index ].username && password == lstAccount[ index ].password )
                {
                    Console.WriteLine( "Authorize confirmed! welcome back, user." );
                    CurrentUser = lstAccount[ index ];
                    CurrentUserID = index;
                    Thread.Sleep( 50 );
                    Console.WriteLine();
                    Thread.Sleep( 50 );
                    Console.WriteLine();
                    Thread.Sleep( 50 );
                    Console.WriteLine();
                    MainMenu();
                }
            Console.WriteLine( "Invalid account or password." );
            Console.WriteLine();
            Thread.Sleep( 50 );
            Console.WriteLine();
            Thread.Sleep( 50 );
            Console.WriteLine();
            Thread.Sleep( 50 );
            ATMain();
        }
        static bool IsExist( string username )
        {
            for (int index = 0 ; index < lstAccount.Count ; index++ )
            {
                if ( lstAccount[ index ].username == username )
                {
                    ToUser = lstAccount[ index ];
                    ToUserID = index;
                    return true;
                }
            }
            return false;
        }
        static void SignUp()
        {
alreadyexist:
            Console.WriteLine( "Please input your new account." );
            string s_username = Console.ReadLine();
            if ( !IsExist( username ) )
            {
                Console.WriteLine( "Please input your password." );
                string s_password = Console.ReadLine();
                Account a = new Account();
                a.username = username;
                a.password = password;
                a.balance = 0;
                Console.WriteLine( "Please wait..." );
                Thread.Sleep( 500 );
                lstAccount.Add( a );
                Console.WriteLine( "Complete! now returning..." );
                Thread.Sleep( 50 );
                Console.WriteLine();
                Thread.Sleep( 50 );
                Console.WriteLine();
                Thread.Sleep( 50 );
                Console.WriteLine();
                Thread.Sleep( 50 );
                Console.WriteLine();
                Thread.Sleep( 50 );
                Console.WriteLine();
                Thread.Sleep( 50 );
                ATMain();
            }
            else
            {
                Console.WriteLine( "This username is already exist" );
                goto alreadyexist;
            }
        }
        static void MainMenu()
        {
            sync();
            n_balance();
            alarm();
            Console.WriteLine( "Please choose one you wanna do:" );
            Thread.Sleep( 50 );
            Console.WriteLine( "1.Deposit" );
            Thread.Sleep( 50 );
            Console.WriteLine( "2.Withdrawal" );
            Thread.Sleep( 50 );
            Console.WriteLine( "3.Transfer" );
            Thread.Sleep( 50 );
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
                Console.WriteLine( "Please put the cash in the cash box" );
                Thread.Sleep( 1000 );
                Console.WriteLine( "Please wait,validating bill" );
                Thread.Sleep( 1000 );
                CurrentUser.balance +=plus;
                Console.WriteLine( "Success, now returning..." );
            }
            else
            {
                Console.WriteLine( "incorrect input" );
                Console.WriteLine();
                Thread.Sleep( 50 );
                Console.WriteLine();
                Thread.Sleep( 50 );
                Console.WriteLine();
                Thread.Sleep( 50 );
                Deposit();
            }
            Console.WriteLine();
            Thread.Sleep( 50 );
            Console.WriteLine();
            Thread.Sleep( 50 );
            Console.WriteLine();
            Thread.Sleep( 50 );
            MainMenu();
        }
        static void Withdrawal()
        {
            Console.WriteLine( "Choose how much you wanna withdraw:" );
            Thread.Sleep( 50 );
            Console.WriteLine( "1.100" );
            Thread.Sleep( 50 );
            Console.WriteLine( "2.300" );
            Thread.Sleep( 50 );
            Console.WriteLine( "3.500" );
            Thread.Sleep( 50 );
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
                        CurrentUser.balance -=100 ;
                        Withdraw();
                        break;
                    case 2:
                        CurrentUser.balance -=300 ;
                        Withdraw();
                        break;
                    case 3:
                        CurrentUser.balance -=500 ;
                        Withdraw();
                        break;
                    case 4:
                        CurrentUser.balance -=800 ;
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
            Thread.Sleep( 2000 );
            Console.WriteLine( "Please take your money" );
            Thread.Sleep( 1000 );
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
                        Console.WriteLine();
                        Thread.Sleep( 50 );
                        Console.WriteLine();
                        Thread.Sleep( 50 );
                        Console.WriteLine();
                        Thread.Sleep( 50 );
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
            string input=Console.ReadLine();
            if ( IsExist( input ) )
            {
                if ( ToUser.username == CurrentUser.username )
                {
                    Console.WriteLine( "U cannot transfer money to yourself...!" );
                    MainMenu();
                }
                Console.WriteLine( "Input the money you wanna transfer:" );
                string input2 = Console.ReadLine();
                bool result = int.TryParse( input2 , out MoneyCount );
                if ( result )
                {
                    Console.WriteLine( "Processing..." );
                    CurrentUser.balance -= MoneyCount;
                    ToUser.balance += MoneyCount;
                    Thread.Sleep( 1000 );
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
            Console.WriteLine();
            Thread.Sleep( 50 );
            Console.WriteLine();
            Thread.Sleep( 50 );
            Console.WriteLine();
            Thread.Sleep( 50 );
            MainMenu();
        }
        static void LogOut()
        {
            Console.WriteLine( "Thank you for using!" );
            Thread.Sleep( 500 );
            Console.Write( "Wiping user data..." );
            Thread.Sleep( 1000 );
            Console.WriteLine( "done!" );
            Thread.Sleep( 50 );
            Console.WriteLine();
            Thread.Sleep( 50 );
            Console.WriteLine();
            Thread.Sleep( 50 );
            Console.WriteLine();
            Thread.Sleep( 50 );
            Console.WriteLine();
            Thread.Sleep( 50 );
            Console.WriteLine();
            Thread.Sleep( 50 );
            ATMain();
        }
        static void n_balance()
        {
            Console.WriteLine( "Your account balance is {0}" , CurrentUser.balance );
        }
        static void alarm()
        {
            if ( CurrentUser.balance < 0 )
                Console.WriteLine( "Your account balance is lower than 0!!!please return it later." );
        }
        static void sync()
        {
            lstAccount[ CurrentUserID ] = CurrentUser;
            lstAccount[ ToUserID ] = ToUser;
        }
    }
}
