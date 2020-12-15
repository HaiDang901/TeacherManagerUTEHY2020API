using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DOAN52.Authentication;

namespace DOAN52.Controllers
{
    //[Authorize(Roles = Role.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class GiaoVienChuNhiemsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GiaoVienChuNhiemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/GiaoVienChuNhiems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblGiaoVienChuNhiem>>> GetTblGiaoVienChuNhiem()
        {
            return await _context.TblGiaoVienChuNhiems.ToListAsync();
        }

        // GET: api/GiaoVienChuNhiems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblGiaoVienChuNhiem>> GetTblGiaoVienChuNhiem(long id)
        {
            var tblGiaoVienChuNhiem = await _context.TblGiaoVienChuNhiems.FindAsync(id);

            if (tblGiaoVienChuNhiem == null)
            {
                return NotFound();
            }

            return tblGiaoVienChuNhiem;
        }

        // PUT: api/GiaoVienChuNhiems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblGiaoVienChuNhiem(long id, TblGiaoVienChuNhiem tblGiaoVienChuNhiem)
        {
            if (id != tblGiaoVienChuNhiem.MaGvcn)
            {
                return BadRequest();
            }

            _context.Entry(tblGiaoVienChuNhiem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblGiaoVienChuNhiemExists(id))
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

        // POST: api/GiaoVienChuNhiems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblGiaoVienChuNhiem>> PostTblGiaoVienChuNhiem(TblGiaoVienChuNhiem tblGiaoVienChuNhiem)
        {
            _context.TblGiaoVienChuNhiems.Add(tblGiaoVienChuNhiem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblGiaoVienChuNhiem", new { id = tblGiaoVienChuNhiem.MaGvcn }, tblGiaoVienChuNhiem);
        }

        // DELETE: api/GiaoVienChuNhiems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblGiaoVienChuNhiem>> DeleteTblGiaoVienChuNhiem(long id)
        {
            var tblGiaoVienChuNhiem = await _context.TblGiaoVienChuNhiems.FindAsync(id);
            if (tblGiaoVienChuNhiem == null)
            {
                return NotFound();
            }

            _context.TblGiaoVienChuNhiems.Remove(tblGiaoVienChuNhiem);
            await _context.SaveChangesAsync();

            return tblGiaoVienChuNhiem;
        }

        private bool TblGiaoVienChuNhiemExists(long id)
        {
            return _context.TblGiaoVienChuNhiems.Any(e => e.MaGvcn == id);
        }
    }
}
