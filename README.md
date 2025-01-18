# NalPaMon
 
# 날아다니는 파스타 몬스터 (날파몬)

크툴루 신화를 바탕으로 한 추리+스릴러 횡스크롤 게임.  
Night in the Woods처럼 2D 횡스크롤 이동, 역전재판/단간론파 식 대화 시스템.

## 특징
- 2D 캐릭터 이동 + 상호작용
- 각종 미니게임
- Yarn Spinner(또는 기타 대화 툴) 기반 분기 대화

## 프로젝트 구조

NalPaMonProject
├── .git/ // Git 버전 관리 폴더
├── .gitattributes // Git LFS 추적 설정
├── .gitignore // Git에서 제외할 파일 목록
├── Packages/ // Unity 패키지 관리 폴더
├── ProjectSettings/ // Unity 프로젝트 설정
├── Assets/ // Unity 에셋 폴더
│ ├── _Project // 실제 게임 관련 폴더 (메인)
│ │ ├── Scenes // 유니티 씬 파일들
│ │ ├── Scripts // 스크립트
│ │ │ ├── Managers // 싱글턴 GameManager, SceneManager 등
│ │ │ ├── Player // 플레이어 관련 (PlayerController 등)
│ │ │ ├── NPC // NPC 제어, AI, 대화 트리거 등
│ │ │ ├── Interactions // 문, 상호작용 오브젝트 스크립트
│ │ │ └── Dialogue // 대화/Yarn 연동 스크립트
│ │ ├── Prefabs // 프리팹 (플레이어, NPC, 아이템, UI 등)
│ │ ├── Art // 2D 스프라이트, UI 이미지, 폰트 등
│ │ ├── Audio // 사운드 (BGM, SFX)
│ │ ├── Dialogue // Yarn Spinner .yarn 파일, 대화 리소스
│ │ └── Data // ScriptableObject, JSON, CSV 등 데이터
│ ├── Plugins // 외부 플러그인/라이브러리
│ │ └── YarnSpinner // Yarn Spinner 관련 파일 (설치 방식 따라 다를 수 있음)
│ ├── Resources // 리소스 로드(Resources.Load) 방식 사용 시 배치
│ └── Animations // 애니메이션 관련 파일
├── Logs/ // 유니티 로그
├── UserSettings/ // 에디터 사용자별 환경
└── ... // 기타 프로젝트 파일
