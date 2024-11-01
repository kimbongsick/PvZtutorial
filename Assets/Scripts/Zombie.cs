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

    public LayerMask plantMask;     // ���ݴ�� ���̾�

    private float eatCooldown;       // ���� ��Ÿ��
    private bool canEat = true;     // ���� ���ɿ���
    public Plant targetPlant;       // ���ݴ�� Ŭ����

    private void Start()
    {
        health = type.health;
        speed = type.speed;
        damage = type.damage;
        range = type.range;
        eatCooldown = type.eatCooldown;

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

    public void Hit(int damage, bool freeze)     // �����Լ�
    {
        health -= damage;
        if (freeze)
            Freeze();
        if (health <= 0)
        {
            GetComponent<SpriteRenderer>().sprite = type.deathSprite;
            Destroy(gameObject, 1);
        }

    }

    void Freeze()
    {
        CancelInvoke("UnFreeze");
        GetComponent<SpriteRenderer>().color = Color.blue;
        speed = type.speed / 2;
        Invoke("UnFreeze", 5);
    }

    void UnFreeze() 
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        speed = type.speed;
    }
}
