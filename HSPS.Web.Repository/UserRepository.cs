using Entities;
using HSPS.Web.Repository.BASE;
using HSPS.Web.Repository.UnitOfWorks;

namespace HSPS.Web.Repository
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(IUnitOfWorkManage unitOfWorkManage) : base(unitOfWorkManage)
        {
        }
    }
}
