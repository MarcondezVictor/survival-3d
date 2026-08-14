using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;

public class HotbarUI : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private Image[] slots;
    [SerializeField] private TMP_Text[] labels;
    [SerializeField] private Image[] icons;

    [SerializeField] private Color normalColor = new Color(0.2f, 0.2f, 0.2f, 0.8f);
    [SerializeField] private Color selectedColor = new Color(0.9f, 0.9f, 0.9f, 1f);

    private void Update()
    {
        int selected = inventory.SelectedIndex;
        IReadOnlyList<ItemStack> stacks = inventory.Stacks;

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].color = (i == selected) ? selectedColor : normalColor;

            if (i < stacks.Count)
            {
                icons[i].sprite = stacks[i].item.icon;
                icons[i].enabled = true;
                labels[i].text = stacks[i].count > 1 ? $"x{stacks[i].count}" : "";
            }
            else
            {
                icons[i].enabled = false;
                labels[i].text = "";
            }
        }
    }
}