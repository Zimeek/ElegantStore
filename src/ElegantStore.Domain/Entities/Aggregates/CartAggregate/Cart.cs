using ElegantStore.Domain.Interfaces;

namespace ElegantStore.Domain.Entities.Aggregates.CartAggregate;

public class Cart : BaseEntity<string>, IAggregateRoot
{

    public Cart()
    {
        
    }

    public ICollection<CartItem> Items { get; private set; } = new List<CartItem>();

    public CartItem? AddItem(int productId, int quantity)
    {
        if (!Items.Any(item => item.ProductId == productId))
        {
            var item = new CartItem(Id, productId, quantity);
            Items.Add(item);
            return item;
        }

        return null;
    }

    public CartItem? UpdateItem(string itemId, int quantity)
    {
        var item = Items.FirstOrDefault(i => i.Id == itemId);
        
        if (item is not null)
        {
            item.SetQuantity(quantity);
            return item;
        }

        return null;
    }

    public void RemoveItem(string itemId)
    {
        var item = Items.FirstOrDefault(i => i.Id == itemId);

        if (item is not null)
        {
            Items.Remove(item);
        }
    }

    public void Clear()
    {
        Items.Clear();
    }


}