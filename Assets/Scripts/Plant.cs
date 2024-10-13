using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{

    public int health;  // 체력

    private void Start()
    {
        gameObject.layer = 9;   // Plant레이어 할당
    }

    public void Hit(int damage)     // 히트 시스템
    {
        health -= damage;
        if(health <= 0)
            Destroy(gameObject);
    }

}
