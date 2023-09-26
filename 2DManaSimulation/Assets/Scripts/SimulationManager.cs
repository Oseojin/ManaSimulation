using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationManager : MonoBehaviour
{
    public int width = 256;
    public int height = 256;
    public float manaScale = 10f;
    public float[,] heightMap;
    public float[,] manaMap;
    public GameObject[,] cells;

    private HeightMapGenerator heightMapGenerator;
    private GridGenerator gridGenerator;
    private ManaPlacer manaPlacer;
    private ManaSimulator manaSimulator;
    private ManaVisualizer manaVisualizer;

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
