using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string mainGameSceneName = "MainGameScene"; // Replace with your main game scene name
    public string gameOverSceneName = "GameOverScene"; // Replace with your game over scene name

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(mainGameSceneName);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(gameOverSceneName);
    }

    public void Retry()
    {
        SceneManager.LoadScene(mainGameSceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}