namespace ql_diemrenluyen
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            textBox1 = new TextBox();
            listBoxStudents = new ListBox();
            textBoxStudentName = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(181, 94);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(67, 32);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(393, 147);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(110, 23);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // listBoxStudents
            // 
            listBoxStudents.FormattingEnabled = true;
            listBoxStudents.ItemHeight = 15;
            listBoxStudents.Location = new Point(177, 208);
            listBoxStudents.Margin = new Padding(3, 2, 3, 2);
            listBoxStudents.Name = "listBoxStudents";
            listBoxStudents.Size = new Size(238, 34);
            listBoxStudents.TabIndex = 2;
            // 
            // textBoxStudentName
            // 
            textBoxStudentName.Location = new Point(304, 59);
            textBoxStudentName.Margin = new Padding(3, 2, 3, 2);
            textBoxStudentName.Name = "textBoxStudentName";
            textBoxStudentName.Size = new Size(110, 23);
            textBoxStudentName.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(textBoxStudentName);
            Controls.Add(listBoxStudents);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox1;
        private ListBox listBoxStudents;
        private TextBox textBoxStudentName;
    }
}
