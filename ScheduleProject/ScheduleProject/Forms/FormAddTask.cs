using ScheduleProject.Models;
using ScheduleProject.Data; // ✅ 3번 문제 해결: DB 헬퍼를 찾기 위한 using 추가
using System;
using System.Windows.Forms;

namespace ScheduleProject.Forms
{
    public partial class FormAddTask : Form
    {
        public FormAddTask()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. 입력값 검사 (제목)
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("일정 제목을 입력해주세요!", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            // 2. 카테고리 선택 검사
            if (cbCategory.SelectedIndex == -1)
            {
                MessageBox.Show("카테고리를 선택해주세요!", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. TaskItem 객체 생성 (데이터 타입 에러 수정 완료!)
            TaskItem newTask = new TaskItem
            {
                Title = txtTitle.Text,
                Description = txtDescription.Text,
                DueDate = dtpDueDate.Value, // ✅ 1번 문제 해결: ToString() 제거하고 DateTime 값 그대로 전달
                Category = cbCategory.SelectedItem.ToString(),
                Priority = cbPriority.SelectedIndex != -1 ? cbPriority.SelectedItem.ToString() : "보통",
                IsCompleted = false // ✅ 2번 문제 해결: 숫자 0 대신 bool 타입인 false 전달
            };

            // 4. DB 추가 호출
            DatabaseHelper.AddTask(newTask);

            // 5. 완료 메시지 및 창 닫기
            MessageBox.Show("일정이 성공적으로 등록되었습니다.", "등록 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close(); 
        }
    }
}