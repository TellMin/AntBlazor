using AntBlazor.Shared.DTO;

namespace AntBlazor.Client.Interfaces.Services
{
    public interface IAccountService
    {
        Task<bool> Login(LoginDto login);
        Task<CurrentUser> CurrentUserInfo();
    }
}
