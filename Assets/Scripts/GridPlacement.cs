using UnityEngine;
using System.Collections.Generic;

public class GridPlacement : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float placeRange = 8f;
    [SerializeField] private float cellSize = 1f;
    [SerializeField] private GameObject blockPrefab;

    private HashSet<Vector3> occupiedCells = new HashSet<Vector3>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void Update()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, placeRange))
        {
            if (Input.GetMouseButtonDown(1))
            {
                Vector3 snapped = SnapToGrid(hit.point);

                if (!occupiedCells.Contains(snapped))
                {
                    Instantiate(blockPrefab, snapped, Quaternion.identity);
                    occupiedCells.Add(snapped);
                }                
            }
        }
    }

    private Vector3 SnapToGrid(Vector3 worldPoint)
    {
        float x = Mathf.Floor(worldPoint.x / cellSize) * cellSize + cellSize / 2f;
        float z = Mathf.Floor(worldPoint.z / cellSize) * cellSize + cellSize / 2f;
        float y = cellSize / 2f;
        return new Vector3(x, y, z);
    }
}
