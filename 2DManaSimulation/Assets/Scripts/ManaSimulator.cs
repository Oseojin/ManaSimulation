using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SimulationManager))]
public class ManaSimulator : MonoBehaviour
{
    private SimulationManager simulationManager;
    public float flowSpeed = 0.1f;

    public void LogicStart()
    {
        simulationManager = GetComponent<SimulationManager>();
    }

    private void Update()
    {
        SimulateManaFlow();
    }

    void SimulateManaFlow()
    {
        int width = simulationManager.width;
        int height = simulationManager.height;
        float[,] nextManaMap = (float[,])simulationManager.manaMap.Clone();

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                // Iterate over neighbor cells
                int[] dx = { -1, 0, 1, 0 };
                int[] dy = { 0, -1, 0, 1 };
                for (int i = 0; i < 4; i++)
                {
                    int nx = x + dx[i];
                    int ny = y + dy[i];
                    if (nx >= 0 && nx < width && ny >= 0 && ny < height)
                    {
                        float heightDiff = simulationManager.heightMap[x, y] - simulationManager.heightMap[nx, ny];
                        if (heightDiff > 0)
                        {
                            float manaFlow = heightDiff * flowSpeed * simulationManager.manaMap[x, y];
                            nextManaMap[x, y] -= manaFlow;
                            nextManaMap[nx, ny] += manaFlow;
                        }
                    }
                }
            }
        }
        simulationManager.manaMap = nextManaMap;
    }
}
