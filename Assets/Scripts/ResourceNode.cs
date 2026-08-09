using UnityEngine;

public class ResourceNode : MonoBehaviour
{
    [SerializeField] private string resourceType = "Wood";
    [SerializeField] private int totalAmount = 3;

    private int remaining;

    private void Awake()
    {
        remaining = totalAmount;
    }

    // Returns the resource type yielded by one hit.
    // Depletes the node; destroys it when empty.
    public string Harvest()
    {
        remaining--;

        Debug.Log($"Harvested 1 {resourceType}. {remaining} left on this node.");

        if (remaining <= 0)
        {
            Destroy(gameObject);
        }

        return resourceType;
    }
}
