using CarDealership.Core.Common;
using CarDealership.Core.Models;
using CarDealership.DataAccess;
using CarDealership.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace CarDealership.Core.Services;

public class SellReportService(IDbContextFactory<CarsContext> factory) : ISellReportService
{
    public async Task<YearStatsReport> GetReportByYear(int year, int? modelId = null)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(year);
        await using var context = await factory.CreateDbContextAsync();
        var query = context.Set<SoldSku>().Include(x => x.CarModel).Where(x => x.SellingDate.Year == year);
        if (modelId is not null)
            query = query.Where(x => x.ModelId == modelId);

        var result = await query.GroupBy(x => x.ModelId).Select(stats => 
                new ModelSellStats
                {
                    ModelId = stats.Key,
                    ModelName = stats.Max(x => x.CarModel.Name)!,
                    JanuaryStats = stats.Where(x => x.SellingDate.Month == 1).Sum(x => x.SellPrice),
                    FebruaryStats = stats.Where(x => x.SellingDate.Month == 2).Sum(x => x.SellPrice),
                    MarchStats = stats.Where(x => x.SellingDate.Month == 3).Sum(x => x.SellPrice),
                    AprilStats = stats.Where(x => x.SellingDate.Month == 4).Sum(x => x.SellPrice),
                    MayStats = stats.Where(x => x.SellingDate.Month == 5).Sum(x => x.SellPrice),
                    JuneStats = stats.Where(x => x.SellingDate.Month == 6).Sum(x => x.SellPrice),
                    JulyStats = stats.Where(x => x.SellingDate.Month == 7).Sum(x => x.SellPrice),
                    AugustStats = stats.Where(x => x.SellingDate.Month == 8).Sum(x => x.SellPrice),
                    SeptemberStats = stats.Where(x => x.SellingDate.Month == 9).Sum(x => x.SellPrice),
                    OctoberStats = stats.Where(x => x.SellingDate.Month == 10).Sum(x => x.SellPrice),
                    NovemberStats = stats.Where(x => x.SellingDate.Month == 11).Sum(x => x.SellPrice),
                    DecemberStats = stats.Where(x => x.SellingDate.Month == 12).Sum(x => x.SellPrice),
                }
            ).ToArrayAsync();
        return new YearStatsReport
        {
            Year = year,
            Stats = result,
            ModelName = NormalizeModelName(modelId, result)
        };
    }

    private string NormalizeModelName(int? modelId, ModelSellStats[] stats)
    {
        var result = "null";
        if (modelId is null)
            result = Constants.UI.ALL_CAR_MODELS_FILTER_TITLE;
        else if (stats.Length > 0) 
            result = stats[0].ModelName;

        return result.Replace(" ", "_").Trim().ToLower();
    }

    public int[] GetLatestYearsReportRange(int numberOfYears)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(numberOfYears);
        var result = new int[numberOfYears];
        var current = DateTime.Now.Year;
        var index = 0;
        for (var i = numberOfYears - 1; i >= 0; i--)
            result[index++] = current - i;
        return result;
    }
}