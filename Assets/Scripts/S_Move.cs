using UnityEngine;
using UnityEngine.InputSystem;

public class S_Move : MonoBehaviour
{
    Vector2 direction = Vector2.zero;
    float vitesse = 6f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

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

    void OnMove(InputValue value)
    {
        direction = value.Get<Vector2>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(direction.x, direction.y, 0) * vitesse * Time.deltaTime;
    }
}
