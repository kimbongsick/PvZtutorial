using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{

    public Transform[] spawnpoints;     // ������ġ �迭

    public GameObject zombie;   // ���� ������Ʈ

    public ZombieTypeProb[] zombieTypes;

    private List<ZombieType> probList = new List<ZombieType>();

    private void Start()
    {
        // SpawnZombie�� 2���Ŀ� 5�ʸ��� ����
        InvokeRepeating("SpawnZombie", 2, 5);

        foreach(ZombieTypeProb zom in zombieTypes)
        {
            for (int i = 0; i < zom.probability; i++)
                probList.Add(zom.type);
        }
    }
    void SpawnZombie()
    {
        int r = Random.Range(0, spawnpoints.Length);    // ������ġ
        GameObject myZombie = Instantiate(zombie, spawnpoints[r].position, Quaternion.identity);    // ���� ��������
        myZombie.GetComponent<Zombie>().type = probList[Random.Range(0, probList.Count)];
    }

}

[System.Serializable]
public class ZombieTypeProb
{
    public ZombieType type;
    public int probability;
}