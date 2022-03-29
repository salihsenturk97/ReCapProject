using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetAllByCarId(int carId);
        IDataResult<CarImage> Get(int id);
        IResult Add(IFormFile image, CarImage carImage);
        IResult Delete(CarImage carImage);
        IResult Update(IFormFile image, CarImage carImage);
        IDataResult<List<CarImage>> GetImagesByCarId(int id);
    }
}