using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillsPaymentSystem.Datas.Models
{
    public class BankAccount
    {
   
        public BankAccount()
        {
        }

        public BankAccount(decimal balance, string bankName, string swift)
        {
            this.Balance = balance;
            this.BankName = bankName;
            this.SWIFT = swift;
        }

        public int BankAccountId { get; set; }

        public decimal Balance { get; set; }

        public string BankName { get; set; }

        public string SWIFT { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public void Withdraw(decimal amount)
        {
            if (amount > this.Balance)
            {
                throw new ArgumentException("Insufficient funds!!!");
            }

            if (amount < 0)
            {
                throw new ArgumentException("Cannot withdraw Negative amount!!!");
            }

            this.Balance -= amount;
        }

        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Cannot deposit Negative amount!!!");
            }

            this.Balance += amount;
        }
    }
}