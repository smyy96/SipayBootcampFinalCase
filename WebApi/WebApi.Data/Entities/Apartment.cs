using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Data.Entities
{
    [Table("Apartment", Schema = "dbo")]
    public class Apartment
    {
        public int ApartmentID { get; set; }
        public string Block { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public int Floor { get; set; }
        public string ApartmentNumber { get; set; }
        public int? ResidentId { get; set; }

        public virtual Resident Resident { get; set; }

        public virtual ICollection<Dues> Dueses { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
    }


    public class ApartmentConfiguration : IEntityTypeConfiguration<Apartment>
    {
        public void Configure(EntityTypeBuilder<Apartment> builder)
        {
            builder.HasKey(x => x.ApartmentID);
            builder.Property(x => x.ApartmentID).IsRequired(true).UseIdentityColumn();
            builder.Property(x => x.Block).IsRequired().HasMaxLength(10);
            builder.Property(x => x.Status).IsRequired().HasMaxLength(10);
            builder.Property(x => x.Type).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Floor).IsRequired();
            builder.Property(x => x.ApartmentNumber).IsRequired().HasMaxLength(10);

            builder.HasIndex(x => x.ApartmentNumber).IsUnique();

            builder.HasMany(x => x.Dueses)         
              .WithOne(p => p.Apartment)        
              .HasForeignKey(p => p.ApartmentID); 

            builder.HasMany(x => x.Bills)            
                   .WithOne(b => b.Apartments)        
                   .HasForeignKey(b => b.ApartmentID);


        }

    }

}
