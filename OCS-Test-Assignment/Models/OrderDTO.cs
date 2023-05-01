using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
//using System.Text.Json.Serialization;


namespace OCS_Test_Assignment.Models
{
    //[JsonObject(MemberSerialization.OptIn)]
    public class OrderDTO : Entity
    {
        [JsonConstructor]
        public OrderDTO() { }
        [JsonProperty("id")]
        public string orderId { get; set; }
        [JsonProperty("status")]
        public string status { get; set; }
        public IEnumerable<OrderDetailsDTO>  lines {get; set;}
        //[JsonIgnore]
        //Guid Id { get; set; }
    }
}
