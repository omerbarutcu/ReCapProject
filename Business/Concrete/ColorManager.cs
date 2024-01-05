using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business.BusinessRules;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            IResult result = BusinessRules.Run(CheckColorExist(color.ColorId), CheckColorNameExist(color.ColorName));
            if (result != null) { return new ErrorResult(); }
            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Delete(Color color)
        {
            _colorDal?.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.ColorListed);
        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId == id));
        }

        public IResult Update(Color color)
        {
            IResult result = BusinessRules.Run(CheckColorNameExist(color.ColorName));
            if (result != null) { return new ErrorResult(); }
            _colorDal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);
        }

        private IResult CheckColorExist(int colorId)
        {
            var result = _colorDal.GetAll(c => c.ColorId == colorId).Any();
            if (!result) { return new ErrorResult(); }
            return new SuccessResult();
        }

        private IResult CheckColorNameExist(string colorName)
        {
            var result = _colorDal.GetAll(c => c.ColorName == colorName).Any();
            if (!result) { return new ErrorResult(); }
            return new SuccessResult();
        }
    }
}
