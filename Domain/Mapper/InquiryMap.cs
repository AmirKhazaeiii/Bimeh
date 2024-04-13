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
            builder.Property(x => new
            {
                x.Title,
                x.Covers,
                x.Capital,
            }).IsRequired();
        }
    }
}
