using System;
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
            Console.WriteLine( "Welcome to ATM System Alpha Build v0.19" );
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
                else if ( plus > 10000 )
                {
                    Console.WriteLine( "Can't deposit more than 10k at once!" );
                    Deposit();
                }
                Console.WriteLine( "Please put the cash in the cash box" );
                Console.WriteLine( "Please wait,validating bill" );
                Account.CurrentUser.Deposit( plus );
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
                        if ( 100 > Account.CurrentUser.Balance )
                        {
                            Console.WriteLine( "Insufficient balance!" );
                            MainMenu();
                        }
                        Account.CurrentUser.Withdraw( 100 );
                        Withdraw();
                        break;
                    case 2:
                        if ( 300 > Account.CurrentUser.Balance )
                        {
                            Console.WriteLine( "Insufficient balance!" );
                            MainMenu();
                        }
                        Account.CurrentUser.Withdraw( 300 );
                        Withdraw();
                        break;
                    case 3:
                        if ( 500 > Account.CurrentUser.Balance )
                        {
                            Console.WriteLine( "Insufficient balance!" );
                            MainMenu();
                        }
                        Account.CurrentUser.Withdraw( 500 );
                        Withdraw();
                        break;
                    case 4:
                        if ( 800 > Account.CurrentUser.Balance )
                        {
                            Console.WriteLine( "Insufficient balance!" );
                            MainMenu();
                        }
                        Account.CurrentUser.Withdraw( 800 );
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
                    if ( MoneyCount <= 0 )
                    {
                        Console.WriteLine( "Incorrect input!" );
                        goto incorrect;
                    }
                    else if ( MoneyCount > Account.CurrentUser.Balance )
                    {
                        Console.WriteLine( "Insufficient balance!" );
                        MainMenu();
                    }
                    Console.WriteLine( "Processing..." );
                    Account.CurrentUser.Withdraw( MoneyCount );
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
            Console.WriteLine( "Your account balance is {0}" , Account.CurrentUser.Balance );
        }
    }
}