using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DOAN52.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System;

namespace DOAN52.Controllers
{

    //[Authorize(Roles = Role.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class TrinhDoHocVansController : ControllerBase
    {
            private readonly ApplicationDbContext _context;

            public TrinhDoHocVansController(ApplicationDbContext context)
            {
                _context = context;
            }

            // GET: api/TblTrinhDoHocVans
            [HttpGet]
            public async Task<ActionResult<IEnumerable<TblTrinhDoHocVan>>> GetTblTrinhDoHocVan()
            {
                return await _context.TblTrinhDoHocVans.ToListAsync();
            }

            // GET: api/TblTrinhDoHocVans/5
            [HttpGet("{id}")]
            public async Task<ActionResult<TblTrinhDoHocVan>> GetTblTrinhDoHocVan(long id)
            {
                var tblTrinhDoHocVan = await _context.TblTrinhDoHocVans.FindAsync(id);

                if (tblTrinhDoHocVan == null)
                {
                    return NotFound();
                }

                return tblTrinhDoHocVan;
            }

            // PUT: api/TblTrinhDoHocVans/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for
            // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
            [HttpPut("{id}")]
            public async Task<IActionResult> PutTblTrinhDoHocVan(long id, TblTrinhDoHocVan tblTrinhDoHocVan)
            {
                if (id != tblTrinhDoHocVan.MaTdhv)
                {
                    return BadRequest();
                }

                _context.Entry(tblTrinhDoHocVan).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblTrinhDoHocVanExists(id))
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

            // POST: api/TblTrinhDoHocVans
            // To protect from overposting attacks, enable the specific properties you want to bind to, for
            // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
            [HttpPost]
            public async Task<ActionResult<TblTrinhDoHocVan>> PostTblTrinhDoHocVan(TblTrinhDoHocVan tblTrinhDoHocVan)
            {
                _context.TblTrinhDoHocVans.Add(tblTrinhDoHocVan);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetTblTrinhDoHocVan", new { id = tblTrinhDoHocVan.MaTdhv }, tblTrinhDoHocVan);
            }

            // DELETE: api/TblTrinhDoHocVans/5
            [HttpDelete("{id}")]
            public async Task<ActionResult<TblTrinhDoHocVan>> DeleteTblTrinhDoHocVan(long id)
            {
                var tblTrinhDoHocVan = await _context.TblTrinhDoHocVans.FindAsync(id);
                if (tblTrinhDoHocVan == null)
                {
                    return NotFound();
                }

                _context.TblTrinhDoHocVans.Remove(tblTrinhDoHocVan);
                await _context.SaveChangesAsync();

                return tblTrinhDoHocVan;
            }

            private bool TblTrinhDoHocVanExists(long id)
            {
                return _context.TblTrinhDoHocVans.Any(e => e.MaTdhv == id);
            }
        }
    }
