using InventoryTrackApi.DTOs;

namespace InventoryTrackApi.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<AuthResponseDto> AuthenticateAsync(LoginDto request);
        Task<AuthResponseDto> RegisterAsync(RegisterDto registerDto);

    }
}
