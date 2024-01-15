using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MudTriggerSound : MonoBehaviour
{
        public AudioClip Players_Walking_Mud;

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name == "Player")
            {
                AudioSource audioSource = GetComponent<AudioSource>();
                audioSource.clip = Players_Walking_Mud;
                audioSource.Play();
            }
        }
}
