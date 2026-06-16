namespace ScheduleProject.Forms
{
    partial class FormExpenseList
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
            lblTitle = new Label();
            lblSubtitle = new Label();
            panelFilters = new Panel();
            btnAll = new Button();
            btnToday = new Button();
            btnThisMonth = new Button();
            dateFilter = new DateTimePicker();
            btnDateSearch = new Button();
            btnImportCsv = new Button();
            btnExportCsv = new Button();
            txtKeyword = new TextBox();
            comboCategory = new ComboBox();
            comboPaymentMethod = new ComboBox();
            btnSearch = new Button();
            dgvExpenses = new DataGridView();
            panelFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvExpenses).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("맑은 고딕", 24F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblTitle.Location = new Point(40, 28);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(197, 54);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "지출 목록";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("맑은 고딕", 10F);
            lblSubtitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblSubtitle.Location = new Point(44, 82);
            lblSubtitle.Margin = new Padding(4, 0, 4, 0);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(327, 23);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "등록된 지출을 통합 조회하고 관리합니다.";
            // 
            // panelFilters
            // 
            panelFilters.BorderStyle = BorderStyle.FixedSingle;
            panelFilters.Controls.Add(btnAll);
            panelFilters.Controls.Add(btnToday);
            panelFilters.Controls.Add(btnThisMonth);
            panelFilters.Controls.Add(dateFilter);
            panelFilters.Controls.Add(btnDateSearch);
            panelFilters.Controls.Add(btnImportCsv);
            panelFilters.Controls.Add(btnExportCsv);
            panelFilters.Controls.Add(txtKeyword);
            panelFilters.Controls.Add(comboCategory);
            panelFilters.Controls.Add(comboPaymentMethod);
            panelFilters.Controls.Add(btnSearch);
            panelFilters.BackColor = Color.White;
            panelFilters.Location = new Point(40, 118);
            panelFilters.Name = "panelFilters";
            panelFilters.Size = new Size(920, 112);
            panelFilters.TabIndex = 2;
            // 
            // btnAll
            // 
            btnAll.Location = new Point(24, 16);
            btnAll.Margin = new Padding(4);
            btnAll.Name = "btnAll";
            btnAll.Size = new Size(96, 34);
            btnAll.TabIndex = 3;
            btnAll.Text = "전체 내역";
            // 
            // btnToday
            // 
            btnToday.Location = new Point(128, 16);
            btnToday.Margin = new Padding(4);
            btnToday.Name = "btnToday";
            btnToday.Size = new Size(96, 34);
            btnToday.TabIndex = 4;
            btnToday.Text = "오늘 지출";
            // 
            // btnThisMonth
            // 
            btnThisMonth.Location = new Point(232, 16);
            btnThisMonth.Margin = new Padding(4);
            btnThisMonth.Name = "btnThisMonth";
            btnThisMonth.Size = new Size(96, 34);
            btnThisMonth.TabIndex = 5;
            btnThisMonth.Text = "이번 달";
            // 
            // dateFilter
            // 
            dateFilter.Format = DateTimePickerFormat.Short;
            dateFilter.Location = new Point(344, 20);
            dateFilter.Margin = new Padding(4);
            dateFilter.Name = "dateFilter";
            dateFilter.Size = new Size(132, 27);
            dateFilter.TabIndex = 6;
            // 
            // btnDateSearch
            // 
            btnDateSearch.Location = new Point(484, 16);
            btnDateSearch.Margin = new Padding(4);
            btnDateSearch.Name = "btnDateSearch";
            btnDateSearch.Size = new Size(96, 34);
            btnDateSearch.TabIndex = 7;
            btnDateSearch.Text = "날짜 검색";
            // 
            // btnImportCsv
            // 
            btnImportCsv.Location = new Point(760, 16);
            btnImportCsv.Margin = new Padding(4);
            btnImportCsv.Name = "btnImportCsv";
            btnImportCsv.Size = new Size(132, 34);
            btnImportCsv.TabIndex = 8;
            btnImportCsv.Text = "CSV 가져오기";
            // 
            // btnExportCsv
            // 
            btnExportCsv.Location = new Point(620, 16);
            btnExportCsv.Margin = new Padding(4);
            btnExportCsv.Name = "btnExportCsv";
            btnExportCsv.Size = new Size(132, 34);
            btnExportCsv.TabIndex = 9;
            btnExportCsv.Text = "CSV 내보내기";
            // 
            // txtKeyword
            // 
            txtKeyword.Location = new Point(24, 66);
            txtKeyword.Margin = new Padding(4);
            txtKeyword.Name = "txtKeyword";
            txtKeyword.PlaceholderText = "검색어 (지출명, 메모)";
            txtKeyword.Size = new Size(300, 27);
            txtKeyword.TabIndex = 10;
            txtKeyword.TextChanged += txtKeyword_TextChanged;
            // 
            // comboCategory
            // 
            comboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            comboCategory.Location = new Point(340, 66);
            comboCategory.Margin = new Padding(4);
            comboCategory.Name = "comboCategory";
            comboCategory.Size = new Size(150, 28);
            comboCategory.TabIndex = 11;
            // 
            // comboPaymentMethod
            // 
            comboPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            comboPaymentMethod.Location = new Point(506, 66);
            comboPaymentMethod.Margin = new Padding(4);
            comboPaymentMethod.Name = "comboPaymentMethod";
            comboPaymentMethod.Size = new Size(150, 28);
            comboPaymentMethod.TabIndex = 12;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(760, 62);
            btnSearch.Margin = new Padding(4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(132, 34);
            btnSearch.TabIndex = 13;
            btnSearch.Text = "검색하기";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // dgvExpenses
            // 
            dgvExpenses.BackgroundColor = Color.White;
            dgvExpenses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvExpenses.BorderStyle = BorderStyle.FixedSingle;
            dgvExpenses.Location = new Point(40, 252);
            dgvExpenses.Name = "dgvExpenses";
            dgvExpenses.RowHeadersWidth = 51;
            dgvExpenses.RowTemplate.Height = 23;
            dgvExpenses.Size = new Size(920, 330);
            dgvExpenses.TabIndex = 15;
            dgvExpenses.CellContentClick += dgvExpenses_CellContentClick;
            // 
            // FormExpenseList
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1000, 630);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Controls.Add(dgvExpenses);
            Controls.Add(panelFilters);
            Controls.Add(lblSubtitle);
            Controls.Add(lblTitle);
            Margin = new Padding(4);
            Name = "FormExpenseList";
            StartPosition = FormStartPosition.CenterParent;
            Text = "MoneyNote - 지출 목록";
            Load += FormExpenseList_Load;
            panelFilters.ResumeLayout(false);
            panelFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvExpenses).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel panelFilters;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.ComboBox comboCategory;
        private System.Windows.Forms.ComboBox comboPaymentMethod;
        private System.Windows.Forms.DateTimePicker dateFilter;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnToday;
        private System.Windows.Forms.Button btnDateSearch;
        private System.Windows.Forms.Button btnThisMonth;
        private System.Windows.Forms.Button btnExportCsv;
        private System.Windows.Forms.Button btnImportCsv;
        private System.Windows.Forms.DataGridView dgvExpenses;
    }
}
