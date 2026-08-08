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
        if (Input.GetMouseButtonDown(0)) // left click
        {
            Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

            if (Physics.Raycast(ray, out RaycastHit hit, interactRange))
            {
                if (hit.collider.CompareTag("Interactable"))
                {
                    inventory.Add(hit.collider.name);
                    Destroy(hit.collider.gameObject);
                }
                else
                {
                    Debug.Log("Not interactable: " + hit.collider.name);
                }
            }
            else
            {
                Debug.Log("Hit nothing in range");
            }
        }
    }
}
