# 협업 가이드 (CONTRIBUTING.md)

## 브랜치 전략
- `main`: 항상 안정적인 버전을 유지합니다.  
  - 직접 커밋하지 않고, PR을 통해 Merge합니다.
- 기능 작업 시:
  - `git checkout -b feature/기능명`
  - 작업 완료 후 main 브랜치로 Pull Request를 보냅니다.
- 버그 수정 시:
  - `git checkout -b fix/버그명` 

## 커밋 메시지 컨벤션
- 형식: `[타입]: 설명
1. feat
  - 설명: 새로운 기능을 추가할 때 사용합니다.
  - 예시:
    - feat: 사용자 로그인 기능 추가
    - feat: 카드 드래그 앤 드롭 기능 구현

2. fix
  - 설명: 버그를 수정할 때 사용합니다.
  - 예시:
    - fix: 사용자 데이터 로딩 중 발생하는 크래시 해결
    - fix: 오타로 인해 발생한 에러 메시지 수정

3. docs
  - 설명: 문서와 관련된 변경 사항에 사용합니다.
  - 예시:
    - docs: README에 설치 방법 추가
    - docs: API 문서에 사용자 서비스 관련 내용 추가
    - docs: CONTRIBUTING에 오타 수정

4. refactor
  - 설명: 기존 코드의 기능을 유지하면서 구조를 개선하거나 리팩토링할 때 사용합니다.
  - 예시:
    - refactor: 카드 드로우 로직 단순화
    - refactor: 유틸리티 함수로 코드 분리
    - refactor: if-else 문을 switch문으로 변경

5. style
  - 설명: 코드의 스타일 변경에 사용하며, 기능에 영향을 미치지 않는 변경입니다. (예: 들여쓰기, 공백, 코드 포맷 등)
  - 예시:
    - style: GameManager 코드 들여쓰기 수정
    - style: Prettier로 코드 포맷팅
    - style: 불필요한 공백 제거

6. test
  - 설명: 테스트 코드 추가 또는 수정 시 사용합니다.
  - 예시:
    - test: 카드 셔플 유닛 테스트 추가
    - test: 로그인 테스트용 데이터 업데이트

7. chore (기타 작업)
  - 설명: 빌드 작업, 패키지 관리, 설정 변경 등 코드의 기능과 직접 관련되지 않은 작업에 사용합니다.
  - 예시:
    - chore: 최신 버전으로 dependencies 업데이트
    - chore: 사용하지 않는 assets 정리

## Pull Request 규칙
- 적절한 PR 제목과 설명을 달아주세요.
- 다른 팀원이 리뷰 후 Merge합니다. 

## Git LFS
- 이미지, 사운드, FBX, PSB 등은 LFS로 추적합니다.
- `.gitattributes`에 등록되어 있어야 합니다.

## Unity 프로젝트 주의사항
- **Unity 버전**: 6000.0.28f1 LTS  
- 씬 파일 충돌 방지를 위해 한 번에 한 사람만 동일 씬을 작업하거나, 작은 씬 단위로 분할합니다.
- `.gitignore`에 `Library/`, `Temp/`, `Build/` 등이 포함되어야 합니다.

## 코드 스타일
- 클래스/메서드 네이밍 규칙, 중괄호 스타일 등 논의 후 구체화합시다.
