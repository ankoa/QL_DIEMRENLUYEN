using OfficeOpenXml;
using OfficeOpenXml.Style;

public class ExcelExporter
{

    public static List<Dictionary<string, string>> ConvertListToDictionaryList<T>(List<T> dtoList)
    {
        var dictionaryList = new List<Dictionary<string, string>>();

        foreach (var item in dtoList)
        {
            var dict = new Dictionary<string, string>();

            // Lấy tất cả các thuộc tính công khai của đối tượng
            var properties = typeof(T).GetProperties();

            foreach (var prop in properties)
            {
                // Lấy tên thuộc tính và giá trị
                string key = prop.Name;
                object value = prop.GetValue(item, null);

                // Thêm vào dictionary dưới dạng chuỗi
                dict[key] = value?.ToString() ?? string.Empty; // Nếu null, dùng chuỗi rỗng
            }

            dictionaryList.Add(dict);
        }

        return dictionaryList;
    }


    // Hàm xuất dữ liệu từ Dictionary sang Excel
    public static void ExportToExcel(Dictionary<string, string> data, string filePath)
    {
        try
        {
            // Khởi tạo gói Excel
            using (var package = new ExcelPackage())
            {
                // Thêm worksheet
                var worksheet = package.Workbook.Worksheets.Add("Data");

                // Ghi tiêu đề cột
                worksheet.Cells[1, 1].Value = "Key";
                worksheet.Cells[1, 2].Value = "Value";

                // In đậm tiêu đề
                using (var range = worksheet.Cells[1, 1, 1, 2])
                {
                    range.Style.Font.Bold = true;
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }

                // Ghi dữ liệu từ Dictionary vào Excel
                int row = 2;
                foreach (var item in data)
                {
                    worksheet.Cells[row, 1].Value = item.Key;
                    worksheet.Cells[row, 2].Value = item.Value;
                    row++;
                }

                // Tự động căn chỉnh cột
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                // Lưu file Excel
                File.WriteAllBytes(filePath, package.GetAsByteArray());
                MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Đã xảy ra lỗi khi xuất Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // Hàm gọi hàm xuất với SaveFileDialog
    public static void ExportDictionaryToExcel(Dictionary<string, string> data)
    {
        using (var saveFileDialog = new SaveFileDialog())
        {
            saveFileDialog.Filter = "Excel Files|*.xlsx";
            saveFileDialog.Title = "Lưu file Excel";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExportToExcel(data, saveFileDialog.FileName);
            }
        }
    }

    // Hàm xuất dữ liệu từ List sang Excel
    public static void ExportListToExcel<T>(List<T> data, string filePath)
    {
        try
        {
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Data");

                // Ghi tiêu đề cột (dựa trên thuộc tính của T)
                var properties = typeof(T).GetProperties();
                for (int i = 0; i < properties.Length; i++)
                {
                    worksheet.Cells[1, i + 1].Value = properties[i].Name;
                }

                using (var range = worksheet.Cells[1, 1, 1, properties.Length])
                {
                    range.Style.Font.Bold = true;
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }

                // Ghi dữ liệu từ List vào Excel
                for (int row = 0; row < data.Count; row++)
                {
                    for (int col = 0; col < properties.Length; col++)
                    {
                        worksheet.Cells[row + 2, col + 1].Value = properties[col].GetValue(data[row]);
                    }
                }

                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
                File.WriteAllBytes(filePath, package.GetAsByteArray());
                MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Đã xảy ra lỗi khi xuất Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // Xuất danh sách Dictionary ra Excel
    public static void ExportListToExcel(List<Dictionary<string, string>> data)
    {
        using (var saveFileDialog = new SaveFileDialog())
        {
            saveFileDialog.Filter = "Excel Files|*.xlsx";
            saveFileDialog.Title = "Lưu file Excel";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Thiết lập LicenseContext
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                    using (var package = new ExcelPackage())
                    {
                        var worksheet = package.Workbook.Worksheets.Add("Data");

                        // Lấy tiêu đề cột từ dictionary đầu tiên
                        var headers = data.First().Keys.ToList();
                        for (int i = 0; i < headers.Count; i++)
                        {
                            worksheet.Cells[1, i + 1].Value = headers[i];
                            worksheet.Cells[1, i + 1].Style.Font.Bold = true;
                            worksheet.Cells[1, i + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        }

                        // Ghi dữ liệu vào các dòng
                        for (int rowIndex = 0; rowIndex < data.Count; rowIndex++)
                        {
                            var row = data[rowIndex];
                            for (int colIndex = 0; colIndex < headers.Count; colIndex++)
                            {
                                worksheet.Cells[rowIndex + 2, colIndex + 1].Value = row[headers[colIndex]];
                            }
                        }

                        // Tự động căn chỉnh cột
                        worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                        // Lưu file Excel
                        File.WriteAllBytes(saveFileDialog.FileName, package.GetAsByteArray());
                        MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi khi xuất Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    public static void ExportDataGridViewToExcelWithColors(DataGridView dataGridView, int columnLimit = -1)
    {
        using (var saveFileDialog = new SaveFileDialog())
        {
            saveFileDialog.Filter = "Excel Files|*.xlsx";
            saveFileDialog.Title = "Lưu file Excel";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Thiết lập LicenseContext
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                    using (var package = new ExcelPackage())
                    {
                        // Tạo worksheet
                        var worksheet = package.Workbook.Worksheets.Add("DataGridView Data");

                        // Giới hạn số lượng cột được xuất (nếu columnLimit > 0)
                        int maxColumns = columnLimit > 0 && columnLimit <= dataGridView.Columns.Count
                            ? columnLimit
                            : dataGridView.Columns.Count;

                        // Ghi tiêu đề cột và áp dụng màu
                        for (int col = 0; col < maxColumns; col++)
                        {
                            var headerCell = dataGridView.Columns[col].HeaderCell;

                            // Ghi tiêu đề cột
                            worksheet.Cells[1, col + 1].Value = headerCell.Value;

                            // Đặt màu nền tiêu đề
                            worksheet.Cells[1, col + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            worksheet.Cells[1, col + 1].Style.Fill.BackgroundColor.SetColor(headerCell.Style.BackColor.IsEmpty ? Color.White : headerCell.Style.BackColor);
                            worksheet.Cells[1, col + 1].Style.Font.Bold = true;
                            worksheet.Cells[1, col + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                            // Thêm viền
                            worksheet.Cells[1, col + 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                        }

                        // Ghi dữ liệu từng dòng từ DataGridView
                        for (int row = 0; row < dataGridView.Rows.Count; row++)
                        {
                            for (int col = 0; col < maxColumns; col++)
                            {
                                var cell = dataGridView.Rows[row].Cells[col];
                                var cellValue = cell.Value != null ? cell.Value.ToString() : string.Empty;

                                // Ghi giá trị ô
                                worksheet.Cells[row + 2, col + 1].Value = cellValue;

                                // Đặt màu nền của ô
                                worksheet.Cells[row + 2, col + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                worksheet.Cells[row + 2, col + 1].Style.Fill.BackgroundColor.SetColor(cell.Style.BackColor.IsEmpty ? Color.White : cell.Style.BackColor);

                                // Đặt màu chữ
                                worksheet.Cells[row + 2, col + 1].Style.Font.Color.SetColor(cell.Style.ForeColor.IsEmpty ? Color.Black : cell.Style.ForeColor);

                                // Thêm viền
                                worksheet.Cells[row + 2, col + 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                            }
                        }

                        // Tự động điều chỉnh cột
                        worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                        // Lưu file Excel
                        File.WriteAllBytes(saveFileDialog.FileName, package.GetAsByteArray());
                        MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi khi xuất Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }


}
