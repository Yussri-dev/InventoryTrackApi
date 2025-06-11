using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace InventoryTrackApi.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IUnitOfWork _unitOfWork;
        public IdentityService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IUnitOfWork unitOfWork,
            ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _unitOfWork = unitOfWork;
        }


        public async Task<AuthResponseDto> AuthenticateAsync(LoginDto request)
        {
            var result = await _signInManager.PasswordSignInAsync(
                request.Email,
                request.Password,
                isPersistent: false,
                lockoutOnFailure: true);

            if (!result.Succeeded)
            {
                return new AuthResponseDto { IsSuccess = false, ErrorMessage = "Login failed" };
            }

            var user = await _userManager.FindByEmailAsync(request.Email);
            var roles = await _userManager.GetRolesAsync(user);
            var idUser = await _userManager.GetUserIdAsync(user);
            var saasClientId = user.SaasClientId;

            var activeSubscription = await _unitOfWork.SaasClients.GetWhereAsync(
                   cs =>
                   cs.SaasClientId == saasClientId &&
                   cs.SubscriptionType == "Free" );

            var activeCashShift = activeSubscription.FirstOrDefault();

            if (activeCashShift == null)
            {
                throw new InvalidOperationException("No active cash shift found for the register.");
            }
            //var idSaasClient = user.
            // Générer le token JWT
            var token = _tokenService.GenerateJwtToken(idUser, user.UserName, roles);

            return new AuthResponseDto
            {
                IsSuccess = true,
                Token = token,
                UserName = user.UserName,
                IdUser = idUser,
                Roles = roles.ToList(),
                SaasClientId = user.SaasClientId

            };
        }

        //public async Task<AuthResponseDto> AuthenticateAsync(LoginDto request)
        //{
        //    var user = await _userManager.FindByEmailAsync(request.Email);

        //    if (user == null)
        //    {
        //        return new AuthResponseDto { IsSuccess = false, ErrorMessage = "Invalid credentials." };
        //    }


        //    var domainUser = await _unitOfWork.Users
        //        .FindAsync(
        //        u => u.SaasClientId == user.SaasClientId && 
        //        u.IsActive, include: q => q.Include(u => u.SaasClient));

        //    if (domainUser == null)
        //    {
        //        return new AuthResponseDto { IsSuccess = false, ErrorMessage = "Inactive user or user not found." };
        //    }

        //    var client = domainUser.SaasClient;

        //    if (client == null)
        //    {
        //        return new AuthResponseDto { IsSuccess = false, ErrorMessage = "No associated SaaS client." };
        //    }

        //    if (client.SubscriptionExpiration.HasValue &&
        //        client.SubscriptionExpiration.Value <= DateTime.UtcNow)
        //    {
        //        return new AuthResponseDto { IsSuccess = false, ErrorMessage = "Subscription expired." };
        //    }

        //    var result = await _signInManager.PasswordSignInAsync(
        //        request.Email,
        //        request.Password,
        //        isPersistent: false,
        //        lockoutOnFailure: true);

        //    if (!result.Succeeded)
        //    {
        //        return new AuthResponseDto { IsSuccess = false, ErrorMessage = "Login failed." };
        //    }

        //    var roles = await _userManager.GetRolesAsync(user);
        //    var idUser = await _userManager.GetUserIdAsync(user);

        //    var token = _tokenService.GenerateJwtToken(idUser, user.UserName);

        //    return new AuthResponseDto
        //    {
        //        IsSuccess = true,
        //        Token = token,
        //        UserName = user.UserName,
        //        IdUser = idUser,
        //        Roles = roles.ToList()
        //    };
        //}

        public async Task<AuthResponseDto> RegisterAsync(RegisterDto dto)
        {
            var user = new ApplicationUser
            {
                UserName = dto.Email,
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                SaasClientId = dto.SaasClientId
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                return new AuthResponseDto
                {
                    IsSuccess = false,
                    ErrorMessage = string.Join(", ", result.Errors.Select(e => e.Description))
                };
            }

            if (dto.Roles != null && dto.Roles.Any())
            {
                foreach (var role in dto.Roles)
                {
                    if (!await _userManager.IsInRoleAsync(user, role))
                    {
                        await _userManager.AddToRoleAsync(user, role);
                    }
                }
            }
            else
            {
                await _userManager.AddToRoleAsync(user, "User");
            }

            var roles = await _userManager.GetRolesAsync(user);

            var token = _tokenService.GenerateJwtToken(user.Id.ToString(), user.UserName, roles);

            return new AuthResponseDto
            {
                IsSuccess = true,
                UserName = user.UserName,
                Token = token,
                Roles = roles.ToList()
            };
        }


        //public async Task<AuthResponseDto> RegisterAsync(RegisterDto dto)
        //{
        //    var user = new ApplicationUser
        //    {
        //        UserName = dto.Email,
        //        Email = dto.Email,
        //        FirstName = dto.FirstName,
        //        LastName = dto.LastName,
        //        SaasClientId = dto.SaasClientId
        //    };

        //    var result = await _userManager.CreateAsync(user, dto.Password);

        //    if (!result.Succeeded)
        //    {
        //        return new AuthResponseDto
        //        {
        //            IsSuccess = false,
        //            ErrorMessage = string.Join(", ", result.Errors.Select(e => e.Description))
        //        };
        //    }

        //    if (dto.Roles != null && dto.Roles.Any())
        //    {
        //        foreach (var role in dto.Roles)
        //        {
        //            if (!await _userManager.IsInRoleAsync(user, role))
        //            {
        //                await _userManager.AddToRoleAsync(user, role);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        await _userManager.AddToRoleAsync(user, "User");
        //    }

        //    var roles = await _userManager.GetRolesAsync(user);

        //    var token = _tokenService.GenerateJwtToken(user.Id.ToString(), user.UserName);

        //    return new AuthResponseDto
        //    {
        //        IsSuccess = true,
        //        UserName = user.UserName,
        //        Token = token,
        //        Roles = roles.ToList()
        //    };
        //}


    }
}
