# MoneyNote-WinForms 프로젝트 전체 설명서

> 이 문서는 생성형 AI 또는 프로젝트를 처음 보는 사람이 이 파일 하나만 읽고도 프로젝트의 목적, 구조, 역할 분담, DB 설계, 화면 구성, 개발 규칙을 바로 파악할 수 있도록 작성한 프로젝트 컨텍스트 문서입니다.

---

## 1. 프로젝트 한 줄 요약

**MoneyNote-WinForms**는 C# Windows Forms와 SQLite를 사용하여 개인의 지출 내역을 등록, 조회, 검색, 수정, 삭제하고 지출 통계를 확인할 수 있는 개인 지출 관리 프로그램입니다.

---

## 2. 프로젝트 기본 정보

| 항목 | 내용 |
|---|---|
| 프로젝트명 | 개인 지출 관리 프로그램 |
| 저장소 이름 추천 | MoneyNote-WinForms |
| 개발 언어 | C# |
| UI 프레임워크 | Windows Forms |
| 데이터베이스 | SQLite |
| DB 패키지 | Microsoft.Data.Sqlite |
| 협업 도구 | GitHub |
| 협업 방식 | Feature Branch + Pull Request |
| 주요 목적 | 개인 지출 내역 관리 및 소비 통계 확인 |

---

## 3. 프로젝트 개발 배경

처음에는 개인 일정 및 과제 관리 프로그램을 만들 계획이었으나, 교수님이 예제로 제시한 내용과 주제가 너무 비슷해질 가능성이 있어 **개인 지출 관리 프로그램**으로 주제를 변경했습니다.

하지만 기존 일정 관리 프로그램의 구조는 그대로 활용할 수 있습니다.

기존 구조:

```text
등록 → 목록 조회 → 수정/삭제 → 검색 → 통계 → SQLite 저장
```

변경 후 구조:

```text
지출 등록 → 지출 목록 조회 → 지출 수정/삭제 → 지출 검색 → 지출 통계 → SQLite 저장
```

즉, 프로그램의 내부 구조는 거의 유지하면서 주제만 일정 관리에서 지출 관리로 바꾼 프로젝트입니다.

---

## 4. 프로그램 핵심 기능

### 4.1 지출 등록

사용자가 새로운 지출 내역을 입력하여 DB에 저장하는 기능입니다.

입력 항목:

| 항목 | 설명 | 예시 |
|---|---|---|
| 지출명 | 무엇에 돈을 썼는지 | 점심, 커피, 택시비 |
| 금액 | 사용한 금액 | 8500 |
| 카테고리 | 지출 종류 | 식비, 교통, 쇼핑, 문화, 기타 |
| 결제수단 | 결제 방식 | 현금, 카드, 계좌이체 |
| 지출 날짜 | 돈을 쓴 날짜 | 2026-06-01 |
| 메모 | 추가 설명 | 친구와 점심 |
| 고정지출 여부 | 매달 반복되는 지출인지 여부 | 통신비, 구독료 |

---

### 4.2 지출 목록 조회

등록된 지출 내역을 DataGridView에 표 형태로 출력합니다.

조회 기능:

- 전체 지출 보기
- 오늘 지출 보기
- 특정 날짜 지출 보기
- 이번 달 지출 보기
- 새로고침

출력 예시:

| 번호 | 날짜 | 지출명 | 카테고리 | 금액 | 결제수단 | 메모 |
|---|---|---|---|---:|---|---|
| 1 | 2026-06-01 | 점심 | 식비 | 8,500원 | 카드 | 학교 앞 식당 |
| 2 | 2026-06-01 | 버스 | 교통 | 1,500원 | 카드 | 등교 |

---

### 4.3 지출 검색

지출 목록 화면 안에서 검색 기능을 함께 제공합니다.

검색 기준:

- 지출명
- 카테고리
- 결제수단
- 메모
- 날짜

검색 기능은 별도 Form으로 분리하지 않고 **FormExpenseList 내부에 포함**하는 것이 좋습니다.  
목록 조회와 검색 결과 출력이 모두 DataGridView를 사용하기 때문에 구현과 통합이 쉬워집니다.

---

### 4.4 지출 관리

선택한 지출 내역을 수정하거나 삭제하는 기능입니다.

관리 기능:

- 선택한 지출 정보 불러오기
- 지출명 수정
- 금액 수정
- 카테고리 수정
- 결제수단 수정
- 날짜 수정
- 메모 수정
- 고정지출 여부 수정
- 지출 내역 삭제
- 삭제 전 확인 메시지 출력

---

### 4.5 지출 통계

DB에 저장된 지출 데이터를 바탕으로 소비 통계를 보여줍니다.

통계 항목:

| 통계 항목 | 설명 |
|---|---|
| 전체 지출 건수 | 등록된 지출 내역 개수 |
| 총 지출 금액 | 전체 지출 금액 합계 |
| 이번 달 지출 금액 | 현재 월의 지출 금액 합계 |
| 평균 지출 금액 | 한 건당 평균 지출 금액 |
| 카테고리별 지출 금액 | 식비, 교통, 쇼핑 등 카테고리별 합계 |

중요한 구조:

```text
통계 계산 SQL은 FormStats에서 직접 작성하지 않는다.
DB 담당자가 DatabaseHelper.cs에 통계 메서드를 만들고,
FormStats는 그 메서드를 호출해서 화면에 출력만 한다.
```

---

## 5. 전체 화면 구성

| 화면 | Form 이름 | 담당자 | 설명 |
|---|---|---|---|
| 메인 화면 | FormMain | 준서 | 각 기능 화면으로 이동하는 메인 메뉴 |
| 지출 등록 화면 | FormAddExpense | 성인 | 새 지출 내역 등록 |
| 지출 목록/검색 화면 | FormExpenseList | 범준 | 전체/날짜별/월별 조회 및 검색 |
| 지출 관리 화면 | FormManageExpense | 윤서 | 지출 내역 수정 및 삭제 |
| 지출 통계 화면 | FormStats | 윤서 | 지출 통계 확인 |

---

## 6. 메인 화면 구성

메인 화면에는 다음 버튼을 배치합니다.

| 버튼 이름 | 연결 Form | 기능 |
|---|---|---|
| 지출 등록 | FormAddExpense | 새 지출 등록 |
| 지출 목록/검색 | FormExpenseList | 지출 내역 조회 및 검색 |
| 지출 관리 | FormManageExpense | 지출 수정 및 삭제 |
| 지출 통계 | FormStats | 지출 통계 확인 |
| 종료 | 없음 | 프로그램 종료 |

버튼 클릭 예시:

```csharp
private void btnAddExpense_Click(object sender, EventArgs e)
{
    FormAddExpense form = new FormAddExpense();
    form.ShowDialog();
}
```

---

## 7. 데이터베이스 설계

SQLite를 사용하며, 지출 데이터는 `Expenses` 테이블에 저장합니다.

### 7.1 DB 파일 이름

```text
expense.db
```

### 7.2 테이블 이름

```text
Expenses
```

### 7.3 Expenses 테이블 구조

| 컬럼명 | 자료형 | 설명 |
|---|---|---|
| Id | INTEGER PRIMARY KEY AUTOINCREMENT | 지출 고유 번호 |
| Title | TEXT NOT NULL | 지출명 |
| Amount | INTEGER NOT NULL | 지출 금액 |
| Category | TEXT | 식비, 교통, 쇼핑, 문화, 기타 등 |
| PaymentMethod | TEXT | 현금, 카드, 계좌이체 등 |
| ExpenseDate | TEXT NOT NULL | 지출 날짜 |
| Memo | TEXT | 지출 관련 메모 |
| IsFixed | INTEGER DEFAULT 0 | 고정지출 여부. 0은 일반 지출, 1은 고정 지출 |
| CreatedAt | TEXT NOT NULL | 지출 등록일 |

### 7.4 테이블 생성 SQL

```sql
CREATE TABLE IF NOT EXISTS Expenses (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Title TEXT NOT NULL,
    Amount INTEGER NOT NULL,
    Category TEXT,
    PaymentMethod TEXT,
    ExpenseDate TEXT NOT NULL,
    Memo TEXT,
    IsFixed INTEGER DEFAULT 0,
    CreatedAt TEXT NOT NULL
);
```

---

## 8. 모델 클래스 설계

### 8.1 ExpenseItem.cs

`ExpenseItem` 클래스는 지출 한 건의 정보를 담는 모델 클래스입니다.

권장 위치:

```text
Models/ExpenseItem.cs
```

예상 코드 구조:

```csharp
namespace MoneyNote.Models
{
    public class ExpenseItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Amount { get; set; }
        public string Category { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string Memo { get; set; }
        public bool IsFixed { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
```

---

## 9. DatabaseHelper 설계

### 9.1 역할

`DatabaseHelper.cs`는 SQLite 관련 처리를 담당하는 공통 클래스입니다.

담당 기능:

- DB 연결
- 테이블 생성
- 지출 등록
- 지출 조회
- 지출 수정
- 지출 삭제
- 지출 검색
- 통계 조회

권장 위치:

```text
Data/DatabaseHelper.cs
```

---

### 9.2 필수 메서드 목록

```csharp
public static void InitializeDatabase();

public static void AddExpense(ExpenseItem expense);
public static List<ExpenseItem> GetAllExpenses();
public static ExpenseItem GetExpenseById(int id);
public static void UpdateExpense(ExpenseItem expense);
public static void DeleteExpense(int id);

public static List<ExpenseItem> SearchExpenses(string keyword);
public static List<ExpenseItem> GetExpensesByDate(DateTime date);
public static List<ExpenseItem> GetThisMonthExpenses(int year, int month);

public static int GetTotalExpenseCount();
public static int GetTotalExpenseAmount();
public static int GetMonthlyExpenseAmount(int year, int month);
public static int GetAverageExpenseAmount();
public static Dictionary<string, int> GetCategoryExpenseSummary();
```

---

### 9.3 메서드별 설명

| 메서드 | 설명 |
|---|---|
| InitializeDatabase() | DB 파일 연결 및 Expenses 테이블 생성 |
| AddExpense(expense) | 새 지출 내역 추가 |
| GetAllExpenses() | 전체 지출 내역 조회 |
| GetExpenseById(id) | 특정 Id의 지출 내역 조회 |
| UpdateExpense(expense) | 기존 지출 내역 수정 |
| DeleteExpense(id) | 특정 지출 내역 삭제 |
| SearchExpenses(keyword) | 키워드 기준 검색 |
| GetExpensesByDate(date) | 특정 날짜 지출 조회 |
| GetThisMonthExpenses(year, month) | 특정 연도/월의 지출 조회 |
| GetTotalExpenseCount() | 전체 지출 건수 조회 |
| GetTotalExpenseAmount() | 전체 지출 금액 합계 조회 |
| GetMonthlyExpenseAmount(year, month) | 특정 월 지출 금액 합계 조회 |
| GetAverageExpenseAmount() | 평균 지출 금액 조회 |
| GetCategoryExpenseSummary() | 카테고리별 지출 금액 합계 조회 |

---

## 10. Form별 구현 내용

## 10.1 FormMain

담당자: 준서

역할:

- 프로그램의 첫 화면
- 각 기능 화면으로 이동하는 버튼 제공
- 전체 Form 연결
- 프로그램 종료 버튼 제공

필요 컨트롤:

| 컨트롤 | 이름 예시 | 설명 |
|---|---|---|
| Button | btnAddExpense | 지출 등록 화면 열기 |
| Button | btnExpenseList | 지출 목록/검색 화면 열기 |
| Button | btnManageExpense | 지출 관리 화면 열기 |
| Button | btnStats | 지출 통계 화면 열기 |
| Button | btnExit | 프로그램 종료 |

---

## 10.2 FormAddExpense

담당자: 성인

역할:

- 새 지출 내역 입력
- 입력값 검사
- ExpenseItem 객체 생성
- DatabaseHelper.AddExpense() 호출

필요 컨트롤:

| 컨트롤 | 이름 예시 | 설명 |
|---|---|---|
| TextBox | txtTitle | 지출명 |
| NumericUpDown | numAmount | 금액 |
| ComboBox | cmbCategory | 카테고리 |
| ComboBox | cmbPaymentMethod | 결제수단 |
| DateTimePicker | dtpExpenseDate | 지출 날짜 |
| TextBox | txtMemo | 메모 |
| CheckBox | chkIsFixed | 고정지출 여부 |
| Button | btnSave | 저장 |
| Button | btnCancel | 취소 |

등록 버튼 처리 흐름:

```text
1. 지출명 입력 여부 검사
2. 금액이 0보다 큰지 검사
3. 카테고리 선택 여부 검사
4. ExpenseItem 객체 생성
5. DatabaseHelper.AddExpense(expense) 호출
6. 저장 완료 메시지 출력
7. 창 닫기 또는 입력값 초기화
```

---

## 10.3 FormExpenseList

담당자: 범준

역할:

- 전체 지출 목록 출력
- 오늘 지출 조회
- 특정 날짜 지출 조회
- 이번 달 지출 조회
- 키워드 검색
- 카테고리 검색

필요 컨트롤:

| 컨트롤 | 이름 예시 | 설명 |
|---|---|---|
| DataGridView | dgvExpenses | 지출 목록 출력 |
| Button | btnLoadAll | 전체 보기 |
| Button | btnToday | 오늘 지출 |
| Button | btnThisMonth | 이번 달 지출 |
| DateTimePicker | dtpFilterDate | 날짜 선택 |
| Button | btnFilterByDate | 날짜별 조회 |
| TextBox | txtSearch | 검색어 입력 |
| ComboBox | cmbSearchCategory | 카테고리 선택 |
| Button | btnSearch | 검색 |
| Button | btnRefresh | 새로고침 |

목록 출력 흐름:

```text
1. DatabaseHelper.GetAllExpenses() 호출
2. 반환된 List<ExpenseItem>을 DataGridView에 바인딩
3. 금액은 10,000원 형식으로 표시
4. 날짜는 yyyy-MM-dd 형식으로 표시
```

검색 처리 흐름:

```text
1. 사용자가 검색어 또는 카테고리 입력
2. DatabaseHelper.SearchExpenses(keyword) 호출
3. 검색 결과를 DataGridView에 출력
```

---

## 10.4 FormManageExpense

담당자: 윤서

역할:

- 지출 목록에서 특정 지출 선택
- 선택한 지출 내역 수정
- 선택한 지출 내역 삭제

필요 컨트롤:

| 컨트롤 | 이름 예시 | 설명 |
|---|---|---|
| DataGridView | dgvExpenses | 지출 목록 |
| TextBox | txtTitle | 지출명 수정 |
| NumericUpDown | numAmount | 금액 수정 |
| ComboBox | cmbCategory | 카테고리 수정 |
| ComboBox | cmbPaymentMethod | 결제수단 수정 |
| DateTimePicker | dtpExpenseDate | 날짜 수정 |
| TextBox | txtMemo | 메모 수정 |
| CheckBox | chkIsFixed | 고정지출 여부 수정 |
| Button | btnUpdate | 수정 |
| Button | btnDelete | 삭제 |
| Button | btnRefresh | 새로고침 |

수정 처리 흐름:

```text
1. DataGridView에서 지출 선택
2. 선택한 지출 정보를 입력 칸에 표시
3. 사용자가 값 수정
4. DatabaseHelper.UpdateExpense(expense) 호출
5. 수정 완료 메시지 출력
6. 목록 새로고침
```

삭제 처리 흐름:

```text
1. DataGridView에서 지출 선택
2. 삭제 버튼 클릭
3. 삭제 확인 메시지 출력
4. 사용자가 확인하면 DatabaseHelper.DeleteExpense(id) 호출
5. 삭제 완료 메시지 출력
6. 목록 새로고침
```

---

## 10.5 FormStats

담당자: 윤서

역할:

- 지출 통계 표시
- 통계 메서드는 직접 SQL을 쓰지 않고 DatabaseHelper 메서드 호출

필요 컨트롤:

| 컨트롤 | 이름 예시 | 설명 |
|---|---|---|
| Label | lblTotalCount | 전체 지출 건수 |
| Label | lblTotalAmount | 총 지출 금액 |
| Label | lblMonthlyAmount | 이번 달 지출 금액 |
| Label | lblAverageAmount | 평균 지출 금액 |
| DataGridView | dgvCategoryStats | 카테고리별 지출 금액 |
| Button | btnRefresh | 통계 새로고침 |

통계 표시 흐름:

```text
1. DatabaseHelper.GetTotalExpenseCount() 호출
2. DatabaseHelper.GetTotalExpenseAmount() 호출
3. DatabaseHelper.GetMonthlyExpenseAmount(year, month) 호출
4. DatabaseHelper.GetAverageExpenseAmount() 호출
5. DatabaseHelper.GetCategoryExpenseSummary() 호출
6. 결과를 Label과 DataGridView에 출력
```

예시 코드:

```csharp
private void LoadStats()
{
    int totalCount = DatabaseHelper.GetTotalExpenseCount();
    int totalAmount = DatabaseHelper.GetTotalExpenseAmount();
    int monthlyAmount = DatabaseHelper.GetMonthlyExpenseAmount(DateTime.Now.Year, DateTime.Now.Month);
    int averageAmount = DatabaseHelper.GetAverageExpenseAmount();

    lblTotalCount.Text = totalCount + "건";
    lblTotalAmount.Text = totalAmount.ToString("N0") + "원";
    lblMonthlyAmount.Text = monthlyAmount.ToString("N0") + "원";
    lblAverageAmount.Text = averageAmount.ToString("N0") + "원";

    var categoryStats = DatabaseHelper.GetCategoryExpenseSummary();
    dgvCategoryStats.DataSource = categoryStats
        .Select(x => new { Category = x.Key, Amount = x.Value })
        .ToList();
}
```

---

## 11. 팀원 역할 분담

| 이름 | 역할 | 담당 파일/화면 | 핵심 책임 |
|---|---|---|---|
| 준서 | 팀장 / 메인 / GitHub / 통합 | FormMain, Program.cs, README.md | 프로젝트 통합, 메인 화면, PR 관리 |
| 정영 | DB / 통계 메서드 | DatabaseHelper.cs, ExpenseItem.cs | SQLite 연결, CRUD, 검색, 통계 조회 메서드 구현 |
| 성인 | 지출 등록 | FormAddExpense | 지출 입력 UI 및 DB 저장 |
| 범준 | 지출 목록 / 검색 | FormExpenseList | 전체/날짜별/월별 조회, 키워드/카테고리 검색 |
| 윤서 | 지출 관리 / 통계 화면 | FormManageExpense, FormStats | 수정, 삭제, 통계 결과 화면 출력 |

---

## 12. GitHub 브랜치 전략

| 브랜치 | 담당자 | 작업 내용 |
|---|---|---|
| main | 준서 | 최종 안정 버전 관리 |
| feature/main-ui | 준서 | 메인 화면, 버튼 연결, Program.cs, README |
| feature/database | 정영 | SQLite DB 연결, ExpenseItem, DatabaseHelper 구현 |
| feature/add-expense | 성인 | 지출 등록 화면 및 DB 저장 기능 |
| feature/expense-list-search | 범준 | 지출 목록, 날짜별 조회, 검색 기능 |
| feature/manage-stats | 윤서 | 지출 수정/삭제, 통계 화면 |

규칙:

```text
main 브랜치에는 직접 작업하지 않는다.
각자 담당 feature 브랜치에서 작업한다.
작업 완료 후 Pull Request로 main에 병합한다.
WinForms Designer 충돌을 줄이기 위해 한 Form은 한 명만 수정한다.
```

---

## 13. Git 작업 명령어

### 13.1 작업 시작 전

```bash
git checkout main
git pull origin main
git checkout 본인브랜치
git merge main
```

### 13.2 작업 완료 후

```bash
git status
git add .
git commit -m "[Add] 작업 내용"
git push origin 본인브랜치
```

### 13.3 브랜치 생성 예시

```bash
git checkout main
git pull origin main
git checkout -b feature/add-expense
git push -u origin feature/add-expense
```

### 13.4 브랜치별 생성 명령어

```bash
git checkout main
git pull origin main
git checkout -b feature/main-ui
git push -u origin feature/main-ui
```

```bash
git checkout main
git pull origin main
git checkout -b feature/database
git push -u origin feature/database
```

```bash
git checkout main
git pull origin main
git checkout -b feature/add-expense
git push -u origin feature/add-expense
```

```bash
git checkout main
git pull origin main
git checkout -b feature/expense-list-search
git push -u origin feature/expense-list-search
```

```bash
git checkout main
git pull origin main
git checkout -b feature/manage-stats
git push -u origin feature/manage-stats
```

---

## 14. 권장 폴더 구조

```text
MoneyNote-WinForms/
│
├─ Program.cs
├─ FormMain.cs
├─ FormMain.Designer.cs
├─ FormMain.resx
│
├─ Models/
│   └─ ExpenseItem.cs
│
├─ Data/
│   └─ DatabaseHelper.cs
│
├─ Forms/
│   ├─ FormAddExpense.cs
│   ├─ FormAddExpense.Designer.cs
│   ├─ FormAddExpense.resx
│   │
│   ├─ FormExpenseList.cs
│   ├─ FormExpenseList.Designer.cs
│   ├─ FormExpenseList.resx
│   │
│   ├─ FormManageExpense.cs
│   ├─ FormManageExpense.Designer.cs
│   ├─ FormManageExpense.resx
│   │
│   ├─ FormStats.cs
│   ├─ FormStats.Designer.cs
│   └─ FormStats.resx
│
├─ README.md
├─ .gitignore
└─ expense.db
```

주의:

```text
expense.db 파일은 GitHub에 올리지 않는 것을 권장한다.
.gitignore에 *.db를 추가한다.
```

---

## 15. 개발 순서

### 1단계: 프로젝트 생성 및 기본 구조 만들기

담당: 준서

작업:

- WinForms 프로젝트 생성
- GitHub 저장소 생성
- 기본 폴더 구조 생성
- FormMain 생성
- README 작성

---

### 2단계: DB 구조 구현

담당: 정영

작업:

- Microsoft.Data.Sqlite 설치
- ExpenseItem.cs 작성
- DatabaseHelper.cs 작성
- InitializeDatabase() 구현
- Expenses 테이블 생성
- CRUD 메서드 구현
- 검색 메서드 구현
- 통계 메서드 구현

---

### 3단계: 지출 등록 화면 구현

담당: 성인

작업:

- FormAddExpense UI 구성
- 입력값 검사
- ExpenseItem 객체 생성
- AddExpense() 연결

---

### 4단계: 지출 목록/검색 화면 구현

담당: 범준

작업:

- FormExpenseList UI 구성
- DataGridView 출력
- 전체/오늘/날짜별/이번 달 조회
- 검색 기능 구현

---

### 5단계: 지출 관리 화면 구현

담당: 윤서

작업:

- FormManageExpense UI 구성
- 지출 선택 시 상세 정보 표시
- 수정 기능 구현
- 삭제 기능 구현

---

### 6단계: 통계 화면 구현

담당: 윤서

작업:

- FormStats UI 구성
- 통계 메서드 호출
- Label과 DataGridView에 통계 출력

---

### 7단계: 통합 및 테스트

담당: 준서 및 전체 팀원

작업:

- FormMain에서 모든 화면 연결
- DB 초기화 확인
- 등록/조회/수정/삭제/검색/통계 전체 테스트
- 오류 수정
- 최종 시연 준비

---

## 16. AI에게 작업을 요청할 때 필요한 기본 정보

생성형 AI에게 이 프로젝트 관련 코드를 요청할 때는 아래 내용을 함께 제공하면 좋습니다.

```text
C# WinForms 프로젝트입니다.
프로젝트명은 MoneyNote-WinForms입니다.
개인 지출 관리 프로그램을 만들고 있습니다.
DB는 SQLite를 사용하고, Microsoft.Data.Sqlite 패키지를 사용합니다.
지출 데이터는 Expenses 테이블에 저장합니다.
모델 클래스는 ExpenseItem입니다.
DB 처리는 Data/DatabaseHelper.cs에서 담당합니다.
화면은 FormMain, FormAddExpense, FormExpenseList, FormManageExpense, FormStats로 나뉩니다.
SQL은 각 Form에서 직접 작성하지 말고 DatabaseHelper 메서드를 호출하는 구조로 작성해야 합니다.
```

---

## 17. AI 작업 요청 예시

### 17.1 DB 담당자가 AI에게 요청할 때

```text
C# WinForms 프로젝트에서 SQLite를 사용하는 개인 지출 관리 프로그램을 만들고 있습니다.
Microsoft.Data.Sqlite를 사용합니다.
ExpenseItem 모델과 DatabaseHelper 클래스를 작성하려고 합니다.

Expenses 테이블 컬럼은 다음과 같습니다.
Id, Title, Amount, Category, PaymentMethod, ExpenseDate, Memo, IsFixed, CreatedAt

DatabaseHelper에는 다음 메서드가 필요합니다.
InitializeDatabase, AddExpense, GetAllExpenses, GetExpenseById, UpdateExpense, DeleteExpense,
SearchExpenses, GetExpensesByDate, GetThisMonthExpenses,
GetTotalExpenseCount, GetTotalExpenseAmount, GetMonthlyExpenseAmount,
GetAverageExpenseAmount, GetCategoryExpenseSummary

전체 코드를 초보자도 이해할 수 있게 주석 포함해서 작성해주세요.
```

---

### 17.2 지출 등록 담당자가 AI에게 요청할 때

```text
C# WinForms에서 FormAddExpense 화면을 만들고 있습니다.
개인 지출 관리 프로그램이고 DB 저장은 DatabaseHelper.AddExpense(expense)를 호출합니다.

입력 컨트롤은 다음과 같습니다.
txtTitle, numAmount, cmbCategory, cmbPaymentMethod, dtpExpenseDate, txtMemo, chkIsFixed, btnSave, btnCancel

저장 버튼을 누르면 입력값 검사 후 ExpenseItem 객체를 만들고 AddExpense를 호출하는 코드를 작성해주세요.
```

---

### 17.3 지출 목록/검색 담당자가 AI에게 요청할 때

```text
C# WinForms에서 FormExpenseList 화면을 만들고 있습니다.
DataGridView에 지출 목록을 출력해야 합니다.

사용할 DB 메서드는 다음과 같습니다.
DatabaseHelper.GetAllExpenses()
DatabaseHelper.GetExpensesByDate(date)
DatabaseHelper.GetThisMonthExpenses(year, month)
DatabaseHelper.SearchExpenses(keyword)

전체 보기, 오늘 지출, 특정 날짜 지출, 이번 달 지출, 키워드 검색 기능을 구현하는 코드를 작성해주세요.
```

---

### 17.4 지출 관리 담당자가 AI에게 요청할 때

```text
C# WinForms에서 FormManageExpense 화면을 만들고 있습니다.
DataGridView에서 지출 내역을 선택하면 입력 칸에 상세 정보가 표시되고,
수정 버튼을 누르면 DatabaseHelper.UpdateExpense(expense),
삭제 버튼을 누르면 DatabaseHelper.DeleteExpense(id)를 호출하게 만들고 싶습니다.

초보자도 이해할 수 있게 전체 코드 흐름을 작성해주세요.
```

---

### 17.5 통계 화면 담당자가 AI에게 요청할 때

```text
C# WinForms에서 FormStats 화면을 만들고 있습니다.
통계 계산 SQL은 FormStats에서 직접 작성하지 않고 DatabaseHelper의 메서드를 호출합니다.

사용할 메서드는 다음과 같습니다.
GetTotalExpenseCount()
GetTotalExpenseAmount()
GetMonthlyExpenseAmount(year, month)
GetAverageExpenseAmount()
GetCategoryExpenseSummary()

Label에는 전체 건수, 총 지출, 이번 달 지출, 평균 지출을 표시하고,
DataGridView에는 카테고리별 지출 금액을 표시하는 코드를 작성해주세요.
```

---

## 18. 중요한 개발 규칙

1. 각 Form은 담당자 한 명만 수정합니다.
2. `main` 브랜치에는 직접 작업하지 않습니다.
3. DB 관련 SQL은 `DatabaseHelper.cs`에 모읍니다.
4. Form에서는 가능하면 `DatabaseHelper` 메서드만 호출합니다.
5. `expense.db` 파일은 GitHub에 올리지 않습니다.
6. 작업 전에는 항상 `main` 브랜치를 pull 합니다.
7. 작업 후에는 본인 feature 브랜치에 push 합니다.
8. Pull Request는 준서가 확인 후 병합합니다.
9. WinForms Designer 파일은 충돌이 자주 나므로 다른 사람의 Form을 수정하지 않습니다.
10. 기능 구현 후에는 반드시 직접 실행해서 확인합니다.

---

## 19. 최종 시연 시 보여줄 기능 순서

1. 프로그램 실행
2. 메인 화면 확인
3. 지출 등록 화면에서 예시 지출 추가
4. 지출 목록 화면에서 전체 지출 확인
5. 오늘 지출 또는 이번 달 지출 조회
6. 검색어로 지출 검색
7. 지출 관리 화면에서 지출 수정
8. 지출 관리 화면에서 지출 삭제
9. 통계 화면에서 총 지출, 월별 지출, 카테고리별 지출 확인
10. 프로그램 종료 후 다시 실행해도 DB에 데이터가 유지되는지 확인

---

## 20. 최종 목표

이 프로젝트의 최종 목표는 단순히 화면만 만드는 것이 아니라, 다음 요소를 모두 포함하는 완성된 Windows 데스크톱 프로그램을 만드는 것입니다.

- Windows Forms UI
- SQLite 데이터 저장
- CRUD 기능
- 검색 기능
- 통계 기능
- GitHub 협업
- 팀원별 Form 분담
- DB와 UI 역할 분리
- 실제 실행 가능한 프로그램

---

## 21. 요약

MoneyNote-WinForms는 개인 지출을 관리하는 C# WinForms 프로젝트입니다.

핵심 구조는 다음과 같습니다.

```text
FormMain
    ├─ FormAddExpense      지출 등록
    ├─ FormExpenseList     지출 목록 및 검색
    ├─ FormManageExpense   지출 수정 및 삭제
    └─ FormStats           지출 통계
```

DB 구조는 다음과 같습니다.

```text
ExpenseItem 모델
        ↓
DatabaseHelper
        ↓
SQLite expense.db
        ↓
Expenses 테이블
```

역할 분담은 다음과 같습니다.

```text
준서: 메인 화면, GitHub, 통합
정영: DB, ExpenseItem, DatabaseHelper, 통계 메서드
성인: 지출 등록
범준: 지출 목록, 검색
윤서: 지출 관리, 통계 화면
```

이 문서의 내용을 기준으로 AI에게 코드 작성, 오류 수정, 기능 추가, README 작성, 발표 자료 작성 등을 요청하면 프로젝트 구조를 빠르게 이해시키고 일관된 결과를 얻을 수 있습니다.
