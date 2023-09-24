using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SimulationManager))]
public class HeightMapGenerator : MonoBehaviour
{
    private SimulationManager simulationManager;
    public float scale = 20;

    public void LogicStart()
    {
        simulationManager = GetComponent<SimulationManager>();
        GenerateHeightMap();
    }

    void GenerateHeightMap()
    {
        int width = simulationManager.width;
        int height = simulationManager.height;
        simulationManager.heightMap = new float[width, height];

        // 가우시안 함수의 파라미터 설정
        float a = 1f; // 최대 높이
        float x0 = width / 2f; // 중심 x 좌표
        float y0 = height / 2f; // 중심 y 좌표
        float sigmaX = width / 6f; // x축 표준편차
        float sigmaY = height / 6f; // y축 표준편차

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float fx = x;
                float fy = y;
                float heightValue = a * Mathf.Exp(-((fx - x0) * (fx - x0) / (2 * sigmaX * sigmaX) + (fy - y0) * (fy - y0) / (2 * sigmaY * sigmaY)));
                simulationManager.heightMap[x, y] = heightValue;
            }
        }
    }
}
