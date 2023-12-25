using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car();
            car1.CarId = 9;
            car1.BrandId = 10;
            car1.ColorId = 11;
            car1.Description = "Doğan SLX";
            car1.DailyPrice = 150;
            car1.ModelYear = 1998;

            Car car2 = new Car();
            car2.CarId = 1;
            car2.BrandId = 7;
            car2.ColorId = 6;
            car2.Description = "Mercedes E200";
            car2.DailyPrice = 130;
            car2.ModelYear = 1995;

            Console.WriteLine("--------GetAll-------");
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
            Console.WriteLine("--------GetById-------");

            Console.WriteLine(carManager.GetById(1).Description);

            Console.WriteLine("--------Add-------");
            carManager.Add(car1);
            Console.WriteLine(carManager.GetById(9).Description);

            Console.WriteLine("--------Update-------");
            carManager.Update(car2);
            Console.WriteLine(carManager.GetById(1).ModelYear + " model " + carManager.GetById(1).Description + " fiyatı : " + carManager.GetById(1).DailyPrice);

            Console.WriteLine("--------Delete-------");

            carManager.Delete(carManager.GetById(3));

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
