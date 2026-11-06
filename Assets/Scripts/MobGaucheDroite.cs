using UnityEngine;

public class MobGaucheDroite : MonoBehaviour
{
    float vitesse = 1f;

    public Vector2 direction = Vector2.right;

    void Update()
    {
        transform.position += (Vector3)(direction * vitesse * Time.deltaTime);
    }
}
