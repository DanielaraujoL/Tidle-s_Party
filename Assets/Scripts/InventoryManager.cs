using UnityEngine;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    private HashSet<string> collectedItems = new HashSet<string>();

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddItem(string itemID)
    {
        collectedItems.Add(itemID);
        UIInventoryBar.Instance.ShowItem(itemID);
    }

    public bool HasItem(string itemID)
    {
        return collectedItems.Contains(itemID);
    }
}
