using AntBlazor.Shared.DTO;

namespace AntBlazor.Client.Interfaces.Fetchers
{
    public interface ICurrentUserFetcher
    {
        Task<CurrentUser> CurrentUserInfo();
    }
}
