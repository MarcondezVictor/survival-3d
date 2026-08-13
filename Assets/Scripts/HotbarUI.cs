using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class HotbarUI : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private Image[] slots;
    [SerializeField] private TMP_Text[] labels;

    [SerializeField] private Color normalColor = new Color(0.2f, 0.2f, 0.2f, 0.8f);
    [SerializeField] private Color selectedColor = new Color(0.9f, 0.9f, 0.9f, 1f);

    private void Update()
    {
        int selected = inventory.SelectedIndex;
        IReadOnlyList<ItemData> items = inventory.Items;

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].color = (i == selected) ? selectedColor : normalColor;

            if (i < items.Count)
                labels[i].text = items[i].itemName;
            else
                labels[i].text = "";
        }
    }
}