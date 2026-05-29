using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    internal class APIlog
    {
        private SqlConnection sqlDb;

        public APIlog(SqlConnection db)
        {
            sqlDb = db;
        }

        public void InsertLog(string apiType, string apiUrl, string cityname, int statuscode, string success, string result)
        {
            string apiName = apiType;
            if ("help".Equals(apiType, StringComparison.OrdinalIgnoreCase))
            {
                apiName = "天氣小幫手";
            }
            else if ("36hr".Equals(apiType, StringComparison.OrdinalIgnoreCase))
            {
                apiName = "今明 36 小時天氣預報";
            }
            else if ("week".Equals(apiType, StringComparison.OrdinalIgnoreCase))
            {
                apiName = "未來1週天氣預報";
            }
            else if ("sun".Equals(apiType, StringComparison.OrdinalIgnoreCase))
            {
                apiName = "日出日沒時刻";
            }
            else if ("temperature".Equals(apiType, StringComparison.OrdinalIgnoreCase))
            {
                apiName = "溫度分布圖";
            }

            if (!string.IsNullOrEmpty(apiUrl))
            {
                int index = apiUrl.IndexOf("Authorization=");
                if (index >= 0)
                {
                    int endIndex = apiUrl.IndexOf('&', index);
                    if (endIndex < 0) endIndex = apiUrl.Length;
                    apiUrl = apiUrl.Substring(0, index) + "Authorization={apiKey}" + apiUrl.Substring(endIndex);
                }
            }

            string sql = @"
            INSERT INTO [dbo].[APILOG] (apiname, apiurl, cityname, statuscode, success, result)
            VALUES (@apiName, @apiUrl, @cityName, @statusCode, @success, @result) ";

            using (SqlCommand cmd = new SqlCommand(sql, sqlDb))
            {
                cmd.Parameters.AddWithValue("@apiName", apiName);
                cmd.Parameters.AddWithValue("@apiUrl", apiUrl); 
                cmd.Parameters.AddWithValue("@cityName", cityname);
                cmd.Parameters.Add("@statusCode", System.Data.SqlDbType.Int).Value= statuscode;

                cmd.Parameters.Add("@success", System.Data.SqlDbType.Char, 1).Value = success;

                cmd.Parameters.AddWithValue("@result", result);

                int rowsAffected = cmd.ExecuteNonQuery();

            }
        }

        public DataTable QueryByDate(DateTime startDate, DateTime endDate)
        {
            string sql = @"SELECT logid, apiname, apiurl, cityname, requesttime, statuscode, success, result 
                           FROM APILOG 
                           WHERE requesttime BETWEEN @startDate AND @endDate 
                           ORDER BY requesttime DESC";
            
            using (SqlCommand cmd = new SqlCommand(sql, sqlDb))
            {
                cmd.Parameters.AddWithValue("@startDate", startDate.Date);
                cmd.Parameters.AddWithValue("@endDate", endDate.Date.AddDays(1));
                
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public DataTable QueryByCity(string cityName)
        {
            string sql = @"SELECT logid, apiname, apiurl, cityname, requesttime, statuscode, success, result 
                           FROM APILOG 
                           WHERE cityname = @cityName 
                           ORDER BY requesttime DESC";
            
            using (SqlCommand cmd = new SqlCommand(sql, sqlDb))
            {
                cmd.Parameters.AddWithValue("@cityName", cityName);
                
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public DataTable QueryByApiName(string apiName)
        {
            string sql = @"SELECT logid, apiname, apiurl, cityname, requesttime, statuscode, success, result 
                           FROM APILOG 
                           WHERE apiname = @apiName 
                           ORDER BY requesttime DESC";
            
            using (SqlCommand cmd = new SqlCommand(sql, sqlDb))
            {
                cmd.Parameters.AddWithValue("@apiName", apiName);
                
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public DataTable QueryByStatus(string status)
        {
            string sql = @"SELECT logid, apiname, apiurl, cityname, requesttime, statuscode, success, result 
                           FROM APILOG 
                           WHERE success = @status 
                           ORDER BY requesttime DESC";
            
            using (SqlCommand cmd = new SqlCommand(sql, sqlDb))
            {
                cmd.Parameters.AddWithValue("@status", status);
                
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }
    }


}
