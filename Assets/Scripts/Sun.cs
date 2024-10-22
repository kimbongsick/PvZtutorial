using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{

    public float dropToYPos;   // ������ġ

    private float speed = 4f; // ���ϼӵ�

    private void Start()
    {
/*        transform.position = new Vector3(Random.Range(-4f, 8.35f), 6, 0);   // sun ��ġ ������ �ο�
        dropToYPos = Random.Range(2f, -3f);     // ������ġ ������ �ο�*/
        Destroy(gameObject, Random.Range(6, 12));   // �ı����� ����
    }

    private void Update()
    {
        if (transform.position.y > dropToYPos)     // ������ġ�� �����Ҷ�����
            transform.position -= new Vector3(0, speed * Time.deltaTime, 0);   // �����ӵ��� ����
    }
}
