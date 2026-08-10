using UnityEngine;
using UnityEngineInternal;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float interactRange = 5f;

    private Inventory inventory;

    private void Awake()
    {
        inventory = GetComponent<Inventory>();
    }
    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

            if (Physics.Raycast(ray, out RaycastHit hit, interactRange))
            {
                if (hit.collider.TryGetComponent(out ResourceNode node))
                {
                    string yielded = node.Harvest();
                    inventory.Add(yielded);
                }
                else
                {
                    Debug.Log("Not harvestable: " + hit.collider.name);
                }
            }
            else
            {
                Debug.Log("Hit nothing in range");
            }
        }
    }
}
