using System.IO;
using CarDealership.DataAccess;
using CarDealership.UI.WPF.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CarDealership.UI.WPF.Extensions;

internal static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterAppViewModels(this IServiceCollection services)
    {
        services.AddSingleton<HomeViewModel>();
        services.AddSingleton<SellStatisticsViewModel>();
        return services;
    }
}