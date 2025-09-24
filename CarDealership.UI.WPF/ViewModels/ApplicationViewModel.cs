using CarDealership.Core.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;

namespace CarDealership.UI.WPF.ViewModels;

public partial class ApplicationViewModel : ObservableObject
{
    private IPageViewModel? _currentPageViewModel;
    private List<IPageViewModel>? _pageViewModels;
    private readonly Ioc serviceProvider = Ioc.Default;

    public ApplicationViewModel()
    {
        PageViewModels.Add(serviceProvider.GetRequiredService<HomeViewModel>());
        PageViewModels.Add(serviceProvider.GetRequiredService<SellStatisticsViewModel>());
        CurrentPageViewModel = PageViewModels[0];
    }

    public List<IPageViewModel> PageViewModels => _pageViewModels ??= [];

    public IPageViewModel? CurrentPageViewModel
    {
        get => _currentPageViewModel;
        set
        {
            if (_currentPageViewModel != value)
            {
                _currentPageViewModel = value;
                OnPropertyChanged();
            }
        }
    }


    [RelayCommand]
    private async Task ChangePage(IPageViewModel pageViewModel)
    {
        if (!PageViewModels.Contains(pageViewModel))
            PageViewModels.Add(pageViewModel);

        CurrentPageViewModel = pageViewModel;
        if (pageViewModel is SellStatisticsViewModel viewModel)
            await viewModel.PreloadData();
    }
}