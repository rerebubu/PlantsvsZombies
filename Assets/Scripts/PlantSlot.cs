using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.Build.Content;


public class PlantSlot : MonoBehaviour
{
    
    public Sprite plantSprite;

    public GameObject plantObject;

    public int price;

    public Image icon;
    public TextMeshProUGUI priceText;

    private Gamemanager gms;

    private void Start() {
        gms = GameObject.Find("GameManager").GetComponent<Gamemanager>();
        GetComponent<Button>().onClick.AddListener(BuyPlant);
    }

    private void BuyPlant()
    {
        if(gms.suns >= price && !gms.currentPlant) {
            gms.suns -= price;
            gms.BuyPlant(plantObject, plantSprite);
        }
    }

    private void OnValidate()
    {
        if (icon && priceText)
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
}
