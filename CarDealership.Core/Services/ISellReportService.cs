using CarDealership.Core.Models;

namespace CarDealership.Core.Services;

public interface ISellReportService
{
    Task<YearStatsReport> GetReportByYear(int year, int? modelId = null);

    int[] GetLatestYearsReportRange(int numberOfYears);
}