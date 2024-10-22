using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{

    public float dropToYPos;   // 낙하위치

    private float speed = 4f; // 낙하속도

    private void Start()
    {
/*        transform.position = new Vector3(Random.Range(-4f, 8.35f), 6, 0);   // sun 위치 랜덤값 부여
        dropToYPos = Random.Range(2f, -3f);     // 낙하위치 랜덤값 부여*/
        Destroy(gameObject, Random.Range(6, 12));   // 파괴시점 랜덤
    }

    private void Update()
    {
        if (transform.position.y > dropToYPos)     // 낙하위치에 도달할때까지
            transform.position -= new Vector3(0, speed * Time.deltaTime, 0);   // 일정속도로 낙하
    }
}
