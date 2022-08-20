namespace Yungching.ViewModels
{
    public class EditProduct
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public int ProductPrice { get; set; }
        public string? ProductDetail { get; set; }
    }
}
