using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EastviewRestAPI.Models;
using EastviewRestAPI.Services.Interfaces;

namespace EastviewRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitizensController : ControllerBase
    {
        private readonly ICitizenService _service;

        public CitizensController(ICitizenService service)
        {
            _service = service;
        }

        // GET: api/Citizens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Citizen>>> GetCitizens()
        {
            return await _service.GetAll();
        }

        // GET: api/Citizens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Citizen>> GetCitizen(int id)
        {
            var citizen = await _service.Get(id);

            if (citizen == null)
            {
                return NotFound();
            }

            return citizen;
        }

        // PUT: api/Citizens/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCitizen(int id, Citizen citizen)
        {
            if (id != citizen.Id)
            {
                return BadRequest();
            }

            try
            {
                await _service.Update(citizen);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CitizenExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Citizens
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Citizen>> PostCitizen(Citizen citizen)
        {
           
            await _service.Add(citizen);

            return CreatedAtAction("GetCitizen", new { id = citizen.Id }, citizen);
        }

        // DELETE: api/Citizens/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Citizen>> DeleteCitizen(int id)
        {
            var citizen = await _service.Delete(id);
            if (citizen == null)
            {
                return NotFound();
            }

            return citizen;
        }

        private bool CitizenExists(int id)
        {
            var citizen = _service.Get(id);
            return citizen != null;
        }
    }
}
