using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car();
            car1.CarId = 3;
            car1.BrandId = 2;
            car1.ColorId = 1;
            car1.Description = "Clio";
            car1.DailyPrice = -1;
            car1.ModelYear = 1998;

            Console.WriteLine("--------Update-------");
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Update(car1);


            Console.WriteLine("--------GetAll-------");


            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
            Console.WriteLine("---------------");
        }
    }
}