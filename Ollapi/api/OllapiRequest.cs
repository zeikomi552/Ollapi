using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Ollapi.api
{
    public class OllapiRequest
    {
        #region 接続用クライアントの作成
        /// <summary>
        /// 接続用クライアントの作成
        /// </summary>
        /// <param name="url">パラメータ</param>
        /// <returns>Task</returns>
        protected async Task<string> Request(string url)
        {
            using (var client = new HttpClient())
            {
                // 上から来たクエリをそのまま実行
                var response = await client.GetAsync(url);

                // レスポンスを返却
                return await response.Content.ReadAsStringAsync();
            }
        }
        #endregion

        private HttpClient? _HttpClient;

        public void Open()
        {
            _HttpClient = new HttpClient();
        }

        protected async Task<string> Post(string url, string jsondata)
        {
            //using (var client = new HttpClient())
            {
                if (_HttpClient == null) return string.Empty;

                // 送信するデータをHttpContentとして作成
                HttpContent content = new StringContent(jsondata, System.Text.Encoding.UTF8, "application/json");
                // 非同期でPOSTリクエストを送信
                HttpResponseMessage response = await _HttpClient.PostAsync(url, content);

                // レスポンスを返却
                return await response.Content.ReadAsStringAsync();
            }
        }

        public void Close()
        {
            if (_HttpClient != null)
                _HttpClient.Dispose();
        }

    }
}
