using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    public GameObject currentPlant;     // ������ �Ĺ�
    public Sprite currentPlantSprite;   // ������ �Ĺ� ��������Ʈ
    public Transform tiles;             // Ÿ��

    public LayerMask tileMask;          // Ÿ�� ���̾��Ʈ

    public int suns = 100;              // ����
    public Text sunText;                // ���� �ؽ�Ʈ

    public LayerMask sunMask;
    
    public void BuyPlant(GameObject plant, Sprite sprite)   // ���Ž� PlantSlot ������Ʈ�κ��� plant�� sprite�� ���޹���
    {
        currentPlant = plant;
        currentPlantSprite = sprite;
    }

    private void Update()
    {
        sunText.text = suns.ToString();

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, tileMask);  // ȭ��� ���콺 Ŭ���� ��ǥ��(�Ĺ� ��ġ��)

        foreach(Transform tile in tiles)    // loop�� ������ tile�� SpriteRenderer�� false�� �ٲ�
            tile.GetComponent<SpriteRenderer>().enabled = false;

        if(hit.collider && currentPlant)    // �Ĺ��� ���� ���¿���, Ÿ�Ͽ� ������Ʈ ��ġ
        {
            hit.collider.GetComponent<SpriteRenderer>().sprite = currentPlantSprite;    // Ÿ�� ��������Ʈ�� Plant������Ʈ Sprite�� ����
            hit.collider.GetComponent<SpriteRenderer>().enabled = true;                 // SpriteRenderer�� true�ٲ� ���̵��� �缳��

            if (Input.GetMouseButtonDown(0) && !hit.collider.GetComponent<Tile>().hasPlant)     // �Ĺ��� ���� Ÿ�Ͽ� ���콺 ��Ŭ���� ����
            {
                Instantiate(currentPlant, hit.collider.transform.position, Quaternion.identity);    // �Ĺ��� �����Ͽ� ��ġ
                hit.collider.GetComponent<Tile>().hasPlant = true;  // Ÿ�Ͽ� �Ĺ���ġ���θ� true�� ����
                currentPlant = null;        // ����ִ� �Ĺ��� ����
                currentPlantSprite = null;  // ��������Ʈ�� ����
            }
        }

        RaycastHit2D sunhit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, sunMask); // ȭ��� ���콺 Ŭ���� ��ǥ��(���� ȹ���)

        if (sunhit.collider)    // ���� ȹ��
        {
            if (Input.GetMouseButtonDown(0))
            {
                suns += 25;
                Destroy(sunhit.collider.gameObject);
            }
        }
    }
}
