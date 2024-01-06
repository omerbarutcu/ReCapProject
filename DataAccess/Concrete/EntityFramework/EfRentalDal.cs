using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, SqlServerDatabaseContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (SqlServerDatabaseContext context = new SqlServerDatabaseContext())
            {
                var result = from rent in context.Rentals
                             join car in context.Cars on rent.CarId equals car.CarId
                             join customer in context.Customers on rent.CustomerId equals customer.UserId
                             join user in context.Users on customer.UserId equals user.Id
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             join color in context.Colors on car.ColorId equals color.ColorId
                             select new RentalDetailDto
                             {
                                 RentalId = rent.Id,
                                 CarColorName = color.ColorName,
                                 CarBrandName = brand.BrandName,
                                 CarDescription = car.Description,
                                 CarModelYear = car.ModelYear,
                                 CustomerFirstName = user.FirstName,
                                 CustomerLastName = user.LastName,
                                 CustomerEmail = user.Email,
                                 RentDate = rent.RentalDate,
                                 ReturnDate = rent.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
