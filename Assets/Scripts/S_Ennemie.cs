using UnityEngine;

public class S_Ennemie : MonoBehaviour
{
    public int health = 100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log("Enemy HP: " + health);

        if (health <= 0)
            Die();
    }

    private void Die()
    {
        Debug.Log("Enemy died!");
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
