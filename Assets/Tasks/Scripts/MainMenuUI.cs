using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f; // Ensure the game is running at normal speed
    }

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Week1");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is quitting");
    }
}
