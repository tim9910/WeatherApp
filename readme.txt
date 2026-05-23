【氣象資料開放平臺】
https://opendata.cwa.gov.tw/index
CWA-1562A959-5BFE-4853-A145-0111EE8FD270
yuchuan.yao@msa.hinet.net
Tim950703@@@

==========  一般天氣預報-今明 36 小時天氣預報  ============================================
/v1/rest/datastore/F-C0032-001

curl -X 'GET' \
  'https://opendata.cwa.gov.tw/api/v1/rest/datastore/F-C0032-001?Authorization=CWA-1562A959-5BFE-4853-A145-0111EE8FD270&locationName=%E8%87%BA%E5%8C%97%E5%B8%82&sort=time' \
  -H 'accept: application/json'

Request URL
https://opendata.cwa.gov.tw/api/v1/rest/datastore/F-C0032-001?Authorization=CWA-1562A959-5BFE-4853-A145-0111EE8FD270&locationName=%E8%87%BA%E5%8C%97%E5%B8%82&sort=time


Response body: response_1777897954248.json
	
Wx天氣現象
PoP降雨機率12小時分段
MinT最低溫度
CI舒適度
MaxT最高溫度

======鄉鎮天氣預報-臺灣未來1週天氣預報===============================================================
GET
/v1/rest/datastore/F-D0047-091

Request URL
https://opendata.cwa.gov.tw/api/v1/rest/datastore/F-D0047-091?Authorization=CWA-1562A959-5BFE-4853-A145-0111EE8FD270&LocationName=%E8%8A%B1%E8%93%AE%E7%B8%A3&ElementName=%E6%9C%80%E9%AB%98%E6%BA%AB%E5%BA%A6,%E5%A4%A9%E6%B0%A3%E7%8F%BE%E8%B1%A1,%E6%9C%80%E4%BD%8E%E6%BA%AB%E5%BA%A6&sort=time
Response body: response_1777906408173.json

T溫度,Td露點溫度,RH相對濕度,Wind風向風速,AT體感溫度,CI舒適度,Wx天氣現象,PoP降雨機率12小時分段,MaxT最高溫度,MinT最低溫度,MaxCI最高舒適度,MinCI最低舒適度,MaxAT最高體感溫度,MinAT最低體感溫度,UVI紫外線指數,WeatherDescription天氣描述


======鄉鎮天氣預報-臺灣未來3天天氣預報===============================================================
GET
/v1/rest/datastore/F-D0047-089

==============================================================================================================================

======日出日沒時刻-全臺各縣市年度逐日日出日沒時刻資料===============================================================

GET /v1/rest/datastore/A-B0062-001

Request URL
https://opendata.cwa.gov.tw/api/v1/rest/datastore/A-B0062-001?Authorization=CWA-1562A959-5BFE-4853-A145-0111EE8FD270&CountyName=%E8%87%BA%E5%8C%97%E5%B8%82&Date=2026-05-04&parameter=SunRiseTime,SunSetTime&sort=Date

Response body: response_1777900923146.json

BeginCivilTwilightTime, SunRiseTime, SunRiseAZ, SunTransitTime, SunTransitAlt, SunSetTime, SunSetAZ, EndCivilTwilightTime

==============================================================================================================================