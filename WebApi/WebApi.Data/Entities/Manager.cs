using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entities
{
    [Table("Manager", Schema = "dbo")]
    public class Manager
    {
        public int ManagerId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public List<ResidentMessage> ReceivedMessages { get; set; }
        public List<ManagerMessage> SentMessages { get; set; }
    }

    public class ManagerConfiguration : IEntityTypeConfiguration<Manager>
    {
        public void Configure(EntityTypeBuilder<Manager> builder)
        {
            builder.HasKey(m => m.ManagerId);
            builder.Property(x => x.ManagerId).IsRequired().UseIdentityColumn();

            builder.Property(m => m.Username).IsRequired();
            builder.Property(m => m.Password).IsRequired();

            // Manager ile ResidentMessage ilişkisi
            builder.HasMany(m => m.ReceivedMessages)
                   .WithOne(m => m.ReceiverManager)
                   .HasForeignKey(m => m.ReceiverManagerId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Manager ile ManagerMessage ilişkisi
            builder.HasMany(m => m.SentMessages)
                   .WithOne(m => m.SenderManager)
                   .HasForeignKey(m => m.SenderManagerId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
