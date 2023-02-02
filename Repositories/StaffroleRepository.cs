using UsingEntityFramework.Data;
using UsingEntityFramework.Models;

namespace UsingEntityFramework.Repositories
{
    internal class StaffroleRepository : Repository<Staffrole>, IStaffroleRepository
    {
        public StaffroleRepository(FbgGymnDbContext context) : base(context)
        {

        }

        public FbgGymnDbContext FbgGymnDbContext
        {
            get { return Context as FbgGymnDbContext; }
        }
    }
}
