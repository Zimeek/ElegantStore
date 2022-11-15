using System.Collections.Immutable;
using ElegantStore.Domain.Interfaces;

namespace ElegantStore.Domain.Entities.Aggregates.CartAggregate;

public class Cart : BaseEntity<string>, IAggregateRoot
{

    public Cart()
    {
        
    }

    public ICollection<CartItem> Items { get; private set; } = new List<CartItem>();

    public CartItem AddItem(int productId, decimal price, string color)
    {
        
        var item = new CartItem(Id, productId, 1, price, color);
        Items.Add(item);

        return item;
    }

    public CartItem? UpdateItem(string itemId, int quantity)
    {
        var item = Items.FirstOrDefault(i => i.Id == itemId);
        
        if (item is not null)
        {
            item.UpdateQuantity(quantity);
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