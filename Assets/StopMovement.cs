using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMovement : MonoBehaviour
{
    void OnTriggerEnter2D(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        { 
            
        }
    }
}
