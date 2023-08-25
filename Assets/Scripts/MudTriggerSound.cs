using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudTriggerSound : MonoBehaviour
{
    public AudioSource Players_WalkingMud;

    void start()
    {
        Players_WalkingMud = GetComponent<AudioSource>(); 
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Object Entered the trigger");
    }

    void OnTriggerStay (Collider Other)
    {
        Debug.Log("Object is within trigger");
    }

    void OnTriggerExit(Collider Other)
    {
        Debug.Log("Object Exited the trigger");
    }
}
