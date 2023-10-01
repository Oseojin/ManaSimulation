using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SimulationManager))]
public class ManaPlacer : MonoBehaviour
{
    private SimulationManager simulationManager;
    [SerializeField]
    private double initialMana = 100.0;
    private enum PlaceShape
    {
        CENTER,
        VERTEX,
        BORDERLINE
    };
    private enum PlaceRepeat
    {
        ONCE,
        REPEAT
    }

    [SerializeField]
    private PlaceRepeat placeRepeat = PlaceRepeat.ONCE;
    [SerializeField]
    private PlaceShape placeShape = PlaceShape.CENTER;

    public void LogicStart()
    {
        simulationManager = GetComponent<SimulationManager>();
        simulationManager.manaMap = new double[simulationManager.width, simulationManager.height];

        switch (placeRepeat)
        { 
            case PlaceRepeat.ONCE:
                PlaceMana();
                break;
            case PlaceRepeat.REPEAT:
                StartCoroutine(PlacerUpdate());
                break;
        }
    }

    private IEnumerator PlacerUpdate()
    {
        while (true)
        {
            PlaceMana();
            yield return new WaitForSeconds(8f);
        }
    }

    // 최초 마나 배치용
    // initialMana를 정해진 위치에 배치
    private void PlaceMana()
    {
        int width = simulationManager.width;
        int height = simulationManager.height;

        switch (placeShape)
        {
            case PlaceShape.CENTER:
                PlaceCenter(width, height, initialMana);
                break;
            case PlaceShape.VERTEX:
                PlaceVertex(width, height, initialMana);
                break;
            case PlaceShape.BORDERLINE:
                PlaceBorderLine(width, height, initialMana);
                break;
        }
    }

    private void PlaceCenter(int width, int height, double mana)
    {
        if (simulationManager.manaMap[width / 2, height / 2] != 0)
        {
            mana -= simulationManager.manaMap[width / 2, height / 2];
        }
        simulationManager.manaMap[width / 2, height / 2] = mana;
    }

    private void PlaceVertex(int width, int height, double mana)
    {
        int x, y;
        double manaCopy = mana;
        x = 0;
        y = 0;
        Debug.Log(simulationManager.manaMap[x, y]);
        if (simulationManager.manaMap[x, y] != 0)
        {
            manaCopy -= simulationManager.manaMap[x, y];
        }
        simulationManager.manaMap[x, y] = manaCopy;

        manaCopy = mana;
        x = width - 1;
        y = 0;
        if (simulationManager.manaMap[x, y] != 0)
        {
            manaCopy -= simulationManager.manaMap[x, y];
        }
        simulationManager.manaMap[x, y] = manaCopy;

        manaCopy = mana;
        x = 0;
        y = height - 1;
        if (simulationManager.manaMap[x, y] != 0)
        {
            manaCopy -= simulationManager.manaMap[x, y];
        }
        simulationManager.manaMap[x, y] = manaCopy;

        manaCopy = mana;
        x = width - 1;
        y = height - 1;
        if (simulationManager.manaMap[x, y] != 0)
        {
            manaCopy -= simulationManager.manaMap[x, y];
        }
        simulationManager.manaMap[x, y] = manaCopy;
    }

    private void PlaceBorderLine(int width, int height, double mana)
    {
        double manaCopy;
        for(int i = 0; i < width; i++)
        {
            manaCopy = mana;
            if (simulationManager.manaMap[i, 0] != 0)
            {
                manaCopy -= simulationManager.manaMap[i, 0];
            }
            simulationManager.manaMap[i, 0] = manaCopy;

            manaCopy = mana;
            if (simulationManager.manaMap[i, height - 1] != 0)
            {
                manaCopy -= simulationManager.manaMap[i, height - 1];
            }
            simulationManager.manaMap[i, height - 1] = manaCopy;
        }
        for(int i = 0; i < height; i++)
        {
            manaCopy = mana;
            if (simulationManager.manaMap[0, i] != 0)
            {
                manaCopy -= simulationManager.manaMap[0, i];
            }
            simulationManager.manaMap[0, i] = mana;

            manaCopy = mana;
            if (simulationManager.manaMap[width - 1, i] != 0)
            {
                manaCopy -= simulationManager.manaMap[width - 1, i];
            }
            simulationManager.manaMap[width - 1, i] = mana;
        }
    }
}
