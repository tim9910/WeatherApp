using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    internal class Favorites
    {
        private string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "favorites.txt");
        private List<string> favoriteCities;

        public Favorites()
        {
            favoriteCities = LoadFavorites();
        }

        // 新增城市到收藏清單
        public void Add(string city)
        {
            if (!favoriteCities.Contains(city))
            {
                favoriteCities.Add(city);
                SaveFavorites();
            }
        }

        // 刪除收藏清單裡的城市
        public void Remove(string city)
        {
            if (favoriteCities.Contains(city))
            {
                favoriteCities.Remove(city);
                SaveFavorites();
            }
        }

        // 取得所有收藏的城市
        public List<string> GetAll()
        {
            return new List<string>(favoriteCities);
        }

        // 取得收藏清單的前top筆資料
        public List<string> GetTop(int top = 3)
        {
            return favoriteCities.Take(top).ToList();
        }

        // 從檔案讀取收藏清單
        private List<string> LoadFavorites()
        {
            var list = new List<string>();
            if (!File.Exists(filePath))
                return list;
            var lines = File.ReadAllLines(filePath);

            // 跳過表頭
            for (int i = 1; i < lines.Length; i++)
            {
                var line = lines[i];
                // 忽略空白行
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var parts = line.Split(',');

                if (parts.Length >= 1)
                    list.Add(parts[0]);
            }

            return list;
        }

        // 將收藏清單寫入檔案
        private void SaveFavorites()
        {
            // 寫入檔案
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // 寫入表頭
                writer.WriteLine("City,ModifyTime");
                for (int i = 0; i < favoriteCities.Count; i++)
                {
                    string city = favoriteCities[i];
                    string modifyTime = DateTime.Now.ToString(); // yyyy-MM-dd HH:mm:ss
                    writer.WriteLine(city + "," + modifyTime);
                }
            }
        }
    }
}
