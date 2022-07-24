using Microsoft.AspNetCore.Mvc;
using AntBlazor.Shared.DTO;

namespace AntBlazor.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ItemController : ControllerBase
    {
        private static readonly string[] Names = new[]
        {
        "South Seas Wall", "Tree's Bounty Little Tree", "Antique Bed", "Cypress Plant", "Portable radio", "Cherry speakers", "Wooden waste bin", "Throwback hat table", "Spinning wheel", "Teacup ride"
        };

        private static readonly string[] Categories = new[]
        {
        "Housewares", "Miscellaneous", "Wall-mounted", "Wallpaper", "Floor", "Rugs", "Accessories", "Other", "Furniture Sets", "Themed Furniture"
        };

        private static readonly string[] ItemStatuses = new[]
        {
        "Orderd", "Out of Stock", "Laughing", "Angry", "Happy", "Completed", "Hopping", "Kidding", "Depressed", "Waiting for pick"
        };

        [HttpGet]
        public IEnumerable<ItemDto> GetItem()
        {
            return Enumerable.Range(1, 1000).Select(index => new ItemDto
            {
                Id = index,
                Name = Names[Random.Shared.Next(Names.Length)],
                Category = Categories[Random.Shared.Next(Categories.Length)],
                ItemStatus = ItemStatuses[Random.Shared.Next(ItemStatuses.Length)],
                Stock = Random.Shared.Next(1000),
                ReleaseDate = DateTime.Now.AddHours(Random.Shared.Next(100,10000)),
                DiscontinuationDate = DateTime.Now.AddHours(Random.Shared.Next(10000, 20000)),
            })
            .ToArray();
        }
    }
}
