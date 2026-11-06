using UnityEngine;

public class S_Araigné_DetMur : MonoBehaviour
{

    public S_Araignée ScriptDepl;
    void Start()
    {
        
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (ScriptDepl.direction == Vector2.right)
            ScriptDepl.direction = Vector2.up;
        else if (ScriptDepl.direction == Vector2.up)
            ScriptDepl.direction = Vector2.left;
        else if (ScriptDepl.direction == Vector2.left)
            ScriptDepl.direction = Vector2.down;
        else if (ScriptDepl.direction == Vector2.down)
            ScriptDepl.direction = Vector2.left;

    }
    void Update()
    {
        
    }
}
