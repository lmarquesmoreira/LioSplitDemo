using Api.Domain;
using Cielo.Sdk.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Api.Contracts
{
    public class TransactionModel
    {
        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("order")]
        public Order Order { get; set; }

        [JsonProperty("offer")]
        public JObject Offer { get; set; }

        [JsonProperty("sellers")]
        public List<Seller> Sellers { get; set; }
    }
}
