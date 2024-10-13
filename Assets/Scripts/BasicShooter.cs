using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicShooter : MonoBehaviour
{

    public GameObject bullet;       // �Ѿ� ������Ʈ
    public Transform shootOrigin;   // �ѱ���ġ

    public float cooldown;          // �߻� ��Ÿ��

    private bool canShoot;          // �߻翩��

    public float range;             // ��Ÿ�
    public LayerMask shootMask;     // Ÿ�� ���̾��ũ
     
    private GameObject target;      // Ÿ�� ������Ʈ

    private void Start()
    {
        Invoke("ResetCooldown", cooldown);  // cooldown�ð� ���Ŀ� ��Ÿ�� �ʱ�ȭ����
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, range, shootMask);  

        if(hit.collider)    // Ÿ���� ������ ���� �浹�� ����
        {
            target = hit.collider.gameObject;   // �浹�� ������Ʈ�� ������ target������ 
            Shoot();    // �����Լ� ����
        }
    }

    void ResetCooldown()
    {
        canShoot = true;    // ���ݰ��� ����
    }

    void Shoot()
    {
        if (!canShoot)  // �߻� �Ұ��� ����
            return;
        canShoot = false;   // �ϴ� ��������
        Invoke("ResetCooldown", cooldown);  // cooldown�ð��Ŀ� ���ݽ���

        GameObject myBullet = Instantiate(bullet, shootOrigin.position, Quaternion.identity);   // �Ѿ� ������Ʈ ����
    }

}