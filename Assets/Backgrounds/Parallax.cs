using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
   private float length, startpos, startposy, height;
    public GameObject cam;
    public float parallaxEffect, parallaxEffecty;
    public float offSetx, offSety;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        startposy = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        height = GetComponent<SpriteRenderer>().bounds.size.y;
       
        
    }

    // Update is called once per frame
    void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);
        float tempy = (cam.transform.position.y * (1 - parallaxEffecty));
         float disty = (cam.transform.position.y * parallaxEffecty);

       transform.position = new Vector3(startpos + dist + offSetx, startposy + disty + offSety, transform.position.z);
       // transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z);
       /* if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -= length;*/
      //  if (startpos && startposy > )
       // transform.position = new Vector3(startpos, startposy);
       // if (tempy > startposy + height) startpos += height;
      //  else if (tempy < startposy - height) startpos -= height;
}
}
