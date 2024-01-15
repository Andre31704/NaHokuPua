using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{   
    public void OnEnable()
    {
        InteractableManager.Instance.Add(this);
    }

    public void OnDisable()
    {
        InteractableManager.Instance.Remove(this); 
    }

    public void OnInteract ()
    {
            Debug.Log("Hello world!"); 
    }

    
}
