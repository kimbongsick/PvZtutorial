using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{

    public int health;  // ü��

    private void Start()
    {
        gameObject.layer = 9;   // Plant���̾� �Ҵ�
    }

    public void Hit(int damage)     // ��Ʈ �ý���
    {
        health -= damage;
        if(health <= 0)
            Destroy(gameObject);
    }

}
