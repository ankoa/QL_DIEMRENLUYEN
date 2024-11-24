using MySql.Data.MySqlClient;
using ql_diemrenluyen.DTO;

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
                    CoVanId = row[2] != DBNull.Value ? (long?)Convert.ToInt64(row[2]) : null, // Xử lý null
                    Khoa = KhoaDAO.GetKhoaByID(Convert.ToInt64(row[3])),
                    HeDaoTao = HeHocDAO.findById(Convert.ToInt32(row[4])),
                    CreatedAt = row[5] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[5]) : null,
                    UpdatedAt = row[6] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[6]) : null,
                    status = Convert.ToInt16(row[7])
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
                    CoVanId = row[2] != DBNull.Value ? (long?)Convert.ToInt64(row[2]) : null, // Xử lý null
                    Khoa = KhoaDAO.GetKhoaByID(Convert.ToInt64(row[3])),
                    HeDaoTao = HeHocDAO.findById(Convert.ToInt32(row[4])),
                    CreatedAt = row[5] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[5]) : null,
                    UpdatedAt = row[6] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[6]) : null,
                    status = Convert.ToInt16(row[7])
                };
                return lop;
            }

            return null;
        }

        // Lấy đối tượng lớp từ ID của lớp
        public static LopDTO GetLopByLopNameAndKhoaName(string lop, string khoa)
        {
            // Câu lệnh SQL để tìm lớp dựa trên tên lớp và tên khoa
            string sql = @"
            SELECT lop.id, lop.tenlop, lop.khoa_id, lop.hedaotao, lop.created_at, lop.updated_at, lop.status
            FROM lop
            INNER JOIN khoa ON lop.khoa_id = khoa.id
            WHERE LOWER(lop.tenlop) = LOWER(@lopName) AND LOWER(khoa.tenkhoa) = LOWER(@khoaName)
            LIMIT 1;
            ";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@lopName", lop);
            cmd.Parameters.AddWithValue("@khoaName", khoa);

            List<List<object>> result = DBConnection.ExecuteReader(cmd);

            if (result.Count > 0)
            {
                List<object> row = result[0];
                LopDTO lopDTO = new LopDTO
                {
                    Id = Convert.ToInt64(row[0]),
                    TenLop = Convert.ToString(row[1]),
                    CoVanId = Convert.ToInt64(row[2]),
                    Khoa = KhoaDAO.GetKhoaByID(Convert.ToInt64(row[3])),
                    HeDaoTao = HeHocDAO.findById(Convert.ToInt32(row[4])),
                    CreatedAt = row[5] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[5]) : null,
                    UpdatedAt = row[6] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[6]) : null,
                    status = Convert.ToInt16(row[7])
                };
                return lopDTO;
            }

            return null;
        }


        // Thêm lớp mới
        public static bool AddLop(LopDTO lop)
        {
            string sql = "INSERT INTO lop (tenlop, covan_id, khoa_id, hedaotao, created_at, updated_at, status) VALUES (@tenLop, @covan_id, @khoaId, @heDaoTao, @createdAt, @updatedAt, @status)";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@tenLop", lop.TenLop);
            cmd.Parameters.AddWithValue("@covan_id", lop.CoVanId.HasValue ? lop.CoVanId.Value : (object)DBNull.Value); // Xử lý null
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
            string sql = "UPDATE lop SET covan_id = @covan_id, tenlop = @tenLop, khoa_id = @khoaId, hedaotao = @heDaoTao, created_at = @createdAt, updated_at = @updatedAt, status = @status WHERE id = @id";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", lop.Id);
            cmd.Parameters.AddWithValue("@covan_id", lop.CoVanId.HasValue ? lop.CoVanId.Value : (object)DBNull.Value); // Xử lý null
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
            String sql = @"
        SELECT 
            lop.id, 
            lop.tenlop, 
            lop.covan_id, 
            lop.khoa_id, 
            lop.hedaotao, 
            lop.created_at, 
            lop.updated_at, 
            lop.status 
        FROM lop
        INNER JOIN khoa ON lop.khoa_id = khoa.id
        INNER JOIN hehoc ON lop.hedaotao = hehoc.id
        LEFT JOIN giangvien ON lop.covan_id = giangvien.id
        WHERE 
            (lop.id LIKE @id OR 
             lop.tenlop LIKE @name OR 
             khoa.tenkhoa LIKE @khoaid OR 
             hehoc.name LIKE @hedaotao OR 
             giangvien.name LIKE @giangvienname)";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", "%" + value + "%");
            cmd.Parameters.AddWithValue("@name", "%" + value + "%");
            cmd.Parameters.AddWithValue("@khoaid", "%" + value + "%");
            cmd.Parameters.AddWithValue("@hedaotao", "%" + value + "%");
            cmd.Parameters.AddWithValue("@giangvienname", "%" + value + "%");

            List<List<object>> result = DBConnection.ExecuteReader(cmd);
            if (result.Count > 0)
            {
                foreach (var row in result)
                {
                    LopDTO lop = new LopDTO
                    {
                        Id = Convert.ToInt64(row[0]),
                        TenLop = Convert.ToString(row[1]),
                        CoVanId = Convert.ToInt64(row[2]),
                        Khoa = KhoaDAO.GetKhoaByID(Convert.ToInt64(row[3])),
                        HeDaoTao = HeHocDAO.findById(Convert.ToInt32(row[4])),
                        CreatedAt = row[5] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[5]) : null,
                        UpdatedAt = row[6] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[6]) : null,
                        status = Convert.ToInt16(row[7])
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
                        CoVanId = Convert.ToInt64(row[2]),
                        Khoa = KhoaDAO.GetKhoaByID(Convert.ToInt64(row[3])),
                        HeDaoTao = HeHocDAO.findById(Convert.ToInt32(row[4])),
                        CreatedAt = row[5] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[5]) : null,
                        UpdatedAt = row[6] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[6]) : null,
                        status = Convert.ToInt16(row[7])
                    };
                    list.Add(lop);
                }
                return list;
            }
            return null;
        }

        public static List<LopDTO> getLopByKhoaId(String value)
        {
            List<LopDTO> list = new List<LopDTO>();
            String sql = "select lop.id, lop.tenlop, lop.khoa_id, lop.hedaotao, lop.created_at, lop.updated_at, lop.status from lop, khoa where (khoa.Id like @khoaid) and ( lop.khoa_id = khoa.id )";
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
                        CoVanId = Convert.ToInt64(row[2]),
                        Khoa = KhoaDAO.GetKhoaByID(Convert.ToInt64(row[3])),
                        HeDaoTao = HeHocDAO.findById(Convert.ToInt32(row[4])),
                        CreatedAt = row[5] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[5]) : null,
                        UpdatedAt = row[6] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[6]) : null,
                        status = Convert.ToInt16(row[7])
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
                        CoVanId = Convert.ToInt64(row[2]),
                        Khoa = KhoaDAO.GetKhoaByID(Convert.ToInt64(row[3])),
                        HeDaoTao = HeHocDAO.findById(Convert.ToInt32(row[4])),
                        CreatedAt = row[5] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[5]) : null,
                        UpdatedAt = row[6] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[6]) : null,
                        status = Convert.ToInt16(row[7])
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
            String sql = "select * from lop where" + value;
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
                        CoVanId = Convert.ToInt64(row[2]),
                        Khoa = KhoaDAO.GetKhoaByID(Convert.ToInt64(row[3])),
                        HeDaoTao = HeHocDAO.findById(Convert.ToInt32(row[4])),
                        CreatedAt = row[5] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[5]) : null,
                        UpdatedAt = row[6] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[6]) : null,
                        status = Convert.ToInt16(row[7])
                    };
                    list.Add(lop);
                }
                return list;
            }
            return null;
        }

        public static LopDetailsDTO GetLopDetailsBySinhVienId(long sinhVienId)
        {
            string sql = @"
        SELECT 
            l.tenlop AS TenLop, 
            k.tenkhoa AS TenKhoa, 
            gv_gv.name AS GiangVien
        FROM sinhvien sv
        INNER JOIN lop l ON sv.lop_id = l.id
        INNER JOIN khoa k ON l.khoa_id = k.id
        LEFT JOIN covan_hoctap gv_ctht ON l.id = gv_ctht.lop_id
        LEFT JOIN giangvien gv_gv ON gv_ctht.giangvien_id = gv_gv.id
        WHERE sv.id = @sinhVienId;
    ";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@sinhVienId", sinhVienId);

            List<List<object>> result = DBConnection.ExecuteReader(cmd);

            if (result.Count == 0)
            {
                return null; // Không tìm thấy kết quả
            }

            var row = result[0]; // Dòng đầu tiên của kết quả

            // Ánh xạ dữ liệu vào DTO
            LopDetailsDTO lopDetails = new LopDetailsDTO
            {
                TenLop = row[0] != DBNull.Value ? Convert.ToString(row[0]) : null,
                TenKhoa = row[1] != DBNull.Value ? Convert.ToString(row[1]) : null,
                CoVan = row[2] != DBNull.Value ? Convert.ToString(row[2]) : null
            };
            return lopDetails;
        }

        public static List<LopDetailsDTO> GetLopHocCuaCoVanById(long covanId)
        {
            string sql = @"
                       SELECT
                l.tenlop AS TenLop,
                k.tenkhoa AS TenKhoa,
                COUNT(sv.id) AS SoLuong
            FROM lop l
            LEFT JOIN giangvien gv ON l.covan_id = gv.id         
            INNER JOIN khoa k ON gv.khoa_id = k.id             
            LEFT JOIN sinhvien sv ON sv.lop_id = l.id            
            WHERE gv.id = @covanId                            
              AND l.khoa_id = gv.khoa_id                         
            GROUP BY l.tenlop, k.tenkhoa;
            "; // Đảm bảo GROUP BY theo cả tên lớp và tên khoa

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@covanId", covanId);

            int count = 1;

            List<List<object>> result = DBConnection.ExecuteReader(cmd);

            List<LopDetailsDTO> lopDetailsList = new List<LopDetailsDTO>();

            foreach (var row in result)
            {
                LopDetailsDTO lopDetails = new LopDetailsDTO
                {
                    STT = count,
                    TenLop = row[0] != DBNull.Value ? Convert.ToString(row[0]) : null,
                    TenKhoa = row[1] != DBNull.Value ? Convert.ToString(row[1]) : null,
                    SoLuong = row[2] != DBNull.Value ? Convert.ToInt32(row[2]) : 0 // Chắc chắn giá trị là số
                };
                count++;
                lopDetailsList.Add(lopDetails);
            }

            return lopDetailsList;
        }


    }

    public class LopDetailsDTO
    {
        public int? STT { get; set; }
        public long LopId { get; set; }
        public string TenLop { get; set; }
        public string TenKhoa { get; set; }
        public string CoVan { get; set; }
        public int? SoLuong { get; set; }
    }

}
