namespace ql_diemrenluyen.GUI.ADMIN.Standards
{
    partial class ChuThichDetailForm
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

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            btnDelete = new Button();
            cbbParentID = new ComboBox();
            cbbStatus = new ComboBox();
            dtpCreatedAt = new DateTimePicker();
            lbTitle = new Label();
            btnEdit = new Button();
            btnClose = new Button();
            lblStatus = new Label();
            dtpUpdatedAt = new DateTimePicker();
            lblUpdatedAt = new Label();
            lblCreatedAt = new Label();
            txtMaxPoint = new TextBox();
            lblRememberToken = new Label();
            lbparentID = new Label();
            txtNoiDung = new TextBox();
            lblPassword = new Label();
            txtId = new TextBox();
            lblId = new Label();
            SuspendLayout();
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Red;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = SystemColors.ControlLight;
            btnDelete.Location = new Point(55, 564);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(114, 40);
            btnDelete.TabIndex = 41;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // cbbParentID
            // 
            cbbParentID.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbParentID.FormattingEnabled = true;
            cbbParentID.Items.AddRange(new object[] { "ID - Nội dung" });
            cbbParentID.Location = new Point(199, 238);
            cbbParentID.Name = "cbbParentID";
            cbbParentID.Size = new Size(228, 28);
            cbbParentID.TabIndex = 40;
            // 
            // cbbStatus
            // 
            cbbStatus.FormattingEnabled = true;
            cbbStatus.Items.AddRange(new object[] { "Hoạt động", "Không hoạt động" });
            cbbStatus.Location = new Point(199, 474);
            cbbStatus.Name = "cbbStatus";
            cbbStatus.Size = new Size(228, 28);
            cbbStatus.TabIndex = 39;
            // 
            // dtpCreatedAt
            // 
            dtpCreatedAt.Location = new Point(199, 358);
            dtpCreatedAt.Name = "dtpCreatedAt";
            dtpCreatedAt.Size = new Size(228, 27);
            dtpCreatedAt.TabIndex = 38;
            // 
            // lbTitle
            // 
            lbTitle.AutoSize = true;
            lbTitle.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTitle.Location = new Point(67, 26);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(349, 38);
            lbTitle.TabIndex = 37;
            lbTitle.Text = "Thông tin chi tiết tiêu chí";
            lbTitle.Click += lbTitle_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.PaleGreen;
            btnEdit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEdit.ForeColor = SystemColors.ControlLightLight;
            btnEdit.Location = new Point(190, 564);
            btnEdit.Margin = new Padding(3, 4, 3, 4);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(103, 40);
            btnEdit.TabIndex = 36;
            btnEdit.Text = "Chỉnh sửa";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = SystemColors.ControlDark;
            btnClose.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnClose.ForeColor = SystemColors.ControlLightLight;
            btnClose.Location = new Point(313, 564);
            btnClose.Margin = new Padding(3, 4, 3, 4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(114, 40);
            btnClose.TabIndex = 35;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStatus.Location = new Point(55, 474);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(57, 20);
            lblStatus.TabIndex = 34;
            lblStatus.Text = "Status:";
            // 
            // dtpUpdatedAt
            // 
            dtpUpdatedAt.Enabled = false;
            dtpUpdatedAt.Location = new Point(199, 418);
            dtpUpdatedAt.Margin = new Padding(3, 4, 3, 4);
            dtpUpdatedAt.Name = "dtpUpdatedAt";
            dtpUpdatedAt.Size = new Size(228, 27);
            dtpUpdatedAt.TabIndex = 33;
            // 
            // lblUpdatedAt
            // 
            lblUpdatedAt.AutoSize = true;
            lblUpdatedAt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUpdatedAt.Location = new Point(55, 418);
            lblUpdatedAt.Name = "lblUpdatedAt";
            lblUpdatedAt.Size = new Size(94, 20);
            lblUpdatedAt.TabIndex = 32;
            lblUpdatedAt.Text = "Updated At:";
            // 
            // lblCreatedAt
            // 
            lblCreatedAt.AutoSize = true;
            lblCreatedAt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCreatedAt.Location = new Point(55, 358);
            lblCreatedAt.Name = "lblCreatedAt";
            lblCreatedAt.Size = new Size(88, 20);
            lblCreatedAt.TabIndex = 31;
            lblCreatedAt.Text = "Created At:";
            // 
            // txtMaxPoint
            // 
            txtMaxPoint.BackColor = SystemColors.ControlLightLight;
            txtMaxPoint.BorderStyle = BorderStyle.FixedSingle;
            txtMaxPoint.Location = new Point(199, 295);
            txtMaxPoint.Margin = new Padding(3, 4, 3, 4);
            txtMaxPoint.Name = "txtMaxPoint";
            txtMaxPoint.Size = new Size(228, 27);
            txtMaxPoint.TabIndex = 30;
            // 
            // lblRememberToken
            // 
            lblRememberToken.AutoSize = true;
            lblRememberToken.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRememberToken.Location = new Point(55, 295);
            lblRememberToken.Name = "lblRememberToken";
            lblRememberToken.Size = new Size(50, 20);
            lblRememberToken.TabIndex = 29;
            lblRememberToken.Text = "Điểm:";
            lblRememberToken.Click += lblRememberToken_Click;
            // 
            // lbparentID
            // 
            lbparentID.AutoSize = true;
            lbparentID.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbparentID.Location = new Point(55, 238);
            lbparentID.Name = "lbparentID";
            lbparentID.Size = new Size(75, 20);
            lbparentID.TabIndex = 28;
            lbparentID.Text = "ParentID:";
            // 
            // txtNoiDung
            // 
            txtNoiDung.BackColor = SystemColors.ControlLightLight;
            txtNoiDung.BorderStyle = BorderStyle.FixedSingle;
            txtNoiDung.Location = new Point(199, 180);
            txtNoiDung.Margin = new Padding(3, 4, 3, 4);
            txtNoiDung.Name = "txtNoiDung";
            txtNoiDung.Size = new Size(228, 27);
            txtNoiDung.TabIndex = 27;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPassword.Location = new Point(55, 180);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(78, 20);
            lblPassword.TabIndex = 26;
            lblPassword.Text = "Nội dung:";
            // 
            // txtId
            // 
            txtId.BackColor = SystemColors.ControlLightLight;
            txtId.BorderStyle = BorderStyle.FixedSingle;
            txtId.Location = new Point(199, 125);
            txtId.Margin = new Padding(3, 4, 3, 4);
            txtId.Name = "txtId";
            txtId.Size = new Size(228, 27);
            txtId.TabIndex = 25;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblId.Location = new Point(55, 125);
            lblId.Name = "lblId";
            lblId.Size = new Size(29, 20);
            lblId.TabIndex = 24;
            lblId.Text = "ID:";
            // 
            // ChuThichDetailForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PaleTurquoise;
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
            Name = "ChuThichDetailForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chi tiết tài khoản";
            Load += ChuThichDetailForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnDelete;
        private ComboBox cbbParentID;
        private ComboBox cbbStatus;
        private DateTimePicker dtpCreatedAt;
        private Label lbTitle;
        private Button btnEdit;
        private Button btnClose;
        private Label lblStatus;
        private DateTimePicker dtpUpdatedAt;
        private Label lblUpdatedAt;
        private Label lblCreatedAt;
        private TextBox txtMaxPoint;
        private Label lblRememberToken;
        private Label lbparentID;
        private TextBox txtNoiDung;
        private Label lblPassword;
        private TextBox txtId;
        private Label lblId;
    }
}