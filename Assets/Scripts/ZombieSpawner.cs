using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{

    public Transform[] spawnpoints;

    public GameObject zombie;

    private void Start()
    {
        // SpawnZombie를 2초후에 5초마다 실행
        InvokeRepeating("SpawnZombie", 2, 5);
    }
    void SpawnZombie()
    {
        int r = Random.Range(0, spawnpoints.Length);
        GameObject myZombie = Instantiate(zombie, spawnpoints[r].position, Quaternion.identity);
    }

}
