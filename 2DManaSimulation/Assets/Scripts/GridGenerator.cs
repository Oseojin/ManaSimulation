using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SimulationManager))]
public class GridGenerator : MonoBehaviour
{
    private SimulationManager simulationManager;
    [SerializeField]
    private double cellSize = 1.0;
    [SerializeField]
    private double heightMultiplier = 10.0;

    public void LogicStart()
    {
        simulationManager = GetComponent<SimulationManager>();
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        int width = simulationManager.width;
        int height = simulationManager.height;
        simulationManager.cells = new GameObject[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                double heightValue = simulationManager.heightMap[x, y] * heightMultiplier;
                Vector3 position = new Vector3((float)(x * cellSize), (float)heightValue, (float)(y * cellSize));
                GameObject cell = GameObject.CreatePrimitive(PrimitiveType.Cube);
                Destroy(cell.gameObject.GetComponent<BoxCollider>());
                cell.transform.position = position;
                cell.transform.localScale = new Vector3((float)(cellSize), (float)heightValue, (float)cellSize);
                simulationManager.cells[x, y] = cell;
            }
        }
    }
}
