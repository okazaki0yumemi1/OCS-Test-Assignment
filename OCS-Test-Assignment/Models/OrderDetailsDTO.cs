using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace OCS_Test_Assignment.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class OrderDetailsDTO : OrderDetails
    {
        public OrderDetailsDTO()
        {
        }
        [Required]
        [JsonProperty("id")]
        new public string Id { get; set; }
        [Required]
        [JsonProperty("qty")]
        public int Qty { get; set; }
    }
}
