using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalSceneTrigger : MonoBehaviour
{
    public string finalSceneName = "FinalBom";

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(finalSceneName);
        }
    }
}

