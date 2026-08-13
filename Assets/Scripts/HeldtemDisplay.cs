using UnityEngine;

public class HeldItemDisplay : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private Transform holdPoint;

    private ItemData shownItem;
    private GameObject shownModel;

    private void Update()
    {
        ItemData selected = inventory.SelectedItem;

        if (selected == shownItem)
            return;

        shownItem = selected;

        if (shownModel != null)
            Destroy(shownModel);

        if (selected != null && selected.heldPrefab != null)
        {
            shownModel = Instantiate(selected.heldPrefab, holdPoint);
            shownModel.transform.localPosition = Vector3.zero;
            shownModel.transform.localRotation = Quaternion.identity;
        }
    }
}
