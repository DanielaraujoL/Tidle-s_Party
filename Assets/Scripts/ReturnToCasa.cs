using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class ReturnToCasa : MonoBehaviour
{
    public LevelLoader levelLoader;
    public string nomeCenaCasa = "Casa"; // nome exato da cena da casa

    void Update()
    {
        // Tecla Enter no teclado
        if (Keyboard.current != null && Keyboard.current.enterKey.wasPressedThisFrame ||
            // Botão Start no controle
            Gamepad.current != null && Gamepad.current.startButton.wasPressedThisFrame)
        {
            VoltarParaCasa();
        }
    }

    void VoltarParaCasa()
    {
        Time.timeScale = 1f;

        if (levelLoader != null)
        {
            levelLoader.CarregarFase(nomeCenaCasa);
        }
        else
        {
            SceneManager.LoadScene(nomeCenaCasa);
        }
    }
}

