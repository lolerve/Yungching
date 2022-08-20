using System;
using System.Collections.Generic;

namespace Yungching.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public int ProductPrice { get; set; }
        public string? ProductDetail { get; set; }
    }
}
