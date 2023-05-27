using BillsPaymentSystem.Datas.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillsPaymentSystem.Data.Config.EntityConfiguration
{
    public class CreditCardConfig : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            builder.HasKey(e => e.CreditCardId);

            builder.Ignore(e => e.LimitLeft);
            //Цей метод зазвичай використовується для видалення типів із моделі, доданих за угодою.
            //ігнорувати властивість LimitLeft під час зіставлення сутності з базою даних.
            //Це означає, що властивість LimitLeft не буде включено в згенеровані оператори
            //SQL для створення або оновлення таблиці.
        }
    }
}
