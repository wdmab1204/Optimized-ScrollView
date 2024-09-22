# Optimized Scroll View

## 프로젝트 개요
이 프로젝트는 유니티의 스크롤뷰가 가지고 있는 고질적 문제를 해결하기 위해 다양한 스크롤뷰를 구현했습니다. 여러 스크롤뷰를 구현 및 시연이 가능하고 각각 성능이 어떤지 확인할 수 있는 씬이 존재합니다.

![image](https://github.com/user-attachments/assets/9b4efe71-9a36-42d2-b00f-a7193aa2687f)


### 주요 기능
- **스크롤뷰 선택 버튼**: FPS를 표기하는 텍스트 양 옆의 버튼을 클릭하면 Default Scroll View, Auto Disable Scroll View, Recycle Scroll View순서로 볼 수 있습니다.
- **FPS 텍스트**: 스크롤뷰에 따라 성능을 가시적으로 확인할 수 있도록 프레임의 상태를 텍스트로 표기했습니다.
- **Claim 버튼**: Default Scroll View를 제외한 모든 스크롤뷰에는 Claim버튼을 클릭하면 해당 Cell의 정보를 로그를 통해 확인할 수 있습니다.

## 핵심 클래스 구조 및 역할
1. ### [IScrollView](./Assets/Scripts/UI/IScrollView.cs)
    스크롤뷰를 정의하는 인터페이스입니다.

2. ### [ScrollCellBase](./Assets/Scripts/UI/ScrollCellBase.cs)
    스크롤뷰의 Cell을 구현할때 사용하는 추상 클래스입니다. Cell의 위치를 설정할 수 있고 인덱스와 이벤트를 가지고 있습니다.

3. ### [RecycleScrollViewBase](./Assets/Scripts/UI/RecycleScrollViewBase.cs)
    Cell을 재사용하는 방법으로 최적화된 스크롤뷰 입니다. 화면에 보이는 만큼의 Cell만 생성하며 스크롤할 때 위치를 재계산하는 방식입니다.

4. ### [AutoDisableScrollViewBase](./Assets/Scripts/UI/AutoDisableScrollViewBase.cs)
    화면에 보이지 않는 Cell들을 Disable하여 렌더링 연산을 줄이는 방법으로 최적화된 스크롤뷰 입니다. 스크롤되는 매 프레임마다 위치를 계산하여 Cell들의 끄거나 켬을 결정하는 방식입니다.

## 사용된 에셋
GUI-PRO : UI를 표현할 이미지를 사용하기위해 구입했습니다.
