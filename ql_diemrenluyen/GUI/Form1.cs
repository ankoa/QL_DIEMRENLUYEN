using Org.BouncyCastle.Asn1.Cmp;
using ql_diemrenluyen.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ql_diemrenluyen.GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            // Sử dụng DBConnection đã tạo để kiểm tra kết nối
            bool isConnected = DBConnection.Open();

            if (isConnected)
            {
                lblStatus.Text = "Kết nối thành công!";
                lblStatus.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblStatus.Text = "Kết nối thất bại!";
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
