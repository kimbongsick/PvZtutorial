using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;  // ���ݷ�

    public float speed = 4f;  // �Ѿ˼ӵ�

    private void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);   // ź�� �̵�
    }

    private void OnTriggerEnter2D(Collider2D other)     // �浹�� ����� ������Ʈ
    {
        if(other.TryGetComponent<Zombie>(out Zombie zombie))    // ���� ������Ʈ�� ������ ��� ������Ʈ������ ����
        {
            zombie.Hit(damage);     // �ǰ����� ����
            Destroy(gameObject);    // �Ѿ� �ı�
        }
    }
}
