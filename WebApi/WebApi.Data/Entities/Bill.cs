using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Data.Entities
{
    [Table("Bill", Schema = "dbo")]
    public class Bill // Fatura
    {
        public int BillID { get; set; }
        public int ApartmentID { get; set; }
        public string BillType { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public decimal Amount { get; set; }


        public virtual Apartment Apartments { get; set; }
    }

    public class BillConfiguration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            
            builder.HasKey(x => x.BillID);
            builder.Property(x => x.BillID).IsRequired().UseIdentityColumn();

            
            builder.Property(x => x.BillType).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Month).IsRequired();
            builder.Property(x => x.Year).IsRequired();
            builder.Property(x => x.Amount).IsRequired().HasPrecision(5, 2);

            
            builder.HasOne(x => x.Apartments)       
                   .WithMany(a => a.Bills)         
                   .HasForeignKey(x => x.ApartmentID);
        }
    }


}
