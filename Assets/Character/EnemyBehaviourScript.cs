using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBehavior : MonoBehaviour
{
    private bool isKneeling = false;
    private bool isGameOver = false;
    private float kneelDuration = 6f; // Time the player needs to kneel to avoid game over
    private float timeSinceKneeling = 0f;
    private float gameOverDuration = 5f; // Time until game over if player doesn't kneel
    private float timeSinceStart = 0f;

    public GameObject Player;

    void Start()
    {
       PlayerMovement PmScript = GetComponent<PlayerMovement>();
        PmScript.onBoolValueChanged.AddListener(OnBoolValueChanged);
    }

   void OnBoolValueChanged (bool newVal){
        isKneeling = newVal;
    }

    private void Update()
    {
        if (isKneeling && !isGameOver)
        {
            timeSinceKneeling += Time.deltaTime;

            // If player has kneeled for the required duration, allow them to continue
            if (timeSinceKneeling >= kneelDuration)
            {
                isKneeling = false;
                timeSinceKneeling = 0f;
                // Resume player's normal movement or animations
            }
        }
        else if (!isKneeling && !isGameOver)
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
        isKneeling = true;
    }

    private void GameOver()
    {
        // Implement game over logic here
        SceneManager.LoadScene("Title Screen"); // Load game over scene or handle accordingly
    }
}