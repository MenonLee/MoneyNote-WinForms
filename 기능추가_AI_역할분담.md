# 지출 관리 프로그램 기능 추가 및 AI 활용 역할 분담

## 1. 기능 추가 방향

현재 프로젝트는 지출 등록, 조회, 검색, 수정/삭제, 기본 통계를 제공하는 개인 지출 관리 프로그램이다.
차별화를 위해 단순 기록형 앱에서 사용자의 소비 상태를 분석하고 관리해주는 앱으로 확장한다.

추가할 핵심 기능은 다음과 같다.

| 구분 | 기능 | 설명 |
|---|---|---|
| 예산 관리 | 월 예산, 카테고리별 예산 설정 | 사용자가 한 달 예산과 식비, 교통비 등 카테고리별 예산을 설정 |
| 예산 알림 | 예산 사용률 표시 | 예산의 80% 이상 사용, 예산 초과 상태 등을 메인 화면에 표시 |
| 고정지출 | 반복 지출 관리 | 통신비, 구독료, 월세처럼 매달 반복되는 지출을 별도로 등록 |
| 고정지출 자동 생성 | 매월 자동 지출 추가 | 등록된 고정지출을 해당 월 지출 내역에 자동 반영 |
| 대시보드 | 메인 화면 개선 | 이번 달 지출, 남은 예산, 고정지출, 최다 카테고리, 최근 지출 표시 |
| 차트 통계 | 카테고리별/결제수단별 차트 | 통계 화면에서 지출 비중을 시각적으로 확인 |
| 월별 리포트 | 지난달 대비 분석 | 이번 달 지출과 지난달 지출을 비교 |
| CSV 기능 | 내보내기/가져오기 | 지출 데이터를 CSV 파일로 백업하거나 불러오기 |
| AI 자연어 등록 | 문장으로 지출 등록 | 사용자가 입력한 문장에서 제목, 금액, 날짜, 카테고리 등을 자동 추출 |
| AI 소비 분석 | 소비 패턴 코멘트 | Gemini API를 사용해 이번 달 소비 패턴과 절약 팁 제공 |

## 2. Gemini API 활용 기능

Gemini API는 사용자가 입력한 자연어를 분석하거나, 저장된 지출 데이터를 바탕으로 소비 패턴을 설명하는 데 사용한다.

### 2.1 AI 자연어 지출 등록

사용자가 문장 형태로 지출 내용을 입력하면 Gemini API가 구조화된 결과로 변환한다.

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

활용 방식:

```text
1. 사용자가 자연어 문장을 입력한다.
2. Gemini API에 문장을 전달한다.
3. Gemini가 JSON 형태로 지출 정보를 반환한다.
4. 반환된 값을 지출 등록 폼에 자동 입력한다.
5. 사용자가 내용을 확인한 뒤 저장한다.
```

### 2.2 AI 소비 분석 코멘트

이번 달 지출 합계, 카테고리별 지출, 지난달 대비 지출 변화 등을 Gemini API에 전달하여 소비 분석 문장을 생성한다.

출력 예시:

```text
이번 달은 식비가 전체 지출의 43%로 가장 높습니다.
지난달보다 카페 지출이 증가했습니다.
다음 달에는 식비 예산을 20,000원 줄이면 전체 예산을 맞추는 데 도움이 됩니다.
```

활용 방식:

```text
1. DB에서 이번 달 지출 통계를 조회한다.
2. 카테고리별 합계, 총지출, 예산 정보를 요약한다.
3. Gemini API에 요약 데이터를 전달한다.
4. Gemini가 소비 분석과 절약 추천 문장을 반환한다.
5. 통계 화면 또는 메인 대시보드에 표시한다.
```

### 2.3 GeminiService 공통 클래스

AI 기능은 여러 화면에서 사용되므로 API 호출 코드를 중복 작성하지 않고 공통 서비스 클래스로 분리한다.

권장 위치:

```text
ScheduleProject/ScheduleProject/Services/GeminiService.cs
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

## 3. 역할 분담

메인 UI와 데이터베이스 역할은 단독으로는 작업량이 적을 수 있으므로, 각각 예산 관리와 고정지출 기능을 함께 맡는다.

| 담당 | 역할 | 주요 기능 |
|---|---|---|
| 준서 | 메인 대시보드 + 예산 관리 | 메인 UI 개선, 예산 설정, 남은 예산 표시 |
| 정영 | DB + 고정지출 자동 생성 | DB 구조 확장, 공통 메서드, 고정지출 관리 |
| 성인 | 지출 등록 + AI 자연어 등록 | 일반 지출 등록, Gemini 자연어 분석, 폼 자동 입력 |
| 범준 | 지출 목록 + 검색 + CSV | 지출 조회, 필터, 검색, CSV 내보내기/가져오기 |
| 윤서 | 통계 차트 + AI 소비 분석 | 차트 통계, 월별 리포트, Gemini 소비 분석 코멘트 |

## 4. 담당자별 세부 작업

### 4.1 준서: 메인 대시보드 + 예산 관리

담당 파일 및 화면:

```text
FormMain
FormBudget
```

구현 내용:

```text
- 왼쪽 사이드 메뉴형 메인 UI 구성
- 이번 달 지출 요약 카드 표시
- 남은 예산 표시
- 고정지출 합계 표시
- 최다 지출 카테고리 표시
- 최근 지출 5개 표시
- 월 예산 설정 화면 구현
- 카테고리별 예산 설정 기능 구현
- 예산 초과 또는 주의 상태 표시
```

발표 포인트:

```text
앱을 실행하자마자 이번 달 소비 상태와 예산 초과 여부를 확인할 수 있다.
```

### 4.2 정영: DB + 고정지출 자동 생성

담당 파일 및 화면:

```text
DatabaseHelper
ExpenseItem
FixedExpenseItem
FormFixedExpense
```

구현 내용:

```text
- Expenses 테이블 유지 및 필요한 컬럼 확장
- Budgets 테이블 추가
- FixedExpenses 테이블 추가
- 예산 관련 CRUD 메서드 작성
- 고정지출 관련 CRUD 메서드 작성
- 매월 고정지출 자동 추가 기능 구현
- 이번 달 고정지출 합계 계산 메서드 구현
- 다른 화면에서 사용할 통계 조회 메서드 제공
```

발표 포인트:

```text
매달 반복되는 통신비, 구독료, 월세 같은 지출을 자동으로 관리할 수 있다.
```

### 4.3 성인: 지출 등록 + AI 자연어 등록

담당 파일 및 화면:

```text
FormAddExpense
GeminiService
```

구현 내용:

```text
- 기존 일반 지출 등록 기능 유지
- 자연어 입력 TextBox 추가
- AI 분석 버튼 추가
- Gemini API로 자연어 문장 분석
- 제목, 금액, 카테고리, 결제수단, 날짜, 메모 자동 추출
- 분석 결과를 기존 입력 칸에 자동 입력
- 저장 전 사용자가 수정할 수 있도록 처리
- API 실패 시 직접 입력 가능하도록 예외 처리
```

발표 포인트:

```text
사용자가 문장으로 지출을 입력하면 AI가 자동으로 항목을 분류하고 등록 폼을 채워준다.
```

### 4.4 범준: 지출 목록 + 검색 + CSV

담당 파일 및 화면:

```text
FormExpenseList
CsvService
```

구현 내용:

```text
- 전체 지출 목록 조회
- 오늘 지출 조회
- 이번 달 지출 조회
- 특정 날짜 지출 조회
- 키워드 검색
- 카테고리별 검색
- 결제수단별 검색
- CSV 내보내기
- CSV 가져오기
- 가져온 CSV 데이터를 DB에 저장
```

발표 포인트:

```text
저장된 지출을 조건별로 빠르게 찾고, CSV 파일로 백업하거나 엑셀에서 활용할 수 있다.
```

### 4.5 윤서: 통계 차트 + AI 소비 분석

담당 파일 및 화면:

```text
FormStats
GeminiService
```

구현 내용:

```text
- 카테고리별 지출 차트 표시
- 결제수단별 지출 통계 표시
- 월별 지출 비교
- 지난달 대비 증가/감소 표시
- 가장 많이 쓴 카테고리 표시
- Gemini API로 소비 분석 코멘트 생성
- 절약 추천 문장 표시
- AI 분석 결과 새로고침 버튼 구현
```

발표 포인트:

```text
단순히 지출 합계를 보여주는 것이 아니라, AI가 소비 패턴을 분석하고 절약 방향을 추천한다.
```

## 5. 권장 브랜치 전략

각 담당자가 서로 다른 화면과 기능을 맡도록 브랜치를 분리한다.

```text
feature/dashboard-budget
feature/database-fixed-expense
feature/ai-natural-expense
feature/expense-list-csv
feature/stats-ai-analysis
```

브랜치별 담당:

| 브랜치 | 담당 | 작업 내용 |
|---|---|---|
| feature/dashboard-budget | 준서 | 메인 대시보드, 예산 관리 |
| feature/database-fixed-expense | 정영 | DB 확장, 고정지출 |
| feature/ai-natural-expense | 성인 | AI 자연어 지출 등록 |
| feature/expense-list-csv | 범준 | 지출 목록, 검색, CSV |
| feature/stats-ai-analysis | 윤서 | 통계 차트, AI 소비 분석 |

## 6. 추가 DB 설계

기존 Expenses 테이블 외에 다음 테이블을 추가하는 것을 권장한다.

### 6.1 Budgets

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

설명:

```text
- Category가 비어 있으면 월 전체 예산
- Category가 있으면 카테고리별 예산
```

### 6.2 FixedExpenses

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

설명:

```text
- 매달 반복되는 지출을 저장한다.
- DayOfMonth는 매월 며칠에 발생하는 지출인지 나타낸다.
- IsActive가 1이면 자동 생성 대상이다.
```

### 6.3 AiAnalysisLogs

AI 분석 결과를 저장하고 싶다면 다음 테이블을 추가할 수 있다.

```sql
CREATE TABLE IF NOT EXISTS AiAnalysisLogs (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Year INTEGER NOT NULL,
    Month INTEGER NOT NULL,
    Summary TEXT NOT NULL,
    CreatedAt TEXT NOT NULL
);
```

설명:

```text
- Gemini API로 생성한 월별 소비 분석 코멘트를 저장한다.
- 같은 달 분석 결과를 다시 볼 수 있다.
```

## 7. 개발 순서

권장 개발 순서는 다음과 같다.

```text
1. 정영이 DB 테이블과 공통 메서드를 먼저 추가한다.
2. 준서가 메인 대시보드와 예산 관리 화면 틀을 만든다.
3. 성인이 AI 자연어 등록 기능을 구현한다.
4. 범준이 지출 목록, 검색, CSV 기능을 구현한다.
5. 윤서가 통계 차트와 AI 소비 분석 기능을 구현한다.
6. 준서가 메인 화면에서 각 기능 화면을 연결한다.
7. 전체 팀이 통합 테스트를 진행한다.
8. 발표 시연 순서를 정리한다.
```

## 8. 최종 발표 시연 흐름

```text
1. 프로그램 실행
2. 메인 대시보드에서 이번 달 지출, 남은 예산, 고정지출 확인
3. 예산 관리 화면에서 월 예산 또는 카테고리 예산 설정
4. AI 자연어 등록으로 문장형 지출 입력
5. 지출 목록에서 등록된 내역 확인
6. 검색과 필터 기능 시연
7. CSV 내보내기 또는 가져오기 시연
8. 고정지출 등록 및 자동 생성 설명
9. 통계 화면에서 차트 확인
10. AI 소비 분석 코멘트 확인
```

## 9. 요약

이번 확장 방향의 핵심은 다음과 같다.

```text
기록 중심 지출 관리 프로그램
→ 예산과 고정지출을 관리하는 프로그램
→ AI가 자연어 등록과 소비 분석을 도와주는 지출 관리 프로그램
```

역할 분담은 다음 기준으로 구성한다.

```text
준서: 메인 화면과 예산 관리
정영: DB와 고정지출
성인: 지출 등록과 AI 자연어 등록
범준: 지출 목록과 CSV
윤서: 통계 차트와 AI 소비 분석
```
