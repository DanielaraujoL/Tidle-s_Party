using UnityEngine;
using UnityEngine.UI;

public class UIInventoryBar : MonoBehaviour
{
    public static UIInventoryBar Instance;
    public Image itemSlot;
    public Sprite chaveSprite;

    void Awake()
    {
        Instance = this;
        itemSlot.enabled = false;
    }

    public void ShowItem(string itemID)
    {
        if (itemID == "ChaveSaida")
        {
            itemSlot.sprite = chaveSprite;
            itemSlot.enabled = true;
        }
    }
}

