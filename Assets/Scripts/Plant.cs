using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{

    public int health;  // 체력
    private Tile parentTile; // 자신이 위치한 Tile의 참조

    private void Start()
    {
        gameObject.layer = 9;   // Plant레이어 할당
    }

    public void Initialize(Tile tile)
    {
        parentTile = tile; // Plant가 생성될 때 타일을 연결
    }

    public void Hit(int damage)     // 히트 시스템
    {
        health -= damage;
        if (health <= 0)
        {
            parentTile.hasPlant = false;
            Destroy(gameObject);
        }
    }

}