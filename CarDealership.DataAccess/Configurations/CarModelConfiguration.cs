using CarDealership.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarDealership.DataAccess.Configurations;

public class CarModelConfiguration : HandbookConfiguration<CarModel>
{
    public override void Configure(EntityTypeBuilder<CarModel> builder)
    {
        base.Configure(builder);
        builder.ToTable("CarModels");
        
        builder
            .HasOne(x => x.CarBrand)
            .WithMany()
            .HasForeignKey(x => x.BrandId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}