using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject Canvas;

    public void PauseMenuButton()
    {
        Canvas.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ResumeButton()
    {
        Canvas.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
    public void RestartButton()
    {
        Time.timeScale = 1f;
        Canvas.gameObject.SetActive(false);
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
