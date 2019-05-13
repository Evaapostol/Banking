using System;

namespace Banking_ex1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            var newStoreAccount = new StoreAccount("Eva");      
            var newOne = new Account("Eva");                    
            newOne.Deposit(550);                                
            Withdraw(100, newOne);                              
            Withdraw(100, newOne);
            Withdraw(50, newOne);
            Withdraw(-300, newOne);
            bool z = newStoreAccount.ChangeCategory(AccountCategoryId.Lead);
            
            if (z == true)
            {
                Console.WriteLine("Accepted!");
            }                                                   
            else
            {
                Console.WriteLine("Not Accepted!");
            }

        }
        public static void Withdraw(decimal amount, Account account)            
        {                                                               
            var ans = account.Withdraw(amount);                         
            HandleTransactionResult(account, ans);                      
        }
        public static void Deposit(decimal amount, Account account)
        {
            var ans = account.Deposit(amount);                          
            HandleTransactionResult(account, ans);
        }

        public static void HandleTransactionResult(Account account, bool transactionResult)     
        {
            if (transactionResult)
            {
                Console.WriteLine($"Available balance, {account.balance}, Total Transactions, {account.numberOfTransations}");
            }
            else
            {
                Console.WriteLine("Transaction can not be completed");
            }

        }




    }

    class Account
    {
        public string CustomerName { get; private set; }
        public decimal balance { get; private set; }
        public int numberOfTransations { get; private set; }

        public Account(string customerName)
        {
            CustomerName = customerName;
        }

        public bool Deposit(decimal amount)
        {
            if (amount < 1 || amount >= 5000)
            {
                return false;
            }
            balance += amount;
            numberOfTransations++;
            return true;
        }

        public bool Withdraw(decimal amount)
        {
            if (amount <= 5000)
            {
                if (balance > amount && amount > 1)
                {
                    balance -= amount;
                    numberOfTransations++;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }

    class StoreAccount : Account
    {
        public string StoreName { get; set; }
        public AccountCategoryId AccountCategory { get; set; }      

        public StoreAccount(string owner) : base(owner)
        {
            AccountCategory = AccountCategoryId.Basic;
        }

        public bool ChangeCategory(AccountCategoryId AccountCategory)
        {
            if (AccountCategory == AccountCategoryId.Basic)
            {
                if (balance <= 1000)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (AccountCategory == AccountCategoryId.Mid)
            {
                if (balance <= 5000)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (AccountCategory == AccountCategoryId.Senior)
            {
                if (balance <= 10000)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (AccountCategory == AccountCategoryId.Senior)
            {
                if (balance <= 10000)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
