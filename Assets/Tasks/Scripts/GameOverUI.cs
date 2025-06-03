using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField]
    private Text scorevalueText;

    private int scoreValue = 0;
    // Start is called before the first frame update
    void Start()
    {
        PlayerScript.OnPlayerDeath += ActivateGameObject; ;
        Enemy.OnEnemyDeath += CountScore;
        this.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        PlayerScript.OnPlayerDeath -= ActivateGameObject; ;
        Enemy.OnEnemyDeath -= CountScore;
    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        Time.timeScale = 1f; // Ensure the game is running at normal speed
    }

    private void CountScore()
    {
        scoreValue++;
    }

    private void ActivateGameObject()
    {
        this.gameObject.SetActive(true);
        scorevalueText.text = scoreValue.ToString();

    }
}
