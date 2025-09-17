using UnityEngine;
using UnityEngine.Rendering.Universal;
using System.Collections;

public class BlackoutManager : MonoBehaviour
{
    [Header("Configuração do blackout")]
    public float minTime = 1f;
    public float maxTime = 1f;
    public float lightDuration = 10f;

    [Header("Referência da luz do jogador")]
    public GameObject playerLightObject;

    private Light2D playerLight;

    void Start()
    {
        if (playerLightObject == null)
        {
            Debug.LogError("Player Light Object não foi atribuído!");
            return;
        }

        playerLight = playerLightObject.GetComponent<Light2D>();

        if (playerLight == null)
        {
            Debug.LogError("Light2D não encontrado no objeto atribuído!");
            return;
        }

        playerLight.enabled = false;
        StartCoroutine(TriggerBlackout());
    }

    IEnumerator TriggerBlackout()
    {
        while (true)
        {
            float waitTime = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(waitTime);

            Debug.Log("Blackout aconteceu!");

            if (playerLight != null)
            {
                playerLight.enabled = true;
                Debug.Log("Luz ativada!");

                yield return new WaitForSeconds(lightDuration);

                playerLight.enabled = false;
                Debug.Log("Luz desligada após blackout.");
            }
        }
    }
}



