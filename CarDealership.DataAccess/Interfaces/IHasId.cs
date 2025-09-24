namespace CarDealership.DataAccess.Interfaces;

public interface IHasId<T>
{
    T Id { get; set; }
}