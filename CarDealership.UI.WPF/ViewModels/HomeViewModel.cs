using CommunityToolkit.Mvvm.ComponentModel;

namespace CarDealership.UI.WPF.ViewModels;

public class HomeViewModel : ObservableObject, IPageViewModel
{
    public string Name { get; } = "Home";
    public string Title { get; } = "Домашняя";
}