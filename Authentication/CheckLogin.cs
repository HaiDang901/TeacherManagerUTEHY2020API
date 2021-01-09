using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DOAN52.Authentication
{
    public class CheckLogin: IDisposable
    {
        public string createkey(string password)
        {
            MD5 mh = MD5.Create();
            //Chuyển kiểu chuổi thành kiểu byte
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(password);
            //mã hóa chuỗi đã chuyển
            byte[] hash = mh.ComputeHash(inputBytes);
            //tạo đối tượng StringBuilder (làm việc với kiểu dữ liệu lớn)
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString());
            }

            return sb.ToString();
        }
        ApplicationDbContext options = new ApplicationDbContext();
        public RegisterModel ValidateUser(string username, string password)
        {
            //kiem tra ngan hang
            RegisterModel tk = new RegisterModel();
            password = createkey(password);
            //var data = options.tblNganHangs.FirstOrDefault(s => s.MaNganHang.Equals(username, StringComparison.OrdinalIgnoreCase));
            //if (data != null)
            //{
            //    if (data.MatKhau == password)
            //    {
            //        tk.UserID = data.MaNganHang;
            //        tk.UserName = username;
            //        tk.Name = "" + data.Ten;
            //        tk.UserPassword = password;
            //        tk.UserInfo = "" + data.DiaChi;
            //        tk.tinhchat = "NH";
            //        tk.UserRoles = "NH";
            //        return tk;
            //    }
            //}
            //kiem tra can bo
            var data1 = options.Users.FirstOrDefault(s => s.Id.Equals(username, StringComparison.OrdinalIgnoreCase));
            if (data1 != null)
            {
                if (data1.PasswordHash == password)
                {
                    tk.Username = username;
                    tk.FullName = data1.FullName;
                    tk.Password = password;
                    tk.Email =  data1.Email;
                    //tk.UserRoles = data1.Quyen.ToString();
                    return tk;
                }

            }
            //kiem tra sinh vien
            //var data2 = context.tblSinhviens.FirstOrDefault(s => s.MaSV.Equals(username, StringComparison.OrdinalIgnoreCase));
            //if (data2 != null)
            //{
            //    if (data2.MatKhau == password)
            //    {
            //        tk.UserID = data2.MaSV;
            //        tk.UserName = username;
            //        tk.Name = data2.HoVaTen;
            //        tk.UserPassword = password;
            //        tk.UserInfo = "" + data2.Email;
            //        tk.tinhchat = "SV";
            //        tk.UserRoles = data2.Quyen.ToString();
            //        return tk;
            //    }

            //}
            return null;
        }
        public void Dispose()
        {
            options.Dispose();
        }
    }
}
