using System;
using System.Drawing;
using System.Windows.Forms;

namespace ql_diemrenluyen.GUI.ADMIN.Teacher
{
    partial class GiangVienDetailForm : Form
    {
        private System.ComponentModel.IContainer components = null;

        // Control Declaration
        private Label lblId;
        private TextBox txtId;
        private Label lblTenGV;
        private TextBox txtTenGV;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblKhoa;
        private TextBox txtKhoa;
        private Label lblTrangThai;
        private ComboBox comboBoxTrangThai;
        private Label lblChucVu;
        private ComboBox comboBoxChucVu;
        private Button btnClose;
        private Button btnEdit;
        private Button btnDelete;
        private Label titleLabel;
        private DateTimePicker dtpCreatedAt;
        private DateTimePicker dtpUpdatedAt;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // Form setup
            SuspendLayout();
            BackColor = SystemColors.ControlLightLight;
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(422, 490);

            // Title Label
            titleLabel = new Label
            {
                Text = "Chi tiết giảng viên",
                Font = new Font("Segoe UI", 16.2F, FontStyle.Bold),
                ForeColor = Color.Black,
                AutoSize = true,
                Location = new Point(95, 7)
            };
            Controls.Add(titleLabel);

            // Label & TextBox for ID
            lblId = new Label
            {
                Text = "ID:",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Location = new Point(58, 64)
            };
            Controls.Add(lblId);

            txtId = new TextBox
            {
                ReadOnly = true,
                BackColor = SystemColors.ControlLightLight,
                Location = new Point(184, 64),
                Size = new Size(200, 23)
            };
            Controls.Add(txtId);

            // Label & TextBox for Tên Giảng Viên
            lblTenGV = new Label
            {
                Text = "Tên GV:",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Location = new Point(58, 105)
            };
            Controls.Add(lblTenGV);

            txtTenGV = new TextBox
            {
                Location = new Point(184, 105),
                Size = new Size(200, 23)
            };
            Controls.Add(txtTenGV);

            // Label & TextBox for Email
            lblEmail = new Label
            {
                Text = "Email:",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Location = new Point(58, 148)
            };
            Controls.Add(lblEmail);

            txtEmail = new TextBox
            {
                Location = new Point(184, 148),
                Size = new Size(200, 23)
            };
            Controls.Add(txtEmail);

            // Label & TextBox for Khoa
            lblKhoa = new Label
            {
                Text = "Khoa:",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Location = new Point(58, 191)
            };
            Controls.Add(lblKhoa);

            txtKhoa = new TextBox
            {
                Location = new Point(184, 191),
                Size = new Size(200, 23)
            };
            Controls.Add(txtKhoa);

            // Label & ComboBox for Trạng thái
            lblTrangThai = new Label
            {
                Text = "Trạng thái:",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Location = new Point(58, 238)
            };
            Controls.Add(lblTrangThai);

            comboBoxTrangThai = new ComboBox
            {
                Location = new Point(184, 238),
                Size = new Size(200, 23),
                Items = { "Hoạt động", "Không hoạt động" }
            };
            Controls.Add(comboBoxTrangThai);

            // Label & ComboBox for Chức vụ
            lblChucVu = new Label
            {
                Text = "Chức vụ:",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Location = new Point(58, 284)
            };
            Controls.Add(lblChucVu);

            comboBoxChucVu = new ComboBox
            {
                Location = new Point(184, 284),
                Size = new Size(200, 23),
                Items = { "Giảng viên bộ môn", "Cố vấn học tập", "Quản lý khoa", "Quản lý trường" }
            };
            Controls.Add(comboBoxChucVu);

            // Created At Date Picker
            dtpCreatedAt = new DateTimePicker
            {
                Location = new Point(184, 326),
                Size = new Size(200, 23)
            };
            Controls.Add(dtpCreatedAt);

            // Updated At Date Picker
            dtpUpdatedAt = new DateTimePicker
            {
                Location = new Point(184, 366),
                Size = new Size(200, 23)
            };
            Controls.Add(dtpUpdatedAt);

            // Edit Button
            btnEdit = new Button
            {
                Text = "Chỉnh sửa",
                Location = new Point(174, 420),
                Size = new Size(90, 30)
            };
            btnEdit.Click += BtnEdit_Click;
            Controls.Add(btnEdit);

            // Delete Button
            btnDelete = new Button
            {
                Text = "Xóa",
                Location = new Point(58, 420),
                Size = new Size(100, 30)
            };
            btnDelete.Click += BtnDelete_Click;
            Controls.Add(btnDelete);

            // Close Button
            btnClose = new Button
            {
                Text = "Đóng",
                Location = new Point(284, 420),
                Size = new Size(100, 30)
            };
            btnClose.Click += BtnClose_Click;
            Controls.Add(btnClose);

            ResumeLayout(false);
            PerformLayout();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chỉnh sửa thông tin giảng viên!");
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Xóa thông tin giảng viên!");
        }
    }
}
