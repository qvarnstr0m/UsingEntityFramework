using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsingEntityFramework.Data;
using UsingEntityFramework.Models;

namespace UsingEntityFramework.Repositories
{
    internal class AdressRepository : Repository<Adress>, IAdressRepository
    {
        public AdressRepository(FbgGymnDbContext context) : base(context)
        {

        }

        public FbgGymnDbContext FbgGymnDbContext
        {
            get { return Context as FbgGymnDbContext; }
        }
    }
}
