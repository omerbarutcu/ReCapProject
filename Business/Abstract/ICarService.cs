using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetByDailyPrice (decimal min,decimal max);
        Car Get(int id);
        List<Car> GetCarsByBrandId (int id);
        List<Car> GetCarByColorId (int id);
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
    }
}
