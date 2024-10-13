using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicShooter : MonoBehaviour
{

    public GameObject bullet;       // 총알 오브젝트
    public Transform shootOrigin;   // 총구위치

    public float cooldown;          // 발사 쿨타임

    private bool canShoot;          // 발사여부

    public float range;             // 사거리
    public LayerMask shootMask;     // 타겟 레이어마스크
     
    private GameObject target;      // 타겟 오브젝트

    private void Start()
    {
        Invoke("ResetCooldown", cooldown);  // cooldown시간 이후에 쿨타임 초기화진행
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, range, shootMask);  

        if(hit.collider)    // 타겟이 범위에 들어와 충돌시 실행
        {
            target = hit.collider.gameObject;   // 충돌한 오브젝트의 정보를 target변수로 
            Shoot();    // 공격함수 실행
        }
    }

    void ResetCooldown()
    {
        canShoot = true;    // 공격가능 실행
    }

    void Shoot()
    {
        if (!canShoot)  // 발사 불가시 종료
            return;
        canShoot = false;   // 일단 공격중지
        Invoke("ResetCooldown", cooldown);  // cooldown시간후에 공격실행

        GameObject myBullet = Instantiate(bullet, shootOrigin.position, Quaternion.identity);   // 총알 오브젝트 복제
    }

}