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
    public class TasksController : ControllerBase
    {
        private readonly ICitizenTaskService _service;

        public TasksController(ICitizenTaskService service)
        {
            _service = service;
        }

        // GET: api/Tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CitizenTask>>> GetTasks()
        {
            return await _service.GetAll();
        }

        // GET: api/Tasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CitizenTask>> GetTask(int id)
        {
            var task = await _service.Get(id);

            if (task == null)
            {
                return NotFound();
            }

            return task;
        }

        // PUT: api/Tasks/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask(int id, CitizenTask task)
        {
            if (id != task.Id)
            {
                return BadRequest();
            }

            try
            {
                await _service.Update(task);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(id))
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

        // POST: api/Tasks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CitizenTask>> PostTask(CitizenTask task)
        {
            await _service.Add(task);            

            return CreatedAtAction("GetTask", new { id = task.Id }, task);
        }

        // DELETE: api/Tasks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CitizenTask>> DeleteTask(int id)
        {
            var task = await _service.Delete(id);
            if (task == null)
            {
                return NotFound();
            }

            return task;
        }

        private bool TaskExists(int id)
        {
            var task = _service.Get(id);
            return task != null;
        }
    }
}
