using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantSlot : MonoBehaviour
{

    public Sprite plantSprite;

    public GameObject plantObject;

    public int price;

    public Image icon;

    public Text priceText;

    private Gamemanager gms;

    private void Start()
    {
        gms = GameObject.Find("GameManager").GetComponent<Gamemanager>();
        GetComponent<Button>().onClick.AddListener(BuyPlant);   // AddListener�� Button������Ʈ�� �̺�Ʈ�� �Ҵ�
    }

    private void BuyPlant()
    {
        if (gms.suns >= price && !gms.currentPlant)
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
