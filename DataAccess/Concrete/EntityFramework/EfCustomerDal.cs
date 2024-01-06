using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, SqlServerDatabaseContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (SqlServerDatabaseContext context = new SqlServerDatabaseContext())
            {
                var result = from c in context.Customers
                             join u in context.Users on c.UserId equals u.Id
                             select new CustomerDetailDto
                             {
                                 Id = u.Id,
                                 UserFirstName = u.FirstName,
                                 UserLastName = u.LastName,
                                 CompanyName = c.CompanyName,
                                 UserEmail = u.Email
                             };
                return result.ToList();
            }
        }
    }
}
