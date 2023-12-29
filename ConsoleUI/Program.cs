using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
using System.Net.Http.Headers;
using Entities.DTOs;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CarAdded();
            //Color();
            //Brand();
            CarDetails();




        }

        private static void CarDetails()
        {
            Console.WriteLine("--------Car Details-------");
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.ColorName + " " + car.BrandName + " " + car.CarName + " : " + car.DailyPrice);
                Console.WriteLine("-----------------");
            }
        }

        private static void Brand()
        {
            Brand brand1 = new Brand();
            brand1.BrandId = 5;
            brand1.BrandName = "Wolkswagen";

            Console.WriteLine("--------Brand-------");
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            //brandManager.Add(brand1);
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void Color()
        {
            Color color1 = new Color();
            color1.ColorId = 5;
            color1.ColorName = "Mavi";

            Console.WriteLine("--------Color-------");
            ColorManager colorManager = new ColorManager(new EfColorDal());
            //colorManager.Add(color1);
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static CarManager CarAdded()
        {
            Car car1 = new Car();
            car1.CarId = 1;
            car1.BrandId = 5;
            car1.ColorId = 3;
            car1.Description = "Polo 1.6";
            car1.DailyPrice = 400;
            car1.ModelYear = 2020;

            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(car1);
            return carManager;
        }
    }
}