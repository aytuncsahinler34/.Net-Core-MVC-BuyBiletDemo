using BuyBiletDemo.Core.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BuyBiletDemo.Core.Helpers
{
    public class HttpHelper
    {
        private const string _apiContentType = "application/json";
        public static async Task<T> HttpRequestAsync<T>(string baseUrl, string url, HttpMethodEnum method, object content,
                                               Dictionary<string, IEnumerable<string>> headers, AuthenticationHeaderValue authorization = null) {

            using (var http = new HttpClient()) {
                http.BaseAddress = new Uri(baseUrl);
                http.DefaultRequestHeaders.Accept.Clear();
                http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_apiContentType));
                if (authorization != null)
                    http.DefaultRequestHeaders.Authorization = authorization;
                var requestMessage = new HttpRequestMessage();
                var serializedContent = JsonConvert.SerializeObject(content);
                var stringContent = new StringContent(serializedContent, Encoding.UTF8, _apiContentType);
                requestMessage.Content = stringContent;

                requestMessage.Headers.Clear();
                if (headers == null)
                    headers = new Dictionary<string, IEnumerable<string>>();
                foreach (var header in headers) {
                    requestMessage.Headers.Add(header.Key, header.Value);
                }
                requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue(_apiContentType);
                requestMessage.Content.Headers.ContentLength = serializedContent.Length;
                requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(_apiContentType));

                if (string.IsNullOrEmpty(CultureInfo.CurrentCulture.Name))
                    requestMessage.Headers.AcceptLanguage.Add(StringWithQualityHeaderValue.Parse("tr-TR"));
                else
                    requestMessage.Headers.AcceptLanguage.Add(StringWithQualityHeaderValue.Parse(CultureInfo.CurrentCulture.Name));

                requestMessage.RequestUri = new Uri($"{http.BaseAddress}{url}");
                requestMessage.Method = new HttpMethod(EnumHelper.GetAttributeOfType<DescriptionAttribute>(method).Description);

                if (method == HttpMethodEnum.GET)
                    requestMessage.Content = null;

                var response = await http.SendAsync(requestMessage);
                var data = await response.Content.ReadAsStringAsync();

                var jsonData = JsonConvert.DeserializeObject<T>(data);
                return jsonData;
            }

        }

    }
}
