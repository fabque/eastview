using EastviewRestAPI.Models;
using EastviewRestAPI.Patterns.Impl;
using EastviewRestAPI.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EastviewRestAPI.Repositories
{
    public class CitizenRepository : Repository<Citizen>, ICitizenRepository
    {
        public CitizenRepository(EastviewDbContext eastviewDbContext) : base(eastviewDbContext)
        {
        }
    }
}
