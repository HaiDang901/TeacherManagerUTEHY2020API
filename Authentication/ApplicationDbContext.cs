
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOAN52.Authentication
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public virtual DbSet<QuanLyPhienBan> QuanLyPhienBans { get; set; }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
        public virtual DbSet<TblBacLuong> TblBacLuongs { get; set; }
        public virtual DbSet<TblBoMonTrungTam> TblBoMonTrungTams { get; set; }
        public virtual DbSet<TblCanBoGiangVien> TblCanBoGiangViens { get; set; }
        public virtual DbSet<TblChiTietPhieuThu> TblChiTietPhieuThus { get; set; }
        public virtual DbSet<TblChuongTrinhDaoTao> TblChuongTrinhDaoTaos { get; set; }
        public virtual DbSet<TblChuongTrinhDaoTaoChiTiet> TblChuongTrinhDaoTaoChiTiets { get; set; }
        public virtual DbSet<TblDiemHocPhan> TblDiemHocPhans { get; set; }
        public virtual DbSet<TblDiemHocPhanChiTiet> TblDiemHocPhanChiTiets { get; set; }
        public virtual DbSet<TblDinhMucHocPhi> TblDinhMucHocPhis { get; set; }
        public virtual DbSet<TblDkgiangDay> TblDkgiangDays { get; set; }
        public virtual DbSet<TblGiaoVienChuNhiem> TblGiaoVienChuNhiems { get; set; }
        public virtual DbSet<TblHocPhan> TblHocPhans { get; set; }
        public virtual DbSet<TblHopDongLd> TblHopDongLds { get; set; }
        public virtual DbSet<TblKhenThuongKiLuat> TblKhenThuongKiLuats { get; set; }
        public virtual DbSet<TblKhoanThu> TblKhoanThus { get; set; }
        public virtual DbSet<TblLophoc> TblLophocs { get; set; }
        public virtual DbSet<TblLuong> TblLuongs { get; set; }
        public virtual DbSet<TblLyLichGv> TblLyLichGvs { get; set; }
        public virtual DbSet<TblNgachCongChuc> TblNgachCongChucs { get; set; }
        public virtual DbSet<TblNganHang> TblNganHangs { get; set; }
        public virtual DbSet<TblNganhDaoTao> TblNganhDaoTaos { get; set; }
        public virtual DbSet<TblPhieuThu> TblPhieuThus { get; set; }
        public virtual DbSet<TblPhongKhoa> TblPhongKhoas { get; set; }
        public virtual DbSet<TblQuanLyPhienBan> TblQuanLyPhienBans { get; set; }
        public virtual DbSet<TblSinhVienLopHoc> TblSinhVienLopHocs { get; set; }
        public virtual DbSet<TblSinhvien> TblSinhviens { get; set; }
        public virtual DbSet<TblSoGhiNoSinhVien> TblSoGhiNoSinhViens { get; set; }
        public virtual DbSet<TblTrinhDoHocVan> TblTrinhDoHocVans { get; set; }
        public virtual DbSet<TblUyNhiemThu> TblUyNhiemThus { get; set; }
        public virtual DbSet<User> User { get; set; }
        //public virtual DbSet<RegisterModel> RegisterModel { get ; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnStr");
            }
        }
            //base.OnModelCreating(builder);


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuanLyPhienBan>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("QuanLyPhienBan", "nhutero5_utehy");

                entity.Property(e => e.PhienBan)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.HasKey(e => e.TokenId);

                entity.ToTable("RefreshToken");

                entity.Property(e => e.TokenId).HasColumnName("token_id");

                entity.Property(e => e.ExpiryDate)
                    .HasColumnName("expiry_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Token)
                    .HasColumnName("token")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("user_id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RefreshToken)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__RefreshTo__user___4F47C5E3");
            });

            modelBuilder.Entity<TblBacLuong>(entity =>
            {
                entity.HasKey(e => e.MaBac);

                entity.ToTable("tblBacLuong");

                entity.Property(e => e.Dp1)
                    .HasColumnName("DP1")
                    .HasColumnType("text");

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.Property(e => e.NguoiTao).HasMaxLength(50);

                entity.Property(e => e.NhomBac).HasColumnType("ntext");

                entity.Property(e => e.TenBac).HasMaxLength(255);
            });

            modelBuilder.Entity<TblBoMonTrungTam>(entity =>
            {
                entity.HasKey(e => e.MaBmtt);

                entity.ToTable("tblBoMonTrungTam");

                entity.Property(e => e.MaBmtt)
                    .HasColumnName("MaBMTT")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DiaChi).HasColumnType("ntext");

                entity.Property(e => e.DienThoai)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Dp1)
                    .HasColumnName("DP1")
                    .HasColumnType("ntext");

                entity.Property(e => e.Dp2)
                    .HasColumnName("DP2")
                    .HasColumnType("ntext");

                entity.Property(e => e.Dp3)
                    .HasColumnName("DP3")
                    .HasColumnType("ntext");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.GhiChu).HasColumnType("ntext");

                entity.Property(e => e.MaPk)
                    .HasColumnName("MaPK")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.Property(e => e.NguoiTao).HasMaxLength(50);

                entity.Property(e => e.TenBmtt)
                    .HasColumnName("TenBMTT")
                    .HasMaxLength(50);

                entity.Property(e => e.Website).HasMaxLength(200);

                entity.HasOne(d => d.MaPkNavigation)
                    .WithMany(p => p.TblBoMonTrungTam)
                    .HasForeignKey(d => d.MaPk)
                    .HasConstraintName("FK_tblBoMonTrungTam_tblPhongKhoa");
            });

            modelBuilder.Entity<TblCanBoGiangVien>(entity =>
            {
                entity.HasKey(e => e.MaCbgv);

                entity.ToTable("tblCanBoGiangVien");

                entity.Property(e => e.MaCbgv)
                    .HasColumnName("MaCBGV")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AiCap).HasMaxLength(255);

                entity.Property(e => e.ChucDanh).HasMaxLength(10);

                entity.Property(e => e.Cmnd)
                    .HasColumnName("CMND")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DanToc).HasMaxLength(50);

                entity.Property(e => e.DienThoai).HasColumnType("ntext");

                entity.Property(e => e.Dp1)
                    .HasColumnName("DP1")
                    .HasColumnType("ntext");

                entity.Property(e => e.Dp2)
                    .HasColumnName("DP2")
                    .HasColumnType("ntext");

                entity.Property(e => e.Dp3)
                    .HasColumnName("DP3")
                    .HasColumnType("ntext");

                entity.Property(e => e.Email).HasColumnType("ntext");

                entity.Property(e => e.HoVaTen).HasMaxLength(50);

                entity.Property(e => e.Image).HasMaxLength(255);

                entity.Property(e => e.KinhNghiem).HasColumnType("ntext");

                entity.Property(e => e.MaBmtt)
                    .HasColumnName("MaBMTT")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaKtkl).HasColumnName("MaKTKL");

                entity.Property(e => e.MaPk)
                    .HasColumnName("MaPK")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaTdhv).HasColumnName("MaTDHV");

                entity.Property(e => e.MatKhau).HasColumnType("ntext");

                entity.Property(e => e.NgayCap).HasColumnType("datetime");

                entity.Property(e => e.NgaySinh).HasColumnType("datetime");

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.Property(e => e.NguoiTao).HasMaxLength(50);

                entity.Property(e => e.QueQuan).HasMaxLength(255);

                entity.Property(e => e.SoTaiKhoan).HasColumnType("text");

                entity.Property(e => e.TonGiao).HasMaxLength(50);

                entity.Property(e => e.TrinhDo).HasMaxLength(255);

                entity.HasOne(d => d.MaBacNavigation)
                    .WithMany(p => p.TblCanBoGiangVien)
                    .HasForeignKey(d => d.MaBac)
                    .HasConstraintName("FK_tblCanBoGiangVien_tblBacLuong");

                entity.HasOne(d => d.MaBmttNavigation)
                    .WithMany(p => p.TblCanBoGiangVien)
                    .HasForeignKey(d => d.MaBmtt)
                    .HasConstraintName("FK_tblCanBoGiangVien_tblBoMonTrungTam");

                entity.HasOne(d => d.MaKtklNavigation)
                    .WithMany(p => p.TblCanBoGiangVien)
                    .HasForeignKey(d => d.MaKtkl)
                    .HasConstraintName("FK_tblCanBoGiangVien_tblKhenThuongKiLuat");

                entity.HasOne(d => d.MaNgachNavigation)
                    .WithMany(p => p.TblCanBoGiangVien)
                    .HasForeignKey(d => d.MaNgach)
                    .HasConstraintName("FK_tblCanBoGiangVien_tblNgachCongChuc");

                entity.HasOne(d => d.MaPkNavigation)
                    .WithMany(p => p.TblCanBoGiangVien)
                    .HasForeignKey(d => d.MaPk)
                    .HasConstraintName("FK_tblCanBoGiangVien_tblPhongKhoa");

                entity.HasOne(d => d.MaTdhvNavigation)
                    .WithMany(p => p.TblCanBoGiangVien
                    )
                    .HasForeignKey(d => d.MaTdhv)
                    .HasConstraintName("FK_tblCanBoGiangVien_tblTrinhDoHocVan");
            });

            modelBuilder.Entity<TblChiTietPhieuThu>(entity =>
            {
                entity.HasKey(e => e.MaChiTietPhieuThu);

                entity.ToTable("tblChiTietPhieuThu");

                entity.Property(e => e.Dp1)
                    .HasColumnName("DP1")
                    .HasColumnType("ntext");

                entity.Property(e => e.Dp2)
                    .HasColumnName("DP2")
                    .HasColumnType("ntext");

                entity.Property(e => e.Dp3)
                    .HasColumnName("DP3")
                    .HasColumnType("ntext");

                entity.Property(e => e.HoaDonDienTu).HasDefaultValueSql("((0))");

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.Property(e => e.NguoiTao).HasMaxLength(50);

                entity.Property(e => e.SoTien).HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblChuongTrinhDaoTao>(entity =>
            {
                entity.HasKey(e => e.MaCtdt);

                entity.ToTable("tblChuongTrinhDaoTao");

                entity.Property(e => e.MaCtdt)
                    .HasColumnName("MaCTDT")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Dp1)
                    .HasColumnName("DP1")
                    .HasColumnType("ntext");

                entity.Property(e => e.Dp2)
                    .HasColumnName("DP2")
                    .HasColumnType("ntext");

                entity.Property(e => e.Dp3)
                    .HasColumnName("DP3")
                    .HasColumnType("ntext");

                entity.Property(e => e.GhiChu).HasColumnType("ntext");

                entity.Property(e => e.MaBmtt)
                    .HasColumnName("MaBMTT")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaNganh)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaPk)
                    .HasColumnName("MaPK")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NamTs).HasColumnName("NamTS");

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.Property(e => e.NguoiTao).HasMaxLength(50);

                entity.Property(e => e.TenCtdt)
                    .HasColumnName("TenCTDT")
                    .HasColumnType("ntext");
            });

            modelBuilder.Entity<TblChuongTrinhDaoTaoChiTiet>(entity =>
            {
                entity.HasKey(e => e.MaCtdt);

                entity.ToTable("tblChuongTrinhDaoTaoChiTiet");

                entity.Property(e => e.MaCtdt)
                    .HasColumnName("MaCTDT")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Dp1)
                    .HasColumnName("DP1")
                    .HasColumnType("ntext");

                entity.Property(e => e.Dp2)
                    .HasColumnName("DP2")
                    .HasColumnType("ntext");

                entity.Property(e => e.Dp3)
                    .HasColumnName("DP3")
                    .HasColumnType("ntext");

                entity.Property(e => e.GhiChu).HasColumnType("ntext");

                entity.Property(e => e.MaHp)
                    .HasColumnName("MaHP")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.Property(e => e.NguoiTao).HasMaxLength(50);

                entity.Property(e => e.SoTt).HasColumnName("SoTT");
            });

            modelBuilder.Entity<TblDiemHocPhan>(entity =>
            {
                entity.HasKey(e => e.MaDiem);

                entity.ToTable("tblDiemHocPhan");

                entity.Property(e => e.DiemThanhPhan).HasColumnType("ntext");

                entity.Property(e => e.Dp1)
                    .HasColumnName("DP1")
                    .HasColumnType("ntext");

                entity.Property(e => e.Dp2)
                    .HasColumnName("DP2")
                    .HasColumnType("ntext");

                entity.Property(e => e.Dp3)
                    .HasColumnName("DP3")
                    .HasColumnType("ntext");

                entity.Property(e => e.GhiChu).HasColumnType("ntext");

                entity.Property(e => e.HeSo).HasDefaultValueSql("((1.0))");

                entity.Property(e => e.MaHp)
                    .HasColumnName("MaHP")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaSv)
                    .HasColumnName("MaSV")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.Property(e => e.NguoiTao).HasMaxLength(50);
            });

            modelBuilder.Entity<TblDiemHocPhanChiTiet>(entity =>
            {
                entity.HasKey(e => new { e.ThuTu, e.MaSv, e.MaHp });

                entity.ToTable("tblDiemHocPhanChiTiet");

                entity.Property(e => e.MaSv)
                    .HasColumnName("MaSV")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaHp)
                    .HasColumnName("MaHP")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DiemThanhPhan).HasColumnType("text");

                entity.Property(e => e.Dp1)
                    .HasColumnName("DP1")
                    .HasColumnType("ntext");

                entity.Property(e => e.Dp2)
                    .HasColumnName("DP2")
                    .HasColumnType("ntext");

                entity.Property(e => e.Dp3)
                    .HasColumnName("DP3")
                    .HasColumnType("ntext");

                entity.Property(e => e.GhiChu).HasColumnType("ntext");

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.Property(e => e.NguoiDay)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NguoiTao).HasMaxLength(50);
            });

            modelBuilder.Entity<TblDinhMucHocPhi>(entity =>
            {
                entity.HasKey(e => e.MaDmhp);

                entity.ToTable("tblDinhMucHocPhi");

                entity.Property(e => e.MaDmhp).HasColumnName("MaDMHP");

                entity.Property(e => e.Dp1)
                    .HasColumnName("DP1")
                    .HasColumnType("ntext");

                entity.Property(e => e.Dp2)
                    .HasColumnName("DP2")
                    .HasColumnType("ntext");

                entity.Property(e => e.Dp3)
                    .HasColumnName("DP3")
                    .HasColumnType("ntext");

                entity.Property(e => e.GhiChu).HasColumnType("ntext");

                entity.Property(e => e.HocPhiHocKy).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.HocPhiThang).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.HocPhiTinChi).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.HocPhiTinChiLt)
                    .HasColumnName("HocPhiTinChiLT")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.HocPhiTinChiTh)
                    .HasColumnName("HocPhiTinChiTH")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.MaKhoanThu)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaLop)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoTa).HasColumnType("ntext");

                entity.Property(e => e.NgayBatDau).HasColumnType("datetime");

                entity.Property(e => e.NgayKetThuc).HasColumnType("datetime");

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.Property(e => e.NguoiTao).HasMaxLength(50);

                entity.Property(e => e.QuyetDinh).HasColumnType("ntext");
            });

            modelBuilder.Entity<TblDkgiangDay>(entity =>
            {
                entity.HasKey(e => e.MaDkgd);

                entity.ToTable("tblDKGiangDay");

                entity.Property(e => e.MaDkgd).HasColumnName("MaDKGD");

                entity.Property(e => e.Dp1)
                    .HasColumnName("DP1")
                    .HasColumnType("text");

                entity.Property(e => e.GhiChu).HasColumnType("ntext");

                entity.Property(e => e.MaCbgv)
                    .HasColumnName("MaCBGV")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaHp)
                    .HasColumnName("MaHP")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NgayDk)
                    .HasColumnName("NgayDK")
                    .HasColumnType("datetime");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.MaCbgvNavigation)
                    .WithMany(p => p.TblDkgiangDay)
                    .HasForeignKey(d => d.MaCbgv)
                    .HasConstraintName("FK_tblDKGiangDay_tblCanBoGiangVien");

                entity.HasOne(d => d.MaHpNavigation)
                    .WithMany(p => p.TblDkgiangDay)
                    .HasForeignKey(d => d.MaHp)
                    .HasConstraintName("FK_tblDKGiangDay_tblHocPhan");
            });

            modelBuilder.Entity<TblGiaoVienChuNhiem>(entity =>
            {
                entity.HasKey(e => e.MaGvcn);

                entity.ToTable("tblGiaoVienChuNhiem");

                entity.Property(e => e.MaGvcn).HasColumnName("MaGVCN");

                entity.Property(e => e.BatDau).HasColumnType("datetime");

                entity.Property(e => e.Dp1)
                    .HasColumnName("DP1")
                    .HasColumnType("ntext");

                entity.Property(e => e.Dp2)
                    .HasColumnName("DP2")
                    .HasColumnType("ntext");

                entity.Property(e => e.Dp3)
                    .HasColumnName("DP3")
                    .HasColumnType("ntext");

                entity.Property(e => e.GhiChu).HasColumnType("ntext");

                entity.Property(e => e.KetThuc).HasColumnType("datetime");

                entity.Property(e => e.MaCbgv)
                    .HasColumnName("MaCBGV")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaLop)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.Property(e => e.NguoiTao).HasMaxLength(50);

                entity.HasOne(d => d.MaCbgvNavigation)
                    .WithMany(p => p.TblGiaoVienChuNhiem)
                    .HasForeignKey(d => d.MaCbgv)
                    .HasConstraintName("FK_tblGiaoVienChuNhiem_tblCanBoGiangVien");
            });

            modelBuilder.Entity<TblHocPhan>(entity =>
            {
                entity.HasKey(e => e.MaHp);

                entity.ToTable("tblHocPhan");

                entity.Property(e => e.MaHp)
                    .HasColumnName("MaHP")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DiemThanhPhan).HasColumnType("ntext");

                entity.Property(e => e.Dp1)
                    .HasColumnName("DP1")
                    .HasColumnType("ntext");

                entity.Property(e => e.Dp2)
                    .HasColumnName("DP2")
                    .HasColumnType("ntext");

                entity.Property(e => e.Dp3)
                    .HasColumnName("DP3")
                    .HasColumnType("ntext");

                entity.Property(e => e.GhiChu).HasColumnType("ntext");

                entity.Property(e => e.MaBmtt)
                    .HasColumnName("MaBMTT")
                    .HasMaxLength(10);

                entity.Property(e => e.MaPk)
                    .HasColumnName("MaPK")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NganhApDung).HasColumnType("ntext");

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.Property(e => e.NguoiTao).HasMaxLength(50);

                entity.Property(e => e.SoTinChiLt).HasColumnName("SoTinChiLT");

                entity.Property(e => e.SoTinChiTh).HasColumnName("SoTinChiTH");

                entity.Property(e => e.TenHocPhan).HasColumnType("ntext");

                entity.HasOne(d => d.MaPkNavigation)
                    .WithMany(p => p.TblHocPhan)
                    .HasForeignKey(d => d.MaPk)
                    .HasConstraintName("FK_tblHocPhan_tblPhongKhoa");
            });

            modelBuilder.Entity<TblHopDongLd>(entity =>
            {
                entity.HasKey(e => e.MaHd);

                entity.ToTable("tblHopDongLD");

                entity.Property(e => e.MaHd).HasColumnName("MaHD");

                entity.Property(e => e.DenNgay).HasColumnType("datetime");

                entity.Property(e => e.Dp1)
                    .HasColumnName("DP1")
                    .HasColumnType("text");

                entity.Property(e => e.GhiChu).HasColumnType("ntext");

                entity.Property(e => e.LoaiHd)
                    .HasColumnName("LoaiHD")
                    .HasMaxLength(255);

                entity.Property(e => e.MaCbgv)
                    .HasColumnName("MaCBGV")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TuNgay).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblKhenThuongKiLuat>(entity =>
            {
                entity.HasKey(e => e.MaKtkl);

                entity.ToTable("tblKhenThuongKiLuat");

                entity.Property(e => e.MaKtkl).HasColumnName("MaKTKL");

                entity.Property(e => e.Dp1)
                    .HasColumnName("DP1")
                    .HasColumnType("text");

                entity.Property(e => e.GhiChu).HasColumnType("ntext");

                entity.Property(e => e.HinhThuc).HasMaxLength(255);

                entity.Property(e => e.LyDo).HasColumnType("ntext");

                entity.Property(e => e.NgayKt)
                    .HasColumnName("NgayKT")
                    .HasColumnType("datetime");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TenKtkl)
                    .HasColumnName("TenKTKL")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<TblKhoanThu>(entity =>
            {
                entity.HasKey(e => e.MaKhoanThu);

                entity.ToTable("tblKhoanThu");

                entity.Property(e => e.MaKhoanThu)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Dp1)
                    .HasColumnName("DP1")
                    .HasColumnType("ntext");

                entity.Property(e => e.Dp2)
                    .HasColumnName("DP2")
                    .HasColumnType("ntext");

                entity.Property(e => e.Dp3)
                    .HasColumnName("DP3")
                    .HasColumnType("ntext");

                entity.Property(e => e.MoTa).HasMaxLength(1000);

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.Property(e => e.NguoiTao).HasMaxLength(50);
            });

            modelBuilder.Entity<TblLophoc>(entity =>
            {
                entity.HasKey(e => e.MaLop);

                entity.ToTable("tblLophoc");

                entity.Property(e => e.MaLop)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Dp1)
                    .HasColumnName("DP1")
                    .HasColumnType("ntext");

                entity.Property(e => e.Dp2)
                    .HasColumnName("DP2")
                    .HasColumnType("ntext");

                entity.Property(e => e.Dp3)
                    .HasColumnName("DP3")
                    .HasColumnType("ntext");

                entity.Property(e => e.GhiChu).HasColumnType("ntext");

                entity.Property(e => e.MaKhoaQuanLy)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaNganhHoc)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NgayNhapHoc).HasColumnType("datetime");

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.Property(e => e.NguoiTao).HasMaxLength(50);

                entity.Property(e => e.NienKhoa)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TenLop)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLuong>(entity =>
            {
                entity.HasKey(e => e.MaLuong);

                entity.ToTable("tblLuong");

                entity.Property(e => e.Dp1)
                    .HasColumnName("DP1")
                    .HasColumnType("text");

                entity.Property(e => e.LuongCb).HasColumnName("LuongCB");

                entity.Property(e => e.LuongPc).HasColumnName("LuongPC");

                entity.Property(e => e.NgayNhan).HasMaxLength(255);

                entity.Property(e => e.NgayTang).HasColumnType("datetime");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.MaBacNavigation)
                    .WithMany(p => p.TblLuong)
                    .HasForeignKey(d => d.MaBac)
                    .HasConstraintName("FK_tblLuong_tblBacLuong");
            });

            modelBuilder.Entity<TblLyLichGv>(entity =>
            {
                entity.HasKey(e => e.MaLl);

                entity.ToTable("tblLyLichGV");

                entity.Property(e => e.MaLl).HasColumnName("MaLL");

                entity.Property(e => e.Dp1)
                    .HasColumnName("DP1")
                    .HasColumnType("text");

                entity.Property(e => e.Ghichu).HasColumnType("ntext");

                entity.Property(e => e.LinkBaiBao).HasColumnType("ntext");

                entity.Property(e => e.LoaiLl)
                    .HasColumnName("LoaiLL")
                    .HasColumnType("ntext");

                entity.Property(e => e.MaCbgv)
                    .HasColumnName("MaCBGV")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TenLl)
                    .HasColumnName("TenLL")
                    .HasMaxLength(255);

                entity.HasOne(d => d.MaCbgvNavigation)
                    .WithMany(p => p.TblLyLichGv)
                    .HasForeignKey(d => d.MaCbgv)
                    .HasConstraintName("FK_tblLyLichGV_tblCanBoGiangVien");
            });

            modelBuilder.Entity<TblNgachCongChuc>(entity =>
            {
                entity.HasKey(e => e.MaNgach);

                entity.ToTable("tblNgachCongChuc");

                entity.Property(e => e.Dp1)
                    .HasColumnName("DP1")
                    .HasColumnType("text");

                entity.Property(e => e.Dp2)
                    .HasColumnName("DP2")
                    .HasColumnType("text");

                entity.Property(e => e.GhiChu).HasColumnType("ntext");

                entity.Property(e => e.MaSo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MoTa).HasMaxLength(255);

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.Property(e => e.NguoiTao).HasMaxLength(50);

                entity.Property(e => e.TenNgach).HasMaxLength(255);
            });

            modelBuilder.Entity<TblNganHang>(entity =>
            {
                entity.HasKey(e => e.MaNganHang);

                entity.ToTable("tblNganHang");

                entity.Property(e => e.MaNganHang)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DiaChi).HasMaxLength(300);

                entity.Property(e => e.Dp1)
                    .HasColumnName("DP1")
                    .HasColumnType("ntext");

                entity.Property(e => e.Dp2)
                    .HasColumnName("DP2")
                    .HasColumnType("ntext");

                entity.Property(e => e.Dp3)
                    .HasColumnName("DP3")
                    .HasColumnType("ntext");

                entity.Property(e => e.GhiChu).HasColumnType("text");

                entity.Property(e => e.MatKhau).HasColumnType("text");

                entity.Property(e => e.NgayTao).HasMaxLength(50);

                entity.Property(e => e.NguoiTao).HasMaxLength(50);

                entity.Property(e => e.Ten).HasMaxLength(1000);
            });

            modelBuilder.Entity<TblNganhDaoTao>(entity =>
            {
                entity.HasKey(e => e.MaNganh);

                entity.ToTable("tblNganhDaoTao");

                entity.Property(e => e.MaNganh)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Dp1)
                    .HasColumnName("DP1")
                    .HasColumnType("ntext");

                entity.Property(e => e.Dp2)
                    .HasColumnName("DP2")
                    .HasColumnType("ntext");

                entity.Property(e => e.Dp3)
                    .HasColumnName("DP3")
                    .HasColumnType("ntext");

                entity.Property(e => e.GhiChu).HasColumnType("ntext");

                entity.Property(e => e.MaBmtt)
                    .HasColumnName("MaBMTT")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaNganhTs)
                    .HasColumnName("MaNganhTS")
                    .HasColumnType("ntext");

                entity.Property(e => e.MaPk)
                    .HasColumnName("MaPK")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NamTs).HasColumnName("NamTS");

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.Property(e => e.NguoiTao).HasMaxLength(50);

                entity.Property(e => e.TenNganh).HasColumnType("ntext");
            });

            modelBuilder.Entity<TblPhieuThu>(entity =>
            {
                entity.HasKey(e => e.MaPhieuThu);

                entity.ToTable("tblPhieuThu");

                entity.Property(e => e.Dp1)
                    .HasColumnName("DP1")
                    .HasColumnType("ntext");

                entity.Property(e => e.Dp2)
                    .HasColumnName("DP2")
                    .HasColumnType("ntext");

                entity.Property(e => e.Dp3)
                    .HasColumnName("DP3")
                    .HasColumnType("ntext");

                entity.Property(e => e.GhiChu).HasColumnType("text");

                entity.Property(e => e.MaGiaoDich).HasMaxLength(20);

                entity.Property(e => e.MaNguoiThu)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoTa).HasColumnType("ntext");

                entity.Property(e => e.Ngay).HasColumnType("datetime");

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.Property(e => e.NguoiTao).HasMaxLength(50);

                entity.Property(e => e.NguoiThu).HasMaxLength(50);

                entity.Property(e => e.TongTien).HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblPhongKhoa>(entity =>
            {
                entity.HasKey(e => e.MaPk);

                entity.ToTable("tblPhongKhoa");

                entity.Property(e => e.MaPk)
                    .HasColumnName("MaPK")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DiaChi).HasColumnType("ntext");

                entity.Property(e => e.DienThoai).HasColumnType("ntext");

                entity.Property(e => e.Dp1)
                    .HasColumnName("DP1")
                    .HasColumnType("ntext");

                entity.Property(e => e.Dp2)
                    .HasColumnName("DP2")
                    .HasColumnType("ntext");

                entity.Property(e => e.Dp3)
                    .HasColumnName("DP3")
                    .HasColumnType("ntext");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.GhiChu).HasColumnType("ntext");

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.Property(e => e.NguoiTao).HasMaxLength(50);

                entity.Property(e => e.TenPhongKhoa).HasMaxLength(150);

                entity.Property(e => e.Webiste).HasColumnType("ntext");
            });

            modelBuilder.Entity<TblQuanLyPhienBan>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblQuanLyPhienBan", "nhutero5_utehy");

                entity.Property(e => e.GhiChu).HasColumnType("ntext");

                entity.Property(e => e.NgayDung).HasColumnType("datetime");

                entity.Property(e => e.NgayPhatHanh).HasColumnType("datetime");

                entity.Property(e => e.PhienBan)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblSinhVienLopHoc>(entity =>
            {
                entity.HasKey(e => e.MaSvlh);

                entity.ToTable("tblSinhVienLopHoc");

                entity.Property(e => e.MaSvlh).HasColumnName("MaSVLH");

                entity.Property(e => e.Dp1)
                    .HasColumnName("DP1")
                    .HasColumnType("ntext");

                entity.Property(e => e.Dp2)
                    .HasColumnName("DP2")
                    .HasColumnType("ntext");

                entity.Property(e => e.Dp3)
                    .HasColumnName("DP3")
                    .HasColumnType("ntext");

                entity.Property(e => e.GhiChu).HasColumnType("text");

                entity.Property(e => e.MaLop)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaSv)
                    .HasColumnName("MaSV")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.Property(e => e.NgayVaoLop).HasColumnType("datetime");

                entity.Property(e => e.NguoiTao).HasMaxLength(50);
            });

            modelBuilder.Entity<TblSinhvien>(entity =>
            {
                entity.HasKey(e => e.MaSv);

                entity.ToTable("tblSinhvien");

                entity.Property(e => e.MaSv)
                    .HasColumnName("MaSV")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Anh).HasColumnType("ntext");

                entity.Property(e => e.DanToc).HasMaxLength(50);

                entity.Property(e => e.DienThoai)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Dp1)
                    .HasColumnName("DP1")
                    .HasColumnType("ntext");

                entity.Property(e => e.Dp2)
                    .HasColumnName("DP2")
                    .HasColumnType("ntext");

                entity.Property(e => e.Dp3)
                    .HasColumnName("DP3")
                    .HasColumnType("ntext");

                entity.Property(e => e.Email).HasColumnType("ntext");

                entity.Property(e => e.HoVaTen)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MatKhau)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.NgayCap).HasColumnType("datetime");

                entity.Property(e => e.NgaySinh).HasColumnType("datetime");

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.Property(e => e.NguoiTao)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NoiCap).HasMaxLength(50);

                entity.Property(e => e.SoDinhDanh)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblSoGhiNoSinhVien>(entity =>
            {
                entity.HasKey(e => e.MaKhoanNo);

                entity.ToTable("tblSoGhiNoSinhVien");

                entity.Property(e => e.BatDau).HasColumnType("datetime");

                entity.Property(e => e.Dp1)
                    .HasColumnName("DP1")
                    .HasColumnType("ntext");

                entity.Property(e => e.Dp2)
                    .HasColumnName("DP2")
                    .HasColumnType("ntext");

                entity.Property(e => e.Dp3)
                    .HasColumnName("DP3")
                    .HasColumnType("ntext");

                entity.Property(e => e.GhiChu).HasColumnType("ntext");

                entity.Property(e => e.KetThuc).HasColumnType("datetime");

                entity.Property(e => e.MaHp)
                    .HasColumnName("MaHP")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaKhoanThu)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaSv)
                    .IsRequired()
                    .HasColumnName("MaSV")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.Property(e => e.NgayThu).HasColumnType("datetime");

                entity.Property(e => e.NguoiTao).HasMaxLength(50);

                entity.Property(e => e.SoTienCanThu).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.SoTienDaThu).HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblTrinhDoHocVan>(entity =>
            {
                entity.HasKey(e => e.MaTdhv);

                entity.ToTable("tblTrinhDoHocVan");

                entity.Property(e => e.MaTdhv).HasColumnName("MaTDHV");

                entity.Property(e => e.ChungChi).HasMaxLength(255);

                entity.Property(e => e.ChuyenNganhDaoTao).HasMaxLength(255);

                entity.Property(e => e.DonViCt)
                    .HasColumnName("DonViCT")
                    .HasMaxLength(255);

                entity.Property(e => e.Dp1)
                    .HasColumnName("DP1")
                    .HasColumnType("text");

                entity.Property(e => e.NamTotNghiêp).HasColumnType("datetime");

                entity.Property(e => e.SoNamDay)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TdngoaiNgu)
                    .HasColumnName("TDNgoaiNgu")
                    .HasMaxLength(255);

                entity.Property(e => e.TdtinHoc)
                    .HasColumnName("TDTinHoc")
                    .HasMaxLength(255);

                entity.Property(e => e.TenHocVan).HasMaxLength(255);
            });

            modelBuilder.Entity<TblUyNhiemThu>(entity =>
            {
                entity.HasKey(e => e.MaUnt);

                entity.ToTable("tblUyNhiemThu");

                entity.Property(e => e.MaUnt).HasColumnName("MaUNT");

                entity.Property(e => e.BatDau).HasColumnType("datetime");

                entity.Property(e => e.Dp1)
                    .HasColumnName("DP1")
                    .HasColumnType("ntext");

                entity.Property(e => e.Dp2)
                    .HasColumnName("DP2")
                    .HasColumnType("ntext");

                entity.Property(e => e.Dp3)
                    .HasColumnName("DP3")
                    .HasColumnType("ntext");

                entity.Property(e => e.GhiChu).HasColumnType("ntext");

                entity.Property(e => e.KetThuc).HasColumnType("datetime");

                entity.Property(e => e.MaKhoanThu)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaNganHang)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.Property(e => e.NguoiTao)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Diachi)
                    .HasColumnName("diachi")
                    .HasMaxLength(250);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Gioitinh)
                    .HasColumnName("gioitinh")
                    .HasMaxLength(30);

                entity.Property(e => e.Hoten)
                    .HasColumnName("hoten")
                    .HasMaxLength(50);

                entity.Property(e => e.ImageUrl)
                    .HasColumnName("image_url")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Matkhau)
                    .HasColumnName("matkhau")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Ngaysinh)
                    .HasColumnName("ngaysinh")
                    .HasColumnType("date");

                entity.Property(e => e.Role)
                    .HasColumnName("role")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Taikhoan)
                    .HasColumnName("taikhoan")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            //OnModelCreatingPartial(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}
