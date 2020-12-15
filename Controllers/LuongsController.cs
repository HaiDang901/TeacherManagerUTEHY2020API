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
    public class LuongsController : ControllerBase
    {
            private readonly ApplicationDbContext _context;

            public LuongsController(ApplicationDbContext context)
            {
                _context = context;
            }
            // GET: api/<LuongController>
            [HttpGet]

            public async Task<ActionResult<IEnumerable<TblLuong>>> GetTblLuongs()
            {
                return await _context.TblLuongs.ToListAsync();
            }

            // GET: api/Luongs/5
            [HttpGet("{id}")]
            public async Task<ActionResult<TblLuong>> GetTblLuong(long id)
            {
                var tblLuong = await _context.TblLuongs.FindAsync(id);

                if (tblLuong == null)
                {
                    return NotFound();
                }

                return tblLuong;
            }

            // PUT: api/Luongs/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for
            // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
            [HttpPut("{id}")]
            public async Task<IActionResult> PutTblLuong(long id, TblLuong tblLuong)
            {
                if (id != tblLuong.MaLuong)
                {
                    return BadRequest();
                }

                _context.Entry(tblLuong).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblLuongExists(id))
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

            // POST: api/BacLuongs
            // To protect from overposting attacks, enable the specific properties you want to bind to, for
            // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
            [HttpPost]
            public async Task<ActionResult<TblLuong>> PostTblLuong(TblLuong tblLuong)
            {
                _context.TblLuongs.Add(tblLuong);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetTblLuong", new { id = tblLuong.MaLuong }, tblLuong);
            }

            // DELETE: api/BacLuongs/5
            [HttpDelete("{id}")]
            public async Task<ActionResult<TblLuong>> DeleteTblLuong(long id)
            {
                var tblLuong = await _context.TblLuongs.FindAsync(id);
                if (tblLuong == null)
                {
                    return NotFound();
                }

                _context.TblLuongs.Remove(tblLuong);
                await _context.SaveChangesAsync();

                return tblLuong;
            }

            private bool TblLuongExists(long id)
            {
                return _context.TblLuongs.Any(e => e.MaLuong == id);
            }
        }
    }

