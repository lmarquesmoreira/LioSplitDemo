using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Domain
{
    [Table("Sellers")]
    public class Seller
    {
        [JsonProperty("id")]
        [Column("id")]
        public int Id { get; set; }

        [JsonProperty("mdr")]
        [Column("mdr")]
        public int Mdr { get; set; }

        [JsonProperty("createdOn")]
        [Column("createdon")]
        public string CreatedOn { get; set; }

        [JsonProperty("updatedOn")]
        [Column("updatedon")]
        public string UpdatedOn { get; set; }
    }
}
