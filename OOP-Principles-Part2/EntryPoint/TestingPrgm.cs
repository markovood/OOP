namespace EntryPoint
{
    using System;
    using BankAccounts;
    using BankAccounts.Accounts;
    using BankAccounts.Customers;
    using CustomExeptions;
    using Shapes;

    public class TestingPrgm
    {
        private static int problemNum = 1;

        public static void Main()
        {
            TaskSeparator();

            #region Task 1

            var triangle = new Triangle(2.2, 3);
            var rectangle = new Rectangle(4, 6);
            var square = new Square(5);

            Shape[] shapes =
            {
                triangle,
                rectangle,
                square
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine(shape.CalculateSurface());
            }

            #endregion

            TaskSeparator();

            #region Task 2

            var bankOfCyprus = new Bank("Bank of Cyprus");

            // polymorphism
            Customer[] customers =
            {
                new Individual("Pesho Mustakov", "0893399339"),
                new Company("ACME", "070070077")
            };

            Account[] accounts =
            {
                new DepositAccount(customers[0], 10000m, 2.5, 12),
                new DepositAccount(customers[1], 150000m, 3.5, 60),
                new LoanAccount(customers[0], 15000m, 4.7, 60),
                new LoanAccount(customers[1], 300000m, 4, 120),
                new MortgageAccount(customers[0], 25000m, 3.2, 60),
                new MortgageAccount(customers[1], 500000m, 3.5, 120)
            };

            bankOfCyprus.AddRangeOfCustomers(customers);
            bankOfCyprus.AddRangeOfAccount(accounts);

            Console.WriteLine("Pesho transaction history:");

            #region pesho deposits 995.95 to his deposit account

            var peshoDepositAcc = FindAccount(bankOfCyprus, "Pesho Mustakov", AccountTypes.DepositAccount);

            PrintLastBalance(peshoDepositAcc.Balance);
            peshoDepositAcc.Deposit(995.95m);
            PrintNewBalance(peshoDepositAcc.Balance);

            #endregion

            // IMPORTANT: because of the polymorphism we have lost the full functionality of the DepositAccount i.e. the withdraw
            // method that's why we have to check explicitly if peshoDepositAccount variable is actually from DepositAccount
            // type, cause it shows like a general Account Type since it is part of the Accounts[] array

            #region pesho withdraws 10101.45 from his deposit account

            if (peshoDepositAcc is DepositAccount)
            {
                var peshoWithdrawableAccount = peshoDepositAcc as DepositAccount;

                PrintLastBalance(peshoDepositAcc.Balance);
                peshoWithdrawableAccount.Withdraw(10101.45m);
                PrintNewBalance(peshoDepositAcc.Balance);
            }
            else
            {
                throw new ApplicationException("This account type doesn't support withdrawing...".ToUpper());
            }

            #endregion

            // for the period that pesho has deposited his money, he will get interest amount of:
            decimal peshoMoneyFromInterest = peshoDepositAcc.CalculateInterestAmount(peshoDepositAcc.PeriodInMonths);
            Console.WriteLine("Pesho will generate {0:F2} from interest", peshoMoneyFromInterest);

            VisualSeparator();

            Console.WriteLine("ACME transaction history:");

            #region ACME deposits to its deposit account the turnover of 100 000

            var acmeDepositAcc = FindAccount(bankOfCyprus, "ACME", AccountTypes.DepositAccount);

            PrintLastBalance(acmeDepositAcc.Balance);
            acmeDepositAcc.Deposit(100000m);
            PrintNewBalance(acmeDepositAcc.Balance);

            #endregion

            #region ACME withdraws 10 500.50 from its deposit account

            if (acmeDepositAcc is DepositAccount)
            {
                var acmeWithdrawableAcc = acmeDepositAcc as DepositAccount;

                PrintLastBalance(acmeDepositAcc.Balance);
                acmeWithdrawableAcc.Withdraw(10500.50m);
                PrintNewBalance(acmeDepositAcc.Balance);
            }
            else
            {
                throw new ApplicationException("This account type doesn't support withdrawing...".ToUpper());
            }

            #endregion

            decimal acmeMoneyFromInterest = acmeDepositAcc.CalculateInterestAmount(acmeDepositAcc.PeriodInMonths);
            Console.WriteLine("ACME will generate {0:F2} from interest", acmeMoneyFromInterest);

            VisualSeparator();

            #region Pesho had taken 15 000 loan and have to return it for 5 years, so now he has to deposit money for his loan

            var peshoLoanAccount = FindAccount(bankOfCyprus, "Pesho Mustakov", AccountTypes.LoanAccount);

            // IMPORTANT: because of the polymorphism we have lost the full functionality of the LoanAccount i.e. the returnAmount
            // property that's why we have to check explicitly if peshoLoanAccount variable is actually from LoanAccount type,
            // cause it shows like a general Account Type since it is part of the Accounts[] array

            if (peshoLoanAccount is LoanAccount)
            {
                var _peshoLoanAccount = peshoLoanAccount as LoanAccount;

                PrintReturnAmount(_peshoLoanAccount);
                _peshoLoanAccount.Deposit(500m);
                // deposit is virtual method from the Account class and it's inherited by all its children
                _peshoLoanAccount.MakePayment();
                PrintReturnAmount(_peshoLoanAccount);
                Console.WriteLine("Balance: {0:F2}", _peshoLoanAccount.Balance);

                decimal peshoLoanInterest = _peshoLoanAccount.CalculateInterestAmount(_peshoLoanAccount.PeriodInMonths);
                Console.WriteLine("{0} will have to pay {1:F2} interest", _peshoLoanAccount.Customer.Name,
                    peshoLoanInterest);
            }
            else
            {
                throw new ApplicationException(
                    "This type of account doesn't support the LoanAccount type functionality!!!".ToUpper());
            }

            #endregion

            VisualSeparator();

            #region ACME had taken 300 000 loan, now it has to make a payment

            var acmeLoanAccount = FindAccount(bankOfCyprus, "ACME", AccountTypes.LoanAccount);

            if (acmeLoanAccount is LoanAccount)
            {
                var _acmeLoanAccount = acmeLoanAccount as LoanAccount;

                PrintReturnAmount(_acmeLoanAccount);
                _acmeLoanAccount.Deposit(12000m);
                _acmeLoanAccount.MakePayment();
                _acmeLoanAccount.MakePayment();
                _acmeLoanAccount.MakePayment();
                PrintReturnAmount(_acmeLoanAccount);
                Console.WriteLine("Balance: {0:F2}", _acmeLoanAccount.Balance);

                decimal acmeLoanInterest = _acmeLoanAccount.CalculateInterestAmount(_acmeLoanAccount.PeriodInMonths);
                Console.WriteLine("{0} will have to pay {1:F2} interest", _acmeLoanAccount.Customer.Name,
                    acmeLoanInterest);
            }
            else
            {
                throw new ApplicationException(
                    "This type of account doesn't support the LoanAccount type functionality!!!".ToUpper());
            }

            #endregion

            VisualSeparator();

            #region Pesho has gotten 25 000 for a mortgage, now he has to make a mortgage payment

            var peshoMortgageAccount = FindAccount(bankOfCyprus, "Pesho Mustakov", AccountTypes.MortgageAccount);

            // IMPORTANT: because of the polymorphism we have lost the full functionality of the MortgageAccount i.e. the returnAmount
            // property that's why we have to check explicitly if peshoMortgageAccount variable is actually from
            // MortgageAccount type, cause it shows like a general Account Type since it is part of the Accounts[] array

            if (peshoMortgageAccount is MortgageAccount)
            {
                var _peshoMortgageAccount = peshoMortgageAccount as MortgageAccount;

                PrintReturnAmount(_peshoMortgageAccount);
                _peshoMortgageAccount.Deposit(1000m);
                _peshoMortgageAccount.MakePayment();
                _peshoMortgageAccount.MakePayment();
                PrintReturnAmount(_peshoMortgageAccount);
                Console.WriteLine("Balance: {0:F2}", _peshoMortgageAccount.Balance);

                decimal peshoMortgageInterest =
                    _peshoMortgageAccount.CalculateInterestAmount(_peshoMortgageAccount.PeriodInMonths);
                Console.WriteLine("{0} will have to pay {1:F2} interest", _peshoMortgageAccount.Customer.Name,
                    peshoMortgageInterest);
            }
            else
            {
                throw new ApplicationException(
                    "This type of account doesn't support the LoanAccount type functionality!!!".ToUpper());
            }

            #endregion

            VisualSeparator();

            #region ACME has gotten 500 000 for a mortgage, now it has to make a mortgage payment

            var acmeMortgageAccount = FindAccount(bankOfCyprus, "ACME", AccountTypes.MortgageAccount);

            if (acmeMortgageAccount is MortgageAccount)
            {
                var _acmeMortgageAccount = acmeMortgageAccount as MortgageAccount;

                PrintReturnAmount(_acmeMortgageAccount);
                _acmeMortgageAccount.Deposit(30000);
                _acmeMortgageAccount.MakePayment();
                _acmeMortgageAccount.MakePayment();
                _acmeMortgageAccount.MakePayment();
                _acmeMortgageAccount.MakePayment();
                _acmeMortgageAccount.MakePayment();
                PrintReturnAmount(_acmeMortgageAccount);
                Console.WriteLine("Balance: {0:F2}", _acmeMortgageAccount.Balance);

                decimal acmeMortgageInterest =
                    _acmeMortgageAccount.CalculateInterestAmount(_acmeMortgageAccount.PeriodInMonths);
                Console.WriteLine("{0} will have to pay {1:F2} interest", _acmeMortgageAccount.Customer.Name,
                    acmeMortgageInterest);
            }
            else
            {
                throw new ApplicationException(
                    "This type of account doesn't support the LoanAccount type functionality!!!");
            }

            #endregion

            #endregion

            TaskSeparator();

            #region Task 3

            try
            {
                Console.WriteLine("Please enter a number in the range [1 ... 100]");
                int someNumber = int.Parse(Console.ReadLine());
                ValidateInputTask3(someNumber);
                Console.WriteLine("Bravo!");
            }
            catch (InvalidRangeException<int> ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("The range must be [{0} ... {1}]", ex.MinValue, ex.MaxValue);
            }

            VisualSeparator();

            try
            {
                Console.WriteLine("Please enter a date in the range [1.1.1980 ... 31.12.2013]");
                DateTime someDate = DateTime.Parse(Console.ReadLine());
                ValidateInputTask3(someDate);
                Console.WriteLine("Bravo!");
            }
            catch (InvalidRangeException<DateTime> ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("The range must be [{0}/{1}/{2} ... {3}/{4}/{5}]"
                    , ex.MinValue.Day, ex.MinValue.Month, ex.MinValue.Year
                    , ex.MaxValue.Day, ex.MaxValue.Month, ex.MaxValue.Year);
            }

            #endregion
        }

        private static void ValidateInputTask3(int someNumber)
        {
            const int MIN_VALUE = 1;
            const int MAX_VALUE = 100;

            if (someNumber < MIN_VALUE || someNumber > MAX_VALUE)
            {
                throw new InvalidRangeException<int>(MIN_VALUE, MAX_VALUE);
                // throw new InvalidRangeException<int>("TEST_MSG", MIN_VALUE, MAX_VALUE);
            }
        }

        private static void ValidateInputTask3(DateTime someDate)
        {
            DateTime MIN_VALUE = new DateTime(1980, 1, 1);
            DateTime MAX_VALUE = new DateTime(2013, 12, 31);

            if (someDate < MIN_VALUE || someDate > MAX_VALUE)
            {
                // throw new InvalidRangeException<DateTime>(MIN_VALUE, MAX_VALUE);
                throw new InvalidRangeException<DateTime>("TEST_MSG", MIN_VALUE, MAX_VALUE);
            }
        }

        private static void TaskSeparator()
        {
            if (problemNum == 1)
            {
                Console.WriteLine(new string('-', 8));
                Console.WriteLine("-Task {0}-", problemNum);
                Console.WriteLine(new string('-', 8));
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine(new string('-', 8));
                Console.WriteLine("-Task {0}-", problemNum);
                Console.WriteLine(new string('-', 8));
                Console.WriteLine();
            }

            problemNum++;
        }

        private static void VisualSeparator()
        {
            Console.WriteLine();
            Console.WriteLine(new string('*', 50));
            Console.WriteLine();
        }

        private static void PrintLastBalance(decimal accountBalance)
        {
            Console.WriteLine("Last balance: {0}", accountBalance);
        }

        private static void PrintNewBalance(decimal accountBalance)
        {
            Console.WriteLine("New balance: {0}", accountBalance);
        }

        private static void PrintReturnAmount(LoanAccount account)
        {
            Console.WriteLine("{0} owes {1:F2} with interest included!",
                                account.Customer.Name,
                                account.ReturnAmount
                             );
        }

        private static void PrintReturnAmount(MortgageAccount account)
        {
            Console.WriteLine("{0} owes {1:F2} with interest included!",
                                account.Customer.Name,
                                account.ReturnAmount
                             );
        }

        private static Account FindAccount(Bank bank, string name, AccountTypes accountType)
        {
            return bank.Accounts.Find(
                account => account.Customer.Name == name && account.GetType().Name == accountType.ToString());
        }
    }

    public enum AccountTypes
    {
        DepositAccount,
        LoanAccount,
        MortgageAccount
    }
}