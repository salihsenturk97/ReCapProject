using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;

        }
        public IResult Add(Color color)
        {

            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }


        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.ColorAdded);

        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IDataResult<List<Color>> GetAll()
        {
            _colorDal.GetAll();
            return new SuccessDataResult<List<Color>>(Messages.ColorListed);
        }



        public IDataResult<Color> GetByColorId(int Id)
        {

            return new SuccessDataResult<Color>(_colorDal.Get(c => c.Id == Id));

        }






    }
}
