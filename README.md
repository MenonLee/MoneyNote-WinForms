# 개인 지출 관리 프로그램

## 프로젝트 소개

**개인 지출 관리 프로그램**은 사용자가 일상에서 사용한 지출 내역을 등록하고, 조회, 수정, 삭제, 검색, 통계 확인을 할 수 있는 Windows 데스크톱 프로그램입니다.

본 프로젝트는 C# Windows Forms와 SQLite를 사용하여 제작하며, GitHub 브랜치 기반 협업 방식으로 개발합니다.

기본적인 지출 기록 기능에 더해 예산 관리, 고정지출 자동 관리, 차트 통계, CSV 백업, Gemini API 기반 AI 자연어 지출 등록 및 AI 소비 분석 기능을 추가하여 단순 가계부가 아니라 소비 습관을 분석해주는 프로그램으로 확장합니다.

---

## 개발 목적

대학생은 식비, 교통비, 쇼핑, 문화생활, 구독료 등 다양한 지출을 반복적으로 하게 됩니다.  
하지만 지출 내역을 따로 기록하지 않으면 한 달 동안 어디에 돈을 많이 사용했는지 파악하기 어렵습니다.

이 프로그램은 사용자가 자신의 지출 내역을 직접 기록하고, 카테고리별 소비 금액과 월별 지출 금액을 확인할 수 있도록 하여 개인 소비 습관을 관리하는 것을 목표로 합니다.

추가 기능을 통해 사용자는 월 예산 초과 여부, 고정지출 규모, 최근 소비 패턴, AI가 생성한 절약 조언까지 확인할 수 있습니다.

---

## 개발 환경

| 항목 | 내용 |
|---|---|
| 언어 | C# |
| UI 프레임워크 | Windows Forms |
| 데이터베이스 | SQLite |
| DB 패키지 | Microsoft.Data.Sqlite |
| AI API | Gemini API |
| 협업 도구 | GitHub |
| 개발 방식 | Feature Branch + Pull Request |

---

## 주요 기능

### 기본 기능

| 기능 | 설명 |
|---|---|
| 지출 등록 | 지출명, 금액, 카테고리, 결제수단, 지출 날짜, 메모, 고정지출 여부를 입력하여 저장 |
| 지출 목록 조회 | 전체 지출, 오늘 지출, 특정 날짜 지출, 이번 달 지출 조회 |
| 지출 검색 | 지출명, 카테고리, 결제수단, 메모 기준 검색 |
| 지출 관리 | 선택한 지출 내역 수정 및 삭제 |
| 지출 통계 | 총 지출 금액, 이번 달 지출 금액, 평균 지출 금액, 카테고리별 지출 금액 확인 |
| 데이터 저장 | SQLite DB 파일에 지출 내역 저장 |

### 확장 기능

| 기능 | 설명 |
|---|---|
| 메인 대시보드 | 이번 달 지출, 남은 예산, 고정지출 합계, 최다 지출 카테고리, 최근 지출 표시 |
| 예산 관리 | 월 전체 예산과 카테고리별 예산 설정 |
| 예산 상태 표시 | 예산 사용률, 예산 초과, 예산 주의 상태 표시 |
| 고정지출 관리 | 통신비, 구독료, 월세처럼 매달 반복되는 지출 등록 |
| 고정지출 자동 생성 | 등록된 고정지출을 매월 지출 내역에 자동 반영 |
| 차트 통계 | 카테고리별, 결제수단별 지출 비중을 차트로 표시 |
| 월별 리포트 | 이번 달 지출과 지난달 지출을 비교 |
| CSV 내보내기/가져오기 | 지출 데이터를 CSV 파일로 백업하거나 불러오기 |
| AI 자연어 지출 등록 | 문장으로 입력한 지출 내용을 Gemini API로 분석하여 등록 폼 자동 입력 |
| AI 소비 분석 코멘트 | Gemini API가 이번 달 소비 패턴과 절약 추천 문장 생성 |

---

## Gemini API 활용

AI 기능은 `GeminiService` 공통 클래스로 분리하여 사용합니다.

권장 위치:

```text
ScheduleProject/ScheduleProject/Services/GeminiService.cs
```

### AI 자연어 지출 등록

사용자가 문장으로 지출 내용을 입력하면 Gemini API가 제목, 금액, 카테고리, 결제수단, 날짜, 메모를 추출합니다.

입력 예시:

```text
오늘 점심으로 김밥천국에서 8500원 카드 결제
```

AI 분석 결과 예시:

```json
{
  "title": "김밥천국 점심",
  "amount": 8500,
  "category": "식비",
  "paymentMethod": "카드",
  "expenseDate": "2026-06-08",
  "memo": "점심"
}
```

처리 흐름:

```text
1. 사용자가 자연어 문장을 입력한다.
2. Gemini API에 문장을 전달한다.
3. Gemini가 JSON 형태로 지출 정보를 반환한다.
4. 반환된 값을 지출 등록 폼에 자동 입력한다.
5. 사용자가 내용을 확인한 뒤 저장한다.
```

### AI 소비 분석 코멘트

DB에 저장된 이번 달 지출 요약, 카테고리별 합계, 예산 정보를 Gemini API에 전달하여 소비 분석 문장을 생성합니다.

출력 예시:

```text
이번 달은 식비가 전체 지출의 43%로 가장 높습니다.
지난달보다 카페 지출이 증가했습니다.
다음 달에는 식비 예산을 20,000원 줄이면 전체 예산을 맞추는 데 도움이 됩니다.
```

권장 메서드:

```csharp
ParseNaturalExpense(string userText)
AnalyzeMonthlySpending(MonthlySpendingSummary summary)
```

주의 사항:

```text
- API 키를 코드에 직접 작성하지 않는다.
- 환경 변수 또는 별도 설정 파일에서 API 키를 읽어온다.
- Gemini 응답은 JSON 형태로 받아 파싱하기 쉽게 만든다.
- API 오류가 발생해도 프로그램이 종료되지 않도록 예외 처리를 한다.
```

---

## 화면 구성

| 화면 | Form 이름 | 설명 |
|---|---|---|
| 메인 대시보드 | FormMain | 메뉴, 월 지출 요약, 예산 상태, 최근 지출, AI 코멘트 표시 |
| 지출 등록 화면 | FormAddExpense | 일반 지출 등록 및 AI 자연어 지출 등록 |
| 지출 목록/검색 화면 | FormExpenseList | 지출 목록 조회, 검색, 필터, CSV 내보내기/가져오기 |
| 지출 관리 화면 | FormManageExpense | 지출 내역 수정 및 삭제 |
| 예산 관리 화면 | FormBudget | 월 예산 및 카테고리별 예산 설정 |
| 고정지출 화면 | FormFixedExpense | 반복 지출 등록, 수정, 삭제, 자동 생성 |
| 소비 분석 화면 | FormStats | 차트 통계, 월별 리포트, AI 소비 분석 코멘트 |

### 메인 UI 개선 방향

메인 화면은 단순 버튼 메뉴가 아니라 소비 상태를 바로 확인할 수 있는 대시보드형 화면으로 구성합니다.

```text
왼쪽 메뉴:
홈 / 지출 등록 / 지출 내역 / 예산 관리 / 고정지출 / 소비 분석 / 종료

오른쪽 대시보드:
이번 달 지출 / 남은 예산 / 예산 사용률 / 고정지출 합계
최다 지출 카테고리 / 최근 지출 5개 / 카테고리별 차트 / AI 소비 코멘트
```

---

## 데이터베이스 구조

SQLite를 사용하며, 기본 지출 데이터는 `Expenses` 테이블에 저장합니다.

### Expenses

| 컬럼명 | 자료형 | 설명 |
|---|---|---|
| Id | INTEGER PRIMARY KEY AUTOINCREMENT | 지출 고유 번호 |
| Title | TEXT NOT NULL | 지출명 |
| Amount | INTEGER NOT NULL | 지출 금액 |
| Category | TEXT | 식비, 교통, 쇼핑, 문화, 기타 등 |
| PaymentMethod | TEXT | 현금, 카드, 계좌이체 등 |
| ExpenseDate | TEXT NOT NULL | 지출 날짜 |
| Memo | TEXT | 지출 관련 메모 |
| IsFixed | INTEGER DEFAULT 0 | 고정지출 여부 |
| CreatedAt | TEXT NOT NULL | 지출 등록일 |

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

### Budgets

월 전체 예산과 카테고리별 예산을 저장합니다.

```sql
CREATE TABLE IF NOT EXISTS Budgets (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Year INTEGER NOT NULL,
    Month INTEGER NOT NULL,
    Category TEXT,
    Amount INTEGER NOT NULL,
    CreatedAt TEXT NOT NULL
);
```

### FixedExpenses

매달 반복되는 고정지출 정보를 저장합니다.

```sql
CREATE TABLE IF NOT EXISTS FixedExpenses (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Title TEXT NOT NULL,
    Amount INTEGER NOT NULL,
    Category TEXT,
    PaymentMethod TEXT,
    DayOfMonth INTEGER NOT NULL,
    Memo TEXT,
    IsActive INTEGER DEFAULT 1,
    CreatedAt TEXT NOT NULL
);
```

### AiAnalysisLogs

AI 분석 결과를 저장하고 다시 확인할 때 사용합니다.

```sql
CREATE TABLE IF NOT EXISTS AiAnalysisLogs (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Year INTEGER NOT NULL,
    Month INTEGER NOT NULL,
    Summary TEXT NOT NULL,
    CreatedAt TEXT NOT NULL
);
```

---

## 주요 클래스 및 메서드

### 모델

```text
ExpenseItem
BudgetItem
FixedExpenseItem
MonthlySpendingSummary
AiAnalysisLog
```

### DatabaseHelper

SQLite 연결, 테이블 생성, CRUD, 검색, 예산, 고정지출, 통계 조회 기능을 담당합니다.

```csharp
public static void InitializeDatabase();

public static void AddExpense(ExpenseItem expense);
public static List<ExpenseItem> GetAllExpenses();
public static ExpenseItem? GetExpenseById(int id);
public static void UpdateExpense(ExpenseItem expense);
public static void DeleteExpense(int id);

public static List<ExpenseItem> SearchExpenses(string keyword);
public static List<ExpenseItem> GetExpensesByDate(DateTime date);
public static List<ExpenseItem> GetThisMonthExpenses(int year, int month);

public static int GetTotalExpenseAmount();
public static int GetMonthlyExpenseAmount(int year, int month);
public static Dictionary<string, int> GetCategoryExpenseSummary();

public static void SaveBudget(BudgetItem budget);
public static int GetMonthlyBudget(int year, int month);
public static Dictionary<string, int> GetCategoryBudgets(int year, int month);

public static void AddFixedExpense(FixedExpenseItem fixedExpense);
public static List<FixedExpenseItem> GetActiveFixedExpenses();
public static void GenerateMonthlyFixedExpenses(int year, int month);
```

### Services

```text
GeminiService
- 자연어 지출 분석
- 월별 소비 분석 코멘트 생성

CsvService
- 지출 내역 CSV 내보내기
- CSV 파일 가져오기
```

---

## 팀원 역할 분담

메인 UI와 데이터베이스 역할은 단독으로는 작업량이 적을 수 있으므로, 각각 예산 관리와 고정지출 기능을 함께 맡습니다.

| 이름 | 역할 | 담당 내용 |
|---|---|---|
| 준서 | 메인 대시보드 + 예산 관리 | 메인 UI 개선, 월 지출 요약, 예산 설정, 남은 예산 표시 |
| 정영 | DB + 고정지출 자동 생성 | DB 구조 확장, 공통 메서드, 고정지출 등록/자동 생성 |
| 성인 | 지출 등록 + AI 자연어 등록 | 일반 지출 등록, Gemini 자연어 분석, 폼 자동 입력 |
| 범준 | 지출 목록 + 검색 + CSV | 지출 조회, 필터, 검색, CSV 내보내기/가져오기 |
| 윤서 | 통계 차트 + AI 소비 분석 | 차트 통계, 월별 리포트, Gemini 소비 분석 코멘트 |

---

## 브랜치 전략

| 브랜치 | 담당자 | 작업 내용 |
|---|---|---|
| main | 전체 | 최종 안정 버전 관리 |
| feature/dashboard-budget | 준서 | 메인 대시보드, 예산 관리 |
| feature/database-fixed-expense | 정영 | DB 확장, 고정지출 |
| feature/ai-natural-expense | 성인 | 지출 등록, AI 자연어 등록 |
| feature/expense-list-csv | 범준 | 지출 목록, 검색, CSV |
| feature/stats-ai-analysis | 윤서 | 통계 차트, AI 소비 분석 |

---

## Git 작업 규칙

### 작업 시작 전

```bash
git checkout main
git pull origin main
git checkout 본인브랜치
git merge main
```

### 작업 완료 후

```bash
git status
git add .
git commit -m "[Add] 작업 내용"
git push origin 본인브랜치
```

### 브랜치 생성 예시

```bash
git checkout main
git pull origin main
git checkout -b feature/ai-natural-expense
git push -u origin feature/ai-natural-expense
```

---

## 개발 일정

| 단계 | 작업 내용 | 담당자 |
|---|---|---|
| 1단계 | DB 테이블 확장, 예산/고정지출/통계 공통 메서드 추가 | 정영 |
| 2단계 | 메인 대시보드 UI와 예산 관리 화면 구현 | 준서 |
| 3단계 | 일반 지출 등록과 AI 자연어 지출 등록 구현 | 성인 |
| 4단계 | 지출 목록, 검색, 필터, CSV 기능 구현 | 범준 |
| 5단계 | 차트 통계, 월별 리포트, AI 소비 분석 구현 | 윤서 |
| 6단계 | 메인 화면에서 전체 화면 연결 | 준서 |
| 7단계 | 통합 테스트 및 DB 연동 오류 수정 | 전체 팀원 |
| 8단계 | 발표 자료 및 시연 흐름 준비 | 전체 팀원 |

---

## 실행 흐름

1. 프로그램 실행
2. `DatabaseHelper.InitializeDatabase()` 호출
3. SQLite DB 파일 및 필요한 테이블 생성
4. 메인 대시보드 표시
5. 사용자가 예산과 고정지출을 설정
6. 일반 입력 또는 AI 자연어 입력으로 지출 등록
7. 지출 목록에서 조회, 검색, CSV 백업 기능 사용
8. 소비 분석 화면에서 차트와 AI 분석 코멘트 확인
9. 모든 지출 데이터는 SQLite DB에 저장

---

## 최종 시연 흐름

1. 프로그램 실행 후 메인 대시보드 확인
2. 이번 달 지출, 남은 예산, 고정지출 합계 확인
3. 예산 관리 화면에서 월 예산 또는 카테고리 예산 설정
4. AI 자연어 지출 등록으로 문장형 지출 입력
5. 지출 목록에서 등록된 내역 확인
6. 검색과 필터 기능 시연
7. CSV 내보내기 또는 가져오기 시연
8. 고정지출 등록 및 자동 생성 설명
9. 통계 화면에서 차트 확인
10. AI 소비 분석 코멘트 확인

---

## 기대 효과

- 개인 지출 내역을 체계적으로 관리할 수 있습니다.
- 예산 대비 지출 상태를 확인하여 과소비를 예방할 수 있습니다.
- 고정지출을 자동으로 관리하여 반복 입력을 줄일 수 있습니다.
- 카테고리별, 결제수단별 차트로 소비 패턴을 쉽게 파악할 수 있습니다.
- Gemini API를 활용해 문장형 지출 입력과 AI 소비 분석을 제공할 수 있습니다.
- CSV 기능으로 지출 데이터를 백업하거나 엑셀에서 활용할 수 있습니다.
- Windows Forms, SQLite, 외부 API 연동, GitHub 협업 방식을 함께 경험할 수 있습니다.
