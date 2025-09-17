using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerLightFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0, 0, -1);
    private Light2D playerLight;

    void Awake()
    {
        playerLight = GetComponent<Light2D>();

        if (playerLight == null)
        {
            Debug.LogError("Light2D não encontrado no objeto!");
            return;
        }

        playerLight.enabled = false;
    }

    void Update()
    {
        if (player != null)
        {
            transform.position = player.position + offset;
        }
    }
}


