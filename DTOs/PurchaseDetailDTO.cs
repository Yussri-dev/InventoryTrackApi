namespace InventoryTrackApi.DTOs
{
    public class PurchaseDetailDTO
    {
        public PurchaseDTO Purchase { get; set; } = new();
        public List<PurchaseItemWithProductDTO> Items { get; set; } = new();
    }
}
