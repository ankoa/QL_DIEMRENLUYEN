using OfficeOpenXml;
using ql_diemrenluyen.BUS;
using ql_diemrenluyen.DTO;

namespace ql_diemrenluyen.Util.ExcelImporter
{
    internal class ImportGiangVien
    {
        /// <summary>
        /// Import dữ liệu từ file Excel và thêm vào database
        /// </summary>
        /// <param name="filePath">Đường dẫn file Excel</param>
        /// <returns>Danh sách giảng viên đã import</returns>
        public List<GiangVienDTO> ImportFromExcel(string filePath)
        {
            // Kiểm tra file có tồn tại hay không
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Không tìm thấy file: {filePath}");
            }

            // Đọc file Excel và chuyển dữ liệu sang danh sách giảng viên
            List<GiangVienDTO> giangVienList = ReadExcel(filePath);

            // Gọi DAO để chèn dữ liệu vào database
            foreach (var giangVien in giangVienList)
            {
                string password = giangVien.NgaySinh.ToString("ddMMyyyy") ?? "123456";

                AccountDTO acc = new AccountDTO
                {
                    Id = giangVien.Id,
                    Password = password,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    Role = 3, // Vai trò 2 cho giảng viên
                    Status = 1
                };

                AccountBUS.AddAccount(acc);

                // Thêm giảng viên vào database
                GiangVienBUS.AddGiangVienByExcel(giangVien);
            }

            return giangVienList;
        }

        /// <summary>
        /// Đọc dữ liệu từ file Excel
        /// </summary>
        /// <param name="filePath">Đường dẫn file Excel</param>
        /// <returns>Danh sách giảng viên từ file Excel</returns>
        private List<GiangVienDTO> ReadExcel(string filePath)
        {
            List<GiangVienDTO> giangVienList = new List<GiangVienDTO>();

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
                        //string tenKhoa = worksheet.Cells[row, 6].Text; // Cột 'Khoa'

                        //// Tra cứu ID của khoa
                        //long khoaId = KhoaBUS.GetKhoaByName(tenKhoa).Id;
                        //if (khoaId == -1) throw new Exception($"Không tìm thấy khoa: {tenKhoa}");

                        // Tạo đối tượng GiangVienDTO
                        GiangVienDTO giangVien = new GiangVienDTO
                        {
                            Id = Convert.ToInt64(worksheet.Cells[row, 1].Text),
                            Name = worksheet.Cells[row, 2].Text,
                            Email = worksheet.Cells[row, 3].Text,
                            KhoaId = Convert.ToInt64(worksheet.Cells[row, 5].Text),
                            NgaySinh = DateTime.Parse(worksheet.Cells[row, 4].Text),
                            GioiTinh = int.Parse(worksheet.Cells[row, 6].Text),
                            Status = 1, // Mặc định là 1
                            CreatedAt = DateTime.UtcNow,
                            UpdatedAt = DateTime.UtcNow
                        };

                        giangVienList.Add(giangVien);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Lỗi tại dòng {row}: {ex.Message}");
                    }
                }
            }

            return giangVienList;
        }
    }
}
