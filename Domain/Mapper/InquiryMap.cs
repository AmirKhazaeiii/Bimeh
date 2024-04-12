using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Mapper
{
    public class InquiryMap : IEntityTypeConfiguration<Inquiry>
    {
        public void Configure(EntityTypeBuilder<Inquiry> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(s => s.Covers)
                   .WithOne(t => t.Inquiry)
                   .HasForeignKey(e => e.InquiryId)
                   .IsRequired();
        }
    }
}
