using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DOAN52.Authentication;
//using DOAN52.Models;
using Microsoft.AspNetCore.Authorization;


namespace DOAN52.Controllers
{
    //[Authorize(Roles = Role.Admin)]

    [Route("api/[controller]")]
    [ApiController]
    public class BacLuongsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BacLuongsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/BacLuongs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblBacLuong>>> GetTblBacLuongs()
        {
            return await _context.TblBacLuongs.ToListAsync();
        }

        // GET: api/BacLuongs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblBacLuong>> GetTblBacLuong(long id)
        {
            var tblBacLuong = await _context.TblBacLuongs.FindAsync(id);

            if (tblBacLuong == null)
            {
                return NotFound();
            }

            return tblBacLuong;
        }

        // PUT: api/BacLuongs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblBacLuong(long id, TblBacLuong tblBacLuong)
        {
            if (id != tblBacLuong.MaBac)
            {
                return BadRequest();
            }

            _context.Entry(tblBacLuong).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblBacLuongExists(id))
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
        public async Task<ActionResult<TblBacLuong>> PostTblBacLuong(TblBacLuong tblBacLuong)
        {
            _context.TblBacLuongs.Add(tblBacLuong);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblBacLuong", new { id = tblBacLuong.MaBac }, tblBacLuong);
        }

        // DELETE: api/BacLuongs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblBacLuong>> DeleteTblBacLuong(long id)
        {
            var tblBacLuong = await _context.TblBacLuongs.FindAsync(id);
            if (tblBacLuong == null)
            {
                return NotFound();
            }

            _context.TblBacLuongs.Remove(tblBacLuong);
            await _context.SaveChangesAsync();

            return tblBacLuong;
        }

        private bool TblBacLuongExists(long id)
        {
            return _context.TblBacLuongs.Any(e => e.MaBac == id);
        }
    }
}
