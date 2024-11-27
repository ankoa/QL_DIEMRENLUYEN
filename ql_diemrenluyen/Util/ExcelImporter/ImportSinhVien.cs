using OfficeOpenXml;
using ql_diemrenluyen.BUS;
using ql_diemrenluyen.DAO;
using ql_diemrenluyen.DTO; // Namespace chứa SinhVienDAO

namespace ql_diemrenluyen.Util.ExcelImporter
{
    internal class ImportSinhVien
    {
        /// <summary>
        /// Import dữ liệu từ file Excel và thêm vào database
        /// </summary>
        /// <param name="filePath">Đường dẫn file Excel</param>
        /// <returns>Danh sách sinh viên đã import</returns>
        public List<SinhVienDTO> ImportFromExcel(string filePath)
        {
            // Kiểm tra file có tồn tại hay không
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Không tìm thấy file: {filePath}");
            }

            // Đọc file Excel và chuyển dữ liệu sang danh sách sinh viên
            List<SinhVienDTO> sinhVienList = ReadExcel(filePath);

            // Gọi DAO để chèn dữ liệu vào database
            foreach (var sinhVien in sinhVienList)
            {
                string password = sinhVien.NgaySinh.ToString("ddMMyyyy");

                AccountDTO acc = new AccountDTO
                {
                    Id = sinhVien.Id,
                    Password = password,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    Role = 1,
                    Status = 1
                };

                AccountBUS.AddAccount(acc);

                //Thêm sinh viên vào database
                SinhVienBUS.AddStudent(sinhVien);
            }

            return sinhVienList;
        }


        /// <summary>
        /// Đọc dữ liệu từ file Excel
        /// </summary>
        /// <param name="filePath">Đường dẫn file Excel</param>
        /// <returns>Danh sách sinh viên từ file Excel</returns>
        private List<SinhVienDTO> ReadExcel(string filePath)
        {
            List<SinhVienDTO> sinhVienList = new List<SinhVienDTO>();

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
                        string tenLop = worksheet.Cells[row, 7].Text.Trim();
                        string tenKhoa = worksheet.Cells[row, 6].Text.Trim();

                        // Tra cứu id của lớp và khoa
                        long lopId = LopDAO.GetLopByLopNameAndKhoaName(tenLop, tenKhoa).Id;
                        if (lopId == -1) throw new Exception($"Không tìm thấy lớp: {tenLop}");


                        // Tạo đối tượng SinhVien
                        SinhVienDTO sinhVien = new SinhVienDTO
                        {
                            Id = Convert.ToInt64(worksheet.Cells[row, 1].Text),
                            Name = worksheet.Cells[row, 2].Text,
                            NgaySinh = DateTime.Parse(worksheet.Cells[row, 3].Text),
                            Email = worksheet.Cells[row, 4].Text,
                            GioiTinh = worksheet.Cells[row, 5].Text == "Nam" ? 1 : 0,
                            LopId = lopId, // Gán lop_id
                            status = 1 // Mặc định là 1
                        };

                        sinhVienList.Add(sinhVien);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Lỗi tại dòng {row}: {ex.Message}");
                    }
                }
            }

            return sinhVienList;
        }

    }
}
