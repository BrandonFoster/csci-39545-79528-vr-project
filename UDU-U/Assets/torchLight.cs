using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torchLight : MonoBehaviour
{
    private bool lit = false;
    public GameObject areaLight;
    public AudioSource litSound;
    void OnTriggerEnter(Collider col)
    {
        Debug.Log("LOOK AT COLLISSSION "+col.gameObject.name+" "+col.gameObject.tag);
        if (col.gameObject.tag == "Lighter" )
        {
            if (lit == false)
            {
                lit = true;
                litSound.Play();
            }
            
        }
    }
    void Update()
    {
        areaLight.SetActive(lit);
    }
}
