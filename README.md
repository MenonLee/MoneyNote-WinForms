# 개인 지출 관리 프로그램

## 프로젝트 소개

**개인 지출 관리 프로그램**은 사용자가 일상에서 사용한 지출 내역을 등록하고, 조회, 수정, 삭제, 검색, 통계 확인을 할 수 있는 Windows 데스크톱 프로그램입니다.

본 프로젝트는 C# Windows Forms와 SQLite를 사용하여 제작하며, GitHub 브랜치 기반 협업 방식으로 개발합니다.

---

## 개발 목적

대학생은 식비, 교통비, 쇼핑, 문화생활, 구독료 등 다양한 지출을 반복적으로 하게 됩니다.  
하지만 지출 내역을 따로 기록하지 않으면 한 달 동안 어디에 돈을 많이 사용했는지 파악하기 어렵습니다.

이 프로그램은 사용자가 자신의 지출 내역을 직접 기록하고, 카테고리별 소비 금액과 월별 지출 금액을 확인할 수 있도록 하여 개인 소비 습관을 관리하는 것을 목표로 합니다.

---

## 개발 환경

| 항목 | 내용 |
|---|---|
| 언어 | C# |
| UI 프레임워크 | Windows Forms |
| 데이터베이스 | SQLite |
| DB 패키지 | Microsoft.Data.Sqlite |
| 협업 도구 | GitHub |
| 개발 방식 | Feature Branch + Pull Request |

---

## 주요 기능

| 기능 | 설명 |
|---|---|
| 지출 등록 | 지출명, 금액, 카테고리, 결제수단, 지출 날짜, 메모, 고정지출 여부를 입력하여 저장 |
| 지출 목록 조회 | 전체 지출, 오늘 지출, 특정 날짜 지출, 이번 달 지출 조회 |
| 지출 검색 | 지출명, 카테고리, 결제수단, 메모 기준 검색 |
| 지출 관리 | 선택한 지출 내역 수정 및 삭제 |
| 지출 통계 | 총 지출 금액, 이번 달 지출 금액, 평균 지출 금액, 카테고리별 지출 금액 확인 |
| 데이터 저장 | SQLite DB 파일에 지출 내역 저장 |

---

## 화면 구성

| 화면 | Form 이름 | 설명 |
|---|---|---|
| 메인 화면 | FormMain | 각 기능 화면으로 이동하는 메인 메뉴 |
| 지출 등록 화면 | FormAddExpense | 새 지출 내역 등록 |
| 지출 목록/검색 화면 | FormExpenseList | 지출 목록 조회 및 검색 |
| 지출 관리 화면 | FormManageExpense | 지출 내역 수정 및 삭제 |
| 지출 통계 화면 | FormStats | 지출 통계 확인 |

---

## 데이터베이스 구조

SQLite를 사용하며, 지출 데이터는 `Expenses` 테이블에 저장합니다.

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

### 테이블 생성 SQL

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

## 주요 클래스 및 메서드

### ExpenseItem.cs

지출 정보를 저장하는 모델 클래스입니다.

```csharp
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
```

### DatabaseHelper.cs

SQLite 연결, 테이블 생성, CRUD, 검색, 통계 조회 기능을 담당합니다.

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

통계 화면에서는 SQL을 직접 작성하지 않고, `DatabaseHelper`의 통계 메서드를 호출하여 결과만 화면에 출력합니다.

---

## 팀원 역할 분담

| 이름 | 역할 | 담당 내용 |
|---|---|---|
| 준서 | 팀장 / 메인 / GitHub / 통합 | 메인 화면 구성, Form 연결, PR 관리, 최종 통합 |
| 정영 | DB / 통계 메서드 | SQLite 연결, ExpenseItem, DatabaseHelper, CRUD, 검색, 통계 메서드 구현 |
| 성인 | 지출 등록 | FormAddExpense 구현, 입력값 검사, DB 저장 기능 |
| 범준 | 지출 목록 / 검색 | FormExpenseList 구현, 전체/날짜별/월별 조회, 검색 기능 |
| 윤서 | 지출 관리 / 통계 화면 | FormManageExpense, FormStats 구현, 수정/삭제, 통계 결과 출력 |

---

## 브랜치 전략

| 브랜치 | 담당자 | 작업 내용 |
|---|---|---|
| main | 준서 | 최종 안정 버전 관리 |
| feature/main-ui | 준서 | 메인 화면, 버튼 연결, Program.cs, README |
| feature/database | 정영 | SQLite DB 연결, ExpenseItem, DatabaseHelper 구현 |
| feature/add-expense | 성인 | 지출 등록 화면 및 DB 저장 기능 |
| feature/expense-list-search | 범준 | 지출 목록, 날짜별 조회, 검색 기능 |
| feature/manage-stats | 윤서 | 지출 수정/삭제, 통계 화면 |

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
git checkout -b feature/add-expense
git push -u origin feature/add-expense
```

---

## 개발 일정

| 단계 | 작업 내용 | 담당자 |
|---|---|---|
| 1단계 | 프로젝트 생성, GitHub 저장소 생성, 메인 화면 기본 구성 | 준서 |
| 2단계 | ExpenseItem 모델 작성, SQLite 패키지 설치, DatabaseHelper 기본 구조 구현 | 정영 |
| 3단계 | Expenses 테이블 생성, CRUD 메서드, 검색/통계 메서드 구현 | 정영 |
| 4단계 | 지출 등록 화면 구현 및 DB 저장 연결 | 성인 |
| 5단계 | 지출 목록 화면 구현 및 날짜별 조회/검색 기능 연결 | 범준 |
| 6단계 | 지출 관리 화면 구현 및 수정/삭제 기능 연결 | 윤서 |
| 7단계 | 통계 화면 구현 및 DatabaseHelper 통계 메서드 연결 | 윤서 |
| 8단계 | 메인 화면과 전체 Form 연결, 통합 테스트 | 준서 및 전체 팀원 |
| 9단계 | 오류 수정, 발표 자료 및 시연 준비 | 전체 팀원 |

---

## 실행 흐름

1. 프로그램 실행
2. `DatabaseHelper.InitializeDatabase()` 호출
3. SQLite DB 파일 및 `Expenses` 테이블 생성
4. 메인 화면 표시
5. 사용자가 지출 등록, 목록 조회, 검색, 관리, 통계 기능 사용
6. 모든 지출 데이터는 SQLite DB에 저장

---

## 기대 효과

- 개인 지출 내역을 체계적으로 관리할 수 있습니다.
- 카테고리별 소비 금액을 확인하여 소비 습관을 파악할 수 있습니다.
- Windows Forms의 주요 컨트롤을 활용할 수 있습니다.
- SQLite를 이용한 데이터 저장 및 CRUD 기능을 실습할 수 있습니다.
- 검색 기능과 통계 기능을 통해 DB 조회 기능을 확장해서 사용할 수 있습니다.
- GitHub 브랜치와 Pull Request를 활용한 팀 협업 방식을 경험할 수 있습니다.
