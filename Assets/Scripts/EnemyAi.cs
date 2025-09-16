using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Configurações de Movimento")]
    public float speed = 3f;
    private Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;

    [Header("Detecção")]
    public float detectionRange = 5f;

    [Header("Ataque")]
    public int damage = 1; // meio coração
    public float attackCooldown = 1f; // tempo entre ataques
    private float lastAttackTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player != null)
        {
            float distance = Vector2.Distance(transform.position, player.position);

            if (distance <= detectionRange)
            {
                Vector2 direction = (player.position - transform.position).normalized;
                movement = direction;
            }
            else
            {
                movement = Vector2.zero; // parado se player sair do alcance
            }
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement * speed;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Time.time >= lastAttackTime + attackCooldown)
            {
                PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(damage); // tira meio coração
                }
                lastAttackTime = Time.time;
            }
        }
    }
}




