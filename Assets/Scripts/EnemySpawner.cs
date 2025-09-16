using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [Header("Configuração de Spawn")]
    [Range(0f, 1f)] public float spawnChance = 0.5f;
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public int enemyCount;

    private bool hasSpawned = false;
    private GameObject currentEnemy;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (hasSpawned) return;

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entrou no trigger!");

            float roll = Random.value;
            Debug.Log($"Chance de spawn: {spawnChance}, valor sorteado: {roll}");

            if (roll <= spawnChance)
            {
                if (enemyCount >= 1)
                {
                    hasSpawned = false;
                    enemyCount = 0;
                }
                else
                {
                    currentEnemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
                    hasSpawned = true;
                    enemyCount += 1;
                    Debug.Log("Inimigo spawnado!");

                    // Inicia a coroutine para despawn
                    StartCoroutine(DespawnEnemyAfterDelay(currentEnemy));
                }
            }
            else
            {
                Debug.Log("Não spawnou dessa vez.");
            }
        }
    }

    IEnumerator DespawnEnemyAfterDelay(GameObject enemy)
    {
        float despawnTime = Random.Range(5f, 30f);
        Debug.Log($"Inimigo será destruído em {despawnTime} segundos.");
        yield return new WaitForSeconds(despawnTime);

        if (enemy != null)
        {
            Destroy(enemy);
            Debug.Log("Inimigo destruído.");
            hasSpawned = false;
            enemyCount = 0;
        }
    }
}

