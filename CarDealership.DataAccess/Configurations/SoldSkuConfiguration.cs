using CarDealership.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarDealership.DataAccess.Configurations;

public class SoldSkuConfiguration : IEntityTypeConfiguration<SoldSku>
{
    public void Configure(EntityTypeBuilder<SoldSku> builder)
    {
        builder.HasKey(k => k.Id);
        builder.Property(x => x.SellingDate).IsRequired();
        builder.Property(x => x.SellPrice).HasColumnType("decimal(18,2)").IsRequired();
        
        builder.HasOne(x => x.CarModel).WithMany(x => x.SoldUnits)
            .HasForeignKey(x => x.ModelId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.CarBrand).WithMany()
            .HasForeignKey(x => x.BrandId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}