using Newtonsoft.Json;

namespace QRCode.BO.Data
{
    public class Symbol
    {
        [JsonProperty("seq")]
        public int Seq { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }
    }
}
