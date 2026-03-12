#  버튼잡기게임(C# 코딩) 2주차 과제 
22017004 강희준

## 개요
-기본 틀 : C# 프로그래밍 학습

-핵심기능: 
         
         1. 마우스가 버튼 위에 위치할 시 버튼 position 변경 *창의 경계선 벗어나는 버튼 위치 max min 줘서 수정
         
         2. 버튼을 잡았을 때와 놓쳤을 때(도망갈 때) 효과음과 잡았을 때의 메세지 박스 피드백 
         
         3. 잡았을 때 +100 놓쳤을 때마다 -10 점수 시스템 추가 , 잡을 때 마다 ButtonSize를 10%로 줄이는 로직
         
         4. 20번 놓쳤을 시 게임오버(모든 버튼 비활성화) 메세지와 함께 리셋 버튼 추가

화면 구성: <img width="776" height="473" alt="기본 화면" src="https://github.com/user-attachments/assets/c055fa82-27bc-4b69-af13-ff199935e75c" />

폼 창 가운데 버튼과 폼 텍스트를 활용한 점수및 좌표 프린트-


## 실행화면
 # 1단계: 기본 도망 기능

• 목표

         1. 버튼 컨트롤 영역 안으로 마우스가 들어가면 버튼을 랜덤 위치로 이동시킴
         2. 좌표를 폼 제목에 추가

<img width="458" height="416" alt="11" src="https://github.com/user-attachments/assets/acb823b1-aa2e-4821-a2fc-2a4a1b7b8126" />

<img width="478" height="480" alt="12" src="https://github.com/user-attachments/assets/a43a54be-2f7a-405c-beb7-45a1a5bda863" />

 
 
 # 2단계: 시각적/청각적피드백

• 목표

         1. 버튼을 잡았을 때와 놓쳤을 때 시청각 피드백을 주기

<img width="781" height="476" alt="성공시 팝업" src="https://github.com/user-attachments/assets/cd615de9-226e-42ee-878f-3752c74cf976" />

 -- 효과음은 따로 코드로 표현 -- 

<img width="219" height="48" alt="잡았 " src="https://github.com/user-attachments/assets/912bf376-15e7-4737-b9ba-c516cfb72605" />

<img width="459" height="100" alt="ee" src="https://github.com/user-attachments/assets/09684118-02b3-4a67-b923-2f044a3f7be4" />

 # 3단계– 점수 표시와 점수별 난이도 조정

• 목표
          
         1. 점수를 계산하여 표시하기 (점수 시스템 추가)
         2.게임이 점점 어려워지도록 만들기 (크기 10%축소)

<img width="285" height="27" alt="점수" src="https://github.com/user-attachments/assets/2d4c4f68-60ec-437f-a74a-c66c37b5babc" />

<img width="605" height="351" alt="줄어듬" src="https://github.com/user-attachments/assets/a473c642-318a-4592-ab04-debe00133e7a" />
 
 -- 줄어들어 크기가 작아진 모습 --

 # 4단계– 게임오버 및 리셋

• 목표

          1. 게임오버 표시하기 ( 놓친 횟수를 폼 텍스트에 표시하여 20번 놓칠시 게임오버 창 팝업)
          2. 재도전 버튼 만들기 (게임 오버 창에 생성하여 사용자가 선택하게 설정)

<img width="196" height="146" alt="게임오버 다시하기" src="https://github.com/user-attachments/assets/b5de5c4d-1c51-489f-8459-a1991eda8e1e" />

