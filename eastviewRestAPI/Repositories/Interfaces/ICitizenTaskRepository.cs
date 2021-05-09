using EastviewRestAPI.Models;
using EastviewRestAPI.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EastviewRestAPI.Repositories.Interface
{
    public interface ICitizenTaskRepository : IRepository<CitizenTask>
    {
        Task<List<CitizenTask>> GetCitizenTaskByDay(DayOfWeek dayOfWeek);
    }
}
