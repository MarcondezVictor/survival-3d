using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<string> items = new List<string>();

    public void Add(string itemName)
    {
        items.Add(itemName);
        Debug.Log($"Picked up {itemName}. Inventory now has {items.Count} item(s)"
            + string.Join(", ", items));
    }

    public bool TryConsume(string itemName)
    {
        if (items.Remove(itemName))
        {
            Debug.Log($"Consumed {itemName}. {items.Count} item(s) left.");
            return true;
        }
        return false;
    }
    void Start()
    {
        
    }
}
