using UnityEngine;

public class S_Compagnon : MonoBehaviour
{
    public Transform joueur;
    public float vitesse = 6f;
    public float distanceSuivi = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, joueur.position);

        if (distance > distanceSuivi)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                joueur.position,
                vitesse * Time.deltaTime
            );
        }
    }
}
