using UnityEngine;

public class ResourceNode : MonoBehaviour
{
    [SerializeField] private ItemData resource;
    [SerializeField] private int totalAmount = 3;

    private int remaining;

    private void Awake()
    {
        remaining = totalAmount;
    }

    // Returns the resource type yielded by one hit.
    // Depletes the node; destroys it when empty.
    public ItemData Harvest()
    {
        remaining--;

        Debug.Log($"Harvested 1 {resource.itemName}. {remaining} left on this node.");

        if (remaining <= 0)
        {
            Destroy(gameObject);
        }

        return resource;
    }
}
