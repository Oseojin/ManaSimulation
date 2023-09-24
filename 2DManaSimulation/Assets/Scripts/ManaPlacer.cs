using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SimulationManager))]
public class ManaPlacer : MonoBehaviour
{
    private SimulationManager simulationManager;
    public float initialMana = 100f;

    public void LogicStart()
    {
        simulationManager = GetComponent<SimulationManager>();
        PlaceMana();
    }

    void PlaceMana()
    {
        int width = simulationManager.width;
        int height = simulationManager.height;
        simulationManager.manaMap = new float[width, height];
        // For example, place initial mana at the center of the grid
        //simulationManager.manaMap[0, 0] = initialMana;
        simulationManager.manaMap[width / 2, height / 2] = initialMana;
    }
}
