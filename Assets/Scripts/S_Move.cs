using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class S_Move : MonoBehaviour
{
    public S_DétectionSol détectionsol; //Le script de détection du sol
    Vector2 direction = Vector2.zero;
    float vitesse = 6f;

    private Rigidbody2D rb;
    private bool jumpPressed;
    private bool jumpHeld;

    public float jumpForce = 12f;


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

    //Pour Sauter

    void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            Debug.Log("true");
            jumpPressed = true;   // début du saut
            jumpHeld = true;      // touche maintenue
        }
        else
        {
            Debug.Log("false");
            jumpHeld = false;     // touche relâchée
        }
    }




    // Update is called once per frame
    void Update()
    {
        
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
                Debug.Log("allo");
                rb.linearVelocity = new Vector2(rb.linearVelocity.x,0);
            }
        }
    }
}
