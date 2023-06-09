﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillsPaymentSystem.Datas.Models
{
    public class PaymentMethod
    {
        public PaymentMethod()
        {
        }

        public PaymentMethod(User user, BankAccount bankAccount)
        {
            this.User = user;
            this.BankAccount = bankAccount;
            this.Type = PaymentType.BankAccount;
        }

        public PaymentMethod(User user, CreditCard creditCard)
        {
            this.User = user;
            this.CreditCard = creditCard;
            this.Type = PaymentType.CreditCard;
        }

        public int Id { get; set; }

        public PaymentType Type { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int? BankAccountId { get; set; }
        public BankAccount BankAccount { get; set; }

        public int? CreditCardId { get; set; }
        public CreditCard CreditCard { get; set; }
    }
}
