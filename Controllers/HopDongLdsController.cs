using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DOAN52.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace DOAN52.Controllers
{
    //[Authorize(Roles = Role.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class HopDongLdsController : ControllerBase
    {

            private readonly ApplicationDbContext _context;

            public HopDongLdsController(ApplicationDbContext context)
            {
                _context = context;
            }

            // GET: api/TblHopDongLds
            [HttpGet]
            public async Task<ActionResult<IEnumerable<TblHopDongLd>>> GetTblHopDongLd()
            {
                return await _context.TblHopDongLds.ToListAsync();
            }

            // GET: api/TblHopDongLds/5
            [HttpGet("{id}")]
            public async Task<ActionResult<TblHopDongLd>> GetTblHopDongLd(long id)
            {
                var tblHopDongLd = await _context.TblHopDongLds.FindAsync(id);

                if (tblHopDongLd == null)
                {
                    return NotFound();
                }

                return tblHopDongLd;
            }

            // PUT: api/TblHopDongLds/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for
            // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
            [HttpPut("{id}")]
            public async Task<IActionResult> PutTblHopDongLd(long id, TblHopDongLd tblHopDongLd)
            {
                if (id != tblHopDongLd.MaHd)
                {
                    return BadRequest();
                }

                _context.Entry(tblHopDongLd).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblHopDongLdExists(id))
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

            // POST: api/TblHopDongLds
            // To protect from overposting attacks, enable the specific properties you want to bind to, for
            // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
            [HttpPost]
            public async Task<ActionResult<TblHopDongLd>> PostTblHopDongLd(TblHopDongLd tblHopDongLd)
            {
                _context.TblHopDongLds.Add(tblHopDongLd);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetTblHopDongLd", new { id = tblHopDongLd.MaHd }, tblHopDongLd);
            }

            // DELETE: api/TblHopDongLds/5
            [HttpDelete("{id}")]
            public async Task<ActionResult<TblHopDongLd>> DeleteTblHopDongLd(long id)
            {
                var tblHopDongLd = await _context.TblHopDongLds.FindAsync(id);
                if (tblHopDongLd == null)
                {
                    return NotFound();
                }

                _context.TblHopDongLds.Remove(tblHopDongLd);
                await _context.SaveChangesAsync();

                return tblHopDongLd;
            }

            private bool TblHopDongLdExists(long id)
            {
                return _context.TblHopDongLds.Any(e => e.MaHd == id);
            }
        }
    }
