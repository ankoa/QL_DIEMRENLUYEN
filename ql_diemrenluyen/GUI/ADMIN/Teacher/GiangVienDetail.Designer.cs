using System;
using System.Windows.Forms;

namespace ql_diemrenluyen.GUI.ADMIN.Teacher
{
    partial class GiangVienDetailForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblId = new Label();
            txtId = new TextBox();
            lblTenGV = new Label();
            txtTenGV = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblKhoa = new Label();
            txtKhoa = new TextBox();
            lblTrangThai = new Label();
            btnClose = new Button();
            btnEdit = new Button();
            label2 = new Label();
            comboBoxTrangThai = new ComboBox();
            SuspendLayout();
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblId.Location = new Point(57, 63);
            lblId.Name = "lblId";
            lblId.Size = new Size(29, 20);
            lblId.TabIndex = 0;
            lblId.Text = "ID:";
            // 
            // txtId
            // 
            txtId.BorderStyle = BorderStyle.FixedSingle;
            txtId.Location = new Point(201, 63);
            txtId.Margin = new Padding(3, 4, 3, 4);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(228, 27);
            txtId.TabIndex = 1;
            // 
            // lblTenGV
            // 
            lblTenGV.AutoSize = true;
            lblTenGV.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTenGV.Location = new Point(57, 118);
            lblTenGV.Name = "lblTenGV";
            lblTenGV.Size = new Size(65, 20);
            lblTenGV.TabIndex = 2;
            lblTenGV.Text = "Tên GV:";
            // 
            // txtTenGV
            // 
            txtTenGV.BorderStyle = BorderStyle.FixedSingle;
            txtTenGV.Location = new Point(201, 118);
            txtTenGV.Margin = new Padding(3, 4, 3, 4);
            txtTenGV.Name = "txtTenGV";
            txtTenGV.Size = new Size(228, 27);
            txtTenGV.TabIndex = 3;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEmail.Location = new Point(57, 176);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(53, 20);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Location = new Point(201, 176);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(228, 27);
            txtEmail.TabIndex = 5;
            // 
            // lblKhoa
            // 
            lblKhoa.AutoSize = true;
            lblKhoa.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblKhoa.Location = new Point(57, 233);
            lblKhoa.Name = "lblKhoa";
            lblKhoa.Size = new Size(51, 20);
            lblKhoa.TabIndex = 6;
            lblKhoa.Text = "Khoa:";
            // 
            // txtKhoa
            // 
            txtKhoa.BorderStyle = BorderStyle.FixedSingle;
            txtKhoa.Location = new Point(201, 233);
            txtKhoa.Margin = new Padding(3, 4, 3, 4);
            txtKhoa.Name = "txtKhoa";
            txtKhoa.Size = new Size(228, 27);
            txtKhoa.TabIndex = 7;
            // 
            // lblTrangThai
            // 
            lblTrangThai.AutoSize = true;
            lblTrangThai.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTrangThai.Location = new Point(57, 296);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(85, 20);
            lblTrangThai.TabIndex = 8;
            lblTrangThai.Text = "Trạng Thái:";
            // 
            // btnClose
            // 
            btnClose.Location = new Point(264, 502);
            btnClose.Margin = new Padding(3, 4, 3, 4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(114, 40);
            btnClose.TabIndex = 14;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(108, 502);
            btnEdit.Margin = new Padding(3, 4, 3, 4);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(114, 40);
            btnEdit.TabIndex = 13;
            btnEdit.Text = "Chỉnh sửa";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(57, 370);
            label2.Name = "label2";
            label2.Size = new Size(91, 20);
            label2.TabIndex = 16;
            label2.Text = "Chức Vụ:";
            // 
            // txtChucVu
            // 
            txtChucVu.BorderStyle = BorderStyle.FixedSingle;
            txtChucVu.Location = new Point(201, 367);
            txtChucVu.Margin = new Padding(3, 4, 3, 4);
            txtChucVu.Name = "txtChucVu";
            txtChucVu.Size = new Size(228, 27);
            txtChucVu.TabIndex = 15;
            // 
            // comboBoxTrangThai
            // 
            comboBoxTrangThai.FormattingEnabled = true;
            comboBoxTrangThai.Items.AddRange(new object[] { "Hoạt động", "Không hoạt động" });
            comboBoxTrangThai.Location = new Point(201, 296);
            comboBoxTrangThai.Name = "comboBoxTrangThai";
            comboBoxTrangThai.Size = new Size(228, 28);
            comboBoxTrangThai.TabIndex = 17;
            // 
            // GiangVienDetailForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(470, 577);
            Controls.Add(comboBoxTrangThai);
            Controls.Add(label2);
            Controls.Add(txtChucVu);
            Controls.Add(btnClose);
            Controls.Add(btnEdit);
            Controls.Add(lblTrangThai);
            Controls.Add(txtKhoa);
            Controls.Add(lblKhoa);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtTenGV);
            Controls.Add(lblTenGV);
            Controls.Add(txtId);
            Controls.Add(lblId);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "GiangVienDetailForm";
            Text = "Chi tiết giảng viên";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblId;
        private TextBox txtId;
        private Label lblTenGV;
        private TextBox txtTenGV;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblKhoa;
        private TextBox txtKhoa;
        private Label lblTrangThai;
        private Button btnClose;
        private Button btnEdit;
        private Label label2;
        private TextBox txtChucVu;
        private ComboBox comboBoxTrangThai;
    }
}
