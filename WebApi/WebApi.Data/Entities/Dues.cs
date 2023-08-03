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
    [Table("Dues", Schema = "dbo")]
    public class Dues //aidat
    {
        public int DuestID { get; set; }
        public int ApartmentID { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public decimal Amount { get; set; }



        public virtual Apartment Apartment { get; set; }
    }

    public class DuesConfiguration : IEntityTypeConfiguration<Dues>
    {
        public void Configure(EntityTypeBuilder<Dues> builder)
        {
            // Primary key 
            builder.HasKey(x => x.DuestID);

            builder.Property(x => x.DuestID).IsRequired().UseIdentityColumn();

            
            builder.Property(x => x.Month).IsRequired();
            builder.Property(x => x.Year).IsRequired();
            builder.Property(x => x.Amount).IsRequired().HasPrecision(5, 2); ;

            
            builder.HasOne(x => x.Apartment)         
                   .WithMany(a => a.Dueses)        
                   .HasForeignKey(x => x.ApartmentID); 
        }
    }
}
