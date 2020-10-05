using System;
using System.Collections.Generic;
using System.Text;

namespace Banking2 {

    class Account {

        private int NextID = 1;

        public int Id { get; private set; }
        public double Balance { get; private set; } = 0;
        public string Description { get; set; }

        public static bool Transfer(double amount, Account FromAccount, Account toAccount) {
            if (amount <=0)
            {

            }
        
                    
                    
                    }


            //------------
        public static bool Transfer(double amount, Account FromAccount, Account ToAccount) {
            if (amount <= 0)
            {
                return false;
            }
            if (FromAccount == null || ToAccount == null)
            {
                return false;
            }
            var BeforeBalance = FromAccount.Balance;
            var AfterBalance = FromAccount.Withdraw(amount);
            if (BeforeBalance != AfterBalance + amount)
            {
                return false;
            }
            ToAccount.Deposit(amount);
            return true;
        }
        //------

    }
}
