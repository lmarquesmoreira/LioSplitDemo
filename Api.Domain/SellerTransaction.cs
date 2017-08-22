using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Domain
{
    [Table("SellersTransactions")]
    public class SellerTransaction
    {
        [JsonProperty("id")]
        [Column("id")]
        public int Id { get; set; }

        [JsonProperty("amount")]
        [Column("amount")]
        public string Amount { get; set; }

        [JsonProperty("order")]
        [Column("order")]
        public string Order { get; set; }

        [JsonProperty("createdOn")]
        [Column("createdon")]
        public string CreatedOn { get; set; }

        [JsonProperty("seller_id")]
        [Column("seller_id")]
        public int SellerId { get; set; }
    }
}
