using OfficeOpenXml;
using ql_diemrenluyen.BUS;
using ql_diemrenluyen.DTO;

namespace ql_diemrenluyen.Util.ExcelImporter
{
    internal class ImportLop
    {
        /// <summary>
        /// Import dữ liệu từ file Excel và thêm vào database
        /// </summary>
        /// <param name="filePath">Đường dẫn file Excel</param>
        /// <returns>Danh sách lớp đã import</returns>
        public List<LopDTO> ImportFromExcel(string filePath)
        {
            // Kiểm tra file có tồn tại hay không
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Không tìm thấy file: {filePath}");
            }

            // Đọc file Excel và chuyển dữ liệu sang danh sách lớp học
            List<LopDTO> lopList = ReadExcel(filePath);

            // Gọi BUS để thêm dữ liệu vào database
            foreach (var lop in lopList)
            {
                LopBUS.AddLop(lop);
            }

            return lopList;
        }

        /// <summary>
        /// Đọc dữ liệu từ file Excel
        /// </summary>
        /// <param name="filePath">Đường dẫn file Excel</param>
        /// <returns>Danh sách lớp học từ file Excel</returns>
        private List<LopDTO> ReadExcel(string filePath)
        {
            List<LopDTO> lopList = new List<LopDTO>();

            // Thiết lập LicenseContext
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // Lấy sheet đầu tiên
                if (worksheet == null)
                {
                    throw new Exception("Không tìm thấy sheet trong file Excel!");
                }

                // Đọc dữ liệu từng dòng trong file Excel
                for (int row = 2; row <= worksheet.Dimension.End.Row; row++) // Bỏ qua dòng tiêu đề
                {
                    try
                    {
                        string tenKhoa = worksheet.Cells[row, 2].Text; // Cột tên khoa
                        string heDaoTao = worksheet.Cells[row, 3].Text; // Cột hệ đào tạo
                        string maCoVan = worksheet.Cells[row, 4].Text; // Cột mã cố vấn

                        // Tra cứu thông tin khoa
                        KhoaDTO khoa = KhoaBUS.GetKhoaByName(tenKhoa);
                        if (khoa == null)
                        {
                            throw new Exception($"Không tìm thấy khoa: {tenKhoa}");
                        }

                        // Tra cứu thông tin hệ đào tạo
                        HeHocDTO heHoc = HeHocBUS.GetHeHocByName(heDaoTao);
                        if (heHoc == null)
                        {
                            throw new Exception($"Không tìm thấy hệ đào tạo: {heDaoTao}");
                        }

                        // Tạo đối tượng LopDTO
                        LopDTO lop = new LopDTO
                        {
                            TenLop = worksheet.Cells[row, 1].Text, // Tên lớp
                            Khoa = khoa,
                            HeDaoTao = heHoc,
                            CreatedAt = DateTime.UtcNow,
                            UpdatedAt = DateTime.UtcNow,
                            status = 1 // Mặc định là 1
                        };

                        // Nếu mã cố vấn không trống, tra cứu giảng viên
                        if (!string.IsNullOrWhiteSpace(maCoVan))
                        {
                            GiangVienDTO giangVien = GiangVienBUS.GetGiangVienById(long.Parse(maCoVan));
                            if (giangVien != null)
                            {
                                lop.CoVanId = giangVien.Id; // Gán CoVanId nếu có giảng viên
                            }
                            else
                            {
                                throw new Exception($"Không tìm thấy giảng viên với mã: {maCoVan}");
                            }
                        }
                        else
                        {
                            lop.CoVanId = null; // Nếu mã cố vấn trống, gán CoVanId là null
                        }

                        lopList.Add(lop);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Lỗi tại dòng {row}: {ex.Message}");
                    }
                }
            }

            return lopList;
        }
    }
}
