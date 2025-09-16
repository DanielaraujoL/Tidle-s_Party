using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Configura��es de Vida")]
    public int maxHealth = 6;  // Vida em "meios cora��es" (6 = 3 cora��es)
    private int currentHealth;

    [Header("UI")]
    public GameObject heartPrefab;     // Prefab de um cora��o (UI Image)
    public Sprite fullHeart;           // Sprite cora��o cheio
    public Sprite halfHeart;           // Sprite meio cora��o
    public Sprite emptyHeart;          // Sprite cora��o vazio
    public Transform heartsContainer;  // Container na UI para os cora��es

    private List<Image> hearts = new List<Image>();

    public LevelLoader levelLoader;


    void Start()
    {
        currentHealth = maxHealth;
        DrawHearts();
    }

    void DrawHearts()
    {
        // Limpa cora��es antigos
        foreach (Transform child in heartsContainer)
            Destroy(child.gameObject);

        hearts.Clear();

        // Cada cora��o = 2 pontos de vida
        int totalHearts = Mathf.CeilToInt(maxHealth / 2f);

        for (int i = 0; i < totalHearts; i++)
        {
            GameObject heart = Instantiate(heartPrefab, heartsContainer);
            Image heartImage = heart.GetComponent<Image>();
            hearts.Add(heartImage);
        }

        UpdateHearts();
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Count; i++)
        {
            int heartHealth = currentHealth - (i * 2);

            if (heartHealth >= 2)
                hearts[i].sprite = fullHeart;
            else if (heartHealth == 1)
                hearts[i].sprite = halfHeart;
            else
                hearts[i].sprite = emptyHeart;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateHearts();

        Debug.Log("Player tomou dano! Vida atual: " + currentHealth);

        if (currentHealth <= 0)
            Die();
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateHearts();
    }
    void Die()
    {
        Debug.Log("Player morreu!");

        // Pausa o jogo
        Time.timeScale = 1f; // importante: resetar antes de trocar de cena

        // Chama a transi��o para a cena de morte
        if (levelLoader != null)
        {
            StartCoroutine(levelLoader.CarregarFase("DeathScene"));


        }
        else
        {
            SceneManager.LoadScene("DeathScene"); // fallback direto
        }
    }



}

