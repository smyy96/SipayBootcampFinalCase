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
    [Table("Resident", Schema = "dbo")]
    public class Resident
    {
        public int ResidentId { get; set; }
        public string FullName { get; set; }
        public string TCNumber { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string VehiclePlate { get; set; }

        public virtual Apartment Apartment { get; set; }

        public List<ManagerMessage> ReceivedMessages { get; set; }
        public List<ResidentMessage> SentMessages { get; set; }
    }


    public class ResidentConfiguration : IEntityTypeConfiguration<Resident>
    {
        public void Configure(EntityTypeBuilder<Resident> builder)
        {

            // Primary key 
            builder.HasKey(x => x.ResidentId);
            builder.Property(x => x.ResidentId).IsRequired().UseIdentityColumn();

            builder.Property(x => x.FullName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.TCNumber).IsRequired().HasMaxLength(11);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Phone).HasMaxLength(20);
            builder.Property(x => x.VehiclePlate).HasMaxLength(20);


            // Resident ile ManagerMessage ilişkisi
            builder.HasMany(r => r.SentMessages)
                   .WithOne(m => m.SenderResident)
                   .HasForeignKey(m => m.SenderResidentId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Resident ile ResidentMessage ilişkisi
            builder.HasMany(r => r.ReceivedMessages)
                   .WithOne(m => m.ReceiverResident)
                   .HasForeignKey(m => m.ReceiverResidentId)
                   .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(r => r.Apartment) 
                .WithOne(a => a.Resident)
                .HasForeignKey<Apartment>(a => a.ResidentId);




        }
    }
}
