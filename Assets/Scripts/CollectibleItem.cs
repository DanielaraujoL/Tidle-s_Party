using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public string itemID = "ChaveSaida";
    public GameObject promptUI;

    private bool playerNearby = false;

    void Start()
    {
        if (promptUI != null)
            promptUI.SetActive(false);
    }

    void Update()
    {
        if (playerNearby && (Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("Submit")))
        {
            InventoryManager.Instance.AddItem(itemID);
            if (promptUI != null)
                promptUI.SetActive(false);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
            if (promptUI != null)
                promptUI.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            if (promptUI != null)
                promptUI.SetActive(false);
        }
    }
}

