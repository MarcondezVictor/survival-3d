using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<ItemData> items = new List<ItemData>();

    private int selectedIndex = 0;
    public int SelectedIndex => selectedIndex;

    public IReadOnlyList<ItemData> Items => items;

    public void Add(ItemData itemName)
    {
        items.Add(itemName);
        Debug.Log($"Picked up {itemName}. Inventory now has {items.Count} item(s)"
            + string.Join(", ", items));
    }

    public bool TryConsume(ItemData itemName)
    {
        if (items.Remove(itemName))
        {
            Debug.Log($"Consumed {itemName}. {items.Count} item(s) left.");
            return true;
        }
        return false;
    }
    
    public ItemData SelectedItem
    {
        get
        {
            if (items.Count == 0) return null;
            selectedIndex = Mathf.Clamp(selectedIndex, 0, items.Count - 1);
            return items[selectedIndex];
        }
    }

    public void Select(int index)
    {
        selectedIndex = index;
        if (items.Count > 0)
        {
            selectedIndex = Mathf.Clamp(selectedIndex, 0, items.Count - 1);
            Debug.Log($"Selected: {SelectedItem.itemName}");
        }
    }
}
