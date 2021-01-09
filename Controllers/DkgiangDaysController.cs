using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DOAN52.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;


namespace DOAN52.Controllers
{
    //[Authorize(Roles = Role.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class DkgiangDaysController : ControllerBase
    {
            private readonly ApplicationDbContext _context;

            public DkgiangDaysController(ApplicationDbContext context)
            {
                _context = context;
            }

        // GET: api/TblDkgiangDays
            [HttpGet("dangki")]
            public async Task<ActionResult<IEnumerable<TblDkgiangDay>>> GetTblDkgiangDay()
            {
                return await _context.TblDkgiangDays.ToListAsync();
            }
            [HttpGet]
            public async Task<ActionResult<IEnumerable<TblDkgiangDay>>> DkgiangDay()
            {
                //return await _context.TblBoMonTrungTams.ToListAsync();
                var listdangki = from bm in _context.TblDkgiangDays
                                 join pk in _context.TblCanBoGiangViens on bm.MaCbgv equals pk.MaCbgv
                                 join l in _context.TblHocPhans on bm.MaHp equals l.MaHp
                                 select new
                                {
                                    pk.MaCbgv,
                                    pk.HoVaTen,
                                    bm.MaDkgd,
                                    l.MaHp,
                                    l.TenHocPhan,
                                    bm.GhiChu,
                                    bm.NgayDk,
                                    pk.Status,
                                };
                return Ok(listdangki);
            }

        // GET: api/TblDkgiangDays/5
        [HttpGet("{id}")]
            public async Task<ActionResult<TblDkgiangDay>> GetTblDkgiangDay(long id)
            {
                var tblDkgiangDay = await _context.TblDkgiangDays.FindAsync(id);

                if (tblDkgiangDay == null)
                {
                    return NotFound();
                }

                return tblDkgiangDay;
            }

            // PUT: api/TblDkgiangDays/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for
            // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
            [HttpPut("{id}")]
            public async Task<IActionResult> PutTblDkgiangDay(long id, TblDkgiangDay tblDkgiangDay)
            {
                if (id != tblDkgiangDay.MaDkgd)
                {
                    return BadRequest();
                }

                _context.Entry(tblDkgiangDay).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblDkgiangDayExists(id))
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

            // POST: api/TblDkgiangDays
            // To protect from overposting attacks, enable the specific properties you want to bind to, for
            // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
            [HttpPost]
            public async Task<ActionResult<TblDkgiangDay>> PostTblDkgiangDay(TblDkgiangDay tblDkgiangDay)
            {
                _context.TblDkgiangDays.Add(tblDkgiangDay);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetTblDkgiangDay", new { id = tblDkgiangDay.MaDkgd }, tblDkgiangDay);
            }

            // DELETE: api/TblDkgiangDays/5
            [HttpDelete("{id}")]
            public async Task<ActionResult<TblDkgiangDay>> DeleteTblDkgiangDay(long id)
            {
                var tblDkgiangDay = await _context.TblDkgiangDays.FindAsync(id);
                if (tblDkgiangDay == null)
                {
                    return NotFound();
                }

                _context.TblDkgiangDays.Remove(tblDkgiangDay);
                await _context.SaveChangesAsync();

                return tblDkgiangDay;
            }

            private bool TblDkgiangDayExists(long id)
            {
                return _context.TblDkgiangDays.Any(e => e.MaDkgd == id);
            }
    }
}