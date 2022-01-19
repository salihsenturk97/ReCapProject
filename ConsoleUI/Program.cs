using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
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

            // CarTest();

            //CarDetailDto carDetailDto = new CarDetailDto();
            
            CarManager carManager1 = new CarManager(new EfCarDal());
            foreach (var car in carManager1.GetCarDetails())
            {
                Console.WriteLine("Araç ismi {0} , {1} araç markası , {2} araç rengi , {3} günlük fiyatı", car.CarName,car.BrandName,car.ColorName,car.DailyPrice);
            }

            //BrandTest();
            //ColorTest();

        }

        private static void BrandTest()
        {
            Brand brand = new Brand();
            brand.BrandName = "Opel";
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(brand);
        }

        private static void ColorTest()
        {
            Color color = new Color();
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { ColorName = "Turuncu" });
        }

        private static void CarTest()
        {
            Car car1 = new Car();
            car1.Id=3;
            car1.Description = "Favorit";
            car1.BrandId = 1;
            car1.DailyPrice = 100;
            car1.ColorId = 2;
            car1.ModelYear = 2016;
          

            CarManager carManager = new CarManager(new EfCarDal());
           carManager.Delete(car1);

           
        }
    }
}
