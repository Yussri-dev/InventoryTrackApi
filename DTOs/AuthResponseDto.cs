namespace InventoryTrackApi.DTOs
{
    public class AuthResponseDto
    {
        public bool IsSuccess { get; set; }
        public string Token { get; set; }
        public string UserName { get; set; }
        public string IdUser { get; set; }
        public int SaasClientId { get; set; }

        public List<string> Roles { get; set; }
        public string ErrorMessage { get; set; }
    }
}
