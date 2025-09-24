using CarDealership.Core.Models;

namespace CarDealership.Core.Services;

public interface IExportService
{
    Task ExportToExcel(YearStatsReport stats, CancellationToken token = new());
}