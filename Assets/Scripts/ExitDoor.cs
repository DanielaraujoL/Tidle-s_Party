using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    public string requiredItemID = "ChaveSaida";
    public GameObject finalSceneTrigger;

    private bool playerNearby = false;

    void Update()
    {
        if (playerNearby && (Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("Submit")))
        {
            if (InventoryManager.Instance.HasItem(requiredItemID))
            {
                finalSceneTrigger.SetActive(true);
            }
            else
            {
                Debug.Log("Você precisa da chave para sair.");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerNearby = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerNearby = false;
    }
}

