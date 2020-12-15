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
    public class PhongKhoasController : ControllerBase
    {
            private readonly ApplicationDbContext _context;

            public PhongKhoasController(ApplicationDbContext context)
            {
                _context = context;
            }

            // GET: api/PhongKhoas
            [HttpGet]
            public async Task<ActionResult<IEnumerable<TblPhongKhoa>>> GetTblPhongKhoas()
            {
                return await _context.TblPhongKhoas.ToListAsync();
            }

            // GET: api/PhongKhoas/GetPhongKhoaDetails/CNTT
            [HttpGet("GetPhongKhoaDetails/{id}")]
            public async Task<ActionResult<TblPhongKhoa>> GetPhongKhoaDetails(string id)
            {
                #region EagerLoading
                //var tblPhongKhoa = await _context.TblPhongKhoas
                //                        .Include(pub => pub.TblBoMonTrungTams)
                //                        .Include(pub => pub.TblCanBoGiangViens)
                //                            .ThenInclude(tech => tech.TblLyLichGvs)
                //                        .Include(pub => pub.TblCanBoGiangViens)
                //                            .ThenInclude(tech => tech.TblDkgiangDays)
                //                        .Include(pub => pub.TblCanBoGiangViens)
                //                            .ThenInclude(tech => tech.TblGiaoVienChuNhiems)
                //                        .Include(pub => pub.TblHocPhans)

                //                        .Where(pub => pub.MaPk == id)
                //                        .FirstOrDefaultAsync();
                #endregion


                var tblPhongKhoa = await _context.TblPhongKhoas.SingleAsync(pub => pub.MaPk == id);

                _context.Entry(tblPhongKhoa)
                    .Collection(pub => pub.TblBoMonTrungTam)
                    .Query()
                    .Where(bmtt => bmtt.TenBmtt.Contains("Công Nghệ")) //Liệt kê ra các bộ môn có tên Công Nghệ
                    .Load();

                _context.Entry(tblPhongKhoa)
                    .Collection(pub => pub.TblCanBoGiangVien)
                    .Query()
                    .Include(tech => tech.TblLyLichGv)
                    .Load();

                _context.Entry(tblPhongKhoa)
                    .Collection(pub => pub.TblCanBoGiangVien)
                    .Query()
                    .Include(tech => tech.TblDkgiangDay)
                    .Load();

                _context.Entry(tblPhongKhoa)
                    .Collection(pub => pub.TblCanBoGiangVien)
                    .Query()
                    .Include(tech => tech.TblGiaoVienChuNhiem)
                    .Load();
                _context.Entry(tblPhongKhoa)
                    .Collection(pub => pub.TblHocPhan)
                    .Load();

                if (tblPhongKhoa == null)
                {
                    return NotFound();
                }

                return tblPhongKhoa;
            }
            // POSST: api/PhongKhoas/PostPhongKhoaDetails/CNTT
            [HttpPost("PostPhongKhoaDetails/")]
            public async Task<ActionResult<TblPhongKhoa>> PostPhongKhoaDetails()
            {
                var khoa = new TblPhongKhoa();
                khoa.MaPk = "L";
                khoa.TenPhongKhoa = "Khoa Luật";
                khoa.SoLuongNhanSu = 50;
                khoa.PhanLoai = 4;
                khoa.DiaChi = "Dân Tiến - Khoái Châu - Hưng Yên";
                khoa.Email = "dientuutehy@gmail.com";
                khoa.NgayTao = DateTime.Now;
                khoa.NguoiTao = "Nguyễn Hải Đăng";

                TblBoMonTrungTam bomon = new TblBoMonTrungTam();
                bomon.MaBmtt = "LNG";
                bomon.MaPk = "L";
                bomon.TenBmtt = " Luật Ngoại Giao";
                bomon.SoLuongNhanSu = 10;
                bomon.PhanLoai = 3;
                bomon.DiaChi = "Ngã Tư Dân Tiến Khoái Châu Hưng Yên ";
                bomon.DienThoai = "0352340838";
                bomon.NgayTao = DateTime.Now;
                bomon.NguoiTao = "Nguyễn Hải Đăng";

                TblCanBoGiangVien giaovien = new TblCanBoGiangVien();
                giaovien.MaCbgv = "GV61";
                giaovien.MaPk = "L";
                giaovien.MaBmtt = "LNG";
                giaovien.MaNgach = 1;
                giaovien.MaBac = 1;
                giaovien.MaTdhv = 5;
                giaovien.MaKtkl = 2;
                giaovien.HoVaTen = " Nguyễn Đặng Nhung Hoa";
                //giaovien.NgaySinh = DateTime.Equals("1993 / 04 / 23");
                giaovien.GioiTinh = 1;
                giaovien.MatKhau = "31031999";
                giaovien.DienThoai = "0352340838";
                giaovien.Email = "haidang1999@gmail.com";
                giaovien.ChucDanh = "GV";
                giaovien.Status = 1;
                giaovien.Quyen = 1;
                giaovien.QueQuan = "Văn Giang - Hưng Yên";
                giaovien.DanToc = "Dân tộc Kinh";
                giaovien.TonGiao = "Phật Giáo ";
                giaovien.TrinhDo = "";
                giaovien.KinhNghiem = "";
                giaovien.NgayCap = DateTime.Now;
                giaovien.NguoiTao = "Nguyễn Hải Đăng";
                TblGiaoVienChuNhiem gvcn = new TblGiaoVienChuNhiem();
                gvcn.MaLop = "TK15.3";
                gvcn.MaCbgv = "GV61";
                gvcn.BatDau = DateTime.Now;
                gvcn.KetThuc = DateTime.Now;
                gvcn.HieuLuc = 2;
                gvcn.NgayTao = DateTime.Now;
                gvcn.NguoiTao = " Nguyễn Hải Đăng";

                giaovien.TblGiaoVienChuNhiem.Add(gvcn);

                TblLyLichGv llgv = new TblLyLichGv();
                llgv.MaCbgv = "GV61";
                llgv.TenLl = "Báo Cáo Khoa Học";
                llgv.LoaiLl = "Bài Báo";
                llgv.Status = 1;

                giaovien.TblLyLichGv.Add(llgv);

                TblHocPhan hp = new TblHocPhan();
                hp.MaHp = "LENG";
                hp.MaPk = "L";
                hp.MaBmtt = "LNG";
                hp.TenHocPhan = "Low English";
                hp.HocKy = 1;
                hp.TinhChat = 1;
                hp.SoTinChi = 4;
                hp.SoTinChiLt = 2.5;
                hp.SoTinChiTh = 1.5;
                hp.HeSo = 1.3;
                hp.SoThuTu = 4;
                hp.GhiChu = "Dánh co dân chuyên bên kĩ thuật điện dân dụng";
                hp.NgayTao = DateTime.Now;
                hp.NguoiTao = "Nguyễn Hải Đăng";

                khoa.TblBoMonTrungTam.Add(bomon);
                khoa.TblCanBoGiangVien.Add(giaovien);
                khoa.TblHocPhan.Add(hp);

                _context.TblPhongKhoas.Add(khoa);
                _context.SaveChanges();

                var tblPhongKhoa = await _context.TblPhongKhoas
                                        .Include(pub => pub.TblBoMonTrungTam)
                                        .Include(pub => pub.TblCanBoGiangVien)
                                            .ThenInclude(tech => tech.TblLyLichGv)
                                        .Include(pub => pub.TblCanBoGiangVien)
                                            .ThenInclude(tech => tech.TblDkgiangDay)
                                        .Include(pub => pub.TblCanBoGiangVien)
                                            .ThenInclude(tech => tech.TblGiaoVienChuNhiem)
                                        .Where(pub => pub.MaPk == khoa.MaPk)
                                        .FirstOrDefaultAsync();

                if (tblPhongKhoa == null)
                {
                    return NotFound();
                }

                return tblPhongKhoa;
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> PutTblPhongKhoa(string id, TblPhongKhoa tblPhongKhoa)
            {
                if (id != tblPhongKhoa.MaPk)
                {
                    return BadRequest();
                }

                _context.Entry(tblPhongKhoa).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblPhongKhoaExists(id))
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


            [HttpPost]
            public async Task<ActionResult<TblPhongKhoa>> PostTblPhongKhoa(TblPhongKhoa tblPhongKhoa)
            {
                _context.TblPhongKhoas.Add(tblPhongKhoa);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    if (TblPhongKhoaExists(tblPhongKhoa.MaPk))
                    {
                        return Conflict();
                    }
                    else
                    {
                        throw;
                    }
                }

                return CreatedAtAction("GetTblPhongKhoa", new { id = tblPhongKhoa.MaPk }, tblPhongKhoa);
            }

            // DELETE: api/PhongKhoas/5
            [HttpDelete("{id}")]
            public async Task<ActionResult<TblPhongKhoa>> DeleteTblPhongKhoa(string id)
            {
                var tblPhongKhoa = await _context.TblPhongKhoas.FindAsync(id);
                if (tblPhongKhoa == null)
                {
                    return NotFound();
                }

                _context.TblPhongKhoas.Remove(tblPhongKhoa);
                await _context.SaveChangesAsync();

                return tblPhongKhoa;
            }

            private bool TblPhongKhoaExists(string id)
            {
                return _context.TblPhongKhoas.Any(e => e.MaPk == id);
            }
        }
    }
