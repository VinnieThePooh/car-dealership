using CarDealership.DataAccess.Interfaces;

namespace CarDealership.DataAccess.Models;

public class CarBrand : IHandbook
{
    public int Id { get; set; }
    public string Name { get; set; }
}