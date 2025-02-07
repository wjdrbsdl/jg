### 오디오 믹서
 ex) 마스터 볼륨, 배경 볼륨, 효과볼륨 - 개성적인곳은 개성적이게 진행하되, 그룹상 Master 볼륨은 다른 볼륨에 모두 영향

### 주 Mathf 함수
* Deg2Rad = Degree(60분법)을 통해 radian(호도법)을 계산하는 코드 - 각도
* Rad2Deg = 라디안 값을 디그리 값으로. 
* Atan = 아크 탄젠트 값 계산
* Ceil = 소수점 올림 계산
* Clamp(value, min, max) = min, max 사이 로 최소 최대 제한.

### 유니티 GUI 시스템
 1. IMGUI - 디버깅용
 2. UGUI - 일반 ui 컴포넌트
 3. UIElements - 에디터 기반

### 유니티 레코더
 window - general - recoderWindow
 - Exit Play Mode - 녹화끝나면 플레이 종료 
 - Recoring Mode - Manual(사용자 직접 녹화 설정 종료 가능)
 - PlayBack - Constant 녹화중 프레임 유지, varient 맥스값
  - TargetFPS, Cap (최대 프레임 제한)
