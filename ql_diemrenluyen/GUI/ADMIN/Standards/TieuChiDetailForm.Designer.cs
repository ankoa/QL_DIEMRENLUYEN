namespace ql_diemrenluyen.GUI.ADMIN.Standards
{
    partial class TieuChiDetailForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            lblId = new Label();
            txtId = new TextBox();
            lblPassword = new Label();
            txtNoiDung = new TextBox();
            lbparentID = new Label();
            lblRememberToken = new Label();
            txtMaxPoint = new TextBox();
            lblCreatedAt = new Label();
            lblUpdatedAt = new Label();
            dtpUpdatedAt = new DateTimePicker();
            lblStatus = new Label();
            btnClose = new Button();
            btnEdit = new Button();
            lbTitle = new Label();
            dtpCreatedAt = new DateTimePicker();
            cbbStatus = new ComboBox();
            cbbParentID = new ComboBox();
            btnDelete = new Button();
            SuspendLayout();
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblId.Location = new Point(66, 85);
            lblId.Name = "lblId";
            lblId.Size = new Size(29, 20);
            lblId.TabIndex = 0;
            lblId.Text = "ID:";
            lblId.Click += lblId_Click;
            // 
            // txtId
            // 
            txtId.BackColor = SystemColors.ControlLightLight;
            txtId.BorderStyle = BorderStyle.FixedSingle;
            txtId.Location = new Point(210, 85);
            txtId.Margin = new Padding(3, 4, 3, 4);
            txtId.Name = "txtId";
            txtId.Size = new Size(228, 27);
            txtId.TabIndex = 1;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPassword.Location = new Point(66, 140);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(78, 20);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Nội dung:";
            // 
            // txtNoiDung
            // 
            txtNoiDung.BackColor = SystemColors.ControlLightLight;
            txtNoiDung.BorderStyle = BorderStyle.FixedSingle;
            txtNoiDung.Location = new Point(210, 140);
            txtNoiDung.Margin = new Padding(3, 4, 3, 4);
            txtNoiDung.Name = "txtNoiDung";
            txtNoiDung.Size = new Size(228, 27);
            txtNoiDung.TabIndex = 3;
            // 
            // lbparentID
            // 
            lbparentID.AutoSize = true;
            lbparentID.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbparentID.Location = new Point(66, 198);
            lbparentID.Name = "lbparentID";
            lbparentID.Size = new Size(75, 20);
            lbparentID.TabIndex = 4;
            lbparentID.Text = "ParentID:";
            // 
            // lblRememberToken
            // 
            lblRememberToken.AutoSize = true;
            lblRememberToken.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRememberToken.Location = new Point(66, 255);
            lblRememberToken.Name = "lblRememberToken";
            lblRememberToken.Size = new Size(94, 20);
            lblRememberToken.TabIndex = 6;
            lblRememberToken.Text = "Điểm tối đa:";
            // 
            // txtMaxPoint
            // 
            txtMaxPoint.BackColor = SystemColors.ControlLightLight;
            txtMaxPoint.BorderStyle = BorderStyle.FixedSingle;
            txtMaxPoint.Location = new Point(210, 255);
            txtMaxPoint.Margin = new Padding(3, 4, 3, 4);
            txtMaxPoint.Name = "txtMaxPoint";
            txtMaxPoint.Size = new Size(228, 27);
            txtMaxPoint.TabIndex = 7;
            txtMaxPoint.TextChanged += txtMaxPoint_TextChanged;
            // 
            // lblCreatedAt
            // 
            lblCreatedAt.AutoSize = true;
            lblCreatedAt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCreatedAt.Location = new Point(66, 318);
            lblCreatedAt.Name = "lblCreatedAt";
            lblCreatedAt.Size = new Size(88, 20);
            lblCreatedAt.TabIndex = 8;
            lblCreatedAt.Text = "Created At:";
            // 
            // lblUpdatedAt
            // 
            lblUpdatedAt.AutoSize = true;
            lblUpdatedAt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUpdatedAt.Location = new Point(66, 378);
            lblUpdatedAt.Name = "lblUpdatedAt";
            lblUpdatedAt.Size = new Size(94, 20);
            lblUpdatedAt.TabIndex = 10;
            lblUpdatedAt.Text = "Updated At:";
            // 
            // dtpUpdatedAt
            // 
            dtpUpdatedAt.Enabled = false;
            dtpUpdatedAt.Location = new Point(210, 378);
            dtpUpdatedAt.Margin = new Padding(3, 4, 3, 4);
            dtpUpdatedAt.Name = "dtpUpdatedAt";
            dtpUpdatedAt.Size = new Size(228, 27);
            dtpUpdatedAt.TabIndex = 11;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStatus.Location = new Point(66, 434);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(57, 20);
            lblStatus.TabIndex = 12;
            lblStatus.Text = "Status:";
            // 
            // btnClose
            // 
            btnClose.BackColor = SystemColors.ControlDark;
            btnClose.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnClose.ForeColor = SystemColors.ControlLightLight;
            btnClose.Location = new Point(324, 524);
            btnClose.Margin = new Padding(3, 4, 3, 4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(114, 40);
            btnClose.TabIndex = 14;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.PaleGreen;
            btnEdit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEdit.ForeColor = SystemColors.ControlLightLight;
            btnEdit.Location = new Point(201, 524);
            btnEdit.Margin = new Padding(3, 4, 3, 4);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(103, 40);
            btnEdit.TabIndex = 15;
            btnEdit.Text = "Chỉnh sửa";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // lbTitle
            // 
            lbTitle.AutoSize = true;
            lbTitle.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTitle.Location = new Point(109, 9);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(250, 38);
            lbTitle.TabIndex = 18;
            lbTitle.Text = "Thông tin tiêu chí";
            // 
            // dtpCreatedAt
            // 
            dtpCreatedAt.Enabled = false;
            dtpCreatedAt.Location = new Point(210, 318);
            dtpCreatedAt.Name = "dtpCreatedAt";
            dtpCreatedAt.Size = new Size(228, 27);
            dtpCreatedAt.TabIndex = 19;
            dtpCreatedAt.ValueChanged += dtpCreatedAt_ValueChanged;
            // 
            // cbbStatus
            // 
            cbbStatus.FormattingEnabled = true;
            cbbStatus.Items.AddRange(new object[] { "Hoạt động", "Không hoạt động" });
            cbbStatus.Location = new Point(210, 434);
            cbbStatus.Name = "cbbStatus";
            cbbStatus.Size = new Size(228, 28);
            cbbStatus.TabIndex = 20;
            // 
            // cbbParentID
            // 
            cbbParentID.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbParentID.FormattingEnabled = true;
            cbbParentID.Items.AddRange(new object[] { "ID - Nội dung" });
            cbbParentID.Location = new Point(210, 198);
            cbbParentID.Name = "cbbParentID";
            cbbParentID.Size = new Size(228, 28);
            cbbParentID.TabIndex = 21;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Red;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = SystemColors.ControlLightLight;
            btnDelete.Location = new Point(66, 524);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(114, 40);
            btnDelete.TabIndex = 23;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // TieuChiDetailForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            ClientSize = new Size(482, 653);
            Controls.Add(btnDelete);
            Controls.Add(cbbParentID);
            Controls.Add(cbbStatus);
            Controls.Add(dtpCreatedAt);
            Controls.Add(lbTitle);
            Controls.Add(btnEdit);
            Controls.Add(btnClose);
            Controls.Add(lblStatus);
            Controls.Add(dtpUpdatedAt);
            Controls.Add(lblUpdatedAt);
            Controls.Add(lblCreatedAt);
            Controls.Add(txtMaxPoint);
            Controls.Add(lblRememberToken);
            Controls.Add(lbparentID);
            Controls.Add(txtNoiDung);
            Controls.Add(lblPassword);
            Controls.Add(txtId);
            Controls.Add(lblId);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "TieuChiDetailForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chi tiết tài khoản";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private Label lblId;
        private TextBox txtId;
        private Label lblPassword;
        private TextBox txtNoiDung;
        private Label lbparentID;
        private Label lblRememberToken;
        private TextBox txtMaxPoint;
        private Label lblCreatedAt;
        private Label lblUpdatedAt;
        private DateTimePicker dtpUpdatedAt;
        private Label lblStatus;
        private Button btnClose;
        private Button btnEdit;
        private Label lbTitle;
        private DateTimePicker dtpCreatedAt;
        private ComboBox cbbStatus;
        private ComboBox cbbParentID;
        private Button btnDelete;
    }

}