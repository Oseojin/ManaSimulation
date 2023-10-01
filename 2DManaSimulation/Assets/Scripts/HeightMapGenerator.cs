using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SimulationManager))]
public class HeightMapGenerator : MonoBehaviour
{
    private SimulationManager simulationManager;
    [SerializeField]
    private double scale = 20.0;

    public void LogicStart()
    {
        simulationManager = GetComponent<SimulationManager>();
        GenerateHeightMap();
    }

    void GenerateHeightMap()
    {
        int width = simulationManager.width;
        int height = simulationManager.height;
        simulationManager.heightMap = new double[width, height];

        // ����þ� �Լ��� �Ķ���� ����
        float a = 1f; // �ִ� ����
        float x0 = width / 2f; // �߽� x ��ǥ
        float y0 = height / 2f; // �߽� y ��ǥ
        float sigmaX = width / 6f; // x�� ǥ������
        float sigmaY = height / 6f; // y�� ǥ������

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float fx = x;
                float fy = y;
                double heightValue = a * Mathf.Exp(-((fx - x0) * (fx - x0) / (2 * sigmaX * sigmaX) + (fy - y0) * (fy - y0) / (2 * sigmaY * sigmaY)));
                simulationManager.heightMap[x, y] = heightValue;
            }
        }
    }
}
