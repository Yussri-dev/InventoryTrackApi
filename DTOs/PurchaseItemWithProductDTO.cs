namespace InventoryTrackApi.DTOs
{
    public class PurchaseItemWithProductDTO
    {
        public PurchaseItemDTO PurchaseItem { get; set; } = new();
        public ProductDTO Product { get; set; } = new();
    }
}
