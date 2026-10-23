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

    public float jumpForce = 14f;

    private int jumpCount = 0;

    //Variable pour le wall jump

    public float wallSlideSpeed = 1.5f;     // Vitesse de glissade
    public float wallJumpForce = 30f;       // Force du wall jump
    public float wallJumpDirection = 1f;    // -1 = gauche, 1 = droite

    [SerializeField] private Transform wallCheck;             // Petit point sur le côté du joueur
    public float wallCheckDistance = 0.5f;  // Distance du raycast
    [SerializeField] private LayerMask whatIsWall;            // Layer des murs
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
        if (!value.isPressed)
        {
            jumpHeld = false;
            return;
        }

        jumpPressed = true;
        jumpHeld = true;

        int dir = GetWallJumpDirection();

        // WALL JUMP
        if (dir == 1)
        {
            rb.AddForce(new Vector2(-30f, 14f), ForceMode2D.Impulse);
            return;
        }
        else if (dir == -1)
        {
            rb.AddForce(new Vector2(30f, 14f), ForceMode2D.Impulse);
            return;
        }

        // SAUT NORMAL + DOUBLE JUMP
        if (jumpCount < 1)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpCount++;
            Debug.Log(jumpCount);
        }
    }

    private int GetWallJumpDirection()
    {
            if (Physics2D.Raycast(wallCheck.position, Vector2.right, 0.52f, whatIsWall))
            {
                return 1; // Mur à droite
            }
            else if (Physics2D.Raycast(wallCheck.position, Vector2.left, 0.52f, whatIsWall))
            {
                return -1; // Mur à gauche
            }
        
        return 0;
    }


    //Glisser sur le mur
    void WallSlide()
    {
        int dir = GetWallJumpDirection();

        if (dir != 0 && !détectionsol.touchesol)
        {

            // On ne touche PAS à la vitesse X ici
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                Mathf.Clamp(rb.linearVelocity.y, -wallSlideSpeed, float.MaxValue)
            );
        }
    }

    void OnDrawGizmos()
    {
        if (wallCheck == null) return;

        Gizmos.color = Color.red;
        // Raycast à droite
        Gizmos.DrawLine(wallCheck.position, wallCheck.position + Vector3.right * 0.52f);

        Gizmos.color = Color.blue;
        // Raycast à gauche
        Gizmos.DrawLine(wallCheck.position, wallCheck.position + Vector3.left * 0.52f);
    }

    // Update is called once per frame
    void Update()
    {
      WallSlide();

    }

    void FixedUpdate()
    {
        if (détectionsol.touchesol)
        {
            jumpCount = 0; // reset du double jump
        }

        // Déplacement horizontal physique
        float targetSpeed = direction.x * vitesse;
        float speedDiff = targetSpeed - rb.linearVelocity.x;

        // Force horizontale
        float accelRate = détectionsol.touchesol ? 50f : 20f;

        rb.AddForce(Vector2.right * speedDiff * accelRate);

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
