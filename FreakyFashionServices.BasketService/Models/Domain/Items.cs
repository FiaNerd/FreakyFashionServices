﻿namespace FreakyFashionServices.BasketService.Models.Domain
{
    public class Items
    {
        public Items(int productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }

        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
