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
    public class LyLichGvsController : ControllerBase
    {
            private readonly ApplicationDbContext _context;

            public LyLichGvsController(ApplicationDbContext context)
            {
                _context = context;
            }

            // GET: api/LyLichGvs
            [HttpGet]
            public async Task<ActionResult<IEnumerable<TblLyLichGv>>> GetTblLyLichGv()
            {
                return await _context.TblLyLichGvs.ToListAsync();
            }

            // GET: api/LyLichGvs/5
            [HttpGet("{id}")]
            public async Task<ActionResult<TblLyLichGv>> GetTblLyLichGv(long id)
            {
                var tblLyLichGv = await _context.TblLyLichGvs.FindAsync(id);

                if (tblLyLichGv == null)
                {
                    return NotFound();
                }

                return tblLyLichGv;
            }

            // PUT: api/LyLichGvs/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for
            // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
            [HttpPut("{id}")]
            public async Task<IActionResult> PutTblLyLichGv(long id, TblLyLichGv tblLyLichGv)
            {
                if (id != tblLyLichGv.MaLl)
                {
                    return BadRequest();
                }

                _context.Entry(tblLyLichGv).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblLyLichGvExists(id))
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

            // POST: api/LyLichGvs
            // To protect from overposting attacks, enable the specific properties you want to bind to, for
            // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
            [HttpPost]
            public async Task<ActionResult<TblLyLichGv>> PostTblLyLichGv(TblLyLichGv tblLyLichGv)
            {
                _context.TblLyLichGvs.Add(tblLyLichGv);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetTblLyLichGv", new { id = tblLyLichGv.MaLl }, tblLyLichGv);
            }

            // DELETE: api/LyLichGvs/5
            [HttpDelete("{id}")]
            public async Task<ActionResult<TblLyLichGv>> DeleteTblLyLichGv(long id)
            {
                var tblLyLichGv = await _context.TblLyLichGvs.FindAsync(id);
                if (tblLyLichGv == null)
                {
                    return NotFound();
                }

                _context.TblLyLichGvs.Remove(tblLyLichGv);
                await _context.SaveChangesAsync();

                return tblLyLichGv;
            }

            private bool TblLyLichGvExists(long id)
            {
                return _context.TblLyLichGvs.Any(e => e.MaLl == id);
            }
        }
    }
