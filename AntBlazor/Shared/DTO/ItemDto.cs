using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntBlazor.Shared.DTO
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string ItemStatus { get; set; } = String.Empty;
        public string Category { get; set; } = String.Empty;
        public int Stock { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime DiscontinuationDate { get; set; }
    }
}
