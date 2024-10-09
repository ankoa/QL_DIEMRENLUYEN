using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ql_diemrenluyen.DTO
{
    public class SinhVienDTO
    {
            private long id;
            private string name;
            private string maSv;
            private string ngaySinh;
            private string email;
            private int gioiTinh;
            private long lopId;
            private int chucVu;

            // Constructor
            public SinhVienDTO() { }

            public SinhVienDTO(long id, string name, string maSv, string ngaySinh, string email, int gioiTinh, long lopId, int chucVu)
            {
                this.id = id;
                this.name = name;
                this.maSv = maSv;
                this.ngaySinh = ngaySinh;
                this.email = email;
                this.gioiTinh = gioiTinh;
                this.lopId = lopId;
                this.chucVu = chucVu;
            }

            // Getters và Setters
            public long Id
            {
                get { return id; }
                set { id = value; }
            }

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public string MaSv
            {
                get { return maSv; }
                set { maSv = value; }
            }

            public string NgaySinh
            {
                get { return ngaySinh; }
                set { ngaySinh = value; }
            }

            public string Email
            {
                get { return email; }
                set { email = value; }
            }

            public int GioiTinh
            {
                get { return gioiTinh; }
                set { gioiTinh = value; }
            }

            public long LopId
            {
                get { return lopId; }
                set { lopId = value; }
            }

            public int ChucVu
            {
                get { return chucVu; }
                set { chucVu = value; }
            }
        }

    }



