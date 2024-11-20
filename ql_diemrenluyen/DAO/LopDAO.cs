using MySql.Data.MySqlClient;
using ql_diemrenluyen.DTO;
using System;
using System.Collections.Generic;

namespace ql_diemrenluyen.DAO
{
    public class LopDAO
    {
        // Lấy tất cả lớp
        public static List<LopDTO> GetAllLop()
        {
            List<LopDTO> lopList = new List<LopDTO>();
            string sql = "SELECT * FROM lop"; // Câu lệnh SQL

            List<List<object>> result = DBConnection.ExecuteReader(sql);

            foreach (var row in result)
            {
                LopDTO lop = new LopDTO
                {
                    Id = Convert.ToInt64(row[0]),
                    TenLop = Convert.ToString(row[1]),
                    Khoa = KhoaDAO.GetKhoaByID(Convert.ToInt64(row[2])),
                    HeDaoTao = HeHocDAO.findById(Convert.ToInt32(row[3])),
                    CreatedAt = row[4] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[4]) : null,
                    UpdatedAt = row[5] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[5]) : null,
                    status = Convert.ToInt16(row[6])
                };

                lopList.Add(lop);
            }

            return lopList;
        }

        // Lấy đối tượng lớp từ ID của lớp
        public static LopDTO GetLopByID(long idLop)
        {
            string sql = "select * from lop where lop.id= @idLop"; // Câu lệnh SQL
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@idLop", idLop);

            List<List<object>> result = DBConnection.ExecuteReader(cmd);

            if (result.Count > 0)
            {
                List<object> row = result[0];
                LopDTO lop = new LopDTO
                {
                    Id = Convert.ToInt64(row[0]),
                    TenLop = Convert.ToString(row[1]),
                    Khoa = KhoaDAO.GetKhoaByID(Convert.ToInt64(row[2])),
                    HeDaoTao = HeHocDAO.findById(Convert.ToInt32(row[3])),
                    CreatedAt = row[4] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[4]) : null,
                    UpdatedAt = row[5] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[5]) : null,
                    status = Convert.ToInt16(row[6])
                };
                return lop;
            }
           
            return null;
        }

        // Thêm lớp mới
        public static bool AddLop(LopDTO lop)
        {
            string sql = "INSERT INTO lop (tenlop, khoa_id, hedaotao, created_at, updated_at, status) VALUES (@tenLop, @khoaId, @heDaoTao, @createdAt, @updatedAt, @status)";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@tenLop", lop.TenLop);
            cmd.Parameters.AddWithValue("@khoaId", lop.Khoa.Id);
            cmd.Parameters.AddWithValue("@heDaoTao", lop.HeDaoTao.Id);
            cmd.Parameters.AddWithValue("@createdAt", lop.CreatedAt);
            cmd.Parameters.AddWithValue("@updatedAt", lop.UpdatedAt);
            cmd.Parameters.AddWithValue("@status", lop.status);
            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Cập nhật thông tin lớp
        public static bool UpdateLop(LopDTO lop)
        {
            string sql = "UPDATE lop SET tenlop = @tenLop, khoa_id = @khoaId, hedaotao = @heDaoTao, created_at = @createdAt, updated_at = @updatedAt, status = @status WHERE id = @id";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", lop.Id);
            cmd.Parameters.AddWithValue("@tenLop", lop.TenLop);
            cmd.Parameters.AddWithValue("@khoaId", lop.Khoa.Id);
            cmd.Parameters.AddWithValue("@heDaoTao", lop.HeDaoTao.Id);
            cmd.Parameters.AddWithValue("@createdAt", lop.CreatedAt);
            cmd.Parameters.AddWithValue("@updatedAt", lop.UpdatedAt);
            cmd.Parameters.AddWithValue("@status", lop.status);
            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Xóa lớp
        public static bool DeleteLop(long id)
        {
            string sql = "UPDATE lop SET status = @status WHERE id = @id";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@status", 0);
            cmd.Parameters.AddWithValue("@id", id);
            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        public static List<LopDTO> findAll(String value)
        {
            List<LopDTO> list = new List<LopDTO>();
            String sql = "select lop.id, lop.tenlop, lop.khoa_id, lop.hedaotao, lop.created_at, lop.updated_at, lop.status from lop, khoa, hehoc where (lop.id like @id or lop.tenlop like @name or khoa.tenkhoa like @khoaid or hehoc.name like @hedaotao) and ( lop.khoa_id = khoa.id and lop.hedaotao = hehoc.id )";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", "%" + value + "%");
            cmd.Parameters.AddWithValue("@name", "%" + value + "%");
            cmd.Parameters.AddWithValue("@khoaid", "%" + value + "%");
            cmd.Parameters.AddWithValue("@hedaotao", "%" + value + "%");
            List<List<object>> result = DBConnection.ExecuteReader(cmd);
            if (result.Count > 0)
            {
                foreach (var row in result)
                {
                    LopDTO lop = new LopDTO
                    {
                        Id = Convert.ToInt64(row[0]),
                        TenLop = Convert.ToString(row[1]),
                        Khoa = KhoaDAO.GetKhoaByID(Convert.ToInt64(row[2])),
                        HeDaoTao = HeHocDAO.findById(Convert.ToInt32(row[3])),
                        CreatedAt = row[4] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[4]) : null,
                        UpdatedAt = row[5] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[5]) : null,
                        status = Convert.ToInt16(row[6])
                    };
                    list.Add(lop);
                }
                return list;
            }
            return null;
        }
        
        
        public static List<LopDTO> findByKhoaId(String value)
        {
            List<LopDTO> list = new List<LopDTO>();
            String sql = "select lop.id, lop.tenlop, lop.khoa_id, lop.hedaotao, lop.created_at, lop.updated_at, lop.status from lop, khoa where (khoa.tenkhoa like @khoaid) and ( lop.khoa_id = khoa.id )";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@khoaid", "%" + value + "%");
            List<List<object>> result = DBConnection.ExecuteReader(cmd);
            if (result.Count > 0)
            {
                foreach (var row in result)
                {
                    LopDTO lop = new LopDTO
                    {
                        Id = Convert.ToInt64(row[0]),
                        TenLop = Convert.ToString(row[1]),
                        Khoa = KhoaDAO.GetKhoaByID(Convert.ToInt64(row[2])),
                        HeDaoTao = HeHocDAO.findById(Convert.ToInt32(row[3])),
                        CreatedAt = row[4] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[4]) : null,
                        UpdatedAt = row[5] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[5]) : null,
                        status = Convert.ToInt16(row[6])
                    };
                    list.Add(lop);
                }
                return list;
            }
            return null;
        }
        public static List<LopDTO> findByHeHoc(String value)
        {
            List<LopDTO> list = new List<LopDTO>();
            String sql = "select lop.id, lop.tenlop, lop.khoa_id, lop.hedaotao, lop.created_at, lop.updated_at, lop.status from lop, hehoc where ( hehoc.name like @hedaotao) and (lop.hedaotao = hehoc.id)";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@hedaotao", "%" + value + "%");
            List<List<object>> result = DBConnection.ExecuteReader(cmd);
            if (result.Count > 0)
            {
                foreach (var row in result)
                {
                    LopDTO lop = new LopDTO
                    {
                        Id = Convert.ToInt64(row[0]),
                        TenLop = Convert.ToString(row[1]),
                        Khoa = KhoaDAO.GetKhoaByID(Convert.ToInt64(row[2])),
                        HeDaoTao = HeHocDAO.findById(Convert.ToInt32(row[3])),
                        CreatedAt = row[4] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[4]) : null,
                        UpdatedAt = row[5] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[5]) : null,
                        status = Convert.ToInt16(row[6])
                    };
                    list.Add(lop);
                }
                return list;
            }
            return null;
        }
        public static List<LopDTO> GetListBySearch(String value)
        {
            List<LopDTO> list = new List<LopDTO>();
            String sql = "select * from lop where"+value;
            var cmd = new MySqlCommand(sql);
            List<List<object>> result = DBConnection.ExecuteReader(cmd);
            if (result.Count > 0)
            {
                foreach (var row in result)
                {
                    LopDTO lop = new LopDTO
                    {
                        Id = Convert.ToInt64(row[0]),
                        TenLop = Convert.ToString(row[1]),
                        Khoa = KhoaDAO.GetKhoaByID(Convert.ToInt64(row[2])),
                        HeDaoTao = HeHocDAO.findById(Convert.ToInt32(row[3])),
                        CreatedAt = row[4] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[4]) : null,
                        UpdatedAt = row[5] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[5]) : null,
                        status = Convert.ToInt16(row[6])
                    };
                    list.Add(lop);
                }
                return list;
            }
            return null;
        }

    }
}
