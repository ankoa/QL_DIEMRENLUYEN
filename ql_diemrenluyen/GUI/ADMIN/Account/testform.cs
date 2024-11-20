using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ql_diemrenluyen.GUI.ADMIN.Account
{
    public partial class testform : Form
    {
        public testform()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Dock= DockStyle.Fill;
            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
        }
    }
}
