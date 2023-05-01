using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
//using System.Text.Json.Serialization;


namespace OCS_Test_Assignment.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class OrderDTO : Order
    {
        public OrderDTO()
        {
        }
        [Required]
        [JsonProperty("id")]
        public string id { get; set; }
        [JsonProperty("status")]
        public string status { get; set; }
        public IEnumerable<OrderDetailsDTO>  lines {get; set;}
    }
}
