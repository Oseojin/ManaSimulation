using System.CodeDom.Compiler;
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
        //PlaceMana();
        StartCoroutine(PlacerUpdate());
    }

    IEnumerator PlacerUpdate()
    {
        simulationManager.manaMap = new float[simulationManager.width, simulationManager.height];
        while(true)
        {
            PlaceMana();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void PlaceMana()
    {
        int width = simulationManager.width;
        int height = simulationManager.height;
        //simulationManager.manaMap = new float[width, height];
        PlaceCenter(width, height);
    }

    private void PlaceCenter(int width, int height)
    {
        simulationManager.manaMap[width / 2, height / 2] = initialMana;
    }

    private void PlaceVertex(int width, int height)
    {
        simulationManager.manaMap[0, 0] = initialMana;
        simulationManager.manaMap[width - 1, 0] = initialMana;
        simulationManager.manaMap[0, height - 1] = initialMana;
        simulationManager.manaMap[width - 1, height - 1] = initialMana;
    }

    private void PlaceBorderLine(int width, int height)
    {
        for(int i = 0; i < width; i++)
        {
            simulationManager.manaMap[i, 0] = initialMana;
            simulationManager.manaMap[i, height - 1] = initialMana;
        }
        for(int i = 0; i < height; i++)
        {
            simulationManager.manaMap[0, i] = initialMana;
            simulationManager.manaMap[width - 1, i] = initialMana;
        }
    }
}
