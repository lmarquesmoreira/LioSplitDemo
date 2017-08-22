using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Cielo.Sdk.Domain
{
    public class Order
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("price")]
        public long Price { get; set; }

        [JsonProperty("paidAmount")]
        public long PaidAmount { get; set; }

        [JsonProperty("pendingAmount")]
        public long PendingAmount { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("items")]
        public List<OrderItem> Items { get; set; }

        [JsonProperty("payments")]
        public List<Payment> Payments { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("releaseDate")]
        public DateTime ReleaseDate { get; set; }
    }
}
