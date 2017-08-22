using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Domain
{
    [Table("Transactions")]
    public class Transaction
    {
        [JsonProperty("id")]
        [Column("id")]
        public int Id { get; set; }

        [JsonProperty("amount")]
        [Column("amount")]
        public string Amount { get; set; }

        [JsonProperty("createdOn")]
        [Column("createdon")]
        public string CreatedOn { get; set; }

        [JsonProperty("updatedOn")]
        [Column("updatedon")]
        public string UpdatedOn { get; set; }

        [JsonProperty("order")]
        [Column("order")]
        public string Order { get; set; }

        [JsonProperty("offer")]
        [Column("offer")]
        public string Offer { get; set; }
    }
}
