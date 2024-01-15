using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableManager
{
    private static InteractableManager _instance = null;
    
    private InteractableManager()
    {
        EventDispatcher.AddListener<PlayerInteract>(InteractWithObjects);
    }

    public static InteractableManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new InteractableManager();
            }

            return _instance;
        }
    }

    private List<Interactable> _interactable = new List<Interactable>();

    public void Add(Interactable item)
    {
        _interactable.Add(item);
    }

    public void Remove(Interactable item)
    {
        _interactable.Remove(item);
    }

    public void InteractWithObjects(PlayerInteract evtData)
    {
        float closestDistance = evtData.interactionDistance;
        Interactable closestInteractable = null;

        foreach (Interactable item in _interactable)
        {
            float distance = Vector3.Distance(item.transform.position, evtData.interactionPosition);

            if (distance < closestDistance)
            { 
                closestDistance = distance;
                closestInteractable = item; 
            }
        }
        if (closestInteractable != null)
        {
            closestInteractable.OnInteract();
        }
    }
}
