# Tistory 카테고리 관리 프로그램
## 배경
- Tistory 블로그([향포레스트:기록](https://hyangforest.tistory.com))에 다양한 기록을 포스팅하고 있습니다.
여러 가지 기록을 하다가 게시글을 분류하기 시작하였고, 카테고리가 많이 생겼습니다. 카테고리는 한글, 영어명으로 오름차순 정렬로 생성하고 있는데 생성할 때마다 정렬을 생각하는 게 번거로워 관리용 응용 프로그램을 만들었습니다. 

## 화면 소개
1. Tistroy 카테고리 관리 화면
![image](https://github.com/hyangforest/TistoryCategoryManager/assets/79884961/a457cf72-2b33-45ef-b683-cbff2e6c5c08)

2. 개발 화면
- 습관 카테고리

![image](https://github.com/hyangforest/TistoryCategoryManager/assets/79884961/8bc89332-0d8f-4cad-8655-df1e832637e9)


- 개발 카테고리
![image](https://github.com/hyangforest/TistoryCategoryManager/assets/79884961/5a3679a5-b81f-45b1-a54d-94440621859f)

## 기능 목표
- EF Core 에서 Stored Procedure 연동 연습하기
- WPF UI ListView 데이터 바인딩 및 선택 이벤트 연습하기
- 정렬순서 저장/수정/삭제 정렬 로직

## 개발 환경
1. [SDK 7.0.110](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)

2. EF Core Version
<pre>
  <code>
    dotnet tool update dotnet-ef -g --version 7.0.10
  </code>
</pre>

## 추가 정보
- 제작정보 : [WPF:나의 Tistory 카테고리 정렬 관리 프로그램](https://hyangforest.tistory.com/252)
- SP 내용 : /StoredProcedures/script.txt

