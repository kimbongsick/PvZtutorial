using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{

    public float speed;     // 이동속도
    public int health;      // 체력
    public int damage;      // 공격력

    public float range;     // 공격범위
    public LayerMask plantMask;     // 공격대상 레이어

    public float eatCooldown;       // 공격 쿨타임
    private bool canEat = true;     // 공격 가능여부
    public Plant targetPlant;       // 공격대상 클래스

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, range, plantMask);

        if(hit.collider)    // 충돌시 실행
        {
            targetPlant = hit.collider.GetComponent<Plant>();   // 충돌한 오브젝트의 Plant 컴포넌트를 가져옴
            Eat();  // 공격함수 실행
        }
    }

    void Eat()
    {
        if (!canEat || !targetPlant)    // 공격 불가능 상태거나 대상이 없을시 실행끝
            return;
        canEat = false;     // 쿨타임을 위해서 공격중지
        Invoke("ResetEatCooldown", eatCooldown);    // 공격 쿨타임이후에 공격실행

        targetPlant.Hit(damage);    // 피격판정 함수 실행
    }

    void ResetEatCooldown()     // 쿨타임 초기화
    {
        canEat = true;
    }

    private void FixedUpdate()
    {
        if (!targetPlant)   // 공격대상이 없을시 이동
            transform.position -= new Vector3(speed, 0, 0);
    }

    public void Hit(int damage)     // 공격함수
    {
        health -= damage;
        if(health <= 0)
            Destroy(gameObject);
    }
}
