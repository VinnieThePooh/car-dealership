using CarDealership.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarDealership.DataAccess.Configurations;

public abstract class HandbookConfiguration<T> : IEntityTypeConfiguration<T> where T : class, IHandbook
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Name).HasMaxLength(300).IsRequired();
        builder.HasIndex(x => x.Name).IsUnique();
    }
}

