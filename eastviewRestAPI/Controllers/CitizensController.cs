﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EastviewRestAPI.Models;

namespace EastviewRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitizensController : ControllerBase
    {
        private readonly EastviewDbContext _context;

        public CitizensController(EastviewDbContext context)
        {
            _context = context;
        }

        // GET: api/Citizens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Citizen>>> GetCitizens()
        {
            return await _context.Citizens.ToListAsync();
        }

        // GET: api/Citizens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Citizen>> GetCitizen(int id)
        {
            var citizen = await _context.Citizens.FindAsync(id);

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

            _context.Entry(citizen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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
            _context.Citizens.Add(citizen);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCitizen", new { id = citizen.Id }, citizen);
        }

        // DELETE: api/Citizens/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Citizen>> DeleteCitizen(int id)
        {
            var citizen = await _context.Citizens.FindAsync(id);
            if (citizen == null)
            {
                return NotFound();
            }

            _context.Citizens.Remove(citizen);
            await _context.SaveChangesAsync();

            return citizen;
        }

        private bool CitizenExists(int id)
        {
            return _context.Citizens.Any(e => e.Id == id);
        }
    }
}