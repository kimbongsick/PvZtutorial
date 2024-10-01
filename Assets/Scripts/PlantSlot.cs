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
        GetComponent<Button>().onClick.AddListener(BuyPlant);
    }

    private void BuyPlant()
    {
        gms.BuyPlant(plantObject, plantSprite);
    }

    private void OnValidate()
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
