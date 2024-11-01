using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;  // ���ݷ�

    public float speed = 2f;  // �Ѿ˼ӵ�

    public bool freeze;

    private void Start()
    {
        Destroy(gameObject, 10);
    }

    private void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);   // ź�� �̵�
    }

    private void OnTriggerEnter2D(Collider2D other)     // �浹�� ����� ������Ʈ
    {
        if(other.TryGetComponent<Zombie>(out Zombie zombie))    // ���� ������Ʈ�� ������ ��� ������Ʈ������ ����
        {
            zombie.Hit(damage, freeze);     // �ǰ����� ����
            Destroy(gameObject);    // �Ѿ� �ı�
        }
    }
}
