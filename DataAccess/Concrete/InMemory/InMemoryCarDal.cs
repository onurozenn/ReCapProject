using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car;
        public InMemoryCarDal()
        {
            _car = new List<Car> {
            new Car{ CarId=1,BrandId=1,ColorId=1,ModelYear=2020,DailyPrice=300,Description="Büyük kırmızı araba" },
            new Car{ CarId=2,BrandId=1,ColorId=2,ModelYear=2018,DailyPrice=200,Description="Büyük Mavi araba" },
            new Car{ CarId=3,BrandId=2,ColorId=1,ModelYear=2015,DailyPrice=150,Description="Büyük Turuncu araba" },
            new Car{ CarId=4,BrandId=2,ColorId=2,ModelYear=2019,DailyPrice=250,Description="Büyük Yeşil araba" },
            new Car{ CarId=5,BrandId=2,ColorId=1,ModelYear=2017,DailyPrice=175,Description="Büyük Sarı araba" }
            };
        }
        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            //LİNQ
            Car carToDelete = _car.SingleOrDefault(c => c.CarId == car.CarId);

            _car.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetAllByBrand(int brandId)
        {
           return _car.Where(c => c.BrandId == brandId).ToList();
        }

        public void Update(Car car)
        {
            //Aynı Id'ye sahip listedeki ürünü bul 
            Car carToUpdate = _car.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
