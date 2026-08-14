using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<ItemStack> stacks = new List<ItemStack>();

    private int selectedIndex = 0;

    public IReadOnlyList<ItemStack> Stacks => stacks;
    public int SelectedIndex => selectedIndex;



    public void Add(ItemData item)
    {
        ItemStack existing = stacks.Find(s => s.item == item);

        if (existing != null)
            existing.count++;
        else
            stacks.Add(new ItemStack(item, 1));

        Debug.Log($"Picked up {item.itemName}. Stacks: {stacks.Count}");
    }

    public bool TryConsume(ItemData item)
    {
        ItemStack existing = stacks.Find(s => s.item == item);

        if (existing == null)
            return false;

        existing.count--;

        if (existing.count <= 0)
            stacks.Remove(existing);

       
        Debug.Log($"Consumed {item.itemName}. {stacks.Count} item(s) left.");
        return true;
        
    }
    
    public ItemData SelectedItem
    {
        get
        {
            if (stacks.Count == 0) return null;
            selectedIndex = Mathf.Clamp(selectedIndex, 0, stacks.Count - 1);
            return stacks[selectedIndex].item;
        }
    }

    public void Select(int index)
    {
        selectedIndex = index;
        if (stacks.Count > 0)
        {
            selectedIndex = Mathf.Clamp(selectedIndex, 0, stacks.Count - 1);
            Debug.Log($"Selected: {SelectedItem.itemName}");
        }
    }
}
