using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SimulationManager))]
public class GridGenerator : MonoBehaviour
{
    private SimulationManager simulationManager;
    public float cellSize = 1f;
    public float heightMultiplier = 10f;

    public void LogicStart()
    {
        simulationManager = GetComponent<SimulationManager>();
        GenerateGrid();
    }

    void GenerateGrid()
    {
        int width = simulationManager.width;
        int height = simulationManager.height;
        simulationManager.cells = new GameObject[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float heightValue = simulationManager.heightMap[x, y] * heightMultiplier;
                Vector3 position = new Vector3(x * cellSize, heightValue, y * cellSize);
                GameObject cell = GameObject.CreatePrimitive(PrimitiveType.Cube);
                Destroy(cell.gameObject.GetComponent<BoxCollider>());
                cell.transform.position = position;
                cell.transform.localScale = new Vector3(cellSize, heightValue, cellSize);
                simulationManager.cells[x, y] = cell;
            }
        }
    }
}
