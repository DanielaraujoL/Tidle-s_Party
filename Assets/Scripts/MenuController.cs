using UnityEngine;

public class MenuControlador : MonoBehaviour
{
    public GameObject levelLoader;
    public GameObject menuPrincipal;

    void Start()
    {
        if (levelLoader != null)
            levelLoader.SetActive(false);
    }

    public void AtivarLevelLoader()
    {
        if (levelLoader != null && !levelLoader.activeSelf)
        {
            levelLoader.SetActive(true);
        }
    }

    public void SelecionarModoHistoria()
    {
        AtivarLevelLoader();
        levelLoader.GetComponent<LevelLoader>().CarregarFase("CasaH");
    }

    public void SelecionarModoSobrevivencia()
    {
        AtivarLevelLoader();
        levelLoader.GetComponent<LevelLoader>().CarregarFase("Casa");
    }
}

