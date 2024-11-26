using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using ql_diemrenluyen.DTO;

namespace ql_diemrenluyen.DAO
{
    public class KetQuaDotChamDAO
    {
        // Lấy tất cả kết quả đợt chấm
        public static List<KetQuaDotChamDTO> GetAllKetQuaDotCham()
        {
            List<KetQuaDotChamDTO> ketQuaList = new List<KetQuaDotChamDTO>();
            string sql = "SELECT * FROM ketquadotcham";

            List<List<object>> result = DBConnection.ExecuteReader(sql);

            foreach (var row in result)
            {
                KetQuaDotChamDTO ketQua = new KetQuaDotChamDTO(
                    Convert.ToInt32(row[0]),
                    Convert.ToInt64(row[1]),
                    Convert.ToInt32(row[2]),
                    Convert.ToString(row[3]),
                    Convert.ToDateTime(row[4]),
                    Convert.ToInt32(row[5])
                );

                ketQuaList.Add(ketQua);
            }

            return ketQuaList;
        }

        // Thêm kết quả đợt chấm
        public static bool AddKetQuaDotCham(KetQuaDotChamDTO ketQua)
        {
            string sql = "INSERT INTO ketquadotcham (thongtindotchamdiem_id, ketqua, danhgia, createdAt, status) " +
                         "VALUES (@thongTinId, @ketQua, @danhGia, @createdAt, @status)";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@thongTinId", ketQua.ThongTinDotChamDiemId);
            cmd.Parameters.AddWithValue("@ketQua", ketQua.KetQua);
            cmd.Parameters.AddWithValue("@danhGia", ketQua.DanhGia);
            cmd.Parameters.AddWithValue("@createdAt", ketQua.CreatedAt);
            cmd.Parameters.AddWithValue("@status", ketQua.Status);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Cập nhật kết quả đợt chấm
        public static bool UpdateKetQuaDotCham(KetQuaDotChamDTO ketQua)
        {
            string sql = "UPDATE ketquadotcham SET thongtindotchamdiem_id = @thongTinId, ketqua = @ketQua, danhgia = @danhGia, " +
                         "createdAt = @createdAt, status = @status WHERE id = @id";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", ketQua.Id);
            cmd.Parameters.AddWithValue("@thongTinId", ketQua.ThongTinDotChamDiemId);
            cmd.Parameters.AddWithValue("@ketQua", ketQua.KetQua);
            cmd.Parameters.AddWithValue("@danhGia", ketQua.DanhGia);
            cmd.Parameters.AddWithValue("@createdAt", ketQua.CreatedAt);
            cmd.Parameters.AddWithValue("@status", ketQua.Status);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Xóa kết quả đợt chấm
        public static bool DeleteKetQuaDotCham(int id)
        {
            string sql = "DELETE FROM ketquadotcham WHERE id = @id";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", id);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }
    }
}

