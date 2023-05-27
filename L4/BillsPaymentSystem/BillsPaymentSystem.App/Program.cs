using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BillsPaymentSystem.Data;
using BillsPaymentSystem.Data.Config;
using BillsPaymentSystem.Datas.Models;
using Microsoft.EntityFrameworkCore;

namespace BillsPaymentSystem.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new BillsPaymentSystemContext())
            {
                //context.Database.EnsureDeleted();
                ///Метод EnsureDeleted() використовується для того,
                ///щоб забезпечити видалення базової бази даних для контексту. Зазвичай він
                ///використовується, коли ви хочете почати з чистого аркуша та видалити всі
                ///існуючі таблиці та дані з бази даних.

                //context.Database.Migrate()
                ///Метод context.Database.Migrate() використовується для застосування будь-яких 
                ///незавершених міграцій до бази даних. 
                ///Він перевіряє, чи є міграції, які ще не застосовано,
                ///і застосовує їх до бази даних.

                //var seeder = new DbSeeder();
                //seeder.Seed(context);
                ///заповнення бази даних початковими даними

                PrintUserDetails(context, 1);
                //PayBills(1, 0.1M, context);
            }
        }
          private static void PayBills(int userId, decimal sum, BillsPaymentSystemContext context)
        {
          //  проектує кожного користувача в новий анонімний об’єкт.
            var user = context.Users
                .Select(u => new
                {

                    u.UserId,
                    BankAccounts = u.PaymentMethods
                        .Where(pm => pm.Type == PaymentType.BankAccount)
                        .Select(pm => pm.BankAccount)//проектує кожен спосіб оплати на відповідний банківський рахунок.
                        .ToArray(),
                    CreditCards = u.PaymentMethods
                        .Where(pm => pm.Type == PaymentType.CreditCard)
                        .Select(pm => pm.CreditCard)
                        .ToArray()
                })
                .FirstOrDefault(u => u.UserId == userId);
            //Отримує першого користувача, який відповідає вказаному userId.
            //Якщо користувач не знайдено, результатом буде null.

            //якщо користувача з таким id не існує то:
            if (user == null)
            {
                Console.WriteLine($"User with id {userId} does not exists");
                return;
            }
            //якщо користувач не може дозволити собі певну суму платежу
            //на основі своїх банківських рахунків і кредитних карток.
            if (!CanPay(user.BankAccounts, user.CreditCards, sum))
            {
                Console.WriteLine("User cannot afford this payment");
                return;
            }
            //зняття грошей з банківского рахунку
            sum = PayWithBankAsMuchAsPossuble(user.BankAccounts, sum, context);
            if (sum > 0)
            {
                //зняття грошей з кредитної карти
                PayWithCreditCards(sum, user.CreditCards, context);
            }

            context.SaveChanges();
            Console.WriteLine("Bills are successfully payed. Have a nice day. :)");
        }
        private static bool CanPay(BankAccount[] bankAccounts, CreditCard[] creditCards, decimal sum)
        {
            decimal totalFunds = 0;

            foreach (var account in bankAccounts)
            {
                Console.WriteLine(account);
                totalFunds += account.Balance;
            }

            foreach (var card in creditCards)
            {
                totalFunds += card.LimitLeft;
            }

            return sum <= totalFunds;
        }

        private static decimal PayWithBankAsMuchAsPossuble(BankAccount[] bankAccounts, decimal amount, BillsPaymentSystemContext context)
        {
            foreach (var account in bankAccounts)
            {
                
               
                /// Завдяки рядку context.Entry(account).State = EntityState.Unchanged; ми позначаємо об'єкт account як незмінений в контексті бази даних. Це дозволяє нам оновлювати лише потрібні властивості об'єкта, а не всі властивості.
                context.Entry(account).State = EntityState.Unchanged;
                //перевірка чи залишок на рахунку достатній для зняття суми
                if (account.Balance >= amount)
                {
                    account.Withdraw(amount);
                    amount = 0;
                    break;
                }
                //Якщо залишок на рахунку менший за суму amount, то здійснюється операція зняття грошей,
                //рівна залишку на рахунку (account.Balance), і змінна amount зменшується на цю суму.
                amount -= account.Balance;
                account.Withdraw(account.Balance);
            }

            return amount;
        }
        private static void PayWithCreditCards(decimal amount, CreditCard[] creditCards, BillsPaymentSystemContext context)
        {
            //Це перевіряє, чи сума amount не перевищує ліміт
            //доступних коштів на кредитних картках користувача.
            if (creditCards.Select(cc => cc.LimitLeft).Sum() < amount)
            {
                throw new ArgumentException("Amount is greater than the cards possibilities");
            }

            foreach (var card in creditCards)
            {
                 context.Entry(card).State = EntityState.Unchanged;

                if (card.LimitLeft >= amount)
                {
                    card.Withdraw(amount);
                    return;
                }

                amount -= card.LimitLeft;
                card.Withdraw(card.LimitLeft);
            }
        }

        private static void PrintUserDetails(BillsPaymentSystemContext context, int userId)
        {
            var user = context.Users
                .Where(u => u.UserId == userId)
                .Select(u => new
                {
                    Name = $"{u.FirstName} {u.LastName}",
                    BankAccounts = u.PaymentMethods
                        .Where(pm => pm.Type == PaymentType.BankAccount)
                        .Select(pm => pm.BankAccount)
                        .ToArray(),
                    CreditCards = u.PaymentMethods
                        .Where(pm => pm.Type == PaymentType.CreditCard)
                        .Select(pm => pm.CreditCard)
                        .ToArray()
                })
                .FirstOrDefault();

            if (user == null)
            {
                Console.WriteLine($"User with id {userId} not found!");
                return;
            }

            var sb = new StringBuilder();
            sb.AppendLine(user.Name)
                .AppendLine("Bank Accounts:");
            AppentBankAccountsDetails(sb, user.BankAccounts);
            sb.AppendLine("Credit Cards:");
            AppendCreditCardsDetails(sb, user.CreditCards);

            Console.WriteLine(sb.ToString().TrimEnd());
        }
        private static void AppendCreditCardsDetails(StringBuilder sb, IEnumerable<CreditCard> creditCards)
        {
            foreach (var card in creditCards)
            {
                sb.AppendLine($"-- ID: {card.CreditCardId}")
                    .AppendLine($"--- Limit: {card.Limit:F2}")
                    .AppendLine($"--- Money Owed: {card.MoneyOwed:F2}")
                    .AppendLine($"--- Limit Left:: {card.LimitLeft}")
                    .AppendLine($"--- Expiration Date: {card.ExpirationDate.ToString("yyyy/MM")}");
            }
        }
        private static void AppentBankAccountsDetails(StringBuilder sb, IEnumerable<BankAccount> bankAccounts)
        {
            foreach (var account in bankAccounts)
            {
                sb.AppendLine($"-- ID: {account.BankAccountId}")
                    .AppendLine($"--- Balance: {account.Balance:F2}")
                    .AppendLine($"--- Bank: {account.BankName}")
                    .AppendLine($"--- SWIFT: {account.SWIFT}");
            }
        }

       
    }
}
