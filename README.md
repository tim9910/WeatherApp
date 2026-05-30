# 台灣天氣查詢系統

## :pushpin: 概述
　　本專案為「**台灣天氣查詢系統**」，主要透過中央氣象署Open Data API取得即時與預報天氣資訊，並以Windows視窗程式介面呈現。使用者可選擇欲查詢的縣市，系統自動以API取得相關天氣資料，透過解析回傳資料，以文字、表格、圖片與清單等不同控制項顯示。同時，系統也加入搜尋紀錄、我的最愛、熱門查詢縣市與快取機制，相關資料皆以檔案方式進行儲存與讀取。當網路連線異常或API無法正常取得資料時，系統會讀取最近一次快取的天氣資訊，避免畫面完全無法顯示資料。另外，系統提供「API 紀錄」功能，以資料庫方式儲存每次天氣 API 的呼叫資訊，並支援依不同條件新增與查詢，方便後續追蹤使用情況與分析錯誤原因。

## :pushpin: 開發環境

- **語言**：C#
- **IDE**：Visual Studio 2026
- **平台**：Windows

## :pushpin: UI版面配置及系統功能說明

  ![UI版面配置](https://github.com/tim9910/tim9910.github.io/blob/main/images/weather/ui.png)

### (https://github.com/tim9910/tim9910.github.io/blob/main/images/weather/number-1.png) **功能選單區**
- 系統提供「我的最愛」管理、「搜尋紀錄」檢視與「API紀錄」檢視功能。其中，「API紀錄」採用資料庫方式儲存，每次系統呼叫天氣API時，會記錄查詢縣市、API類型、呼叫時間與是否成功取得資料等資訊，後續可追蹤API使用情況與錯誤原因；而「我的最愛」與「搜尋紀錄」則以檔案方式儲存，方便管理常用縣市及查看歷史查詢紀錄。

### (https://github.com/tim9910/tim9910.github.io/blob/main/images/weather/number-2.png) **選擇縣市區**
- 透過「選擇縣市」下拉選單即時取得中央氣象署Open Data API的資料。

### (https://github.com/tim9910/tim9910.github.io/blob/main/images/weather/number-3.png) **今日天氣提醒**
- 透過「天氣小幫手API」取得縣市天氣提醒，並以跑馬燈方式顯示今日天氣重點。

### (https://github.com/tim9910/tim9910.github.io/blob/main/images/weather/number-4.png) **天氣提醒文字區**
- 透過「天氣小幫手API」取得天氣提醒內容，並以文字搭配圖示呈現。

### (https://github.com/tim9910/tim9910.github.io/blob/main/images/weather/number-5.png) **日出日沒區**
- 透過「日出日沒API」取得日出與日沒時間，並以圖示搭配文字呈現。

### (https://github.com/tim9910/tim9910.github.io/blob/main/images/weather/number-6.png) **圖片顯示區**
- 透過「溫度分布狀態 API」取得溫度分布圖，並以圖片方式呈現。

### (https://github.com/tim9910/tim9910.github.io/blob/main/images/weather/number-7.png) **預報資料顯示區**
- 透過「36小時及1週預報API」取得資料，並使用頁籤與DataGridView呈現不同時段的天氣預報內容。

(https://github.com/tim9910/tim9910.github.io/blob/main/images/weather/number-8.png) **快速查詢區**
- 設有「搜尋紀錄」、「我的最愛」與「熱門查詢」三個區塊。搜尋紀錄會依搜尋時間顯示最近曾查詢過的縣市；我的最愛可自訂加入常用縣市；熱門查詢則顯示最常被查詢的縣市，方便快速點選查詢。

### (https://github.com/tim9910/tim9910.github.io/blob/main/images/weather/number-9.png) **快取機制**
- 當網路不通或API無法取得資料時，仍可顯示最近成功查詢的資料，避免畫面無法顯示。


## :pushpin: 貼心輔助

  ![貼心輔助](https://github.com/tim9910/tim9910.github.io/blob/main/images/weather/info2.gif)

## :pushpin: 系統操作流程

### (1)啟動台灣天氣查詢系統
### (2)從「選擇縣市」下拉式選單選擇欲查詢的縣市，系統透過中央氣象署Open Data API 取得資料。
### (3)畫面更新今日提醒、天氣小幫手、日出日沒、預報表格與溫度分布圖。
### (4)使用者可切換「36小時預報」或「1 週預報」查看不同資料。
### (5)若想快速查詢常用縣市，可點選搜尋紀錄、我的最愛或熱門查詢中的縣市。
### (6)若網路異常，系統會載入最近一次快取資料。
  
  ![系統操作](https://github.com/tim9910/tim9910.github.io/blob/main/images/weather/app.png)
  
### (7)透過功能選單的「設定」功能，或使用快捷鍵開啟，可管理常用縣市清單。設定後可在主畫面下方直接點選縣市快速查詢。
### (8)透過功能選單的「檢視」功能，或使用快捷鍵開啟，可查看過去查詢過的縣市紀錄。
  
  ![功能選單](https://github.com/tim9910/tim9910.github.io/blob/main/images/weather/app1.png)

## :pushpin: 系統操作畫面

  ![系統操作畫面](https://github.com/tim9910/tim9910.github.io/blob/main/images/weather/runapp.gif)


  