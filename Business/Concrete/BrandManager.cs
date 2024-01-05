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
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            IResult result = BusinessRules.Run(CheckIfBrandNameExist(brand.BrandName));
            if (result == null) { return new ErrorResult(); }
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        public IResult Delete(Brand brand)
        {
            IResult result = BusinessRules.Run(CheckIfBrandExist(brand.BrandId));
            if (result != null) { return new ErrorResult(); }
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandListed);
        }

        public IDataResult<Brand> GetById(int id)
        {
            IResult result = BusinessRules.Run(CheckIfBrandExist(id));
            if (result != null) { return new ErrorDataResult<Brand>(); }
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandId == id));
        }

        public IResult Update(Brand brand)
        {
            IResult result = BusinessRules.Run(CheckIfBrandNameExist(brand.BrandName), CheckIfBrandExist(brand.BrandId));
            if (result != null) { return new ErrorResult(); }
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }

        private IResult CheckIfBrandNameExist(string brandName)
        {
            var result = _brandDal.GetAll(b => b.BrandName == brandName).Any();
            if (result) { return new ErrorResult(Messages.BrandNameInvalid); }
            return new SuccessResult();
        }

        private IResult CheckIfBrandExist(int brandId)
        {
            var result = _brandDal.GetAll(b => b.BrandId == brandId).Any();
            if (result) { return new ErrorResult("Marka bulunamadı !"); }
            return new SuccessResult();
        }
    }
}
