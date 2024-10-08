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
        GetComponent<Button>().onClick.AddListener(BuyPlant);   // AddListener를 Button컴포넌트에 이벤트를 할당
    }

    private void BuyPlant()
    {
        if (gms.suns >= price && !gms.currentPlant)
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
