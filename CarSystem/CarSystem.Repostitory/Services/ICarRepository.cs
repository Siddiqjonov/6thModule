using CarSystem.Dal.Entities;

namespace CarSystem.Repostitory.Services;

public interface ICarRepository
{
    Task<long> InsertCarAsync(Car car);
    Task DeleteCarByIdAsync(long id);
    Task UpdateCarAsync(Car car);
    Task<ICollection<Car>> SelectAllCarsAsync(int skip, int take);
    Task<Car> SelectCarByIdAsync(long id);
    Task<ICollection<Car>> SelectByDueDateCarsAsync(DateTime dueDate);
    Task<ICollection<Car>> SelectCompletedCarsAsync(int skip, int take);
    Task<ICollection<Car>> SelectIncompleteCarsAsync(int skip, int take);
    Task<int> SelectTotalCountAsync();
    IQueryable<Car> SelectAllCars();

}