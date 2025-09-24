using System.Diagnostics;
using System.IO;
using System.Windows;
using CarDealership.Core.Common;
using CarDealership.Core.Extensions;
using CarDealership.Core.Services;
using CarDealership.DataAccess;
using CarDealership.DataAccess.Extensions;
using CarDealership.UI.WPF.Extensions;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CarDealership.UI.WPF;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override async void OnStartup(StartupEventArgs e)
    {
        try
        {
            var serviceCollection = new ServiceCollection()
                .RegisterAppServices()
                .RegisterAppViewModels();
        
            var serviceProvider = serviceCollection.BuildServiceProvider();
            Ioc.Default.ConfigureServices(serviceProvider);

            var factory = serviceProvider.GetRequiredService<IDbContextFactory<CarsContext>>();
            await using (var context = await factory.CreateDbContextAsync())
            {
                Debug.WriteLine("Migration is running...");
                await context.Database.MigrateAsync();
                Debug.WriteLine("completed");

                Debug.WriteLine("Seeding is running...");
                await context.TrySeedSoldCars();
                Debug.WriteLine("completed");
                
                await serviceProvider.GetRequiredService<ICacheService>().LoadCarModels();
            }
            base.OnStartup(e);
        }
        catch (Exception exception)
        {
            Debug.WriteLine($"Unhandled exception: {exception}");
        }
    }
}