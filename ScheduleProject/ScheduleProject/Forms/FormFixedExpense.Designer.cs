namespace ScheduleProject.Forms
{
    partial class FormFixedExpense
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

        private void InitializeComponent()
        {
            this.dgvFixedExpenses = new System.Windows.Forms.DataGridView();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.numAmount = new System.Windows.Forms.NumericUpDown();
            this.numDay = new System.Windows.Forms.NumericUpDown();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.cmbPayment = new System.Windows.Forms.ComboBox();
            this.txtMemo = new System.Windows.Forms.TextBox();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblDay = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblPayment = new System.Windows.Forms.Label();
            this.lblMemo = new System.Windows.Forms.Label();
            this.grpInput = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFixedExpenses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDay)).BeginInit();
            this.grpInput.SuspendLayout();
            this.SuspendLayout();

            // dgvFixedExpenses
            this.dgvFixedExpenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFixedExpenses.Location = new System.Drawing.Point(12, 12);
            this.dgvFixedExpenses.Name = "dgvFixedExpenses";
            this.dgvFixedExpenses.ReadOnly = true;
            this.dgvFixedExpenses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFixedExpenses.Size = new System.Drawing.Size(460, 420);
            this.dgvFixedExpenses.TabIndex = 0;

            // grpInput
            this.grpInput.Controls.Add(this.lblTitle);
            this.grpInput.Controls.Add(this.txtTitle);
            this.grpInput.Controls.Add(this.lblAmount);
            this.grpInput.Controls.Add(this.numAmount);
            this.grpInput.Controls.Add(this.lblDay);
            this.grpInput.Controls.Add(this.numDay);
            this.grpInput.Controls.Add(this.lblCategory);
            this.grpInput.Controls.Add(this.cmbCategory);
            this.grpInput.Controls.Add(this.lblPayment);
            this.grpInput.Controls.Add(this.cmbPayment);
            this.grpInput.Controls.Add(this.lblMemo);
            this.grpInput.Controls.Add(this.txtMemo);
            this.grpInput.Controls.Add(this.chkIsActive);
            this.grpInput.Controls.Add(this.btnAdd);
            this.grpInput.Controls.Add(this.btnUpdate);
            this.grpInput.Controls.Add(this.btnDelete);
            this.grpInput.Location = new System.Drawing.Point(485, 12);
            this.grpInput.Name = "grpInput";
            this.grpInput.Size = new System.Drawing.Size(280, 420);
            this.grpInput.TabIndex = 1;
            this.grpInput.TabStop = false;
            this.grpInput.Text = "항목 정보 입력";

            // Labels and Inputs positioning
            int labelX = 15, inputX = 15, width = 250;
            
            this.lblTitle.Text = "지출명"; this.lblTitle.Location = new System.Drawing.Point(labelX, 30);
            this.txtTitle.Location = new System.Drawing.Point(inputX, 50); this.txtTitle.Size = new System.Drawing.Size(width, 23);

            this.lblAmount.Text = "금액"; this.lblAmount.Location = new System.Drawing.Point(labelX, 85);
            this.numAmount.Location = new System.Drawing.Point(inputX, 105); this.numAmount.Size = new System.Drawing.Size(width, 23);
            this.numAmount.Maximum = 100000000;

            this.lblDay.Text = "발생일 (매월)"; this.lblDay.Location = new System.Drawing.Point(labelX, 140);
            this.numDay.Location = new System.Drawing.Point(inputX, 160); this.numDay.Size = new System.Drawing.Size(width, 23);
            this.numDay.Minimum = 1; this.numDay.Maximum = 31;

            this.lblCategory.Text = "카테고리"; this.lblCategory.Location = new System.Drawing.Point(labelX, 195);
            this.cmbCategory.Location = new System.Drawing.Point(inputX, 215); this.cmbCategory.Size = new System.Drawing.Size(120, 23);
            this.cmbCategory.Items.AddRange(new object[] { "식비", "주거", "통신", "교통", "문화/생활", "보험", "기타" });

            this.lblPayment.Text = "결제수단"; this.lblPayment.Location = new System.Drawing.Point(145, 195);
            this.cmbPayment.Location = new System.Drawing.Point(145, 215); this.cmbPayment.Size = new System.Drawing.Size(120, 23);
            this.cmbPayment.Items.AddRange(new object[] { "카드", "현금", "계좌이체" });

            this.lblMemo.Text = "메모"; this.lblMemo.Location = new System.Drawing.Point(labelX, 250);
            this.txtMemo.Location = new System.Drawing.Point(inputX, 270); this.txtMemo.Size = new System.Drawing.Size(width, 60);
            this.txtMemo.Multiline = true;

            // chkIsActive
            this.chkIsActive.Text = "고정지출 활성화 (자동 생성)";
            this.chkIsActive.Location = new System.Drawing.Point(inputX, 335);
            this.chkIsActive.Size = new System.Drawing.Size(width, 23);
            this.chkIsActive.Checked = true;

            // Buttons
            this.btnAdd.Text = "추가"; this.btnAdd.Location = new System.Drawing.Point(15, 365); this.btnAdd.Size = new System.Drawing.Size(80, 40);
            this.btnAdd.BackColor = System.Drawing.Color.LightGreen;

            this.btnUpdate.Text = "수정"; this.btnUpdate.Location = new System.Drawing.Point(100, 365); this.btnUpdate.Size = new System.Drawing.Size(80, 40);
            this.btnUpdate.BackColor = System.Drawing.Color.LightBlue;

            this.btnDelete.Text = "삭제"; this.btnDelete.Location = new System.Drawing.Point(185, 365); this.btnDelete.Size = new System.Drawing.Size(80, 40);
            this.btnDelete.BackColor = System.Drawing.Color.LightPink;

            // FormFixedExpense
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 450);
            this.Controls.Add(this.grpInput);
            this.Controls.Add(this.dgvFixedExpenses);
            this.Name = "FormFixedExpense";
            this.Text = "고정지출 관리";
            ((System.ComponentModel.ISupportInitialize)(this.dgvFixedExpenses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDay)).EndInit();
            this.grpInput.ResumeLayout(false);
            this.grpInput.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dgvFixedExpenses;
        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.NumericUpDown numAmount;
        private System.Windows.Forms.NumericUpDown numDay;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.ComboBox cmbPayment;
        private System.Windows.Forms.TextBox txtMemo;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblPayment;
        private System.Windows.Forms.Label lblMemo;
    }
}
