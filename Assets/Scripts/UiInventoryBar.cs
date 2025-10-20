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
            Debug.LogWarning("UIInventoryBar: 'itemSlot' n�o foi atribu�do no Inspector.");
        }

        if (chaveSprite == null)
        {
            Debug.LogWarning("UIInventoryBar: 'chaveSprite' n�o foi atribu�do no Inspector.");
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
                Debug.LogWarning("UIInventoryBar: itemSlot ou chaveSprite est� nulo. Verifique o Inspector.");
            }
        }
    }
}


