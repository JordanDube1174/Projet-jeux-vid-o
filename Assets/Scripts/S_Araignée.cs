using UnityEngine;

public class S_Araignée : MonoBehaviour
{
    public float vitesse = 5f;

    public Vector2 direction = Vector2.right;

    public DetecteurAraignée DetAr;



    void Update()
    {
        transform.position += (Vector3)(direction * vitesse * Time.deltaTime);

        if (direction == Vector2.right)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        if (direction == Vector2.up)
            transform.rotation = Quaternion.Euler(0, 0, 90);
        if (direction == Vector2.left)
            transform.rotation = Quaternion.Euler(0, 0, 180);
        if (direction == Vector2.down)
            transform.rotation = Quaternion.Euler(0, 0, 270);
        
    }
}
