using UnityEngine;

public class S_ControleurMainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void PlayButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Projet jeux");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
