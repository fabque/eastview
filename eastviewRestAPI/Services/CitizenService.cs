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
    public class CitizenService : ICitizenService
    {
        private readonly ICitizenRepository _citizenRepository;

        public CitizenService(ICitizenRepository citizenRepository)
        {
            _citizenRepository = citizenRepository;
        }

        public Task<Citizen> Add(Citizen entity)
        {
            return _citizenRepository.Add(entity);
        }

        public Task<Citizen> Delete(int id)
        {
            return _citizenRepository.Delete(id);
        }

        public Task<Citizen> Get(int id)
        {
            return _citizenRepository.Get(id);
        }

        public Task<List<Citizen>> GetAll()
        {
            return _citizenRepository.GetAll();
        }

        public Task<Citizen> Update(Citizen entity)
        {
            return _citizenRepository.Update(entity);
        }
    }
}
