namespace API.Entities
{
    public class Basket
    {
        public int Id { get; set; }
        public string BuyerId { get; set; }
        public List<BasketItem> Items { get; set; } = new();

        public void AddItem(Product product, int quantity)
        {
            if(Items.All(p => p.ProductId != product.Id))
            {
                Items.Add(new BasketItem{Product = product, Quantity = quantity});
            }

            var existingItem = Items.FirstOrDefault(p => p.ProductId == product.Id);

            if(existingItem is not null) existingItem.Quantity += quantity;
        }

        public void RemoveItem(int producuId, int quantity)
        {
            var item = Items.FirstOrDefault(i => i.ProductId == producuId);
            if(item is null) return;
            item.Quantity -= quantity;
            if(item.Quantity == 0) Items.Remove(item);
        }
    }
}