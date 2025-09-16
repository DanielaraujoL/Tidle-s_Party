using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Configurações de Vida")]
    public int maxHealth = 6;  // Vida em "meios corações" (6 = 3 corações)
    private int currentHealth;

    [Header("UI")]
    public GameObject heartPrefab;     // Prefab de um coração (UI Image)
    public Sprite fullHeart;           // Sprite coração cheio
    public Sprite halfHeart;           // Sprite meio coração
    public Sprite emptyHeart;          // Sprite coração vazio
    public Transform heartsContainer;  // Container na UI para os corações

    private List<Image> hearts = new List<Image>();

    public LevelLoader levelLoader;


    void Start()
    {
        currentHealth = maxHealth;
        DrawHearts();
    }

    void DrawHearts()
    {
        // Limpa corações antigos
        foreach (Transform child in heartsContainer)
            Destroy(child.gameObject);

        hearts.Clear();

        // Cada coração = 2 pontos de vida
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

        // Chama a transição para a cena de morte
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

