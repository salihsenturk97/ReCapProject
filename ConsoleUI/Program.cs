using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarManager carManager = new CarManager(new InMemoryCarDal());

            //foreach (var car in carManager.GetAll() )
            //{
            //    Console.WriteLine(car.Description + " Yılı = " + car.ModelYear + " Günlük fiyatı = " + car.DailyPrice + " TL");
            //}

            Car car1 = new Car();
            car1.Description = "Favorit";
            car1.BrandId = 1;
            car1.DailyPrice = 100;
            car1.ColorId = 2;
            car1.ModelYear = 2016;
          
            CarManager carManager = new CarManager(new EfCarDal());           
            carManager.Add(car1);

        }
    }
}
