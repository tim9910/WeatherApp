using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    public class CityClick
    {
        public string City { get; set; }
        public int ClickCount { get; set; }
        public DateTime ModifyTime { get; set; }
    }

    internal class ClickHistory
    {
        private string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "search_history.txt");
        private List<CityClick> history;
        public ClickHistory()
        {
            history = LoadClicks();
        }

        // 新增點擊紀錄
        public void Add(string city)
        {

            CityClick existing = null;
            foreach (CityClick c in history)
            {
                if (c.City == city)
                {
                    existing = c;
                    break; // 找到後直接跳出
                }
            }

            if (existing != null)
            {
                // 城市已存在，累加點擊數並更新 ModifyTime
                existing.ClickCount += 1;
                existing.ModifyTime = DateTime.Now;
            }
            else
            {
                // 城市不存在，新增一筆資料
                history.Add(new CityClick
                {
                    City = city,
                    ClickCount = 1,
                    ModifyTime = DateTime.Now
                });
            }

            SaveClicks();// 儲存更新後的點擊資料
        }
        public List<CityClick> GetAll()
        {
            return new List<CityClick>(history);
        }
        // 找出點擊最多的前幾筆資料
        public List<CityClick> TopHot(int top = 3)
        {
            var result = new List<CityClick>();

            var tempList = new List<CityClick>(history);

            // 找出前 top 名點擊數最多的城市
            for (int i = 0; i < top && tempList.Count > 0; i++)
            {
                CityClick maxClick = tempList[0];
                foreach (var c in tempList)
                {
                    if (c.ClickCount > maxClick.ClickCount)
                        maxClick = c;
                }

                result.Add(maxClick);
                tempList.Remove(maxClick); // 移除已加入的，下一輪找次高
            }

            return result; 
        }

        // 找出最近點擊過的城市(前top筆，依 ModifyTime 排序)
        public List<CityClick> Recent(int top = 3)
        {
            var result = new List<CityClick>();

            var tempList = new List<CityClick>(history);

            for (int i = 0; i < top && tempList.Count > 0; i++)
            {
                CityClick latest = tempList[0];
                foreach (var c in tempList)
                {
                    if (c.ModifyTime > latest.ModifyTime)
                        latest = c;
                }

                result.Add(latest);
                tempList.Remove(latest);
            }

            return result;
        }

        // 從檔案讀取點擊資料
        private List<CityClick> LoadClicks()
        {
            var list = new List<CityClick>();

            if (!File.Exists(filePath))
                return list;

            var lines = File.ReadAllLines(filePath);

            // 跳過表頭
            for (int i = 1; i < lines.Length; i++)
            {
                var line = lines[i];
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var parts = line.Split(',');

                if (parts.Length >= 3)
                {
                    list.Add(new CityClick
                    {
                        City = parts[0],
                        ClickCount = int.Parse(parts[1]),
                        ModifyTime = DateTime.Parse(parts[2])
                    });
                }
            }

            return list;
        }

        // 將點擊資料寫入檔案
        private void SaveClicks()
        {
            using (var writer = new StreamWriter(filePath))
            {
                writer.WriteLine("City,ClickCount,ModifyTime");
                foreach (var c in history)
                    writer.WriteLine($"{c.City},{c.ClickCount},{c.ModifyTime}");
            }
        }
    }
}
