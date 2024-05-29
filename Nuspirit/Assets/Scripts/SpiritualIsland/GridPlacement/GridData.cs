using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class GridData : MonoBehaviour
{
    public Tilemap tilemap;  // Add this line to define the Tilemap

    // A dictionary to keep track of occupied cells
    private Dictionary<Vector3Int, GameObject> occupiedCells = new Dictionary<Vector3Int, GameObject>();

    public bool IsCellOccupied(Vector3Int cellPosition)
    {
        return occupiedCells.ContainsKey(cellPosition);
    }

    public void OccupyCell(Vector3Int cellPosition, GameObject gameObject)
    {
        if (!occupiedCells.ContainsKey(cellPosition))
        {
            occupiedCells[cellPosition] = gameObject;
        }
    }

    public void FreeCell(Vector3Int cellPosition)
    {
        if (occupiedCells.ContainsKey(cellPosition))
        {
            occupiedCells.Remove(cellPosition);
        }
    }
}
