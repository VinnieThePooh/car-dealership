using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using CarDealership.Core.Common;
using CarDealership.Core.Models;
using CarDealership.Core.Services;
using CarDealership.Core.UiModels;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace CarDealership.UI.WPF.ViewModels;

public partial class SellStatisticsViewModel(ISellReportService reportService, IExportService exportService, ICacheService cacheService)
    : ObservableObject, IPageViewModel
{
    public string Name => "SellStatistics";
    public string Title => "Статистика по продажам";

    private YearStatsReport? _yearStatsReport;

    [ObservableProperty] [NotifyCanExecuteChangedFor(nameof(ExportToExcelCommand))]
    private ObservableCollection<ModelSellStats>? stats;

    public int[] YearsFilter { get; } = reportService.GetLatestYearsReportRange(Constants.YEAR_REPORT_RANGE);

    public CarModelItem[]? ModelsFilter { get; private set; }
    
    public CarModelItem? SelectedModel { get; set; }
    
    public int SelectedYear { get; set; }


    [ObservableProperty]
    public Visibility exportProgress =  Visibility.Hidden;
    
    [ObservableProperty]
    public Visibility loadProgress = Visibility.Visible;

    [ObservableProperty]
    public string? exportResult = "";

    [RelayCommand(CanExecute = nameof(CanExport), AllowConcurrentExecutions = false)]
    internal async Task ExportToExcel(CancellationToken token)
    {
        try
        {
            ExportProgress = Visibility.Visible;
            await Task.Delay(500, token);
            await exportService.ExportToExcel(_yearStatsReport!, token);
            ExportProgress = Visibility.Hidden;
            ExportResult = "Экспорт завершен успешно";
            await Task.Delay(2000, CancellationToken.None);
            ExportResult = null;
        }
        catch (OperationCanceledException)
        {
            Debug.WriteLine("ExportToExcel operation cancelled");
        }
    }

    internal async Task PreloadData()
    {
        SelectedYear = YearsFilter.Last();
        SetCarModelFilter();
        SelectedModel = ModelsFilter!.First();
        LoadProgress  = Visibility.Visible;
        await LoadStats(SelectedYear, SelectedModel.Id);
        LoadProgress  = Visibility.Visible;
    }

    public bool CanExport() => _yearStatsReport is not null && Stats?.Count != 0;


    [RelayCommand]
    internal async Task LoadStats(int year)
    {
        LoadProgress  = Visibility.Visible;
        await LoadStats(year, SelectedModel!.Id);
        LoadProgress  = Visibility.Hidden;
    }

    [RelayCommand]
    internal async Task LoadStatsByModel(CarModelItem model)
    {
        LoadProgress =  Visibility.Visible;
        await LoadStats(SelectedYear, model.Id);
        LoadProgress  = Visibility.Hidden;
    }
    

    internal async Task LoadStats(int year, int? modelId)
    {
        _yearStatsReport = await reportService.GetReportByYear(year, modelId);
        Stats = new ObservableCollection<ModelSellStats>(_yearStatsReport.Stats);
    }

    internal void SetCarModelFilter()
    {
        ModelsFilter = [
        new CarModelItem
        {
            Id = null, Name = Constants.UI.ALL_CAR_MODELS_FILTER_TITLE,
        }, ..cacheService.CarModels.Select(x => new CarModelItem { Id = x.Id, Name = x.Name })];
    }

}