using ScheduleProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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
            // 1. 입력값 검사 (제목을 안 적었는지 확인)
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("일정 제목을 입력해주세요!", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // 더 이상 진행하지 않고 멈춤
            }

            // 2. 카테고리를 선택 안 했는지 확인
            if (cbCategory.SelectedIndex == -1)
            {
                MessageBox.Show("카테고리를 선택해주세요!", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. TaskItem 객체 생성 (화면에 입력된 값들 담기)
            TaskItem newTask = new TaskItem
            {
                Title = txtTitle.Text,
                Description = txtDescription.Text,
                DueDate = dtpDueDate.Value.ToString("yyyy-MM-dd"), // 날짜를 글자로 변환
                Category = cbCategory.SelectedItem.ToString(),
                // 중요도를 선택 안 했으면 "보통"으로 기본값 처리
                Priority = cbPriority.SelectedIndex != -1 ? cbPriority.SelectedItem.ToString() : "보통",
                IsCompleted = 0 // 처음 만드는 거니까 미완료 상태(0)
            };

            // 4. DatabaseHelper.AddTask(task) 호출
            DatabaseHelper.AddTask(newTask);

            // 5. 등록 완료 메시지 출력 및 창 닫기
            MessageBox.Show("일정이 성공적으로 등록되었습니다.", "등록 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close(); // 현재 등록 창 닫기
        }
    }
}
