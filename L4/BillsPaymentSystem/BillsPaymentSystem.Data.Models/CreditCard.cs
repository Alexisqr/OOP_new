using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillsPaymentSystem.Datas.Models
{
    public class CreditCard
    {
        

        public CreditCard()
        {
        }

        public CreditCard(decimal limit, decimal moneyOwed, DateTime expirationDate)
        {
            this.Limit = limit;
            this.MoneyOwed = moneyOwed;
            this.ExpirationDate = expirationDate;
        }

        public int CreditCardId { get; set; }

        public decimal Limit { get;  set; }

        public decimal MoneyOwed { get; set; }

        public decimal LimitLeft => this.Limit - this.MoneyOwed;

        public DateTime ExpirationDate { get; set; }

        public PaymentMethod PaymentMethod { get; private set; }

        public void Withdraw(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Cannot withdraw Negative amount!!!");
            }

            if (this.LimitLeft < amount)
            {
                throw new ArgumentException("Insufficient limit! Please contact us for a new contract which will be more suitable for for you. :) ");
            }

            this.MoneyOwed += amount;
        }

        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Cannot deposit Negative amount!!!");
            }

            if (this.MoneyOwed < amount)
            {
                throw new ArgumentException(string.Format("The deposit is bigger than the owed sum ({0:C2})!!!", this.MoneyOwed));
            }

            this.MoneyOwed -= amount;
        }
    }
}
