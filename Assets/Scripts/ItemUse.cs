using UnityEngine;

public class ItemUse : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float placeRange = 8f;

    private Inventory inventory;
    private Hunger hunger;
    private GridPlacement gridPlacement;

    private void Awake()
    {
        inventory = GetComponent<Inventory>();
        hunger = GetComponent<Hunger>();
        gridPlacement = GetComponent<GridPlacement>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            ItemData held = inventory.SelectedItem;
            if (held == null) return;

            if (held.isFood)
            {
                if (inventory.TryConsume(held))
                    hunger.Restore(held.hungerRestored);
            }
            else if(held.isPlaceable)
            {
                Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
                if (Physics.Raycast(ray, out RaycastHit hit, placeRange))
                {
                    if (gridPlacement.TryPlace(held.blockPrefab, hit.point))
                        inventory.TryConsume(held);
                }
            }
        }
    }

}
