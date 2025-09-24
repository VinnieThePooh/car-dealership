using CarDealership.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarDealership.DataAccess.Configurations;

public class CarBrandConfiguration : HandbookConfiguration<CarBrand>
{
    public override void Configure(EntityTypeBuilder<CarBrand> builder)
    {
        base.Configure(builder);
        builder.ToTable("CarBrands");
    }
}