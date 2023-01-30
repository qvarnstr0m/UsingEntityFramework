using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsingEntityFramework.Data;
using UsingEntityFramework.Models;

namespace UsingEntityFramework.Repositories
{
    internal class ClassRepository : Repository<Class>, IClassRepository
    {
        public ClassRepository(FbgGymnDbContext context) : base(context)
        {

        }

        public FbgGymnDbContext FbgGymnDbContext
        {
            get { return Context as FbgGymnDbContext; }
        }
    }
}
