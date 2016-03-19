using System;
using System.Threading;

namespace Normal
{
    class ATM
    {
        static string username;
        static string password;
        static string new_user;
        static string new_password;
        static int balance = 0;
        static int add( int a , int b )
        {
            int c = a + b;
            return c;
        }
        static int nagative( int a , int b )
        {
            int c = a - b;
            return c;
        }
        static void Main( string[] args )
        {
            ATMain();
        }
        static void ATMain()
        {
            Console.WriteLine( "Welcome to ATM System Alpha Build v0.02" );
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
            Thread.Sleep( 1000 );
            if ( username == new_user && password == new_password )
            {
                Console.WriteLine( "Authorize confirmed! welcome back, user." );
                Thread.Sleep( 50 );
                Console.WriteLine();
                Thread.Sleep( 50 );
                Console.WriteLine();
                Thread.Sleep( 50 );
                Console.WriteLine();
                MainMenu();
            }
            else
            {
                Console.WriteLine( "invalid account or password." );
                Console.WriteLine();
                Thread.Sleep( 50 );
                Console.WriteLine();
                Thread.Sleep( 50 );
                Console.WriteLine();
                Thread.Sleep( 50 );
                ATMain();
            }
        }
        static void SignUp()
        {
            Console.WriteLine( "Enter your new account" );
            new_user = Console.ReadLine();
            Console.WriteLine( "Enter your new password" );
            new_password = Console.ReadLine();
            Console.WriteLine( "Signing up..." );
            balance = 0;
            Thread.Sleep( 1000 );
            Console.WriteLine( "Complete, now return to main menu..." );
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
        static void MainMenu()
        {
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
                balance = add( plus , balance );
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
                        balance = nagative( balance , 100 );
                        Withdraw();
                        break;
                    case 2:
                        balance = nagative( balance , 300 );
                        Withdraw();
                        break;
                    case 3:
                        balance = nagative( balance , 500 );
                        Withdraw();
                        break;
                    case 4:
                        balance = nagative( balance , 800 );
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
            Console.ReadLine();
            Console.WriteLine( "Input the money you wanna transfer:" );
            Console.ReadLine();
            Console.WriteLine( "Processing..." );
            Thread.Sleep( 2000 );
            Console.WriteLine( "Success, now returning..." );
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
            Console.WriteLine( "Your account balance is {0}" , balance );
        }
        static void alarm()
        {
            if ( balance < 0 )
                Console.WriteLine( "Your account balance is lower than 0!!!please return it later." );
        }
    }
}
