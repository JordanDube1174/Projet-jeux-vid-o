using UnityEngine;

public class S_DétectionSol : MonoBehaviour
{
    public bool touchesol;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        touchesol = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
            touchesol = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
