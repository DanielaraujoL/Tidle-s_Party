using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Configurações de Velocidade")]
    [SerializeField] private float speed = 5f;   // Velocidade base do jogador
    private float currentSpeed;
    private float lastHorizontal = 1f;           // 1 = olhando para direita, -1 = esquerda

    // Input
    private float horizontal;
    private float vertical;

    // Controle
    public bool IsMoving = false;

    // Componentes
    private Rigidbody2D rb;
    private Animator anim;

    // Movimento
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentSpeed = speed;
    }

    void Update()
    {
        // --- Captura input ---
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        Vector2 input = new Vector2(horizontal, vertical);

        // Gamepad D-Pad
        if (Gamepad.current != null)
        {
            Vector2 dpad = Gamepad.current.dpad.ReadValue();
            if (dpad != Vector2.zero) input = dpad;
        }

        // D-Pad digital opcional
        float dpadX = Input.GetAxisRaw("DPadX");
        float dpadY = Input.GetAxisRaw("DPadY");
        if (dpadX != 0) input.x = dpadX;
        if (dpadY != 0) input.y = dpadY;

        // --- Normaliza movimento ---
        // --- Trava movimento para 4 direções ---
        if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
        {
            movement = new Vector2(Mathf.Sign(input.x), 0f);
        }
        else if (Mathf.Abs(input.y) > Mathf.Abs(input.x))
        {
            movement = new Vector2(0f, Mathf.Sign(input.y));
        }
        else
        {
            movement = Vector2.zero;
        }

        IsMoving = movement != Vector2.zero;

        // --- Atualiza Animator ---
        anim.SetFloat("MoveX", Mathf.Round(movement.x));
        anim.SetFloat("MoveY", Mathf.Round(movement.y));
        anim.SetBool("IsMoving", IsMoving);

        if (IsMoving)
        {
            anim.SetFloat("LastMoveX", Mathf.Round(movement.x));
            anim.SetFloat("LastMoveY", Mathf.Round(movement.y));
        }

        // --- Flip horizontal confiável ---
        // Atualiza lastHorizontal apenas quando houver movimento horizontal significativo
        if (Mathf.Abs(movement.x) > 0.1f)
            lastHorizontal = Mathf.Sign(movement.x);

        // Aplica flip usando lastHorizontal
        transform.localScale = new Vector3(lastHorizontal, 1, 1);
    }

    void FixedUpdate()
    {
        // Aplica movimento físico
        ApplyMovement();
    }

    void ApplyMovement()
    {
        rb.linearVelocity = movement * currentSpeed;
    }
}
