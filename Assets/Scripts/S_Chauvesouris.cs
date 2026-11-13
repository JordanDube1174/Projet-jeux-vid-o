using System.Collections;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class S_Chauvesouris : MonoBehaviour
{
    

    Vector3 direction;

    
    [SerializeField]
    public Transform Joueur;

    

    float Xvelocity = 0;
    float Yvelocity = 0;
    float x = 0;
    float y = 0;

    void Start()
    {
        StartCoroutine(Upndown());
        StartCoroutine(LeftRight());
    }

    IEnumerator LeftRight()
    {
        while (true)
        {
            while (transform.position.x < Joueur.transform.position.x)
            {
                Xvelocity += 0.0001f;
                yield return new WaitForSeconds(0.005f);
                if(Xvelocity > 0.01)
                {
                    Xvelocity = 0.01f;
                }
            }
            while (transform.position.x > Joueur.transform.position.x)
            {
                Xvelocity -= 0.0001f;
                yield return new WaitForSeconds(0.005f);
                if (Xvelocity < -0.01)
                {
                    Xvelocity = -0.01f;
                }
            }

        }

    }
    IEnumerator Upndown()
    {
        while (true)
        {
            while (Yvelocity < 0.01f || transform.position.y < Joueur.transform.position.y +2)
            {
                Yvelocity += 0.0001f;
                yield return new WaitForSeconds(0.005f);
                if (Yvelocity > 0.01)
                {
                    Yvelocity = 0.01f;
                }
            }
            while (Yvelocity > -0.01f || transform.position.y > Joueur.transform.position.y +2)
            {
                Yvelocity -= 0.0001f;
                yield return new WaitForSeconds(0.005f);
                if (Xvelocity < -0.01)
                {
                    Xvelocity = -0.01f;
                }
            }

        }

    }



        void Update()
    {


        y += Yvelocity;
       
        x += Xvelocity;
        transform.position = new Vector3(x, y, transform.position.z);
    }
}
