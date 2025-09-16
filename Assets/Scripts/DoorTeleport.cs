using UnityEngine;

public class DoorTeleport : MonoBehaviour
{
    [Header("Para onde o player será teleportado")]
    public Transform targetDoor; // arraste aqui a outra porta no Inspector

    private bool isPlayerNearby = false;
    private Transform player;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            player = other.transform;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            player = null;
        }
    }

    void Update()
    {
        if (isPlayerNearby && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton0)))
        {
            if (player != null && targetDoor != null)
            {
                player.position = targetDoor.position;
            }
        }

        
    }
}
