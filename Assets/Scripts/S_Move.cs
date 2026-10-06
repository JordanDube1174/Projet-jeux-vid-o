using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class S_Move : MonoBehaviour
{
    //Le script de détection du sol
    public S_DétectionSol détectionsol;

    //Variables pour le mouvement horizontal
    Vector2 direction = Vector2.zero;
    float vitesse = 6f;

    //Rigidbody du joueur
    private Rigidbody2D rb;

    // Variables pour le saut
    private bool jumpPressed;
    private bool jumpHeld;

    public float jumpForce = 12f;

    //Variable pour le wall jump

    public float wallSlideSpeed = 1.5f;     // Vitesse de glissade
    public float wallJumpForce = 12f;       // Force du wall jump
    public float wallJumpDirection = 1f;    // -1 = gauche, 1 = droite

    [SerializeField] private Transform wallCheck;             // Petit point sur le côté du joueur
    public float wallCheckDistance = 0.2f;  // Distance du raycast
    [SerializeField] private LayerMask whatIsWall;            // Layer des murs
    bool isWallSliding;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //Pour courir
    void OnSprint(InputValue value)
    {
        if (value.isPressed)
        {
            vitesse = 15f;
        }
        else
        {
            vitesse = 6f;
        }
    }

    //Pour se déplacer verticalement
    void OnMove(InputValue value)
    {
        direction = value.Get<Vector2>();
    }

    //Pour Sauter et wall jump

    void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            jumpPressed = true;
            jumpHeld = true;

            // Wall Jump
            if (isWallSliding)
            {
                float dir = transform.localScale.x > 0 ? -1 : 1;

                rb.linearVelocity = new Vector2(dir * wallJumpForce, wallJumpForce);

                return;
            }
        }
        else
        {
            jumpHeld = false;
        }
    }

    //Vérifie si le joueur touche un mur
    private bool CheckWall()
    {
        Vector2 dir = transform.localScale.x > 0 ? Vector2.right : Vector2.left;

        return Physics2D.Raycast(wallCheck.position, dir, wallCheckDistance, whatIsWall);
    }

    //Glisser sur le mur
    void WallSlide()
    {
        if (CheckWall() && !détectionsol.touchesol)
        {
            isWallSliding = true;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, Mathf.Clamp(rb.linearVelocity.y, -wallSlideSpeed, float.MaxValue));
        }
        else
        {
            isWallSliding = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
            WallSlide();

    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(direction.x * vitesse, rb.linearVelocity.y);

        //Début du saut
        if (jumpPressed && détectionsol.touchesol)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
        jumpPressed = false;

        // Saut variable
        if (rb.linearVelocity.y > 0) // le joueur monte
        {
            if (!jumpHeld)
            {
                // relâché tôt → chute rapide
                rb.linearVelocity = new Vector2(rb.linearVelocity.x,0);
            }
        }
    }
}
