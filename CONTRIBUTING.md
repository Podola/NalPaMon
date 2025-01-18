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
- 형식: `[타입]: 설명 (이슈번호)`
  - 예) `feat: 플레이어 이동 로직 추가 (#15)`
  - 예) `fix: NPC 대화 중 null reference 에러 해결 (#22)`
- 타입 예시: `feat`, `fix`, `docs`, `refactor`, `style`, `test`, `chore`

## Pull Request 규칙
- 적절한 PR 제목과 설명을 달아주세요.
- 다른 팀원이 리뷰 후 Merge합니다(셀프 머지는 최소화).

## Git LFS
- 이미지, 사운드, FBX, PSB 등은 LFS로 추적합니다.
- `.gitattributes`에 등록되어 있어야 합니다.

## Unity 프로젝트 주의사항
- **Unity 버전**: 6000.0.28f1 LTS  
- 씬 파일 충돌 방지를 위해 한 번에 한 사람만 동일 씬을 작업하거나, 작은 씬 단위로 분할합니다.
- `.gitignore`에 `Library/`, `Temp/`, `Build/` 등이 포함되어야 합니다.

## 코드 스타일
- 클래스/메서드 네이밍 규칙, 중괄호 스타일 등 논의 후 구체화합시다.
