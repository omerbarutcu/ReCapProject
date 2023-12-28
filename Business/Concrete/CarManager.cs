﻿using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager:ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.Description.Length<2 || car.DailyPrice<0) 
            {
                Console.WriteLine("Araç ekleme işlemi başarısız !");
                Console.WriteLine("Araç ismi en az 2 karakter olmalıdır.");
            }
            else
            {
                _carDal.Add(car);
            }
            
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public Car Get(int id)
        {
            return _carDal.Get(c=>c.CarId==id);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetByDailyPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(c=>c.DailyPrice>=min && c.DailyPrice<=max);
        }

        public List<Car> GetCarByColorId(int id)
        {
            return _carDal.GetAll(c=>c.ColorId==id);
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(c=> c.BrandId==id);
        }

        public void Update(Car car)
        {
            if (car.Description.Length < 2 || car.DailyPrice < 0)
            {
                Console.WriteLine("Araç güncelleme işlemi başarısız !");
                Console.WriteLine("Araç ismi en az 2 karakter olmalıdır.");
            }
            else
            {
                _carDal.Update(car);
            }
             
            
        }
    }
}
