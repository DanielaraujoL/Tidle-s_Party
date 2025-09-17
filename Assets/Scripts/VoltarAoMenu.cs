using UnityEngine;
using UnityEngine.SceneManagement;

public class VoltarAoMenu : MonoBehaviour
{
    public float tempoAposCreditos = 10f;
    public string nomeCenaMenu = "MenuPrincipal";

    void Start()
    {
        Invoke("CarregarMenu", tempoAposCreditos);
    }

    void CarregarMenu()
    {
        SceneManager.LoadScene(nomeCenaMenu);
    }
}

