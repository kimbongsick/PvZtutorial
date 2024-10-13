using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantSlot : MonoBehaviour
{

    public Sprite plantSprite;      // �Ĺ� ��������Ʈ

    public GameObject plantObject;  // �Ĺ� ������Ʈ

    public int price;               // �Ĺ� ����

    public Image icon;              // �Ĺ� ������

    public Text priceText;          // UI ����Text

    private Gamemanager gms;        // ���ӸŴ���

    private void Start()
    {
        gms = GameObject.Find("GameManager").GetComponent<Gamemanager>();
        GetComponent<Button>().onClick.AddListener(BuyPlant);   // AddListener�� Button������Ʈ�� �̺�Ʈ�� �Ҵ�
    }

    private void BuyPlant()     // �Ĺ� ���� �ý���
    {
        if (gms.suns >= price && !gms.currentPlant)     // �Ĺ����� && ���� �������ִ� �Ĺ��� �ִ���
        {
            gms.suns -= price;
            gms.BuyPlant(plantObject, plantSprite);     // ���ӸŴ����κ��� ������Ʈ�� ����
        }
    }

    private void OnValidate() // Inspectorâ���� ��ũ��Ʈ�� �Ӽ��� ������ ������ ȣ��Ǵ� �Լ�.
    {
        if (plantSprite)
        {
            icon.enabled = true; 
            icon.sprite = plantSprite;
            priceText.text = price.ToString();
        }
        else
        {
            icon.enabled = false;
        }
    }
}
