﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLDiemRenLuyen;

namespace ql_diemrenluyen.GUI.ADMIN.Student
{
    public partial class AdminStudentTest : Form
    {
        public AdminStudentTest()
        {
            InitializeComponent();
            QLSinhVien qLSinhVien = new QLSinhVien();
            qLSinhVien.Dock = DockStyle.Fill;
            this.Controls.Add(qLSinhVien);
        }

        private void AdminStudentTest_Load(object sender, EventArgs e)
        {

        }
    }
}
