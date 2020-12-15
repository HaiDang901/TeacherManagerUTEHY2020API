using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DOAN52.Authentication;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.AspNetCore.Authorization;

namespace DOAN52.Controllers
{
    //[Authorize(Roles = Role.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class CanBoGiangViensController : ControllerBase
    {
            private readonly ApplicationDbContext _context;

            public CanBoGiangViensController(ApplicationDbContext context)
            {
                _context = context;
            }

            // GET: api/CanBoGiangViens/
            [HttpGet]
            public async Task<ActionResult<IEnumerable<TblCanBoGiangVien>>> GetTblCanBoGiangViens()
            {
                return await _context.TblCanBoGiangViens.ToListAsync();
            }
            // GET: api/CanBoGiangViens/dscanbo
            [HttpGet("dscanbo")]
            public async Task<ActionResult<IEnumerable<TblCanBoGiangVien>>> GetTbldscanbo()
            {
                var listcanbo = from cb in _context.TblCanBoGiangViens
                                join l in _context.TblTrinhDoHocVans on cb.MaTdhv equals l.MaTdhv
                                select new
                                {
                                    cb.MaCbgv,
                                    cb.HoVaTen,
                                    cb.GioiTinh,
                                    l.ChungChi,
                                    l.ChuyenNganhDaoTao,
                                    l.DonViCt
                                };
                return Ok(listcanbo);
            }


            [HttpGet("dscanboluong")]
            public async Task<ActionResult<IEnumerable<TblCanBoGiangVien>>> GetTbldscanboluong()
            {
                var listcanboluong = from cb in _context.TblCanBoGiangViens
                                     join b in _context.TblTrinhDoHocVans on cb.MaTdhv equals b.MaTdhv
                                     join l in _context.TblLuongs on cb.MaBac equals l.MaBac
                                     select new
                                     {
                                         cb.MaCbgv,
                                         cb.HoVaTen,
                                         cb.GioiTinh,
                                         b.ChungChi,
                                         b.ChuyenNganhDaoTao,
                                         b.DonViCt,
                                         l.MucLuong,
                                         l.LuongCb,
                                         l.NgayNhan
                                     };
                return Ok(listcanboluong);
            }

            [HttpGet("thongkegv")]
            public async Task<ActionResult<IEnumerable<TblCanBoGiangVien>>> Getthongke()
            {
                var listcanboluong = from cb in _context.TblCanBoGiangViens
                                     where cb.GioiTinh == 1
                                     select new
                                     {
                                         cb,
                                     };
                int s = listcanboluong.ToArray().Length;
                return Ok(s);
            }

            [HttpGet("thongkegvnu")]
            public async Task<ActionResult<IEnumerable<TblCanBoGiangVien>>> Getthongkenu()
            {
                var listcanboluong = from cb in _context.TblCanBoGiangViens
                                     where cb.GioiTinh == 0
                                     select new
                                     {
                                         cb,
                                         cb.HoVaTen,
                                     };
                int s = listcanboluong.ToArray().Length;

                return Ok(s);
            }

            // GET: api/CanBoGiangViens/5
            [HttpGet("get-by-id/{id}")]
            public async Task<ActionResult<TblCanBoGiangVien>> GetTblCanBoGiangVien(string id)
            {
                var tblCanBoGiangVien = await _context.TblCanBoGiangViens.FindAsync(id);

                if (tblCanBoGiangVien == null)
                {
                    return NotFound();
                }

                return tblCanBoGiangVien;
            }

            [HttpGet("searchgiaovien")]
            public async Task<ActionResult<IEnumerable<TblCanBoGiangVien>>> SearchGiaoVien()
            {
                var listcanbo = from cb in _context.TblCanBoGiangViens
                                select new
                                {
                                    cb.MaCbgv,
                                    cb.HoVaTen,
                                    cb.GioiTinh
                                };
                return Ok(listcanbo);
            }

            //[HttpGet("searchgv/{id}/{id1}/{id2}")]
            //public JsonResult GetSearch(string id , string id1 , string id2)
            //{
            //    IEnumerable<dynamic> data = GetData($"exec sp_canbogiangvien_search @page_index = '{id}', @page_size  = '{id1}', @HoVaTen = '{id2}' ");
            //    List<TblCanBoGiangVien> list = new List<TblCanBoGiangVien>();
            //    foreach(dynamic temp in data)
            //    {
            //        MaCbgv = temp.MaCbgv;
            //    }

            //}

            [HttpPut("{id}")]
            public async Task<IActionResult> PutTblCanBoGiangVien(string id, TblCanBoGiangVien tblCanBoGiangVien)
            {
                if (id != tblCanBoGiangVien.MaCbgv)
                {
                    return BadRequest();
                }

                _context.Entry(tblCanBoGiangVien).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblCanBoGiangVienExists(id))
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

            // POST: api/CanBoGiangViens
            // To protect from overposting attacks, enable the specific properties you want to bind to, for
            // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
            [HttpPost]
            public async Task<ActionResult<TblCanBoGiangVien>> PostTblCanBoGiangVien(TblCanBoGiangVien tblCanBoGiangVien)
            {
                _context.TblCanBoGiangViens.Add(tblCanBoGiangVien);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    if (TblCanBoGiangVienExists(tblCanBoGiangVien.MaCbgv))
                    {
                        return Conflict();
                    }
                    else
                    {
                        throw;
                    }
                }

                return CreatedAtAction("GetTblCanBoGiangVien", new { id = tblCanBoGiangVien.MaCbgv }, tblCanBoGiangVien);
            }

            // DELETE: api/CanBoGiangViens/5
            [HttpDelete("{id}")]
            public async Task<ActionResult<TblCanBoGiangVien>> DeleteTblCanBoGiangVien(string id)
            {
                var tblCanBoGiangVien = await _context.TblCanBoGiangViens.FindAsync(id);
                if (tblCanBoGiangVien == null)
                {
                    return NotFound();
                }

                _context.TblCanBoGiangViens.Remove(tblCanBoGiangVien);
                await _context.SaveChangesAsync();

                return tblCanBoGiangVien;
            }

            private bool TblCanBoGiangVienExists(string id)
            {
                return _context.TblCanBoGiangViens.Any(e => e.MaCbgv == id);
            }
        }
    }