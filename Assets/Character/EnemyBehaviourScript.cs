using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBehavior : MonoBehaviour
{
    public bool isKneeling1 = false;
    public bool isKneeling = false;

    private bool isGameOver = false;
    private float kneelDuration = 7f; // Time the player needs to kneel to avoid game over
    private float timeSinceKneeling = 0f;
    private float gameOverDuration = 10f; // Time until game over if player doesn't kneel
    private float timeSinceStart = 0f;
    private bool inTrigger = false;

    public AudioClip Death_Game_Sound;
    public AudioClip warningSound;
    private AudioSource audioSource;
    private string sceneToStopSound = "Title Screen";

    public float moveSpeed = 0f;
        private float i;

    public void RecieveBoolValue(bool isKneeling1)
        
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = Death_Game_Sound;
        Debug.Log("Banana " + isKneeling1);
        if(isKneeling1 == true){
            //iFunction(isKneeling1);

    }
    }

   /* private bool iFunction(bool isKneeling1)
    {
        Debug.Log(i + "gay");
        isKneeling = isKneeling1;
        Debug.Log("Recieved " + isKneeling1);
        if (isKneeling1 == true)
        {
            Debug.Log("YESSSSSSS");
            return isKneeling1;
        }

    }*/

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = warningSound;

        PlayerMovement PmScript = GetComponent<PlayerMovement>();
     if (PmScript != null)
     {
        bool inTrigger = PmScript.inTrigger;
     }
   // PmScript.onBoolValueChanged.AddListener(OnBoolValueChanged);
    }

    private void Update()
    {

        // Move the object to the left
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        // Check if the object has moved far enough to the left (or reached a specific position)
        if (transform.position.x <=  60f) 
        {
            Debug.Log("Disappear");
            moveSpeed = 0f;
            audioSource.Play(); //Play the Night Marchers sound
            // Destroy the game object
            Destroy(gameObject);
        }
        if(inTrigger == true && Input.GetKeyDown(KeyCode.K) == true)
            {
                isKneeling = true;

            }
                       
        if (inTrigger == true) { 
        if (isKneeling == true && isGameOver == false)
        { 
            timeSinceKneeling += Time.deltaTime;
            // If player has kneeled for the required duration, allow them to continue
            if (timeSinceKneeling >= kneelDuration)
            {
                moveSpeed = 4f;
                timeSinceKneeling = 0f;
                inTrigger = false;
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
                audioSource.Play();
                GameOver();
            }

                if (SceneManager.GetActiveScene().name == sceneToStopSound && audioSource.isPlaying)
                {
                    audioSource.Stop();
                }
            }
    }

    }


    private void GameOver()
    {
        // Implement game over logic here
        SceneManager.LoadScene("Title Screen"); // Load game over scene or handle accordingly
    }

private void OnCollisionEnter2D(Collision2D collision)
{
         if(collision.gameObject.tag == "Player"){
            inTrigger = true;
            moveSpeed = 0;
            Debug.Log("timer is on");
    }
}

private void OnCollisionExit2D(Collision2D collision)
{
     if(collision.gameObject.tag != "Player"){
            inTrigger = false;
                        Debug.Log("timer is off");
                                    moveSpeed = 3;
                    

}
}
}