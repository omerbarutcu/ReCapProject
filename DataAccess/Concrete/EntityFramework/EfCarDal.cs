using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, SqlServerDatabaseContext>, ICarDal
    {
        public List<CarDetailDto> GetCarByColorAndBrand(int colorId, int brandId)
        {
            using (SqlServerDatabaseContext context = new SqlServerDatabaseContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join co in context.Colors on c.ColorId equals co.ColorId
                             where c.ColorId == colorId && c.BrandId == brandId
                             select new CarDetailDto()
                             {
                                 CarId = c.CarId,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 BrandId = b.BrandId,
                                 ColorId = co.ColorId,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ImagePath = (from image in context.CarImages where c.CarId == image.CarId select image.ImagePath).FirstOrDefault()!


                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (SqlServerDatabaseContext context = new SqlServerDatabaseContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join co in context.Colors on c.ColorId equals co.ColorId
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 BrandId = b.BrandId,
                                 ColorId = c.ColorId,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                                 ImagePath = (from image in context.CarImages where c.CarId == image.CarId select image.ImagePath).FirstOrDefault()!
                             };
                if (filter == null) { return result.ToList(); }
                result = result.Where(filter);
                return result.ToList();
            }
        }
    }
}
