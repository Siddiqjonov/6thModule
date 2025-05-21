using CarSystem.Dal;
using CarSystem.Dal.Entities;

namespace CarSystem.Repostitory.Services;

public class CarRepository : ICarRepository
{
    private readonly MainContext MainContext;

    public CarRepository(MainContext mainContext)
    {
        MainContext = mainContext;
    }

    public async Task<long> InsertCarAsync(Car car)
    {
        throw new NotImplementedException();

    }

    public Task DeleteCarByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Car> SelectAllCars()
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Car>> SelectAllCarsAsync(int skip, int take)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Car>> SelectByDueDateCarsAsync(DateTime dueDate)
    {
        throw new NotImplementedException();
    }

    public Task<Car> SelectCarByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Car>> SelectCompletedCarsAsync(int skip, int take)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Car>> SelectIncompleteCarsAsync(int skip, int take)
    {
        throw new NotImplementedException();
    }

    public Task<int> SelectTotalCountAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateCarAsync(Car car)
    {
        throw new NotImplementedException();
    }
}
