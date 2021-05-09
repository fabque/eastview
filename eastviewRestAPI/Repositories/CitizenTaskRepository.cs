using EastviewRestAPI.Models;
using EastviewRestAPI.Patterns.Impl;
using EastviewRestAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EastviewRestAPI.Repositories
{
    public class CitizenTaskRepository : Repository<CitizenTask>, ICitizenTaskRepository
    {
        public CitizenTaskRepository(EastviewDbContext eastviewDbContext) : base(eastviewDbContext)
        {
        }

        public new async Task<List<CitizenTask>> GetAll()
        {
            return await context.Tasks.Include(x => x.Citizen).ToListAsync();
        }

        public Task<List<CitizenTask>> GetCitizenTaskByDay(DayOfWeek dayOfWeek)
        {
            return context.Tasks.Where(x => x.Day.Equals(dayOfWeek)).Include(z => z.Citizen).ToListAsync();
        }
    }
}
