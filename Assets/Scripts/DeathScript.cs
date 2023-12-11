using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour
{

    public Transform SpawnPoint;
    public GameObject Prefab;
    private GameObject instantiatedObject;

     void OnTriggerEnter2D()
{
         Debug.Log("TRIGGERED");
           instantiatedObject = Instantiate(Prefab, SpawnPoint.position, SpawnPoint.rotation);
    
}
private void OnTriggerExit2D()
{
                    Debug.Log("Delete");
                    DeletePreFab();
}

void DeletePreFab()
{
    if(instantiatedObject != null)
    {
        Destroy(instantiatedObject);
        instantiatedObject = null;
    }
}

void Update()
{
    if(Input.GetKeyDown(KeyCode.K) == true){
        DeletePreFab();
    }
}
}
