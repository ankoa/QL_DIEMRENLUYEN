using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ql_diemrenluyen.DTO;

namespace ql_diemrenluyen.DAO
{
    internal class ChuThichTieuChiDAO
    {
        public static List<ChuThichTieuChiDTO> GetAllChuThichTieuChi()
        {
            List<ChuThichTieuChiDTO> chuThichList = new List<ChuThichTieuChiDTO>();
            string sql = @"
                SELECT 
                    id, 
                    tieuchidanhgia_id, 
                    name, 
                    diem, 
                    created_at, 
                    updated_at, 
                    status
                FROM 
                    chuthichtieuchi
                WHERE 
                    status = 1;
            ";

            List<List<object>> result = DBConnection.ExecuteReader(sql);

            foreach (var row in result)
            {
                // Đọc dữ liệu từ kết quả truy vấn
                int id = Convert.ToInt32(row[0]);
                long tieuChiDanhGiaId = Convert.ToInt64(row[1]);
                string name = Convert.ToString(row[2]);
                int diem = Convert.ToInt32(row[3]);
                DateTime createdAt = Convert.ToDateTime(row[4]);
                DateTime updatedAt = Convert.ToDateTime(row[5]);
                int status = Convert.ToInt32(row[6]);

                // Tạo đối tượng DTO và thêm vào danh sách
                ChuThichTieuChiDTO chuThich = new ChuThichTieuChiDTO(
                    id,
                    tieuChiDanhGiaId,
                    name,
                    diem,
                    createdAt,
                    updatedAt,
                    status
                );

                chuThichList.Add(chuThich);
            }

            return chuThichList;
        }
        public static List<ChuThichTieuChiDTO> GetChuThichByTieuChiId(long tieuChiId)
    {
        string sql = $@"
            SELECT 
                id, 
                tieuchidanhgia_id, 
                name, 
                diem, 
                created_at, 
                updated_at, 
                status
            FROM 
                chuthichtieuchi
            WHERE 
                tieuchidanhgia_id = {tieuChiId} AND status = 1";

        var result = DBConnection.ExecuteReader(sql); // Giả định phương thức ExecuteReader trả về List<Dictionary<string, object>>
        List<ChuThichTieuChiDTO> list = new List<ChuThichTieuChiDTO>();

        foreach (var row in result)
        {
            list.Add(new ChuThichTieuChiDTO(
                id: Convert.ToInt32(row[0]),
                tieuChiDanhGiaId: Convert.ToInt64(row[1]),
                name: Convert.ToString(row[2]),
                diem: Convert.ToInt32(row[3]),
                createdAt: Convert.ToDateTime(row[4]),
                updatedAt: Convert.ToDateTime(row[5]),
                status: Convert.ToInt32(row[6])
            ));
        }
        return list;
    }
    }
}

