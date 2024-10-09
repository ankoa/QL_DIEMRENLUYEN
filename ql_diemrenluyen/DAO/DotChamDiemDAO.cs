using MySql.Data.MySqlClient;
using ql_diemrenluyen.DTO;
using System;
using System.Collections.Generic;

namespace ql_diemrenluyen.DAO
{
    public class DotChamDiemDAO
    {
        // Lấy tất cả đợt chấm điểm
        public static List<DotChamDiemDTO> GetAllDotChamDiem()
        {
            List<DotChamDiemDTO> dotChamDiems = new List<DotChamDiemDTO>();
            string sql = "SELECT * FROM dot_cham_diem"; // Thay đổi câu lệnh SQL nếu cần

            List<List<object>> result = DBConnection.ExecuteReader(sql);

            foreach (var row in result)
            {
                DotChamDiemDTO dotChamDiem = new DotChamDiemDTO
                {
                    Id = Convert.ToInt32(row[0]),
                    HocKiId = Convert.ToInt32(row[1]),
                    StartDate = Convert.ToDateTime(row[2]),
                    EndDate = Convert.ToDateTime(row[3]),
                    Name = Convert.ToString(row[4])
                };

                dotChamDiems.Add(dotChamDiem);
            }

            return dotChamDiems;
        }

        // Thêm đợt chấm điểm mới
        public static bool AddDotChamDiem(DotChamDiemDTO dotChamDiem)
        {
            string sql = $"INSERT INTO dot_cham_diem (HocKiId, StartDate, EndDate, Name) " +
                         $"VALUES (@hocKiId, @startDate, @endDate, @name)";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@hocKiId", dotChamDiem.HocKiId);
            cmd.Parameters.AddWithValue("@startDate", dotChamDiem.StartDate);
            cmd.Parameters.AddWithValue("@endDate", dotChamDiem.EndDate);
            cmd.Parameters.AddWithValue("@name", dotChamDiem.Name);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Cập nhật thông tin đợt chấm điểm
        public static bool UpdateDotChamDiem(DotChamDiemDTO dotChamDiem)
        {
            string sql = $"UPDATE dot_cham_diem SET HocKiId = @hocKiId, StartDate = @startDate, " +
                         $"EndDate = @endDate, Name = @name WHERE Id = @id";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", dotChamDiem.Id);
            cmd.Parameters.AddWithValue("@hocKiId", dotChamDiem.HocKiId);
            cmd.Parameters.AddWithValue("@startDate", dotChamDiem.StartDate);
            cmd.Parameters.AddWithValue("@endDate", dotChamDiem.EndDate);
            cmd.Parameters.AddWithValue("@name", dotChamDiem.Name);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Xóa đợt chấm điểm
        public static bool DeleteDotChamDiem(int id)
        {
            string sql = $"DELETE FROM dot_cham_diem WHERE Id = @id";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", id);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }
    }
}
