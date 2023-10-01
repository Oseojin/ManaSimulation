using UnityEngine;

[RequireComponent(typeof(SimulationManager))]
public class ManaSimulator : MonoBehaviour
{
    private SimulationManager simulationManager;
    [SerializeField]
    private double flowSpeed = 0.1;
    [SerializeField]
    private double totalMana = 0.0;

    public void LogicStart()
    {
        simulationManager = GetComponent<SimulationManager>();
    }

    private void Update()
    {
        SimulateManaFlow();
        double manaStorage16 = (Mathf.Log((1f - (float)simulationManager.heightMap[16, 14] + 1f), 2f) + 0.25f) * 4f;
        Debug.Log(" height: " + simulationManager.heightMap[16, 14] + " mana: " + simulationManager.manaMap[16, 14] + " manaStorage: " + manaStorage16);
    }

    private void SimulateManaFlow()
    {
        int width = simulationManager.width;
        int height = simulationManager.height;
        double[,] nextManaMap = (double[,])simulationManager.manaMap.Clone();
        totalMana = 0;

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
                        double heightDiff = simulationManager.heightMap[x, y] - simulationManager.heightMap[nx, ny];
                        // �� ������ ������ �� �ִ� ������ �ִ뷮 ((log2(x + 1) + 0.25) * 4) -> �������� ������ ���� ���� ����
                        double manaStorage = (Mathf.Log((1f - (float)simulationManager.heightMap[nx, ny] + 1f), 2f) + 0.25f) * 4f;
                        
                        if (heightDiff > 0 && manaStorage > nextManaMap[nx, ny])
                        {
                            double manaFlow = heightDiff * flowSpeed * nextManaMap[x, y];
                            double leftManaStorage = manaStorage - nextManaMap[nx, ny];
                            // �帣�� ������ ���� ���� ������ �纸�� ���� ���
                            if(manaFlow >= nextManaMap[x, y])
                            {
                                // ������ �ִ� 4�������� �带 �� �����Ƿ� 1,2,3,4�� �ּҰ������ 12�� ������ �����ϰ� ���
                                manaFlow = nextManaMap[x, y] / 12.0;
                            }
                            // �̵���ų ������ ���� ���� ������ ������ ���
                            if(manaFlow >= leftManaStorage)
                            {
                                // ���� ���� ��ü�� ä��
                                manaFlow = leftManaStorage;
                            }
                            nextManaMap[x, y] -= manaFlow;
                            nextManaMap[nx, ny] += manaFlow;
                        }
                    }
                }
                totalMana += simulationManager.manaMap[x, y];
            }
        }
        simulationManager.manaMap = nextManaMap;
    }

    public double GetTotalMana()
    {
        return totalMana;
    }
}
