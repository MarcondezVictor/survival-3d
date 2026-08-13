using UnityEngine;
using UnityEngine.UI;

public class HotbarUI : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private Image[] slots;

    [SerializeField] private Color normalColor = new Color(0.2f, 0.2f, 0.2f, 0.8f);
    [SerializeField] private Color selectedColor = new Color(0.9f, 0.9f, 0.9f, 1f);

    private void Update()
    {
        int selected = inventory.SelectedIndex;

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].color = (i == selected) ? selectedColor : normalColor;
        }
    }
}