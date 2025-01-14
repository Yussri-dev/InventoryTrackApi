using InventoryTrackApi.Models;

namespace InventoryTrackApi.Queries
{
    public class DiscountCalculator
    {
        public decimal CalculateDiscountedPrice(Product product, decimal quantity, decimal secondProductDiscountPercentage = 50)
        {
            decimal totalPrice = 0;

            // Check for "Buy 3 for 5 Euros" offer
            if (product.IsBuyThreeForFiveEligible && quantity >= 3)
            {
                decimal eligibleSets = quantity / 3; // Number of "3 for 5" sets
                decimal remainingItems = quantity % 3; // Items not part of the offer

                totalPrice = (eligibleSets * 5) + (remainingItems * product.SalePrice1);
            }
            else if (product.IsSecondItemDiscountEligible && quantity > 1)
            {
                // Apply the custom second product discount
                decimal discountedItems = quantity / 2; // Items eligible for the discount
                decimal fullPriceItems = quantity - discountedItems;

                totalPrice = (fullPriceItems * product.SalePrice1) +
                             (discountedItems * (product.SalePrice1 * (1 - secondProductDiscountPercentage / 100)));
            }
            else
            {
                // Flat discount logic
                totalPrice = quantity * (product.SalePrice1 * (1 - product.DiscountPercentage / 100));
            }

            return totalPrice;
        }
    }
}
