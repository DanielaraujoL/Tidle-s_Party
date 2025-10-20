using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject itemPrefab;
    public Transform[] pontosDeSpawn;

    void Start()
    {
        SpawnItemAleatorio();
    }

    void SpawnItemAleatorio()
    {
        if (pontosDeSpawn.Length == 0 || itemPrefab == null)
        {
            Debug.LogWarning("ItemSpawner: faltam pontos de spawn ou prefab.");
            return;
        }

        int index = Random.Range(0, pontosDeSpawn.Length);

        // Aplica o offset vertical diretamente na posição de spawn
        Vector3 posicaoComOffset = pontosDeSpawn[index].position + new Vector3(0, 0.5f, 0);

        Instantiate(itemPrefab, posicaoComOffset, Quaternion.identity);
    }
}

