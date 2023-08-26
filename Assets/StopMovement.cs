using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMovement : MonoBehaviour
{
    private PlayerMovement pm;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pm = other.gameObject.GetComponent<PlayerMovement>();
            if (pm != null)
            {
                pm.SlowPlayer();
            }

        }

    }


    void OnTriggerExit2D(Collider2D other)
    {
        if  (other.gameObject.CompareTag("Player"))
        {
            if (pm != null)
            {
                pm.RestorePlayerSpeed();
            }

        }

    }
  
}
