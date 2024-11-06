using System;
using System.Windows.Forms;

namespace ql_diemrenluyen.GUI.ADMIN.Account
{
    partial class AddDotCham
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
            lblPassword = new Label();
            lblRole = new Label();
            lblRememberToken = new Label();
            lblCreatedAt = new Label();
            lblUpdatedAt = new Label();
            dtpUpdatedAt = new DateTimePicker();
            lblStatus = new Label();
            btnClose = new Button();
            btnEdit = new Button();
            label2 = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            dtpCreatedAt = new DateTimePicker();
            comboBox1 = new ComboBox();
            txtRememberToken = new TextBox();
            txtRole = new TextBox();
            txtPassword = new TextBox();
            SuspendLayout();
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblId.Location = new Point(50, 47);
            lblId.Name = "lblId";
            lblId.Size = new Size(23, 15);
            lblId.TabIndex = 0;
            lblId.Text = "ID:";
            // 
            // txtId
            // 
            txtId.BorderStyle = BorderStyle.FixedSingle;
            txtId.Enabled = false;
            txtId.Location = new Point(176, 47);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(200, 23);
            txtId.TabIndex = 1;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPassword.Location = new Point(50, 88);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(45, 15);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Học kì:";
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRole.Location = new Point(50, 132);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(59, 15);
            lblRole.TabIndex = 4;
            lblRole.Text = "Năm học:";
            // 
            // lblRememberToken
            // 
            lblRememberToken.AutoSize = true;
            lblRememberToken.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRememberToken.Location = new Point(50, 175);
            lblRememberToken.Name = "lblRememberToken";
            lblRememberToken.Size = new Size(78, 15);
            lblRememberToken.TabIndex = 6;
            lblRememberToken.Text = "Người chấm:";
            // 
            // lblCreatedAt
            // 
            lblCreatedAt.AutoSize = true;
            lblCreatedAt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCreatedAt.Location = new Point(50, 222);
            lblCreatedAt.Name = "lblCreatedAt";
            lblCreatedAt.Size = new Size(83, 15);
            lblCreatedAt.TabIndex = 8;
            lblCreatedAt.Text = "Ngày bắt đầu:";
            // 
            // lblUpdatedAt
            // 
            lblUpdatedAt.AutoSize = true;
            lblUpdatedAt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUpdatedAt.Location = new Point(50, 267);
            lblUpdatedAt.Name = "lblUpdatedAt";
            lblUpdatedAt.Size = new Size(88, 15);
            lblUpdatedAt.TabIndex = 10;
            lblUpdatedAt.Text = "Ngày kết thúc:";
            // 
            // dtpUpdatedAt
            // 
            dtpUpdatedAt.Format = DateTimePickerFormat.Short;
            dtpUpdatedAt.Location = new Point(176, 267);
            dtpUpdatedAt.Name = "dtpUpdatedAt";
            dtpUpdatedAt.Size = new Size(200, 23);
            dtpUpdatedAt.TabIndex = 11;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStatus.Location = new Point(50, 309);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(45, 15);
            lblStatus.TabIndex = 12;
            lblStatus.Text = "Status:";
            // 
            // btnClose
            // 
            btnClose.Location = new Point(244, 376);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(100, 30);
            btnClose.TabIndex = 14;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(82, 376);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(90, 30);
            btnEdit.TabIndex = 15;
            btnEdit.Text = "Chỉnh sửa";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(96, 9);
            label2.Name = "label2";
            label2.Size = new Size(218, 30);
            label2.TabIndex = 18;
            label2.Text = "Thông tin đợt chấm";
            // 
            // dtpCreatedAt
            // 
            dtpCreatedAt.Format = DateTimePickerFormat.Short;
            dtpCreatedAt.Location = new Point(176, 222);
            dtpCreatedAt.Margin = new Padding(3, 2, 3, 2);
            dtpCreatedAt.Name = "dtpCreatedAt";
            dtpCreatedAt.Size = new Size(200, 23);
            dtpCreatedAt.TabIndex = 19;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Hoạt động", "Không hoạt động" });
            comboBox1.Location = new Point(176, 309);
            comboBox1.Margin = new Padding(3, 2, 3, 2);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(200, 23);
            comboBox1.TabIndex = 20;
            // 
            // txtRememberToken
            // 
            txtRememberToken.BorderStyle = BorderStyle.FixedSingle;
            txtRememberToken.Enabled = false;
            txtRememberToken.Location = new Point(176, 175);
            txtRememberToken.Name = "txtRememberToken";
            txtRememberToken.ReadOnly = true;
            txtRememberToken.Size = new Size(200, 23);
            txtRememberToken.TabIndex = 7;
            // 
            // txtRole
            // 
            txtRole.BorderStyle = BorderStyle.FixedSingle;
            txtRole.Enabled = false;
            txtRole.Location = new Point(176, 132);
            txtRole.Name = "txtRole";
            txtRole.ReadOnly = true;
            txtRole.Size = new Size(200, 23);
            txtRole.TabIndex = 5;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Enabled = false;
            txtPassword.Location = new Point(176, 88);
            txtPassword.Name = "txtPassword";
            txtPassword.ReadOnly = true;
            txtPassword.Size = new Size(200, 23);
            txtPassword.TabIndex = 3;
            // 
            // AddDotCham
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(422, 490);
            ControlBox = false;
            Controls.Add(comboBox1);
            Controls.Add(dtpCreatedAt);
            Controls.Add(label2);
            Controls.Add(btnEdit);
            Controls.Add(btnClose);
            Controls.Add(lblStatus);
            Controls.Add(dtpUpdatedAt);
            Controls.Add(lblUpdatedAt);
            Controls.Add(lblCreatedAt);
            Controls.Add(txtRememberToken);
            Controls.Add(lblRememberToken);
            Controls.Add(txtRole);
            Controls.Add(lblRole);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtId);
            Controls.Add(lblId);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "AddDotCham";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chi tiết tài khoản";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblRememberToken;
        private System.Windows.Forms.Label lblCreatedAt;
        private System.Windows.Forms.Label lblUpdatedAt;
        private System.Windows.Forms.DateTimePicker dtpUpdatedAt;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnEdit;
        private Label label2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private DateTimePicker dtpCreatedAt;
        private ComboBox comboBox1;
        private TextBox txtRememberToken;
        private TextBox txtRole;
        private TextBox txtPassword;
    }
}
