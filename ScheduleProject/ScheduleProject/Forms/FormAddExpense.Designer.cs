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
            panelAi = new Panel();
            buttonReceiptAi = new Button();
            buttonAnalyzeAi = new Button();
            textNaturalExpense = new TextBox();
            lblAiInput = new Label();
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
            panelAi.SuspendLayout();
            panelInput.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("맑은 고딕", 24F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblTitle.Location = new Point(37, 24);
            lblTitle.Margin = new Padding(2, 0, 2, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(150, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "지출 등록";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblSubtitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblSubtitle.Location = new Point(40, 64);
            lblSubtitle.Margin = new Padding(2, 0, 2, 0);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(440, 19);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "문장이나 영수증 사진을 AI가 분석해서 아래 입력칸을 자동으로 채웁니다.";
            // 
            // panelAi
            // 
            panelAi.BackColor = Color.White;
            panelAi.BorderStyle = BorderStyle.FixedSingle;
            panelAi.Controls.Add(buttonReceiptAi);
            panelAi.Controls.Add(buttonAnalyzeAi);
            panelAi.Controls.Add(textNaturalExpense);
            panelAi.Controls.Add(lblAiInput);
            panelAi.Location = new Point(40, 94);
            panelAi.Margin = new Padding(2);
            panelAi.Name = "panelAi";
            panelAi.Size = new Size(545, 88);
            panelAi.TabIndex = 2;
            // 
            // buttonReceiptAi
            // 
            buttonReceiptAi.BackColor = Color.White;
            buttonReceiptAi.FlatAppearance.BorderColor = Color.FromArgb(37, 99, 235);
            buttonReceiptAi.FlatAppearance.BorderSize = 2;
            buttonReceiptAi.FlatStyle = FlatStyle.Flat;
            buttonReceiptAi.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point, 129);
            buttonReceiptAi.ForeColor = Color.FromArgb(37, 99, 235);
            buttonReceiptAi.Location = new Point(426, 10);
            buttonReceiptAi.Margin = new Padding(2);
            buttonReceiptAi.Name = "buttonReceiptAi";
            buttonReceiptAi.Size = new Size(89, 26);
            buttonReceiptAi.TabIndex = 3;
            buttonReceiptAi.Text = "영수증 선택";
            buttonReceiptAi.UseVisualStyleBackColor = false;
            buttonReceiptAi.Click += buttonReceiptAi_Click;
            // 
            // buttonAnalyzeAi
            // 
            buttonAnalyzeAi.BackColor = Color.FromArgb(37, 99, 235);
            buttonAnalyzeAi.FlatAppearance.BorderSize = 0;
            buttonAnalyzeAi.FlatStyle = FlatStyle.Flat;
            buttonAnalyzeAi.Font = new Font("맑은 고딕", 10F, FontStyle.Bold, GraphicsUnit.Point, 129);
            buttonAnalyzeAi.ForeColor = Color.White;
            buttonAnalyzeAi.Location = new Point(426, 40);
            buttonAnalyzeAi.Margin = new Padding(2);
            buttonAnalyzeAi.Name = "buttonAnalyzeAi";
            buttonAnalyzeAi.Size = new Size(89, 26);
            buttonAnalyzeAi.TabIndex = 2;
            buttonAnalyzeAi.Text = "AI 분석";
            buttonAnalyzeAi.UseVisualStyleBackColor = false;
            buttonAnalyzeAi.Click += buttonAnalyzeAi_Click;
            // 
            // textNaturalExpense
            // 
            textNaturalExpense.BorderStyle = BorderStyle.FixedSingle;
            textNaturalExpense.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point, 129);
            textNaturalExpense.Location = new Point(28, 41);
            textNaturalExpense.Margin = new Padding(2);
            textNaturalExpense.Name = "textNaturalExpense";
            textNaturalExpense.PlaceholderText = "예: 오늘 김밥천국에서 점심 8500원 카드 결제";
            textNaturalExpense.Size = new Size(384, 25);
            textNaturalExpense.TabIndex = 1;
            // 
            // lblAiInput
            // 
            lblAiInput.AutoSize = true;
            lblAiInput.Font = new Font("맑은 고딕", 10F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblAiInput.ForeColor = Color.FromArgb(30, 41, 59);
            lblAiInput.Location = new Point(28, 20);
            lblAiInput.Margin = new Padding(2, 0, 2, 0);
            lblAiInput.Name = "lblAiInput";
            lblAiInput.Size = new Size(121, 19);
            lblAiInput.TabIndex = 0;
            lblAiInput.Text = "AI 자동 지출 입력";
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
            panelInput.Location = new Point(40, 196);
            panelInput.Margin = new Padding(2);
            panelInput.Name = "panelInput";
            panelInput.Size = new Size(545, 270);
            panelInput.TabIndex = 3;
            // 
            // checkIsFixed
            // 
            checkIsFixed.AutoSize = true;
            checkIsFixed.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point, 129);
            checkIsFixed.ForeColor = Color.FromArgb(51, 65, 85);
            checkIsFixed.Location = new Point(28, 233);
            checkIsFixed.Margin = new Padding(2);
            checkIsFixed.Name = "checkIsFixed";
            checkIsFixed.Size = new Size(184, 23);
            checkIsFixed.TabIndex = 12;
            checkIsFixed.Text = "매달 반복되는 고정 지출";
            checkIsFixed.UseVisualStyleBackColor = true;
            // 
            // textMemo
            // 
            textMemo.BorderStyle = BorderStyle.FixedSingle;
            textMemo.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point, 129);
            textMemo.Location = new Point(28, 175);
            textMemo.Margin = new Padding(2);
            textMemo.Multiline = true;
            textMemo.Name = "textMemo";
            textMemo.Size = new Size(487, 47);
            textMemo.TabIndex = 11;
            // 
            // lblMemo
            // 
            lblMemo.AutoSize = true;
            lblMemo.Font = new Font("맑은 고딕", 10F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblMemo.ForeColor = Color.FromArgb(30, 41, 59);
            lblMemo.Location = new Point(28, 155);
            lblMemo.Margin = new Padding(2, 0, 2, 0);
            lblMemo.Name = "lblMemo";
            lblMemo.Size = new Size(37, 19);
            lblMemo.TabIndex = 10;
            lblMemo.Text = "메모";
            // 
            // dateExpense
            // 
            dateExpense.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point, 129);
            dateExpense.Format = DateTimePickerFormat.Short;
            dateExpense.Location = new Point(300, 119);
            dateExpense.Margin = new Padding(2);
            dateExpense.Name = "dateExpense";
            dateExpense.Size = new Size(216, 25);
            dateExpense.TabIndex = 9;
            // 
            // lblExpenseDate
            // 
            lblExpenseDate.AutoSize = true;
            lblExpenseDate.Font = new Font("맑은 고딕", 10F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblExpenseDate.ForeColor = Color.FromArgb(30, 41, 59);
            lblExpenseDate.Location = new Point(300, 100);
            lblExpenseDate.Margin = new Padding(2, 0, 2, 0);
            lblExpenseDate.Name = "lblExpenseDate";
            lblExpenseDate.Size = new Size(65, 19);
            lblExpenseDate.TabIndex = 8;
            lblExpenseDate.Text = "지출 날짜";
            // 
            // comboPaymentMethod
            // 
            comboPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            comboPaymentMethod.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point, 129);
            comboPaymentMethod.FormattingEnabled = true;
            comboPaymentMethod.Items.AddRange(new object[] { "카드", "현금", "계좌이체", "간편결제", "기타" });
            comboPaymentMethod.Location = new Point(28, 119);
            comboPaymentMethod.Margin = new Padding(2);
            comboPaymentMethod.Name = "comboPaymentMethod";
            comboPaymentMethod.Size = new Size(216, 25);
            comboPaymentMethod.TabIndex = 7;
            // 
            // lblPaymentMethod
            // 
            lblPaymentMethod.AutoSize = true;
            lblPaymentMethod.Font = new Font("맑은 고딕", 10F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblPaymentMethod.ForeColor = Color.FromArgb(30, 41, 59);
            lblPaymentMethod.Location = new Point(28, 100);
            lblPaymentMethod.Margin = new Padding(2, 0, 2, 0);
            lblPaymentMethod.Name = "lblPaymentMethod";
            lblPaymentMethod.Size = new Size(65, 19);
            lblPaymentMethod.TabIndex = 6;
            lblPaymentMethod.Text = "결제 수단";
            // 
            // comboCategory
            // 
            comboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            comboCategory.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point, 129);
            comboCategory.FormattingEnabled = true;
            comboCategory.Items.AddRange(new object[] { "식비", "교통", "쇼핑", "문화", "생활", "통신", "기타" });
            comboCategory.Location = new Point(300, 65);
            comboCategory.Margin = new Padding(2);
            comboCategory.Name = "comboCategory";
            comboCategory.Size = new Size(216, 25);
            comboCategory.TabIndex = 5;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("맑은 고딕", 10F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblCategory.ForeColor = Color.FromArgb(30, 41, 59);
            lblCategory.Location = new Point(300, 47);
            lblCategory.Margin = new Padding(2, 0, 2, 0);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(65, 19);
            lblCategory.TabIndex = 4;
            lblCategory.Text = "카테고리";
            // 
            // textAmount
            // 
            textAmount.BorderStyle = BorderStyle.FixedSingle;
            textAmount.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point, 129);
            textAmount.Location = new Point(28, 66);
            textAmount.Margin = new Padding(2);
            textAmount.Name = "textAmount";
            textAmount.PlaceholderText = "예: 8500";
            textAmount.Size = new Size(215, 25);
            textAmount.TabIndex = 3;
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.Font = new Font("맑은 고딕", 10F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblAmount.ForeColor = Color.FromArgb(30, 41, 59);
            lblAmount.Location = new Point(28, 47);
            lblAmount.Margin = new Padding(2, 0, 2, 0);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(37, 19);
            lblAmount.TabIndex = 2;
            lblAmount.Text = "금액";
            // 
            // textTitle
            // 
            textTitle.BorderStyle = BorderStyle.FixedSingle;
            textTitle.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point, 129);
            textTitle.Location = new Point(120, 20);
            textTitle.Margin = new Padding(2);
            textTitle.Name = "textTitle";
            textTitle.PlaceholderText = "예: 점심, 커피, 버스";
            textTitle.Size = new Size(396, 25);
            textTitle.TabIndex = 1;
            // 
            // lblExpenseTitle
            // 
            lblExpenseTitle.AutoSize = true;
            lblExpenseTitle.Font = new Font("맑은 고딕", 10F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblExpenseTitle.ForeColor = Color.FromArgb(30, 41, 59);
            lblExpenseTitle.Location = new Point(28, 22);
            lblExpenseTitle.Margin = new Padding(2, 0, 2, 0);
            lblExpenseTitle.Name = "lblExpenseTitle";
            lblExpenseTitle.Size = new Size(51, 19);
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
            buttonSave.Location = new Point(394, 484);
            buttonSave.Margin = new Padding(2);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(114, 33);
            buttonSave.TabIndex = 4;
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
            buttonCancel.Location = new Point(512, 484);
            buttonCancel.Margin = new Padding(2);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(73, 33);
            buttonCancel.TabIndex = 5;
            buttonCancel.Text = "닫기";
            buttonCancel.UseVisualStyleBackColor = false;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // FormAddExpense
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(625, 537);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(panelInput);
            Controls.Add(panelAi);
            Controls.Add(lblSubtitle);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(2);
            MaximizeBox = false;
            Name = "FormAddExpense";
            StartPosition = FormStartPosition.CenterParent;
            Text = "MoneyNote - 지출 등록";
            panelAi.ResumeLayout(false);
            panelAi.PerformLayout();
            panelInput.ResumeLayout(false);
            panelInput.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitle;
        private Label lblSubtitle;
        private Panel panelAi;
        private Button buttonReceiptAi;
        private Button buttonAnalyzeAi;
        private TextBox textNaturalExpense;
        private Label lblAiInput;
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
