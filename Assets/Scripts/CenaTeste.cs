using UnityEngine;
using UnityEngine.SceneManagement;

public class CenaTeste : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Debug.Log("Forçando troca para FinalBom...");
            SceneManager.LoadScene("FinalBom");
        }
    }
}

