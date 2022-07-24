using AntBlazor.Shared.DTO;

namespace AntBlazor.Client.Interfaces.Services
{
    public interface IItemService
    {
        Task<ItemDto[]> GetItems();
    }
}
