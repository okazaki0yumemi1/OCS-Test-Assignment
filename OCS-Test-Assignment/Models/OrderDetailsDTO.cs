using System.ComponentModel.DataAnnotations;
//using System.Text.Json;
//using System.Text.Json.Serialization;
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
        public string detailsId { get; set; } //"new" because of this bug: https://github.com/dotnet/runtime/issues/30964
        [Required]
        [JsonProperty("qty")]
        public int quantity { get; set; }
        [JsonIgnore]
        Guid Id { get; set; }
    }
}
