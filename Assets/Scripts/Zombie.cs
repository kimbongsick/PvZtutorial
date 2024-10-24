using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{

    private float speed;     // �̵��ӵ�
    private int health;      // ü��
    private int damage;      // ���ݷ�

    private float range;     // ���ݹ���

    public ZombieType type;  // �ʱ�ȭ�� ZombieType Ŭ�������� ����

    private LayerMask plantMask;     // ���ݴ�� ���̾�

    private float eatCooldown;       // ���� ��Ÿ��
    private bool canEat = true;     // ���� ���ɿ���
    public Plant targetPlant;       // ���ݴ�� Ŭ����

    private void Start()
    {
        health = type.health;
        speed = type.speed;
        damage = type.damage;
        range = type.range;

        GetComponent<SpriteRenderer>().sprite = type.sprite;
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, range, plantMask);

        if(hit.collider)    // �浹�� ����
        {
            targetPlant = hit.collider.GetComponent<Plant>();   // �浹�� ������Ʈ�� Plant ������Ʈ�� ������
            Eat();  // �����Լ� ����
        }

        if(health == 1)
        {
            GetComponent<SpriteRenderer>().sprite = type.deathSprite;
        }
    }

    void Eat()
    {
        if (!canEat || !targetPlant)    // ���� �Ұ��� ���°ų� ����� ������ ���ೡ
            return;
        canEat = false;     // ��Ÿ���� ���ؼ� ��������
        Invoke("ResetEatCooldown", eatCooldown);    // ���� ��Ÿ�����Ŀ� ���ݽ���

        targetPlant.Hit(damage);    // �ǰ����� �Լ� ����
    }

    void ResetEatCooldown()     // ��Ÿ�� �ʱ�ȭ
    {
        canEat = true;
    }

    private void FixedUpdate()
    {
        if (!targetPlant)   // ���ݴ���� ������ �̵�
            transform.position -= new Vector3(speed, 0, 0);
    }

    public void Hit(int damage)     // �����Լ�
    {
        health -= damage;
        if(health <= 0)
            Destroy(gameObject);
    }
}
