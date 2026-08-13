using System.IO.Enumeration;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class ItemData : ScriptableObject
{
    public string itemName = "New Item";

    [Header("Food")]
    public bool isFood;
    public float hungerRestored = 25f;

    [Header("Placeable")]
    public bool isPlaceable;
    public GameObject blockPrefab;

    [Header("Visuals")]
    public GameObject heldPrefab;
}