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
using DOAN52.Interfaces;

namespace DOAN52.Controllers
{

    //[Authorize(Roles = Role.Admin)]
    [Route("api/[controller]")]
    [ApiController]

    public class CanBoGiangViensController : ControllerBase
    {
           private readonly ApplicationDbContext _context;
        //private ITeacherBusiness _teacherBusiness;

        public List<TblCanBoGiangVien> GetData = new List<TblCanBoGiangVien>();
        //TblCanBoGiangVien GetTeacher(bool GioiTinh);
        //List<TblCanBoGiangVien> Search(int pageIndex, int pageSize, out long total, string HoVaTen, string DanToc);


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


            [HttpGet("ds")]
            public async Task<ActionResult<IEnumerable<TblCanBoGiangVien>>> Dscanbo()
            {
            var listds = from cb in _context.TblCanBoGiangViens
                         join pk in _context.TblPhongKhoas on cb.MaPk equals pk.MaPk
                         join bm in _context.TblBoMonTrungTams on cb.MaBmtt equals bm.MaBmtt
                         select new
                         {
                             pk.MaPk,
                             pk.TenPhongKhoa,
                             bm.MaBmtt,
                             bm.TenBmtt,
                             cb.MaCbgv,
                             cb.HoVaTen,
                             cb.Image,
                             cb.KinhNghiem,
                             cb.DienThoai,
                             cb.Email,
                             cb.GioiTinh,
                             cb.QueQuan,
                             cb.NgaySinh,
                             cb.Quyen,
                             cb.DanToc,
                             cb.Cmnd,
                             cb.ChucDanh
                         };
                                   
                return Ok(listds);
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
                                         cb.Image,
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

            // GET: api/CanBoGiangViens/get-by-id/{id}
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

            [HttpGet("getgvbypk/{id}")]
            public async Task<ActionResult<IEnumerable<TblCanBoGiangVien>>> GetCanBoGiangViensByPK(string id)
            {
                var dscb = _context.TblCanBoGiangViens.Where(s => s.MaPk == id).ToListAsync(); 
                return await dscb;
            }

        //[Route("get-teacher-gender/{GioiTinh}")]
        //[HttpGet]
        //public TblCanBoGiangVien GetTeacher(bool GioiTinh)
        //{
        //    return _teacherBusiness.GetTeacher(GioiTinh);
        //}
        //[Route("search")]
        //[HttpPost]
        //public Response Search([FromBody] Dictionary<string, object> formData)
        //{
        //    var response = new Response();
        //    try
        //    {
        //        var page = int.Parse(formData["page"].ToString());
        //        var pageSize = int.Parse(formData["pageSize"].ToString());
        //        string HoVaTen = "";
        //        if (formData.Keys.Contains("HoVaTen") && !string.IsNullOrEmpty(Convert.ToString(formData["HoVaTen"])))
        //        { HoVaTen = Convert.ToString(formData["HoVaTen"]); }

        //        string DanToc = "";
        //        if (formData.Keys.Contains("DanToc") && !string.IsNullOrEmpty(Convert.ToString(formData["DanToc"])))
        //        { DanToc = Convert.ToString(formData["DanToc"]); }

        //        long total = 0;
        //        var data = _teacherBusiness.Search(page, pageSize, out total, HoVaTen, DanToc);
        //        response.TotalItems = total;
        //        response.Data = data;
        //        response.Page = page;
        //        response.PageSize = pageSize;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    return response;
        //}






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