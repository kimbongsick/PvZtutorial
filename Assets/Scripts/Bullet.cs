using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;  // 공격력

    public float speed = 4f;  // 총알속도

    private void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);   // 탄알 이동
    }

    private void OnTriggerEnter2D(Collider2D other)     // 충돌한 대상의 오브젝트
    {
        if(other.TryGetComponent<Zombie>(out Zombie zombie))    // 좀비 컴포넌트를 가져와 대상 오브젝트변수로 실행
        {
            zombie.Hit(damage);     // 피격판정 실행
            Destroy(gameObject);    // 총알 파괴
        }
    }
}
