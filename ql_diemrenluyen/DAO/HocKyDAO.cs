using MySql.Data.MySqlClient;
using ql_diemrenluyen.DTO;

namespace ql_diemrenluyen.DAO
{
    public class HocKyDAO
    {
        // Lấy tất cả học kỳ
        public static List<HocKyDTO> GetAllHocKy()
        {
            List<HocKyDTO> hocKys = new List<HocKyDTO>();
            string sql = "SELECT * FROM hocky";

            List<List<object>> result = DBConnection.ExecuteReader(sql);

            foreach (var row in result)
            {
                HocKyDTO hocKy = new HocKyDTO
                {
                    Id = Convert.ToInt32(row[0]),
                    Name = Convert.ToString(row[1]),
                    namhoc = Convert.ToInt32(row[2])
                };

                hocKys.Add(hocKy);
            }

            return hocKys;
        }

        // Thêm học kỳ mới
        public static bool AddHocKy(HocKyDTO hocKy)
        {
            string sql = $"INSERT INTO hocky (Name, namhoc) " +
                         $"VALUES (@name, @namhoc)";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@name", hocKy.Name);
            cmd.Parameters.AddWithValue("@namhoc", hocKy.namhoc);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Cập nhật thông tin học kỳ
        public static bool UpdateHocKy(HocKyDTO hocKy)
        {
            string sql = $"UPDATE hocky SET Name = @name, namhoc = @namhoc WHERE Id = @id";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", hocKy.Id);
            cmd.Parameters.AddWithValue("@name", hocKy.Name);
            cmd.Parameters.AddWithValue("@namhoc", hocKy.namhoc);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Xóa học kỳ
        public static bool DeleteHocKy(int id)
        {
            string sql = $"DELETE FROM hocky WHERE Id = @id";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", id);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Lấy tên tất cả học kì
        public static List<string> GetAllNamHoc()
        {
            List<string> namhoc = new List<string>();
            string sql = "SELECT DISTINCT namhoc \r\nFROM hocky\r\nORDER BY namhoc ASC;\r\n";

            List<List<object>> result = DBConnection.ExecuteReader(sql);

            foreach (var row in result)
            {
                namhoc.Add(Convert.ToString(row[0]));
            }

            return namhoc;
        }

        // Lấy học kỳ theo tên và năm học
        public static HocKyDTO GetHocKyByNameAndYear(string name, int namhoc)
        {
            string sql = "SELECT * FROM hocky WHERE Name = @name AND namhoc = @namhoc";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@namhoc", namhoc);

            List<List<object>> result = DBConnection.ExecuteReader(cmd);

            if (result.Count > 0)
            {
                var row = result[0];
                HocKyDTO hocKy = new HocKyDTO
                {
                    Id = Convert.ToInt32(row[0]),
                    Name = Convert.ToString(row[1]),
                    namhoc = Convert.ToInt32(row[2]),
                };
                return hocKy;
            }

            return null;
        }

    }
}
