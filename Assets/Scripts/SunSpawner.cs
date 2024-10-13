using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunSpawner : MonoBehaviour
{

    public GameObject sunObject;

    private void Start()
    {
        SpawnSun();
    }

    void SpawnSun()
    {
        Instantiate(sunObject);     // sun오브젝트 복제
        Invoke("SpawnSun", Random.Range(4, 10));    // 랜덤한 위치에 SpawnSun 함수 실행
    }
}
