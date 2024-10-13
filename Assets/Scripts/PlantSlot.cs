using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantSlot : MonoBehaviour
{

    public Sprite plantSprite;      // 식물 스프라이트

    public GameObject plantObject;  // 식물 오브젝트

    public int price;               // 식물 가격

    public Image icon;              // 식물 아이콘

    public Text priceText;          // UI 가격Text

    private Gamemanager gms;        // 게임매니저

    private void Start()
    {
        gms = GameObject.Find("GameManager").GetComponent<Gamemanager>();
        GetComponent<Button>().onClick.AddListener(BuyPlant);   // AddListener를 Button컴포넌트에 이벤트를 할당
    }

    private void BuyPlant()     // 식물 구매 시스템
    {
        if (gms.suns >= price && !gms.currentPlant)     // 식물가격 && 현재 가지고있는 식물이 있는지
        {
            gms.suns -= price;
            gms.BuyPlant(plantObject, plantSprite);     // 게임매니저로부터 오브젝트를 전달
        }
    }

    private void OnValidate() // Inspector창에서 스크립트의 속성이 수정될 때마다 호출되는 함수.
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
