using UnityEngine;

public class S_GD_DetMur : MonoBehaviour
{

    public MobGaucheDroite ScriptDepl;
    void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (ScriptDepl.direction == Vector2.right)
        {
            ScriptDepl.direction = Vector2.left;
            ScriptDepl.transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
        }
        else
        {
            ScriptDepl.direction = Vector2.right;
            ScriptDepl.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        }
    }
  

    void Update()
    {

    }
}
