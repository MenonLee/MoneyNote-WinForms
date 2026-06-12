namespace ScheduleProject
{
    partial class FormAddExpense
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
            lblTitle = new Label();
            lblSubtitle = new Label();
            panelInput = new Panel();
            checkIsFixed = new CheckBox();
            textMemo = new TextBox();
            lblMemo = new Label();
            dateExpense = new DateTimePicker();
            lblExpenseDate = new Label();
            comboPaymentMethod = new ComboBox();
            lblPaymentMethod = new Label();
            comboCategory = new ComboBox();
            lblCategory = new Label();
            textAmount = new TextBox();
            lblAmount = new Label();
            textTitle = new TextBox();
            lblExpenseTitle = new Label();
            buttonSave = new Button();
            buttonCancel = new Button();
            panelInput.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("맑은 고딕", 24F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblTitle.Location = new Point(53, 43);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(237, 65);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "지출 등록";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblSubtitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblSubtitle.Location = new Point(57, 110);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(438, 28);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "오늘 사용한 금액과 결제 정보를 입력해 주세요.";
            // 
            // panelInput
            // 
            panelInput.BackColor = Color.White;
            panelInput.BorderStyle = BorderStyle.FixedSingle;
            panelInput.Controls.Add(checkIsFixed);
            panelInput.Controls.Add(textMemo);
            panelInput.Controls.Add(lblMemo);
            panelInput.Controls.Add(dateExpense);
            panelInput.Controls.Add(lblExpenseDate);
            panelInput.Controls.Add(comboPaymentMethod);
            panelInput.Controls.Add(lblPaymentMethod);
            panelInput.Controls.Add(comboCategory);
            panelInput.Controls.Add(lblCategory);
            panelInput.Controls.Add(textAmount);
            panelInput.Controls.Add(lblAmount);
            panelInput.Controls.Add(textTitle);
            panelInput.Controls.Add(lblExpenseTitle);
            panelInput.Location = new Point(57, 167);
            panelInput.Name = "panelInput";
            panelInput.Size = new Size(778, 449);
            panelInput.TabIndex = 2;
            // 
            // checkIsFixed
            // 
            checkIsFixed.AutoSize = true;
            checkIsFixed.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point, 129);
            checkIsFixed.ForeColor = Color.FromArgb(51, 65, 85);
            checkIsFixed.Location = new Point(40, 388);
            checkIsFixed.Name = "checkIsFixed";
            checkIsFixed.Size = new Size(259, 32);
            checkIsFixed.TabIndex = 12;
            checkIsFixed.Text = "매달 반복되는 고정 지출";
            checkIsFixed.UseVisualStyleBackColor = true;
            // 
            // textMemo
            // 
            textMemo.BorderStyle = BorderStyle.FixedSingle;
            textMemo.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point, 129);
            textMemo.Location = new Point(40, 292);
            textMemo.Multiline = true;
            textMemo.Name = "textMemo";
            textMemo.Size = new Size(695, 77);
            textMemo.TabIndex = 11;
            // 
            // lblMemo
            // 
            lblMemo.AutoSize = true;
            lblMemo.Font = new Font("맑은 고딕", 10F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblMemo.ForeColor = Color.FromArgb(30, 41, 59);
            lblMemo.Location = new Point(40, 258);
            lblMemo.Name = "lblMemo";
            lblMemo.Size = new Size(52, 28);
            lblMemo.TabIndex = 10;
            lblMemo.Text = "메모";
            // 
            // dateExpense
            // 
            dateExpense.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point, 129);
            dateExpense.Format = DateTimePickerFormat.Short;
            dateExpense.Location = new Point(429, 198);
            dateExpense.Name = "dateExpense";
            dateExpense.Size = new Size(307, 34);
            dateExpense.TabIndex = 9;
            // 
            // lblExpenseDate
            // 
            lblExpenseDate.AutoSize = true;
            lblExpenseDate.Font = new Font("맑은 고딕", 10F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblExpenseDate.ForeColor = Color.FromArgb(30, 41, 59);
            lblExpenseDate.Location = new Point(429, 167);
            lblExpenseDate.Name = "lblExpenseDate";
            lblExpenseDate.Size = new Size(99, 28);
            lblExpenseDate.TabIndex = 8;
            lblExpenseDate.Text = "지출 날짜";
            // 
            // comboPaymentMethod
            // 
            comboPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            comboPaymentMethod.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point, 129);
            comboPaymentMethod.FormattingEnabled = true;
            comboPaymentMethod.Items.AddRange(new object[] { "카드", "현금", "계좌이체", "간편결제", "기타" });
            comboPaymentMethod.Location = new Point(40, 198);
            comboPaymentMethod.Name = "comboPaymentMethod";
            comboPaymentMethod.Size = new Size(307, 36);
            comboPaymentMethod.TabIndex = 7;
            // 
            // lblPaymentMethod
            // 
            lblPaymentMethod.AutoSize = true;
            lblPaymentMethod.Font = new Font("맑은 고딕", 10F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblPaymentMethod.ForeColor = Color.FromArgb(30, 41, 59);
            lblPaymentMethod.Location = new Point(40, 167);
            lblPaymentMethod.Name = "lblPaymentMethod";
            lblPaymentMethod.Size = new Size(99, 28);
            lblPaymentMethod.TabIndex = 6;
            lblPaymentMethod.Text = "결제 수단";
            // 
            // comboCategory
            // 
            comboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            comboCategory.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point, 129);
            comboCategory.FormattingEnabled = true;
            comboCategory.Items.AddRange(new object[] { "식비", "교통", "쇼핑", "문화", "생활", "통신", "기타" });
            comboCategory.Location = new Point(429, 108);
            comboCategory.Name = "comboCategory";
            comboCategory.Size = new Size(307, 36);
            comboCategory.TabIndex = 5;
            comboCategory.SelectedIndexChanged += comboCategory_SelectedIndexChanged;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("맑은 고딕", 10F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblCategory.ForeColor = Color.FromArgb(30, 41, 59);
            lblCategory.Location = new Point(429, 78);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(92, 28);
            lblCategory.TabIndex = 4;
            lblCategory.Text = "카테고리";
            lblCategory.Click += lblCategory_Click;
            // 
            // textAmount
            // 
            textAmount.BorderStyle = BorderStyle.FixedSingle;
            textAmount.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point, 129);
            textAmount.Location = new Point(40, 108);
            textAmount.Name = "textAmount";
            textAmount.PlaceholderText = "예: 8500";
            textAmount.Size = new Size(306, 34);
            textAmount.TabIndex = 3;
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.Font = new Font("맑은 고딕", 10F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblAmount.ForeColor = Color.FromArgb(30, 41, 59);
            lblAmount.Location = new Point(40, 78);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(52, 28);
            lblAmount.TabIndex = 2;
            lblAmount.Text = "금액";
            // 
            // textTitle
            // 
            textTitle.BorderStyle = BorderStyle.FixedSingle;
            textTitle.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point, 129);
            textTitle.Location = new Point(171, 33);
            textTitle.Name = "textTitle";
            textTitle.PlaceholderText = "예: 점심, 커피, 버스";
            textTitle.Size = new Size(565, 34);
            textTitle.TabIndex = 1;
            textTitle.TextChanged += textTitle_TextChanged;
            // 
            // lblExpenseTitle
            // 
            lblExpenseTitle.AutoSize = true;
            lblExpenseTitle.Font = new Font("맑은 고딕", 10F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblExpenseTitle.ForeColor = Color.FromArgb(30, 41, 59);
            lblExpenseTitle.Location = new Point(40, 37);
            lblExpenseTitle.Name = "lblExpenseTitle";
            lblExpenseTitle.Size = new Size(72, 28);
            lblExpenseTitle.TabIndex = 0;
            lblExpenseTitle.Text = "지출명";
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.FromArgb(37, 99, 235);
            buttonSave.FlatAppearance.BorderSize = 0;
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.Font = new Font("맑은 고딕", 11F, FontStyle.Bold, GraphicsUnit.Point, 129);
            buttonSave.ForeColor = Color.White;
            buttonSave.Location = new Point(563, 648);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(163, 55);
            buttonSave.TabIndex = 3;
            buttonSave.Text = "저장";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.BackColor = Color.White;
            buttonCancel.FlatAppearance.BorderColor = Color.FromArgb(148, 163, 184);
            buttonCancel.FlatAppearance.BorderSize = 2;
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.Font = new Font("맑은 고딕", 11F, FontStyle.Bold, GraphicsUnit.Point, 129);
            buttonCancel.ForeColor = Color.FromArgb(51, 65, 85);
            buttonCancel.Location = new Point(731, 648);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(104, 55);
            buttonCancel.TabIndex = 4;
            buttonCancel.Text = "닫기";
            buttonCancel.UseVisualStyleBackColor = false;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // FormAddExpense
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(893, 738);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(panelInput);
            Controls.Add(lblSubtitle);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormAddExpense";
            StartPosition = FormStartPosition.CenterParent;
            Text = "MoneyNote - 지출 등록";
            panelInput.ResumeLayout(false);
            panelInput.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitle;
        private Label lblSubtitle;
        private Panel panelInput;
        private TextBox textTitle;
        private Label lblExpenseTitle;
        private TextBox textAmount;
        private Label lblAmount;
        private ComboBox comboCategory;
        private Label lblCategory;
        private ComboBox comboPaymentMethod;
        private Label lblPaymentMethod;
        private DateTimePicker dateExpense;
        private Label lblExpenseDate;
        private TextBox textMemo;
        private Label lblMemo;
        private CheckBox checkIsFixed;
        private Button buttonSave;
        private Button buttonCancel;
    }
}
