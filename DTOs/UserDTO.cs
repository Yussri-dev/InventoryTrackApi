using System.Text.Json.Serialization;

namespace InventoryTrackApi.DTOs
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string Username { get; set; }

        [JsonIgnore]
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public int SaasClientId { get; set; }

    }
}
