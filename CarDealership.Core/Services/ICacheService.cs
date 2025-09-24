using CarDealership.DataAccess.Models;

namespace CarDealership.Core.Services;

public interface ICacheService
{
    CarModel[] CarModels { get; }

    Task LoadCarModels(CancellationToken token = default);
}