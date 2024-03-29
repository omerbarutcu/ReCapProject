﻿using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ConsoleUI
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //CarAdd();
            //CarGetAll();
            //CarDetails();

            //ColorAdd();
            //ColorGetAll();

            //BrandAdd();
            //BrandGetAll();

            //CustomerAdd();
            //CustomerGetAll();
            //CustomerDetails();

            //RentalAdd();
            //RentalGetAll();
            //RentalDetails();
        }
        private static void CarAdd()
        {
            Console.WriteLine("--------CarAdd-------");
            Car car1 = new Car();
            car1.CarId = 4;
            car1.BrandId = 2;
            car1.ColorId = 2;
            car1.Description = "Megane 1.4";
            car1.DailyPrice = 350;
            car1.ModelYear = 2018;

            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(car1);
        }

        private static void CarGetAll()
        {
            Console.WriteLine("--------CarGetAll-------");
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Description);
            }
        }

        private static void CarDetails()
        {
            Console.WriteLine("--------Car Details-------");
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.ColorName + " " + car.BrandName + " " + car.CarName + " : " + car.DailyPrice);
                    Console.WriteLine("-----------------");
                }
            }
            else { Console.WriteLine(result.Message); }

        }

        private static void ColorAdd()
        {
            Console.WriteLine("--------ColorAdd-------");
            Color color1 = new Color();
            color1.ColorId = 5;
            color1.ColorName = "Mavi";

            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(color1);
        }

        private static void ColorGetAll()
        {
            Console.WriteLine("--------ColorGetAll-------");
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void BrandAdd()
        {
            Console.WriteLine("--------BrandAdd-------");
            Brand brand1 = new Brand();
            brand1.BrandId = 5;
            brand1.BrandName = "Wolkswagen";

            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(brand1);
        }

        private static void BrandGetAll()
        {
            Console.WriteLine("--------BrandGetAll-------");
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void CustomerAdd()
        {
            Console.WriteLine("--------CustomerAdd-------");
            Customer customer1 = new Customer();
            customer1.Id = 2;
            customer1.UserId = 2;
            customer1.CompanyName = "Ozge LTD";
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(customer1);
        }

        private static void CustomerGetAll()
        {
            Console.WriteLine("--------CustomerGetAll-------");

            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine(customer.CompanyName);
            }
        }

        private static void CustomerDetails()
        {
            Console.WriteLine("--------CustomerDetails-------");
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.GetCustomerDetails();
            if (result.Success)
            {
                foreach (var customer in result.Data)
                {
                    Console.WriteLine("{0}, {1}, {2}, {3}",
                        customer.UserFirstName,
                        customer.UserLastName,
                        customer.CompanyName,
                        customer.UserEmail
                        );
                    Console.WriteLine("-----------------");
                }
            }
            else { Console.WriteLine(result.Message); }

        }

        private static void RentalAdd()
        {
            Console.WriteLine("--------RentalAdd-------");
            Rental rental1 = new Rental();
            rental1.Id = 2;
            rental1.CarId = 1;
            rental1.CustomerId = 2;
            rental1.RentalDate = DateTime.Now;
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.Add(rental1);
        }

        private static void RentalGetAll()
        {
            Console.WriteLine("--------RentalGetAll-------");
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            foreach (var rental in rentalManager.GetAll().Data)
            {
                Console.WriteLine(rental.RentalDate);
            }
        }

        private static void RentalDetails()
        {
            Console.WriteLine("--------RentalDetails-------");
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetRentalDetails();
            if (result.Success)
            {
                foreach (var rental in result.Data)
                {
                    Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}",
                        rental.CarModelYear,
                        rental.CarColorName,
                        rental.CarBrandName,
                        rental.CarName,
                        rental.CustomerFirstName,
                        rental.CustomerLastName,
                        rental.CustomerEmail,
                        rental.RentDate,
                        rental.ReturnDate
                        );
                    Console.WriteLine("-----------------");
                }
            }
            else { Console.WriteLine(result.Message); }

        }
    }
}