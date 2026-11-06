using UnityEngine;

public class DetecteurAraignée : MonoBehaviour
{
    public S_Araignée ScriptDepl;


    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (ScriptDepl.direction == Vector2.right)
            ScriptDepl.direction = Vector2.down;
        else if (ScriptDepl.direction == Vector2.down)
            ScriptDepl.direction = Vector2.left;
        else if (ScriptDepl.direction == Vector2.left)
            ScriptDepl.direction = Vector2.up;
        else if (ScriptDepl.direction == Vector2.up)
            ScriptDepl.direction = Vector2.right;
       
        




        // Start is called once before the first execution of Update after the MonoBehaviour is created



    }
    void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
}
