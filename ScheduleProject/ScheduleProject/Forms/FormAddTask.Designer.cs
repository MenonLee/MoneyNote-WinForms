namespace ScheduleProject.Forms
{
    partial class FormAddTask
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtTitle = new TextBox();
            txtDescription = new TextBox();
            dtpDueDate = new DateTimePicker();
            cbCategory = new ComboBox();
            cbPriority = new ComboBox();
            btnSave = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(75, 106);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(438, 23);
            txtTitle.TabIndex = 0;
            txtTitle.Text = "일정 제목";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(75, 319);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(438, 99);
            txtDescription.TabIndex = 1;
            txtDescription.Text = "일정내용";
            // 
            // dtpDueDate
            // 
            dtpDueDate.Location = new Point(75, 242);
            dtpDueDate.Name = "dtpDueDate";
            dtpDueDate.Size = new Size(438, 23);
            dtpDueDate.TabIndex = 2;
            // 
            // cbCategory
            // 
            cbCategory.FlatStyle = FlatStyle.System;
            cbCategory.FormattingEnabled = true;
            cbCategory.Items.AddRange(new object[] { "과제", "시험", "약속", "팀플" });
            cbCategory.Location = new Point(75, 170);
            cbCategory.Name = "cbCategory";
            cbCategory.Size = new Size(218, 23);
            cbCategory.TabIndex = 3;
            cbCategory.Text = "카테고리";
            // 
            // cbPriority
            // 
            cbPriority.FormattingEnabled = true;
            cbPriority.Items.AddRange(new object[] { "높음", "보통", "낮음" });
            cbPriority.Location = new Point(299, 170);
            cbPriority.Name = "cbPriority";
            cbPriority.Size = new Size(214, 23);
            cbPriority.TabIndex = 4;
            cbPriority.Text = "중요도";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(438, 464);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 36);
            btnSave.TabIndex = 5;
            btnSave.Text = "등록";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(75, 88);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 6;
            label1.Text = "일정 제목";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(75, 152);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 7;
            label2.Text = "카테고리";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(299, 152);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 8;
            label3.Text = "중요도";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(75, 224);
            label4.Name = "label4";
            label4.Size = new Size(43, 15);
            label4.TabIndex = 9;
            label4.Text = "마감일";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(75, 301);
            label5.Name = "label5";
            label5.Size = new Size(59, 15);
            label5.TabIndex = 10;
            label5.Text = "일정 내용";
            // 
            // FormAddTask
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(583, 551);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnSave);
            Controls.Add(cbPriority);
            Controls.Add(cbCategory);
            Controls.Add(dtpDueDate);
            Controls.Add(txtDescription);
            Controls.Add(txtTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormAddTask";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormAddTask";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTitle;
        private TextBox txtDescription;
        private DateTimePicker dtpDueDate;
        private ComboBox cbCategory;
        private ComboBox cbPriority;
        private Button btnSave;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}