using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Adeprimo.Tulo.Engage.Tracker.Sdk.Xamarin.Models;

namespace Adeprimo.Tulo.Engage.Tracker.Sdk.Xamarin
{
    public class Dispatcher
    {
        readonly string _eventUrl;
        static HttpClient _httpClient;

        public Dispatcher(string eventUrl)
        {
            _eventUrl = eventUrl;
            _httpClient = new HttpClient();
        }

        public async Task SendAsync(EngageEvent sendEvent)
        {
            var data = sendEvent.Build();
            try
            {
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(_eventUrl, content);
                Util.LogInfo($"Event tracked: {response.IsSuccessStatusCode}");
            }
            catch(HttpRequestException hre)
            {
                Util.LogError($"Could not send event to {_eventUrl}, failed with message: {hre.Message}");
                Util.LogError($"Data: {data}");
            }
            catch(Exception e)
            {
                Util.LogError($"Could not send event to {_eventUrl}, failed with message: {e.Message}");
                Util.LogError($"Data: {data}");
            }

        }

        public void Send(EngageEvent sendEvent)
        {
            var data = sendEvent.Build();
            try
            {
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var response = _httpClient.PostAsync(_eventUrl, content).Result;
                Util.LogInfo($"Event tracked: {response.IsSuccessStatusCode}");
            }
            catch(HttpRequestException hre)
            {
                Util.LogError($"Could not send event to {_eventUrl}, failed with message: {hre.Message}");
                Util.LogError($"Data: {data}");
            }
            catch(Exception e)
            {
                Util.LogError($"Could not send event to {_eventUrl}, failed with message: {e.Message}");
                Util.LogError($"Data: {data}");
            }
        }
    }
}
