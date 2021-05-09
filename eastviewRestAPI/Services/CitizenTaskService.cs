using EastviewRestAPI.Models;
using EastviewRestAPI.Patterns;
using EastviewRestAPI.Repositories.Interface;
using EastviewRestAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EastviewRestAPI.Services
{
    public class CitizenTaskService : ICitizenTaskService
    {
        private readonly ICitizenTaskRepository _taskRepository;

        public CitizenTaskService(ICitizenTaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public Task<CitizenTask> Add(CitizenTask entity)
        {
            return _taskRepository.Add(entity);
        }

        public Task<CitizenTask> Delete(int id)
        {
            return _taskRepository.Delete(id);
        }

        public Task<CitizenTask> Get(int id)
        {
            return _taskRepository.Get(id);
        }

        public Task<List<CitizenTask>> GetAll()
        {
            return _taskRepository.GetAll();
        }

        public Task<List<CitizenTask>> GetCitizenTaskByDay(DayOfWeek dayOfWeek)
        {
            return _taskRepository.GetCitizenTaskByDay(dayOfWeek);
        }

        public Task<CitizenTask> Update(CitizenTask entity)
        {
            return _taskRepository.Update(entity);
        }
    }
}
