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
    [Table("ResidentMessage", Schema = "dbo")]
    public class ResidentMessage
    {
        public int MessageId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public bool IsRead { get; set; }
        public int SenderResidentId { get; set; }
        public int ReceiverManagerId { get; set; }

        public Resident SenderResident { get; set; }
        public Manager ReceiverManager { get; set; }
    }


    public class ResidentMessageConfiguration : IEntityTypeConfiguration<ResidentMessage>
    {
        public void Configure(EntityTypeBuilder<ResidentMessage> builder)
        {
            builder.HasKey(m => m.MessageId);
            builder.Property(m => m.Title).IsRequired().HasMaxLength(50);
            builder.Property(m => m.Content).IsRequired().HasMaxLength(500);
            builder.Property(m => m.Date).IsRequired();
            builder.Property(m => m.IsRead).IsRequired();

            // ResidentMessage ile Resident (IkametEden) ilişkisi
            builder.HasOne(m => m.SenderResident)
                   .WithMany(r => r.SentMessages)
                   .HasForeignKey(m => m.SenderResidentId)
                   .OnDelete(DeleteBehavior.Restrict);

            // ResidentMessage ile Manager (Yonetici) ilişkisi
            builder.HasOne(m => m.ReceiverManager)
                   .WithMany(m => m.ReceivedMessages)
                   .HasForeignKey(m => m.ReceiverManagerId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
