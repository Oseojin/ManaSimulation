using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationManager : MonoBehaviour
{
    public int width = 256;
    public int height = 256;
    public double manaScale = 10.0;
    public double[,] heightMap;
    public double[,] manaMap;
    public GameObject[,] cells;

    public HeightMapGenerator heightMapGenerator;
    public GridGenerator gridGenerator;
    public ManaPlacer manaPlacer;
    public ManaSimulator manaSimulator;
    public ManaVisualizer manaVisualizer;

    // ���⿡ �ʿ��� �߰� ���� �������� ������ �� �ֽ��ϴ�.

    private void Awake()
    {
        heightMapGenerator = GetComponent<HeightMapGenerator>();
        gridGenerator = GetComponent<GridGenerator>();
        manaPlacer = GetComponent<ManaPlacer>();
        manaSimulator = GetComponent<ManaSimulator>();
        manaVisualizer = GetComponent<ManaVisualizer>();
        // heightMap, manaMap ���� �ʱ�ȭ ������ ���⿡ �� �� �ֽ��ϴ�.
    }

    private void Start()
    {
        heightMapGenerator.LogicStart();
        gridGenerator.LogicStart();
        manaPlacer.LogicStart();
        manaSimulator.LogicStart();
        manaVisualizer.LogicStart();
    }
}
