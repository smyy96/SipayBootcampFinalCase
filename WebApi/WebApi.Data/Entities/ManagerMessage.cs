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
    [Table("ManagerMessage", Schema = "dbo")]
    public class ManagerMessage
    {
        public int MessageId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public bool IsRead { get; set; }
        public int SenderManagerId { get; set; }
        public int ReceiverResidentId { get; set; }

        public Manager SenderManager { get; set; }
        public Resident ReceiverResident { get; set; }
    }

    public class ManagerMessageConfiguration : IEntityTypeConfiguration<ManagerMessage>
    {
        public void Configure(EntityTypeBuilder<ManagerMessage> builder)
        {
            builder.HasKey(m => m.MessageId);
            builder.Property(m => m.Title).IsRequired().HasMaxLength(50);
            builder.Property(m => m.Content).IsRequired().HasMaxLength(500);
            builder.Property(m => m.Date).IsRequired();
            builder.Property(m => m.IsRead).IsRequired();

            // ManagerMessage ile Manager (Yonetici) ilişkisi
            builder.HasOne(m => m.SenderManager)
                   .WithMany(m => m.SentMessages)
                   .HasForeignKey(m => m.SenderManagerId)
                   .OnDelete(DeleteBehavior.Restrict);

            // ManagerMessage ile Resident (IkametEden) ilişkisi
            builder.HasOne(m => m.ReceiverResident)
                   .WithMany(r => r.ReceivedMessages)
                   .HasForeignKey(m => m.ReceiverResidentId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
