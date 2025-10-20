using UnityEngine;

public class MenuEntrada : MonoBehaviour
{
    public GameObject bannerInicial;
    public GameObject menuPrincipal;

    void Start()
    {
        bannerInicial.SetActive(true);
        menuPrincipal.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) // Enter
        {
            bannerInicial.SetActive(false);
            menuPrincipal.SetActive(true);
        }
    }
}

