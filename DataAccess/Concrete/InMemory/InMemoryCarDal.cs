using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1, BrandId=1,ColorId=1,ModelYear=1998,DailyPrice=250,Description="Polo"},
                new Car{Id=2, BrandId=1,ColorId=2,ModelYear=2014,DailyPrice=450,Description="Golf"},
                new Car{Id=3, BrandId=2,ColorId=3,ModelYear=2021,DailyPrice=650,Description="Octavia"},
                new Car{Id=4, BrandId=3,ColorId=4,ModelYear=2004,DailyPrice=350,Description="Fiesta"},
                new Car{Id=5, BrandId=4,ColorId=5,ModelYear=2016,DailyPrice=550,Description="Clio"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            var carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);

        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            //Id unique olduğu için class ismiyle imzalıyoruz.
            //List yazsaydık 1 Id'li araba 1 tane olduğundan sadece 1 adet görünecekti.
            //sürekli 1 i döndürmemesi için list yerine class ismiyle imzaladık.
            Car carToGetById = _cars.SingleOrDefault(c => c.Id == id);
            return carToGetById;
        }

        public void Update(Car car)
        {
            var carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
