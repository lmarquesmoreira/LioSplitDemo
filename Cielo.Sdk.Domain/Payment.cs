using Newtonsoft.Json;
using System.Collections.Generic;

namespace Cielo.Sdk.Domain
{
    public class Payment
    {

        [JsonProperty("id")]
        private string Id { get; set; }

        [JsonProperty("externalId")]
        private string ExternalId { get; set; }

        [JsonProperty("description")]
        private string Description { get; set; }

        [JsonProperty("cieloCode")]
        private string CieloCode { get; set; }

        [JsonProperty("authCode")]
        private string AuthCode { get; set; }

        [JsonProperty("brand")]
        private string Brand { get; set; }

        [JsonProperty("mask")]
        private string Mask { get; set; }

        [JsonProperty("terminal")]
        private string Terminal { get; set; }

        [JsonProperty("amount")]
        private long Amount { get; set; }

        [JsonProperty("primaryCode")]
        private string PrimaryCode { get; set; }

        [JsonProperty("secondaryCode")]
        private string SecondaryCode { get; set; }

        [JsonProperty("applicationName")]
        private string ApplicationName { get; set; }

        [JsonProperty("requestDate")]
        private string RequestDate { get; set; }

        [JsonProperty("merchantCode")]
        private string MerchantCode { get; set; }

        [JsonProperty("discontedAmount")]
        private long DiscountedAmount { get; set; }

        [JsonProperty("installments")]
        private long Installments { get; set; }

        [JsonProperty("paymentFields")]
        private Dictionary<string, string> PaymentFields { get; set; }
    }
}