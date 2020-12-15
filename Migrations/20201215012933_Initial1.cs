using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DOAN52.Migrations
{
    public partial class Initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "nhutero5_utehy");

            migrationBuilder.CreateTable(
                name: "tblBacLuong",
                columns: table => new
                {
                    MaBac = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenBac = table.Column<string>(maxLength: 255, nullable: true),
                    HeSoBacLg = table.Column<double>(nullable: true),
                    Status = table.Column<int>(nullable: true),
                    NhomBac = table.Column<string>(type: "ntext", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiTao = table.Column<string>(maxLength: 50, nullable: true),
                    DP1 = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblBacLuong", x => x.MaBac);
                });

            migrationBuilder.CreateTable(
                name: "tblChiTietPhieuThu",
                columns: table => new
                {
                    MaChiTietPhieuThu = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaPhieuThu = table.Column<long>(nullable: true),
                    MaKhoanNo = table.Column<long>(nullable: true),
                    SoTien = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    HoaDonDienTu = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiTao = table.Column<string>(maxLength: 50, nullable: true),
                    DP1 = table.Column<string>(type: "ntext", nullable: true),
                    DP2 = table.Column<string>(type: "ntext", nullable: true),
                    DP3 = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblChiTietPhieuThu", x => x.MaChiTietPhieuThu);
                });

            migrationBuilder.CreateTable(
                name: "tblChuongTrinhDaoTao",
                columns: table => new
                {
                    MaCTDT = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    MaNganh = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    MaPK = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    MaBMTT = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    TenCTDT = table.Column<string>(type: "ntext", nullable: true),
                    SoTinChi = table.Column<double>(nullable: true),
                    NamTS = table.Column<int>(nullable: true),
                    GhiChu = table.Column<string>(type: "ntext", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiTao = table.Column<string>(maxLength: 50, nullable: true),
                    DP1 = table.Column<string>(type: "ntext", nullable: true),
                    DP2 = table.Column<string>(type: "ntext", nullable: true),
                    DP3 = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblChuongTrinhDaoTao", x => x.MaCTDT);
                });

            migrationBuilder.CreateTable(
                name: "tblChuongTrinhDaoTaoChiTiet",
                columns: table => new
                {
                    MaCTDT = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    MaHP = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    TinhTrang = table.Column<int>(nullable: true),
                    HocKy = table.Column<int>(nullable: true),
                    NamHoc = table.Column<int>(nullable: true),
                    SoTT = table.Column<int>(nullable: true),
                    GhiChu = table.Column<string>(type: "ntext", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiTao = table.Column<string>(maxLength: 50, nullable: true),
                    DP1 = table.Column<string>(type: "ntext", nullable: true),
                    DP2 = table.Column<string>(type: "ntext", nullable: true),
                    DP3 = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblChuongTrinhDaoTaoChiTiet", x => x.MaCTDT);
                });

            migrationBuilder.CreateTable(
                name: "tblDiemHocPhan",
                columns: table => new
                {
                    MaDiem = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSV = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    MaHP = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    Diem = table.Column<double>(nullable: true),
                    HocKy = table.Column<int>(nullable: true),
                    NamHoc = table.Column<int>(nullable: true),
                    TinhTrang = table.Column<int>(nullable: true),
                    ThuTu = table.Column<int>(nullable: true),
                    SoLanHoc = table.Column<int>(nullable: true),
                    SoTinChi = table.Column<double>(nullable: true),
                    HeSo = table.Column<double>(nullable: true, defaultValueSql: "((1.0))"),
                    SoThuTu = table.Column<int>(nullable: true),
                    TinhTrungBinh = table.Column<int>(nullable: true),
                    TotNghiep = table.Column<int>(nullable: true),
                    DiemThanhPhan = table.Column<string>(type: "ntext", nullable: true),
                    GhiChu = table.Column<string>(type: "ntext", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiTao = table.Column<string>(maxLength: 50, nullable: true),
                    DP1 = table.Column<string>(type: "ntext", nullable: true),
                    DP2 = table.Column<string>(type: "ntext", nullable: true),
                    DP3 = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDiemHocPhan", x => x.MaDiem);
                });

            migrationBuilder.CreateTable(
                name: "tblDiemHocPhanChiTiet",
                columns: table => new
                {
                    ThuTu = table.Column<int>(nullable: false),
                    MaSV = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    MaHP = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    Diem = table.Column<double>(nullable: true),
                    HocKy = table.Column<int>(nullable: true),
                    NamHoc = table.Column<int>(nullable: true),
                    TinhTrang = table.Column<int>(nullable: true),
                    KhaoSat = table.Column<int>(nullable: true),
                    DiemThanhPhan = table.Column<string>(type: "text", nullable: true),
                    NguoiDay = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    GhiChu = table.Column<string>(type: "ntext", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiTao = table.Column<string>(maxLength: 50, nullable: true),
                    DP1 = table.Column<string>(type: "ntext", nullable: true),
                    DP2 = table.Column<string>(type: "ntext", nullable: true),
                    DP3 = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDiemHocPhanChiTiet", x => new { x.ThuTu, x.MaSV, x.MaHP });
                });

            migrationBuilder.CreateTable(
                name: "tblDinhMucHocPhi",
                columns: table => new
                {
                    MaDMHP = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaLop = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    MoTa = table.Column<string>(type: "ntext", nullable: true),
                    HocPhiThang = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    HocPhiHocKy = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    HocPhiTinChi = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    HocPhiTinChiLT = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    HocPhiTinChiTH = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    HocKy = table.Column<int>(nullable: true),
                    NamHoc = table.Column<int>(nullable: true),
                    TrangThai = table.Column<int>(nullable: true),
                    TinhChat = table.Column<int>(nullable: true),
                    NgayBatDau = table.Column<DateTime>(type: "datetime", nullable: true),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime", nullable: true),
                    QuyetDinh = table.Column<string>(type: "ntext", nullable: true),
                    GhiChu = table.Column<string>(type: "ntext", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiTao = table.Column<string>(maxLength: 50, nullable: true),
                    DP1 = table.Column<string>(type: "ntext", nullable: true),
                    DP2 = table.Column<string>(type: "ntext", nullable: true),
                    DP3 = table.Column<string>(type: "ntext", nullable: true),
                    MaKhoanThu = table.Column<string>(unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDinhMucHocPhi", x => x.MaDMHP);
                });

            migrationBuilder.CreateTable(
                name: "tblHopDongLD",
                columns: table => new
                {
                    MaHD = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaCBGV = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    LoaiHD = table.Column<string>(maxLength: 255, nullable: true),
                    TuNgay = table.Column<DateTime>(type: "datetime", nullable: true),
                    DenNgay = table.Column<DateTime>(type: "datetime", nullable: true),
                    GhiChu = table.Column<string>(type: "ntext", nullable: true),
                    status = table.Column<int>(nullable: true),
                    DP1 = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblHopDongLD", x => x.MaHD);
                });

            migrationBuilder.CreateTable(
                name: "tblKhenThuongKiLuat",
                columns: table => new
                {
                    MaKTKL = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKTKL = table.Column<string>(maxLength: 255, nullable: true),
                    LyDo = table.Column<string>(type: "ntext", nullable: true),
                    NgayKT = table.Column<DateTime>(type: "datetime", nullable: true),
                    HinhThuc = table.Column<string>(maxLength: 255, nullable: true),
                    GhiChu = table.Column<string>(type: "ntext", nullable: true),
                    status = table.Column<int>(nullable: true),
                    DP1 = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblKhenThuongKiLuat", x => x.MaKTKL);
                });

            migrationBuilder.CreateTable(
                name: "tblKhoanThu",
                columns: table => new
                {
                    MaKhoanThu = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    MoTa = table.Column<string>(maxLength: 1000, nullable: true),
                    TinhChat = table.Column<int>(nullable: true),
                    HoaDonDienTu = table.Column<int>(nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiTao = table.Column<string>(maxLength: 50, nullable: true),
                    DP1 = table.Column<string>(type: "ntext", nullable: true),
                    DP2 = table.Column<string>(type: "ntext", nullable: true),
                    DP3 = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblKhoanThu", x => x.MaKhoanThu);
                });

            migrationBuilder.CreateTable(
                name: "tblLophoc",
                columns: table => new
                {
                    MaLop = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    TenLop = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    MaNganhHoc = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    MaKhoaQuanLy = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    NienKhoa = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    TrinhDo = table.Column<int>(nullable: true),
                    He = table.Column<int>(nullable: true),
                    NgayNhapHoc = table.Column<DateTime>(type: "datetime", nullable: true),
                    SiSo = table.Column<int>(nullable: true),
                    TrangThai = table.Column<int>(nullable: true),
                    GhiChu = table.Column<string>(type: "ntext", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiTao = table.Column<string>(maxLength: 50, nullable: true),
                    DP1 = table.Column<string>(type: "ntext", nullable: true),
                    DP2 = table.Column<string>(type: "ntext", nullable: true),
                    DP3 = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLophoc", x => x.MaLop);
                });

            migrationBuilder.CreateTable(
                name: "tblNgachCongChuc",
                columns: table => new
                {
                    MaNgach = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSo = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    TenNgach = table.Column<string>(maxLength: 255, nullable: true),
                    MoTa = table.Column<string>(maxLength: 255, nullable: true),
                    Status = table.Column<int>(nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiTao = table.Column<string>(maxLength: 50, nullable: true),
                    DP1 = table.Column<string>(type: "text", nullable: true),
                    DP2 = table.Column<string>(type: "text", nullable: true),
                    GhiChu = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblNgachCongChuc", x => x.MaNgach);
                });

            migrationBuilder.CreateTable(
                name: "tblNganHang",
                columns: table => new
                {
                    MaNganHang = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    Ten = table.Column<string>(maxLength: 1000, nullable: true),
                    DiaChi = table.Column<string>(maxLength: 300, nullable: true),
                    MatKhau = table.Column<string>(type: "text", nullable: true),
                    KichHoat = table.Column<int>(nullable: true),
                    GhiChu = table.Column<string>(type: "text", nullable: true),
                    NgayTao = table.Column<string>(maxLength: 50, nullable: true),
                    NguoiTao = table.Column<string>(maxLength: 50, nullable: true),
                    DP1 = table.Column<string>(type: "ntext", nullable: true),
                    DP2 = table.Column<string>(type: "ntext", nullable: true),
                    DP3 = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblNganHang", x => x.MaNganHang);
                });

            migrationBuilder.CreateTable(
                name: "tblNganhDaoTao",
                columns: table => new
                {
                    MaNganh = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    MaPK = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    MaBMTT = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    MaNganhTS = table.Column<string>(type: "ntext", nullable: true),
                    TenNganh = table.Column<string>(type: "ntext", nullable: true),
                    SoTinChi = table.Column<double>(nullable: true),
                    TrinhDo = table.Column<int>(nullable: true),
                    SoThang = table.Column<int>(nullable: true),
                    NamTS = table.Column<int>(nullable: true),
                    GhiChu = table.Column<string>(type: "ntext", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiTao = table.Column<string>(maxLength: 50, nullable: true),
                    DP1 = table.Column<string>(type: "ntext", nullable: true),
                    DP2 = table.Column<string>(type: "ntext", nullable: true),
                    DP3 = table.Column<string>(type: "ntext", nullable: true),
                    He = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblNganhDaoTao", x => x.MaNganh);
                });

            migrationBuilder.CreateTable(
                name: "tblPhieuThu",
                columns: table => new
                {
                    MaPhieuThu = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoHieu = table.Column<int>(nullable: true),
                    NamTaiKhoa = table.Column<int>(nullable: true),
                    MaGiaoDich = table.Column<string>(maxLength: 20, nullable: true),
                    Ngay = table.Column<DateTime>(type: "datetime", nullable: true),
                    MoTa = table.Column<string>(type: "ntext", nullable: true),
                    NguoiThu = table.Column<string>(maxLength: 50, nullable: true),
                    MaNguoiThu = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    TongTien = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    HoaDonDienTu = table.Column<int>(nullable: true),
                    GhiChu = table.Column<string>(type: "text", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiTao = table.Column<string>(maxLength: 50, nullable: true),
                    DP1 = table.Column<string>(type: "ntext", nullable: true),
                    DP2 = table.Column<string>(type: "ntext", nullable: true),
                    DP3 = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPhieuThu", x => x.MaPhieuThu);
                });

            migrationBuilder.CreateTable(
                name: "tblPhongKhoa",
                columns: table => new
                {
                    MaPK = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    TenPhongKhoa = table.Column<string>(maxLength: 150, nullable: true),
                    SoLuongNhanSu = table.Column<int>(nullable: true),
                    PhanLoai = table.Column<int>(nullable: true),
                    DiaChi = table.Column<string>(type: "ntext", nullable: true),
                    DienThoai = table.Column<string>(type: "ntext", nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    Webiste = table.Column<string>(type: "ntext", nullable: true),
                    GhiChu = table.Column<string>(type: "ntext", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiTao = table.Column<string>(maxLength: 50, nullable: true),
                    DP1 = table.Column<string>(type: "ntext", nullable: true),
                    DP2 = table.Column<string>(type: "ntext", nullable: true),
                    DP3 = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPhongKhoa", x => x.MaPK);
                });

            migrationBuilder.CreateTable(
                name: "tblSinhvien",
                columns: table => new
                {
                    MaSV = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    HoVaTen = table.Column<string>(maxLength: 50, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime", nullable: true),
                    GioiTinh = table.Column<byte>(nullable: true),
                    DanToc = table.Column<string>(maxLength: 50, nullable: true),
                    SoDinhDanh = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    NoiCap = table.Column<string>(maxLength: 50, nullable: true),
                    NgayCap = table.Column<DateTime>(type: "datetime", nullable: true),
                    DienThoai = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "ntext", nullable: true),
                    MatKhau = table.Column<string>(type: "text", nullable: false),
                    Quyen = table.Column<int>(nullable: true),
                    TrangThai = table.Column<int>(nullable: true),
                    Anh = table.Column<string>(type: "ntext", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiTao = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    DP1 = table.Column<string>(type: "ntext", nullable: true),
                    DP2 = table.Column<string>(type: "ntext", nullable: true),
                    DP3 = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSinhvien", x => x.MaSV);
                });

            migrationBuilder.CreateTable(
                name: "tblSinhVienLopHoc",
                columns: table => new
                {
                    MaSVLH = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSV = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    MaLop = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    HoatDong = table.Column<int>(nullable: true),
                    NgayVaoLop = table.Column<DateTime>(type: "datetime", nullable: true),
                    GhiChu = table.Column<string>(type: "text", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiTao = table.Column<string>(maxLength: 50, nullable: true),
                    DP1 = table.Column<string>(type: "ntext", nullable: true),
                    DP2 = table.Column<string>(type: "ntext", nullable: true),
                    DP3 = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSinhVienLopHoc", x => x.MaSVLH);
                });

            migrationBuilder.CreateTable(
                name: "tblSoGhiNoSinhVien",
                columns: table => new
                {
                    MaKhoanNo = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSV = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    MaKhoanThu = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    MaHP = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    SoTienCanThu = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    SoTienDaThu = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    BatDau = table.Column<DateTime>(type: "datetime", nullable: true),
                    KetThuc = table.Column<DateTime>(type: "datetime", nullable: true),
                    NgayThu = table.Column<DateTime>(type: "datetime", nullable: true),
                    NamTaiKhoa = table.Column<int>(nullable: true),
                    TinhTrang = table.Column<int>(nullable: true),
                    ChonSan = table.Column<int>(nullable: true),
                    GhiChu = table.Column<string>(type: "ntext", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiTao = table.Column<string>(maxLength: 50, nullable: true),
                    DP1 = table.Column<string>(type: "ntext", nullable: true),
                    DP2 = table.Column<string>(type: "ntext", nullable: true),
                    DP3 = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSoGhiNoSinhVien", x => x.MaKhoanNo);
                });

            migrationBuilder.CreateTable(
                name: "tblTrinhDoHocVan",
                columns: table => new
                {
                    MaTDHV = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenHocVan = table.Column<string>(maxLength: 255, nullable: true),
                    NamTotNghiêp = table.Column<DateTime>(type: "datetime", nullable: true),
                    ChungChi = table.Column<string>(maxLength: 255, nullable: true),
                    ChuyenNganhDaoTao = table.Column<string>(maxLength: 255, nullable: true),
                    DonViCT = table.Column<string>(maxLength: 255, nullable: true),
                    TDTinHoc = table.Column<string>(maxLength: 255, nullable: true),
                    TDNgoaiNgu = table.Column<string>(maxLength: 255, nullable: true),
                    SoNamDay = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    status = table.Column<int>(nullable: true),
                    DP1 = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTrinhDoHocVan", x => x.MaTDHV);
                });

            migrationBuilder.CreateTable(
                name: "tblUyNhiemThu",
                columns: table => new
                {
                    MaUNT = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaKhoanThu = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    MaNganHang = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    BatDau = table.Column<DateTime>(type: "datetime", nullable: true),
                    KetThuc = table.Column<DateTime>(type: "datetime", nullable: true),
                    KichHoat = table.Column<int>(nullable: true),
                    GhiChu = table.Column<string>(type: "ntext", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiTao = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    DP1 = table.Column<string>(type: "ntext", nullable: true),
                    DP2 = table.Column<string>(type: "ntext", nullable: true),
                    DP3 = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUyNhiemThu", x => x.MaUNT);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    user_id = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    hoten = table.Column<string>(maxLength: 50, nullable: true),
                    ngaysinh = table.Column<DateTime>(type: "date", nullable: true),
                    diachi = table.Column<string>(maxLength: 250, nullable: true),
                    gioitinh = table.Column<string>(maxLength: 30, nullable: true),
                    email = table.Column<string>(unicode: false, maxLength: 150, nullable: true),
                    taikhoan = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    matkhau = table.Column<string>(unicode: false, maxLength: 60, nullable: true),
                    role = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    image_url = table.Column<string>(unicode: false, maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "QuanLyPhienBan",
                schema: "nhutero5_utehy",
                columns: table => new
                {
                    PhienBan = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    KichHoat = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblQuanLyPhienBan",
                schema: "nhutero5_utehy",
                columns: table => new
                {
                    PhienBan = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    KichHoat = table.Column<int>(nullable: true),
                    NgayPhatHanh = table.Column<DateTime>(type: "datetime", nullable: true),
                    NgayDung = table.Column<DateTime>(type: "datetime", nullable: true),
                    GhiChu = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblLuong",
                columns: table => new
                {
                    MaLuong = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaBac = table.Column<long>(nullable: true),
                    MucLuong = table.Column<int>(nullable: true),
                    LuongCB = table.Column<int>(nullable: true),
                    LuongPC = table.Column<int>(nullable: true),
                    NgayNhan = table.Column<string>(maxLength: 255, nullable: true),
                    NgayTang = table.Column<DateTime>(type: "datetime", nullable: true),
                    status = table.Column<int>(nullable: true),
                    DP1 = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLuong", x => x.MaLuong);
                    table.ForeignKey(
                        name: "FK_tblLuong_tblBacLuong",
                        column: x => x.MaBac,
                        principalTable: "tblBacLuong",
                        principalColumn: "MaBac",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblBoMonTrungTam",
                columns: table => new
                {
                    MaBMTT = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    TenBMTT = table.Column<string>(maxLength: 50, nullable: true),
                    MaPK = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    SoLuongNhanSu = table.Column<int>(nullable: true),
                    PhanLoai = table.Column<int>(nullable: true),
                    DiaChi = table.Column<string>(type: "ntext", nullable: true),
                    DienThoai = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    Website = table.Column<string>(maxLength: 200, nullable: true),
                    GhiChu = table.Column<string>(type: "ntext", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiTao = table.Column<string>(maxLength: 50, nullable: true),
                    DP1 = table.Column<string>(type: "ntext", nullable: true),
                    DP2 = table.Column<string>(type: "ntext", nullable: true),
                    DP3 = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblBoMonTrungTam", x => x.MaBMTT);
                    table.ForeignKey(
                        name: "FK_tblBoMonTrungTam_tblPhongKhoa",
                        column: x => x.MaPK,
                        principalTable: "tblPhongKhoa",
                        principalColumn: "MaPK",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblHocPhan",
                columns: table => new
                {
                    MaHP = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    MaPK = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    MaBMTT = table.Column<string>(maxLength: 10, nullable: true),
                    TenHocPhan = table.Column<string>(type: "ntext", nullable: true),
                    HocKy = table.Column<int>(nullable: true),
                    TinhChat = table.Column<int>(nullable: true),
                    SoTinChi = table.Column<double>(nullable: true),
                    SoTinChiLT = table.Column<double>(nullable: true),
                    SoTinChiTH = table.Column<double>(nullable: true),
                    HeSo = table.Column<double>(nullable: true),
                    SoThuTu = table.Column<int>(nullable: true),
                    TinhTrungBinh = table.Column<int>(nullable: true),
                    TotNghiep = table.Column<int>(nullable: true),
                    DiemThanhPhan = table.Column<string>(type: "ntext", nullable: true),
                    NganhApDung = table.Column<string>(type: "ntext", nullable: true),
                    GhiChu = table.Column<string>(type: "ntext", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiTao = table.Column<string>(maxLength: 50, nullable: true),
                    DP1 = table.Column<string>(type: "ntext", nullable: true),
                    DP2 = table.Column<string>(type: "ntext", nullable: true),
                    DP3 = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblHocPhan", x => x.MaHP);
                    table.ForeignKey(
                        name: "FK_tblHocPhan_tblPhongKhoa",
                        column: x => x.MaPK,
                        principalTable: "tblPhongKhoa",
                        principalColumn: "MaPK",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    token_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    token = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    expiry_date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.token_id);
                    table.ForeignKey(
                        name: "FK__RefreshTo__user___4F47C5E3",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblCanBoGiangVien",
                columns: table => new
                {
                    MaCBGV = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    MaPK = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    MaBMTT = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    MaNgach = table.Column<long>(nullable: true),
                    MaBac = table.Column<long>(nullable: true),
                    MaTDHV = table.Column<long>(nullable: true),
                    MaKTKL = table.Column<long>(nullable: true),
                    HoVaTen = table.Column<string>(maxLength: 50, nullable: true),
                    Image = table.Column<string>(maxLength: 255, nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "datetime", nullable: true),
                    GioiTinh = table.Column<int>(nullable: true),
                    MatKhau = table.Column<string>(type: "ntext", nullable: true),
                    DienThoai = table.Column<string>(type: "ntext", nullable: true),
                    Email = table.Column<string>(type: "ntext", nullable: true),
                    ChucDanh = table.Column<string>(maxLength: 10, nullable: true),
                    SoTaiKhoan = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(nullable: true),
                    Quyen = table.Column<int>(nullable: true),
                    QueQuan = table.Column<string>(maxLength: 255, nullable: true),
                    DanToc = table.Column<string>(maxLength: 50, nullable: true),
                    TonGiao = table.Column<string>(maxLength: 50, nullable: true),
                    TrinhDo = table.Column<string>(maxLength: 255, nullable: true),
                    KinhNghiem = table.Column<string>(type: "ntext", nullable: true),
                    CMND = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    NgayCap = table.Column<DateTime>(type: "datetime", nullable: true),
                    AiCap = table.Column<string>(maxLength: 255, nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiTao = table.Column<string>(maxLength: 50, nullable: true),
                    DP1 = table.Column<string>(type: "ntext", nullable: true),
                    DP2 = table.Column<string>(type: "ntext", nullable: true),
                    DP3 = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCanBoGiangVien", x => x.MaCBGV);
                    table.ForeignKey(
                        name: "FK_tblCanBoGiangVien_tblBacLuong",
                        column: x => x.MaBac,
                        principalTable: "tblBacLuong",
                        principalColumn: "MaBac",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblCanBoGiangVien_tblBoMonTrungTam",
                        column: x => x.MaBMTT,
                        principalTable: "tblBoMonTrungTam",
                        principalColumn: "MaBMTT",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblCanBoGiangVien_tblKhenThuongKiLuat",
                        column: x => x.MaKTKL,
                        principalTable: "tblKhenThuongKiLuat",
                        principalColumn: "MaKTKL",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblCanBoGiangVien_tblNgachCongChuc",
                        column: x => x.MaNgach,
                        principalTable: "tblNgachCongChuc",
                        principalColumn: "MaNgach",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblCanBoGiangVien_tblPhongKhoa",
                        column: x => x.MaPK,
                        principalTable: "tblPhongKhoa",
                        principalColumn: "MaPK",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblCanBoGiangVien_tblTrinhDoHocVan",
                        column: x => x.MaTDHV,
                        principalTable: "tblTrinhDoHocVan",
                        principalColumn: "MaTDHV",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblDKGiangDay",
                columns: table => new
                {
                    MaDKGD = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaCBGV = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    MaHP = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    NgayDK = table.Column<DateTime>(type: "datetime", nullable: true),
                    GhiChu = table.Column<string>(type: "ntext", nullable: true),
                    status = table.Column<int>(nullable: true),
                    DP1 = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDKGiangDay", x => x.MaDKGD);
                    table.ForeignKey(
                        name: "FK_tblDKGiangDay_tblCanBoGiangVien",
                        column: x => x.MaCBGV,
                        principalTable: "tblCanBoGiangVien",
                        principalColumn: "MaCBGV",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblDKGiangDay_tblHocPhan",
                        column: x => x.MaHP,
                        principalTable: "tblHocPhan",
                        principalColumn: "MaHP",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblGiaoVienChuNhiem",
                columns: table => new
                {
                    MaGVCN = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaLop = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    MaCBGV = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    BatDau = table.Column<DateTime>(type: "datetime", nullable: true),
                    KetThuc = table.Column<DateTime>(type: "datetime", nullable: true),
                    HieuLuc = table.Column<int>(nullable: true),
                    GhiChu = table.Column<string>(type: "ntext", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiTao = table.Column<string>(maxLength: 50, nullable: true),
                    DP1 = table.Column<string>(type: "ntext", nullable: true),
                    DP2 = table.Column<string>(type: "ntext", nullable: true),
                    DP3 = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblGiaoVienChuNhiem", x => x.MaGVCN);
                    table.ForeignKey(
                        name: "FK_tblGiaoVienChuNhiem_tblCanBoGiangVien",
                        column: x => x.MaCBGV,
                        principalTable: "tblCanBoGiangVien",
                        principalColumn: "MaCBGV",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblLyLichGV",
                columns: table => new
                {
                    MaLL = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaCBGV = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    TenLL = table.Column<string>(maxLength: 255, nullable: true),
                    LoaiLL = table.Column<string>(type: "ntext", nullable: true),
                    LinkBaiBao = table.Column<string>(type: "ntext", nullable: true),
                    Ghichu = table.Column<string>(type: "ntext", nullable: true),
                    Status = table.Column<int>(nullable: true),
                    DP1 = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLyLichGV", x => x.MaLL);
                    table.ForeignKey(
                        name: "FK_tblLyLichGV_tblCanBoGiangVien",
                        column: x => x.MaCBGV,
                        principalTable: "tblCanBoGiangVien",
                        principalColumn: "MaCBGV",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_user_id",
                table: "RefreshToken",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblBoMonTrungTam_MaPK",
                table: "tblBoMonTrungTam",
                column: "MaPK");

            migrationBuilder.CreateIndex(
                name: "IX_tblCanBoGiangVien_MaBac",
                table: "tblCanBoGiangVien",
                column: "MaBac");

            migrationBuilder.CreateIndex(
                name: "IX_tblCanBoGiangVien_MaBMTT",
                table: "tblCanBoGiangVien",
                column: "MaBMTT");

            migrationBuilder.CreateIndex(
                name: "IX_tblCanBoGiangVien_MaKTKL",
                table: "tblCanBoGiangVien",
                column: "MaKTKL");

            migrationBuilder.CreateIndex(
                name: "IX_tblCanBoGiangVien_MaNgach",
                table: "tblCanBoGiangVien",
                column: "MaNgach");

            migrationBuilder.CreateIndex(
                name: "IX_tblCanBoGiangVien_MaPK",
                table: "tblCanBoGiangVien",
                column: "MaPK");

            migrationBuilder.CreateIndex(
                name: "IX_tblCanBoGiangVien_MaTDHV",
                table: "tblCanBoGiangVien",
                column: "MaTDHV");

            migrationBuilder.CreateIndex(
                name: "IX_tblDKGiangDay_MaCBGV",
                table: "tblDKGiangDay",
                column: "MaCBGV");

            migrationBuilder.CreateIndex(
                name: "IX_tblDKGiangDay_MaHP",
                table: "tblDKGiangDay",
                column: "MaHP");

            migrationBuilder.CreateIndex(
                name: "IX_tblGiaoVienChuNhiem_MaCBGV",
                table: "tblGiaoVienChuNhiem",
                column: "MaCBGV");

            migrationBuilder.CreateIndex(
                name: "IX_tblHocPhan_MaPK",
                table: "tblHocPhan",
                column: "MaPK");

            migrationBuilder.CreateIndex(
                name: "IX_tblLuong_MaBac",
                table: "tblLuong",
                column: "MaBac");

            migrationBuilder.CreateIndex(
                name: "IX_tblLyLichGV_MaCBGV",
                table: "tblLyLichGV",
                column: "MaCBGV");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "tblChiTietPhieuThu");

            migrationBuilder.DropTable(
                name: "tblChuongTrinhDaoTao");

            migrationBuilder.DropTable(
                name: "tblChuongTrinhDaoTaoChiTiet");

            migrationBuilder.DropTable(
                name: "tblDiemHocPhan");

            migrationBuilder.DropTable(
                name: "tblDiemHocPhanChiTiet");

            migrationBuilder.DropTable(
                name: "tblDinhMucHocPhi");

            migrationBuilder.DropTable(
                name: "tblDKGiangDay");

            migrationBuilder.DropTable(
                name: "tblGiaoVienChuNhiem");

            migrationBuilder.DropTable(
                name: "tblHopDongLD");

            migrationBuilder.DropTable(
                name: "tblKhoanThu");

            migrationBuilder.DropTable(
                name: "tblLophoc");

            migrationBuilder.DropTable(
                name: "tblLuong");

            migrationBuilder.DropTable(
                name: "tblLyLichGV");

            migrationBuilder.DropTable(
                name: "tblNganHang");

            migrationBuilder.DropTable(
                name: "tblNganhDaoTao");

            migrationBuilder.DropTable(
                name: "tblPhieuThu");

            migrationBuilder.DropTable(
                name: "tblSinhvien");

            migrationBuilder.DropTable(
                name: "tblSinhVienLopHoc");

            migrationBuilder.DropTable(
                name: "tblSoGhiNoSinhVien");

            migrationBuilder.DropTable(
                name: "tblUyNhiemThu");

            migrationBuilder.DropTable(
                name: "QuanLyPhienBan",
                schema: "nhutero5_utehy");

            migrationBuilder.DropTable(
                name: "tblQuanLyPhienBan",
                schema: "nhutero5_utehy");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "tblHocPhan");

            migrationBuilder.DropTable(
                name: "tblCanBoGiangVien");

            migrationBuilder.DropTable(
                name: "tblBacLuong");

            migrationBuilder.DropTable(
                name: "tblBoMonTrungTam");

            migrationBuilder.DropTable(
                name: "tblKhenThuongKiLuat");

            migrationBuilder.DropTable(
                name: "tblNgachCongChuc");

            migrationBuilder.DropTable(
                name: "tblTrinhDoHocVan");

            migrationBuilder.DropTable(
                name: "tblPhongKhoa");
        }
    }
}
