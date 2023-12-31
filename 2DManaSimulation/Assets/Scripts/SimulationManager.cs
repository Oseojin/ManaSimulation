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

    // 여기에 필요한 추가 설정 변수들을 선언할 수 있습니다.

    private void Awake()
    {
        heightMapGenerator = GetComponent<HeightMapGenerator>();
        gridGenerator = GetComponent<GridGenerator>();
        manaPlacer = GetComponent<ManaPlacer>();
        manaSimulator = GetComponent<ManaSimulator>();
        manaVisualizer = GetComponent<ManaVisualizer>();
        // heightMap, manaMap 등의 초기화 로직이 여기에 올 수 있습니다.
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
