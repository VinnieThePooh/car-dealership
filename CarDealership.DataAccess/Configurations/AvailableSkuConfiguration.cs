using CarDealership.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarDealership.DataAccess.Configurations;

public class AvailableSkuConfiguration : IEntityTypeConfiguration<AvailableSku>
{
    public void Configure(EntityTypeBuilder<AvailableSku> builder)
    {
        builder.HasKey(k => k.Id);
        
        builder.HasOne(x => x.CarModel).WithMany(x => x.StockUnits)
            .HasForeignKey(x => x.ModelId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.CarBrand).WithMany()
            .HasForeignKey(x => x.BrandId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}