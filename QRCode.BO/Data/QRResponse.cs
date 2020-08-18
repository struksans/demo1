using System.Collections.Generic;
using Newtonsoft.Json;

namespace QRCode.BO.Data
{
    public class QRResponse
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("symbol")]
        public ICollection<Symbol> Symbols { get; set; }
    }
}
