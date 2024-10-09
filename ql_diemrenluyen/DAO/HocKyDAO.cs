using MySql.Data.MySqlClient;
using ql_diemrenluyen.DTO;
using System;
using System.Collections.Generic;

namespace ql_diemrenluyen.DAO
{
    public class HocKyDAO
    {
        // Lấy tất cả học kỳ
        public static List<HocKyDTO> GetAllHocKy()
        {
            List<HocKyDTO> hocKys = new List<HocKyDTO>();
            string sql = "SELECT * FROM hoc_ky"; // Thay đổi câu lệnh SQL nếu cần

            List<List<object>> result = DBConnection.ExecuteReader(sql);

            foreach (var row in result)
            {
                HocKyDTO hocKy = new HocKyDTO
                {
                    Id = Convert.ToInt32(row[0]),
                    Name = Convert.ToString(row[1])
                };

                hocKys.Add(hocKy);
            }

            return hocKys;
        }

        // Thêm học kỳ mới
        public static bool AddHocKy(HocKyDTO hocKy)
        {
            string sql = $"INSERT INTO hoc_ky (Name) " +
                         $"VALUES (@name)";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@name", hocKy.Name);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Cập nhật thông tin học kỳ
        public static bool UpdateHocKy(HocKyDTO hocKy)
        {
            string sql = $"UPDATE hoc_ky SET Name = @name WHERE Id = @id";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", hocKy.Id);
            cmd.Parameters.AddWithValue("@name", hocKy.Name);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Xóa học kỳ
        public static bool DeleteHocKy(int id)
        {
            string sql = $"DELETE FROM hoc_ky WHERE Id = @id";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", id);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }
    }
}
