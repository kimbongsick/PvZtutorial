using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{

    public int health;  // ü��
    private Tile parentTile; // �ڽ��� ��ġ�� Tile�� ����

    private void Start()
    {
        gameObject.layer = 9;   // Plant���̾� �Ҵ�
    }

    public void Initialize(Tile tile)
    {
        parentTile = tile; // Plant�� ������ �� Ÿ���� ����
    }

    public void Hit(int damage)     // ��Ʈ �ý���
    {
        health -= damage;
        if (health <= 0)
        {
            parentTile.hasPlant = false;
            Destroy(gameObject);
        }
    }

}