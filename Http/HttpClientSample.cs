using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static System.Console;

namespace Http
{
    public class HttpClientSample
    {
        private const string NorthwindUrl = "http://services.odata.org/Northwind/Northwind.svc/Regions";
        private const string IncorrectUrl = "http://services.odata.org/Northwind1/Northwind.svc/Regions";


        private static void ShowUsage()
        {
            WriteLine("Usage: HttpClientSample command");
            WriteLine("commands:");
            WriteLine("\t-s\tSimple");
            WriteLine("\t-a\tAdvanced");
            WriteLine("\t-e\tUsing Exceptions");
            WriteLine("\t-h\tWith Headers");
            WriteLine("\t-mh\tWith message handler");
        }

        public static async Task GetDataSimpleAsync()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = null;
                try
                {
                    response = await client.GetAsync(IncorrectUrl);
                    response.EnsureSuccessStatusCode();
                }
                catch (Exception e)
                {
                    WriteLine(e);
                    throw;
                }
                
                if (response.IsSuccessStatusCode)
                {
                    WriteLine($"Response Status Code: {(int)response.StatusCode} {response.ReasonPhrase}");
                    string responseBodyAsText = await response.Content.ReadAsStringAsync();
                    WriteLine($"Received payload of {responseBodyAsText.Length} characters");
                    WriteLine();
                    WriteLine(responseBodyAsText);
                }
            }
        }
        /// <summary>
        /// httppost请求
        /// </summary>
        /// <param name="method"></param>
        /// <param name="json"></param>
        /// <returns></returns>
        public static async Task HttpRequest11(string method, string json)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Accept", "application/json;odata=verbose");
                    var request = new HttpRequestMessage(HttpMethod.Post,
                        "https://hestia.zaihuiba.com:443/api/v1/auth/login/");
                    //request.Headers.Accept.Add();
                    var entity = new LoginEnity()
                    {
                        UserName = "suncle",
                        Timeout = "100",
                        Password = "123"

                    };
                    request.Content = new StringContent(JsonConvert.SerializeObject(entity));
                    request.Content.Headers.ContentType = 
                        new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    HttpResponseMessage response = await client.SendAsync(request);
                    response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        WriteLine($"Response Status Code: {(int)response.StatusCode} {response.ReasonPhrase}");
                        string responseBodyAsText = await response.Content.ReadAsStringAsync();
                        WriteLine($"Received payload of {responseBodyAsText.Length} characters");
                        WriteLine();
                        WriteLine(responseBodyAsText);
                    }
                }
            }
            catch (Exception e)
            {
                WriteLine(e);
                throw;
            }
            
        }

        public static async Task GetDataAdvancedAsync()
        {
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Get, NorthwindUrl);

                HttpResponseMessage response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    WriteLine($"Response Status Code: {(int)response.StatusCode} {response.ReasonPhrase}");
                    string responseBodyAsText = await response.Content.ReadAsStringAsync();
                    WriteLine($"Received payload of {responseBodyAsText.Length} characters");
                    WriteLine();
                    WriteLine(responseBodyAsText);
                }
            }
        }

        public static async Task GetDataWithExceptionsAsync()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Accept", "application/json;odata=verbose");
                    ShowHeaders("Request Headers:", client.DefaultRequestHeaders);
                    HttpResponseMessage response = await client.GetAsync(NorthwindUrl);
                    response.EnsureSuccessStatusCode();

                    ShowHeaders("Response Headers:", response.Headers);

                    WriteLine($"Response Status Code: {response.StatusCode} {response.ReasonPhrase}");
                    string responseBodyAsText = await response.Content.ReadAsStringAsync();
                    WriteLine($"Received payload of {responseBodyAsText.Length} characters");
                    WriteLine();
                    WriteLine(responseBodyAsText);

                }
            }
            catch (Exception ex)
            {
                WriteLine($"{ex.Message}");
            }
        }

        public static async Task GetDataWithHeadersAsync()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Accept", "application/json;odata=verbose");
                    ShowHeaders("Request Headers:", client.DefaultRequestHeaders);

                    HttpResponseMessage response = await client.GetAsync(NorthwindUrl);
                    response.EnsureSuccessStatusCode();

                    ShowHeaders("Response Headers:", response.Headers);

                    WriteLine($"Response Status Code: {(int)response.StatusCode} {response.ReasonPhrase}");
                    string responseBodyAsText = await response.Content.ReadAsStringAsync();
                    WriteLine($"Received payload of {responseBodyAsText.Length} characters");
                    WriteLine();
                    WriteLine(responseBodyAsText);

                }
            }
            catch (Exception ex)
            {
                WriteLine($"{ex.Message}");
            }
        }

        public static void ShowHeaders(string title, HttpHeaders headers)
        {
            WriteLine(title);
            foreach (var header in headers)
            {
                string value = string.Join(" ", header.Value);
                WriteLine($"Header: {header.Key} Value: {value}");
            }
            WriteLine();
        }

        public static async Task GetDataWithMessageHandlerAsync()
        {
            try
            {
                using (var client = new HttpClient(new SampleMessageHandler("error")))
                {
                    client.DefaultRequestHeaders.Add("Accept", "application/json;odata=verbose");
                    ShowHeaders("Request Headers:", client.DefaultRequestHeaders);

                    HttpResponseMessage response = await client.GetAsync(NorthwindUrl);
                    response.EnsureSuccessStatusCode();

                    ShowHeaders("Response Headers:", response.Headers);

                    WriteLine($"Response Status Code: {(int)response.StatusCode} {response.ReasonPhrase}");
                    string responseBodyAsText = await response.Content.ReadAsStringAsync();
                    WriteLine($"Received payload of {responseBodyAsText.Length} characters");
                    WriteLine();
                    WriteLine(responseBodyAsText);

                }
            }
            catch (Exception ex)
            {
                WriteLine($"{ex.Message}");
            }
        }
    }

    public class SampleMessageHandler : HttpClientHandler
    {
        private string _displayMessage;
        public SampleMessageHandler(string message)
        {
            _displayMessage = message;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            WriteLine($"In SampleMessageHandler {_displayMessage}");
            if (_displayMessage == "error")
            {
                var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                return Task.FromResult<HttpResponseMessage>(response);
            }

            return base.SendAsync(request, cancellationToken);
        }

    }

    [Serializable]
    public class LoginEnity
    {
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("timeout")]
        public string Timeout { get; set; }
        [JsonProperty("username")]
        public string UserName { get; set; }
    }
}
