using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ql_diemrenluyen.GUI.ADMIN.TieuChi
{
    public partial class FormTieuChi : Form
    {
        public FormTieuChi()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill; // Đặt Dock để chiếm toàn bộ không gian
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void TieuChi_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill; // Đảm bảo chiếm toàn bộ không gian
            this.ControlBox = false;
        }
    }
}
