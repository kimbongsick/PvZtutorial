using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{

    public Transform[] spawnpoints;     // 스폰위치 배열

    public GameObject zombie;   // 좀비 오브젝트

    public ZombieTypeProb[] zombieTypes;

    private List<ZombieType> probList = new List<ZombieType>();

    private void Start()
    {
        // SpawnZombie를 2초후에 5초마다 실행
        InvokeRepeating("SpawnZombie", 2, 5);

        foreach(ZombieTypeProb zom in zombieTypes)
        {
            for (int i = 0; i < zom.probability; i++)
                probList.Add(zom.type);
        }
    }
    void SpawnZombie()
    {
        int r = Random.Range(0, spawnpoints.Length);    // 랜덤배치
        GameObject myZombie = Instantiate(zombie, spawnpoints[r].position, Quaternion.identity);    // 좀비 복제생성
        myZombie.GetComponent<Zombie>().type = probList[Random.Range(0, probList.Count)];
    }

}

[System.Serializable]
public class ZombieTypeProb
{
    public ZombieType type;
    public int probability;
}