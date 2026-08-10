using UnityEngine;

public class Eating : MonoBehaviour
{
    [SerializeField] private string foodItem = "Berry";
    [SerializeField] private float hungerPerFood = 25f;

    private Inventory inventory;
    private Hunger hunger;

    private void Awake()
    {
        inventory = GetComponent<Inventory>();
        hunger = GetComponent<Hunger>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (inventory.TryConsume(foodItem))
            {
                hunger.Restore(hungerPerFood);
            }
        }
    }
}
