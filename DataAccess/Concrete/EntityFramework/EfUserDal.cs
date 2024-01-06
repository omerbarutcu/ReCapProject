using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, SqlServerDatabaseContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var contex = new SqlServerDatabaseContext())
            {
                var result = from oC in contex.OperationClaims
                             join uOC in contex.UserOperationClaims
                             on oC.Id equals uOC.OperationClaimId
                             where uOC.UserId == user.Id
                             select new OperationClaim
                             {
                                 Id = oC.Id,
                                 Name = oC.Name
                             };
                return result.ToList();
            }
        }
    }
}
