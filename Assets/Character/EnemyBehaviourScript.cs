using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBehavior : MonoBehaviour
{
    private bool isPlayerKneeling = false;
    private bool isGameOver = false;
    private float kneelDuration = 6f; // Time the player needs to kneel to avoid game over
    private float timeSinceKneeling = 0f;
    private float gameOverDuration = 5f; // Time until game over if player doesn't kneel
    private float timeSinceStart = 0f;

    private void Update()
    {
        if (isPlayerKneeling && !isGameOver)
        {
            timeSinceKneeling += Time.deltaTime;

            // If player has kneeled for the required duration, allow them to continue
            if (timeSinceKneeling >= kneelDuration)
            {
                isPlayerKneeling = false;
                timeSinceKneeling = 0f;
                // Resume player's normal movement or animations
            }
        }
        else if (!isPlayerKneeling && !isGameOver)
        {
            timeSinceStart += Time.deltaTime;

            // If player hasn't kneeled within the time limit, trigger game over
            if (timeSinceStart >= gameOverDuration)
            {
                isGameOver = true;
                GameOver();
            }
        }
    }

    public void PlayerKneeling()
    {
        isPlayerKneeling = true;
    }

    private void GameOver()
    {
        // Implement game over logic here
        SceneManager.LoadScene("GameOverScene"); // Load game over scene or handle accordingly
    }
}