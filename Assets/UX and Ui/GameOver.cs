using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public float gameOverDelay = 5f; // Time before game over after not kneeling

    private float elapsedTime = 0f;
    private bool kneeling = false;

    private void Update()
    {
        // Check if player is kneeling
        if (Input.GetKeyDown(KeyCode.K))
        {
            kneeling = true;
            elapsedTime = 0f;
        }

        // Check if game over condition is met
        if (!kneeling)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= gameOverDelay)
            {
                LoadGameOverScene();
            }
        }
    }

    private void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOverScene"); // Replace with the actual scene name
    }
    public void Retry()
    {
        SceneManager.LoadScene("MainGameScene"); // Replace with your main game scene name
    }
    public void StartGame()
    {
        // Initialize or reset game state here
        SceneManager.LoadScene("MainGameScene"); // Replace with your main game scene name
    }

}
