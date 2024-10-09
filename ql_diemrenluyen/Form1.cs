using ql_diemrenluyen.DAO;
using System.Data;

namespace ql_diemrenluyen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "SELECT id FROM sinhvien"; // Chỉ lấy id từ bảng sinh viên
            List<List<object>> result = DBConnection.ExecuteReader(sql); // ExecuteReader trả về List<List<object>>

            listBoxStudents.Items.Clear(); // Xóa danh sách trước khi thêm dữ liệu mới

            if (result.Count > 0)
            {
                foreach (var row in result)
                {
                    try
                    {
                        int id = Convert.ToInt32(row[0]); // Chuyển đổi phần tử đầu tiên của hàng (id) sang int
                        listBoxStudents.Items.Add(id); // Thêm giá trị id vào listBox
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi chuyển đổi dữ liệu: {ex.Message}");
                    }
                }
                textBox1.Text = "Kết nối thành công! Dữ liệu đã được lấy.";
            }
            else
            {
                textBox1.Text = "Kết nối thành công nhưng không có dữ liệu.";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
