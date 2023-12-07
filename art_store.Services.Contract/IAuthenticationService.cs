using art_store.art_storeDto;

namespace art_store.Services.Contract
{
    public interface IAuthenticationService
    {
        Task<RegisterResultDto> Register(RegisterDto registerModel);
        Task<LoginResultDto> Login(LoginDto loginModel);
        Task Logout();

        Task<bool> IsAuthenticated();
    }
}
