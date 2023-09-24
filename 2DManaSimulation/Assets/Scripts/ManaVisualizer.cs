using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SimulationManager))]
public class ManaVisualizer : MonoBehaviour
{
    private SimulationManager simulationManager;

    public void LogicStart()
    {
        simulationManager = GetComponent<SimulationManager>();
    }

    private void Update()
    {
        VisualizeMana();
    }

    void VisualizeMana()
    {
        int width = simulationManager.width;
        int height = simulationManager.height;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float manaValue = simulationManager.manaMap[x, y];
                // Update the color of the cell at (x, y) based on manaValue
                Color manaColor = new Color(manaValue, manaValue, manaValue);
                simulationManager.cells[x, y].GetComponent<Renderer>().material.color = manaColor;
            }
        }
    }
}
