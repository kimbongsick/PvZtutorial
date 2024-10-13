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
        Instantiate(sunObject);     // sun������Ʈ ����
        Invoke("SpawnSun", Random.Range(4, 10));    // ������ ��ġ�� SpawnSun �Լ� ����
    }
}
