using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footsteps : MonoBehaviour
{
    private Animator m_Animator;
    public AudioClip Players_FootstepGrass, Players_WalkingMud, Jump, Kneeling_Indiator;
    public AudioSource audioSource; 

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

         if (Input.GetKey(KeyCode.LeftArrow)) {
         this.transform.Translate(new Vector3(-10f, 0f, 0f) * Time.deltaTime);
         if (!audioSource.isPlaying) 
            {
          audioSource.PlayOneShot(Players_FootstepGrass);
             }
           }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            Renderer renderer = hit.collider.GetComponent<Renderer>();
            if (renderer != null)
            {
                Material material = renderer.material;
                Texture2D texture = material.mainTexture as Texture2D;
                if (texture != null)
                {
                    Color pixelColor = texture.GetPixelBilinear(hit.textureCoord.x, hit.textureCoord.y);
                    Debug.Log("Ground texture: " + pixelColor.ToString());
                }
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(new Vector3(-10f, 0f, 0f) * Time.deltaTime);
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(Players_FootstepGrass);
            }
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.Translate(new Vector3(-10f, 0f, 0f) * Time.deltaTime);
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(Jump);
            }
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.Translate(new Vector3(-10f, 0f, 0f) * Time.deltaTime);
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(Kneeling_Indiator);
            }
        }
    }

    
}
