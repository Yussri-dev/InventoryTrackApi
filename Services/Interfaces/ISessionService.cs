namespace InventoryTrackApi.Services.Interfaces
{
    public interface ISessionService
    {
        void SetToken(string token);
        string GetToken();
        void SetUserRole(List<string> roles);
        List<string> GetUserRoles();
        void ClearSession();
    }
}
