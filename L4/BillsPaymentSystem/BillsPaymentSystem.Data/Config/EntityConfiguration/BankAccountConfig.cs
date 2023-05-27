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
    public class BankAccountConfig : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.HasKey(e => e.BankAccountId);

            builder.Property(e => e.BankName)
                .HasMaxLength(50)
                .IsRequired(true);

            builder.Property(e => e.SWIFT)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsRequired(true);
        }
    }
}
