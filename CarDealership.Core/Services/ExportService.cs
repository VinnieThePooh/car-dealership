using System.Diagnostics;
using System.Globalization;
using CarDealership.Core.Common;
using CarDealership.Core.ExportConfigs;
using CarDealership.Core.Models;
using CsvHelper.Configuration;
using CsvHelper.OpenXml.Excel;

namespace CarDealership.Core.Services;

public class ExportService : IExportService
{
    private readonly string exportPath = Path.Combine(AppContext.BaseDirectory, Constants.EXCEL_EXPORT_DIR);
    
    public async Task ExportToExcel(YearStatsReport report, CancellationToken token = new())
    {
        if (!Directory.Exists(exportPath))
            Directory.CreateDirectory(exportPath);
        
        // exactly this version works
        using MemoryStream ExcelStream = new MemoryStream();
        using (ExcelDomWriter ExcelWriter = new ExcelDomWriter(ExcelStream, new CsvConfiguration(CultureInfo.CurrentCulture)))
        {
            ExcelWriter.Context.RegisterClassMap<ModelSellStatsMap>();
            ExcelWriter.WriteRecords(report.Stats);
        }

        byte[] bytes = ExcelStream.ToArray();
        await File.WriteAllBytesAsync(Path.Combine(exportPath, $"{report.Year}-{report.ModelName}-{DateTime.Now:dd.MM.yyyy}.xlsx"), bytes, token);
        
        // todo: not working for some reason
        // using var memory = new MemoryStream();
        // await using var excelWriter = new ExcelDomWriter(memory, new CsvConfiguration(CultureInfo.InvariantCulture));
        // excelWriter.Context.RegisterClassMap<ModelSellStatsMap>();
        // excelWriter.WriteHeader<ModelSellStats>();
        // await excelWriter.WriteRecordsAsync(report.Stats, token);
        // await excelWriter.FlushAsync();
        // await using (var fileStream = File.OpenWrite(Path.Combine(exportPath, $"{report.Year}-{DateTime.Now.ToString(CultureInfo.GetCultureInfo("ru-RU"))}.xlsx")))
        //     await memory.CopyToAsync(fileStream, token);
    }
}