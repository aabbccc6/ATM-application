﻿using System;
using System.Threading;
using ATM_account;

namespace Normal
{
    class ATM
    {
        static void Main( string[] args )
        {
            AccountInit();
            ATMain();
        }
        static void AccountInit()
        {
            Account a1 = new Account( "aabbccc6" , "123" , 500 );
            Account.lstAccount.Add( a1 );

            Account a2 = new Account( "aabbccc7" , "111" , 200 );
            Account.lstAccount.Add( a2 );
        }
        static void ATMain()
        {
            Console.WriteLine( "Welcome to ATM System Alpha Build v0.20" );
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
            if ( Account.Authorize( username , password ) )
            {
                MainMenu();
            }
            else
            {
                ATMain();
            }
        }
        static void SignUp()
        {
            Console.WriteLine( "Please input your new account." );
            string S_UserName = Console.ReadLine();
            if ( Account.GetAccount( S_UserName ) == null )
            {
                Console.WriteLine( "Please input your password." );
                string S_Password = Console.ReadLine();
                Account a = new Account( S_UserName , S_Password , 0 );
                Console.WriteLine( "Please wait..." );
                Account.lstAccount.Add( a );
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
            N_Balance();
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
            Console.WriteLine( "How much do you want to deposit(can't deposit 10k at once)?" );
            string input = Console.ReadLine();
            int plus = 0;
            bool result = int.TryParse( input , out plus );
            if ( result )
            {
                result = Account.CurrentUser.Save( plus );
                if ( result )
                {
                    Console.WriteLine( "Please put the cash in the cash box" );
                    Console.WriteLine( "Please wait,validating bill" );
                    Console.WriteLine( "success, now returning..." );
                }
                else
                {
                    Console.WriteLine( "Incorrect input!" );
                    Deposit();
                }
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
                        result = Account.CurrentUser.Draw( 100 );
                        if ( result )
                        {
                            Withdraw();
                        }
                        else
                        {
                            Console.WriteLine( "Insufficient balance!" );
                            MainMenu();
                        }
                        break;
                    case 2:
                        result = Account.CurrentUser.Draw( 300 );
                        if ( result )
                        {
                            Withdraw();
                        }
                        else
                        {
                            Console.WriteLine( "Insufficient balance!" );
                            MainMenu();
                        }
                        break;
                    case 3:
                        result = Account.CurrentUser.Draw( 500 );
                        if ( result )
                        {
                            Withdraw();
                        }
                        else
                        {
                            Console.WriteLine( "Insufficient balance!" );
                            MainMenu();
                        }
                        break;
                    case 4:
                        result = Account.CurrentUser.Draw( 800 );
                        if ( result )
                        {
                            Withdraw();
                        }
                        else
                        {
                            Console.WriteLine( "Insufficient balance!" );
                            MainMenu();
                        }
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
            Account toUser = Account.GetAccount( input );
            if ( toUser != null )
            {
                if ( toUser.username == Account.CurrentUser.username )
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
                    result = Account.CurrentUser.Trans( toUser , MoneyCount );
                    if ( result )
                    {
                        Console.WriteLine( "Processing..." );
                        Console.WriteLine( "Success, now returning..." );
                    }
                    else
                    {
                        Console.WriteLine( "Incorrect input!" );
                        goto incorrect;
                    }
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
            Console.WriteLine( "Your account balance is {0}" , Account.CurrentUser.Balance );
        }
    }
}