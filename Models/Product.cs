using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Task3.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Price { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string BadgeType { get; set; }
        public string ProductType { get; set; }
        public int ColourWayId { get; set; }
        public bool IsSale { get; set; }
        public string ReducedPrice { get; set; }
        public bool HasMultiplePrices { get; set; }
        public bool IsOutlet { get; set; }
        public bool IsSellingFast { get; set; }
        public int PageNumber { get; set; }
        public int TileId { get; set; }
        public string Colour { get; set; }
        public string CategoryName { get; set; }
        public string BaseUrl { get; set; }
        public string MainCategory { get; set; }
        public string BrandName { get; set; }
        public string ProductRating { get; set; }
        public string ProductCode { get; set; }
        public string ProductDescription { get; set; }
    }
}
