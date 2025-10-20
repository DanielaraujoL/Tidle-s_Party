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

        if (itemSlot != null)
        {
            itemSlot.enabled = false;
        }
        else
        {
            Debug.LogWarning("UIInventoryBar: 'itemSlot' não foi atribuído no Inspector.");
        }

        if (chaveSprite == null)
        {
            Debug.LogWarning("UIInventoryBar: 'chaveSprite' não foi atribuído no Inspector.");
        }
    }

    public void ShowItem(string itemID)
    {
        if (itemID == "ChaveSaida")
        {
            if (itemSlot != null && chaveSprite != null)
            {
                itemSlot.sprite = chaveSprite;
                itemSlot.enabled = true;
            }
            else
            {
                Debug.LogWarning("UIInventoryBar: itemSlot ou chaveSprite está nulo. Verifique o Inspector.");
            }
        }
    }
}


