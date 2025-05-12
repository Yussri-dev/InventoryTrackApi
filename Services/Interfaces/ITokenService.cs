namespace InventoryTrackApi.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateJwtToken(string userId, string userName, IList<string> roles);
    }
}
