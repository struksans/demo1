using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using QRCode.BO.Data;
using QRCode.Common.Configs;
using QRCode.Common.Enums;

namespace QRCode.Service
{
    public class QRServerClient : IQRServerClient
    {
        private readonly HttpClient _httpClient;

        public QRServerClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<(OperationStatus Status, string Result)> ScanAsync(byte[] data)
        {
            var content = new MultipartFormDataContent();

            content.Add(new StreamContent(new MemoryStream(data)), "file", "dummy");
            content.Add(new StringContent("json"), "outputformat");

            try
            {
                var httpResponseMessage = await _httpClient.PostAsync(Config.BaseUrl, content);
                var responseText = await httpResponseMessage.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<ICollection<QRResponse>>(responseText);

                var symbol = response?
                    .FirstOrDefault()?
                    .Symbols?
                    .FirstOrDefault();

                if (symbol == null || !string.IsNullOrWhiteSpace(symbol.Error))
                {
                    //TODO: log error
                    return (OperationStatus.UnableToProcessImage, null);
                }

                return (OperationStatus.Success, symbol.Data);
            }
            catch (Exception e)
            {
                //TODO: log error
                return (OperationStatus.ExternalApiError, null);
            }
        }
    }
}
