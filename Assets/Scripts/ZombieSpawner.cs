using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{

    public Transform[] spawnpoints;     // ������ġ �迭

    public GameObject zombie;   // ���� ������Ʈ

    private void Start()
    {
        // SpawnZombie�� 2���Ŀ� 5�ʸ��� ����
        InvokeRepeating("SpawnZombie", 2, 5);
    }
    void SpawnZombie()
    {
        int r = Random.Range(0, spawnpoints.Length);    // ������ġ
        GameObject myZombie = Instantiate(zombie, spawnpoints[r].position, Quaternion.identity);    // ���� ��������
    }

}
