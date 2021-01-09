using DOAN52.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOAN52.Interfaces
{
    public partial interface ITeacherBusiness
    {
        bool Create(TblCanBoGiangVien model);

        List<TblCanBoGiangVien> GetData();
        TblCanBoGiangVien GetTeacher(bool GioiTinh);
        List<TblCanBoGiangVien> Search(int pageIndex, int pageSize, out long total, string HoVaTen, string DanToc);

    }
}
