# Optimized Scroll View

## 프로젝트 개요
이 프로젝트는 유니티의 스크롤뷰가 가지고 있는 고질적 문제를 해결하기 위해 다양한 스크롤뷰를 구현했습니다. 여러 스크롤뷰를 구현 및 시연이 가능하고 각각 성능이 어떤지 확인할 수 있는 씬이 존재합니다.

![image](https://github.com/user-attachments/assets/9b4efe71-9a36-42d2-b00f-a7193aa2687f)


### 주요 기능
- **캐릭터 상태 관리**: 캐릭터의 체력, 마나, 공격력, 방어력 등의 스탯을 관리하고 이를 기반으로 전투에서 결과를 반영합니다.
- **턴제 전투 시스템**: 플레이어와 적의 턴을 번갈아 가며 진행되는 전투 시스템을 구현했습니다.
- **스킬 시스템**: 각 캐릭터는 고유한 스킬을 가지고 있으며, 전투 중에 스킬을 사용해 적에게 다양한 효과를 부여할 수 있습니다.
- **아이템 사용**: 전투 중에 아이템을 사용하여 캐릭터의 상태를 회복하거나 강화할 수 있습니다.

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
