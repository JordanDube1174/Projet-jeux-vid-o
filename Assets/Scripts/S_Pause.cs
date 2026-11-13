using UnityEngine;
using UnityEngine.InputSystem;

public class S_Pause : MonoBehaviour
{

    public GameObject countainer;

    //public void OnPause(InputValue value)
    //{
    //    if (value.isPressed)
    //    {
    //        countainer.SetActive(true);
    //        Time.timeScale = 0f;
    //    }
    //}
    public void OnPause(InputValue value)
    {
        if (!value.isPressed)
            return;

        if (countainer.activeSelf)
        {
            countainer.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            countainer.SetActive(true);
            Time.timeScale = 0f;
        }
    }


    public void ResumeButton()
    {
        countainer.SetActive(false);
        Time.timeScale = 1f;
    }

    public void MainMenuButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
    void Update()
    {

  
    }
}
