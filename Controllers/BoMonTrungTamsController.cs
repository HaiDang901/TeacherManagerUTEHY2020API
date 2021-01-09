using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DOAN52.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace DOAN52.Controllers
{
    //[Authorize(Roles = Role.Admin)]
    [Route("api/[controller]")]
    [ApiController]

    public class BoMonTrungTamsController : ControllerBase
    {
            private readonly ApplicationDbContext _context;

            public BoMonTrungTamsController(ApplicationDbContext context)
            {
                _context = context;
            }

        // GET: api/BoMonTrungTams
        [HttpGet("dsBoMonTrungTam")]
        public async Task<ActionResult<IEnumerable<TblBoMonTrungTam>>> GetTblBoMonTrungTams()
            {
            //return await _context.TblBoMonTrungTams.ToListAsync();
                var listbomon = from bm in _context.TblBoMonTrungTams
                            join pk in _context.TblPhongKhoas on bm.MaPk equals pk.MaPk
                            select new
                            {
                                pk.TenPhongKhoa,
                                pk.MaPk,
                                bm.MaBmtt,
                                bm.TenBmtt,
                                bm.SoLuongNhanSu,
                                bm.DiaChi,
                                pk.Webiste,
                                pk.NguoiTao,
                                pk.NgayTao
                            };
            return Ok(listbomon);
        }
            [HttpGet("dsbomon")]
            public async Task<ActionResult<IEnumerable<TblBoMonTrungTam>>> Getdsbomon()
            {
                var listbomon = from bm in _context.TblBoMonTrungTams
                                join pk in _context.TblPhongKhoas on bm.MaPk equals pk.MaPk
                                select new
                                {
                                    pk.TenPhongKhoa,
                                    bm.MaBmtt,
                                    bm.TenBmtt,
                                    bm.SoLuongNhanSu,
                                    bm.DiaChi,
                                    pk.Webiste,
                                    pk.NguoiTao,
                                    pk.NgayTao
                                };
                return Ok(listbomon);
            }
            //public List<TblCanBoGiangVien> Search(int pageIndex, int pageSize, out long total, string MaGiaoDich)
            //{
            //    string msgError = "";
            //    total = 0;
            //    try
            //    {
            //        var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_phieuthu_search",
            //            "@page_index", pageIndex,
            //            "@page_size", pageSize,
            //            "@MaGiaoDich", MaGiaoDich
            //            );
            //        if (!string.IsNullOrEmpty(msgError))
            //            throw new Exception(msgError);
            //        if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
            //        return dt.ConvertTo<TblCanBoGiangVien>().ToList();
            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }
            //}

            // GET: api/BoMonTrungTams/5
            [HttpGet("get-by-id/{id}")]
            public async Task<ActionResult<TblBoMonTrungTam>> GetTblBoMonTrungTam(string id)
            {
                var tblBoMonTrungTam = await _context.TblBoMonTrungTams.FindAsync(id);

                if (tblBoMonTrungTam == null)
                {
                    return NotFound();
                }

                return tblBoMonTrungTam;
            }

            [HttpGet("id")]
            public async Task<ActionResult> GetBoMon( string id)
            {
            var bomon = from t1 in _context.TblBoMonTrungTams.Include(x => x.MaPkNavigation)
                         where t1.MaPk == id
                        select t1;
            return Ok(bomon.First());
            }
            //[HttpGet("getBMbyPB")]
            //public async Task<ActionResult> GetBMbyPB()
            //{
            //    var bomon = from t1 in _context.TblBoMonTrungTams.Include(x => x.MaPkNavigation)
            //                where t1.MaBmtt == maPk
            //                select t1;
            //    return Ok(bomon.ToList());
            //}

        // PUT: api/BoMonTrungTams/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
            public async Task<IActionResult> PutTblBoMonTrungTam(string id, TblBoMonTrungTam tblBoMonTrungTam)
            {
                if (id != tblBoMonTrungTam.MaBmtt)
                {
                    return BadRequest();
                }

                _context.Entry(tblBoMonTrungTam).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblBoMonTrungTamExists(id))
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

            // POST: api/BoMonTrungTams
            // To protect from overposting attacks, enable the specific properties you want to bind to, for
            // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
            [HttpPost]
            [HttpPost("createBM")]
            public async Task<ActionResult<TblBoMonTrungTam>> PostTblBoMonTrungTam(TblBoMonTrungTam tblBoMonTrungTam)
            {
                _context.TblBoMonTrungTams.Add(tblBoMonTrungTam);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    if (TblBoMonTrungTamExists(tblBoMonTrungTam.MaBmtt))
                    {
                        return Conflict();
                    }
                    else
                    {
                        throw;
                    }
                }

                return CreatedAtAction("GetTblBoMonTrungTam", new { id = tblBoMonTrungTam.MaBmtt }, tblBoMonTrungTam);
            }






        // DELETE: api/BoMonTrungTams/5
        [HttpDelete("{id}")]
            public async Task<ActionResult<TblBoMonTrungTam>> DeleteTblBoMonTrungTam(string id)
            {
                var tblBoMonTrungTam = await _context.TblBoMonTrungTams.FindAsync(id);
                if (tblBoMonTrungTam == null)
                {
                    return NotFound();
                }

                _context.TblBoMonTrungTams.Remove(tblBoMonTrungTam);
                await _context.SaveChangesAsync();

                return tblBoMonTrungTam;
            }

            private bool TblBoMonTrungTamExists(string id)
            {
                return _context.TblBoMonTrungTams.Any(e => e.MaBmtt == id);
            }
        }
    }
