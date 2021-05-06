using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torchLight : MonoBehaviour
{
    public GameObject lightSource;
    private bool lit = false;
    public AudioSource litSound;
    void OnTriggerEnter(Collider col)
    {
        Debug.Log("LOOK AT COLLISSSION "+col.gameObject.name+" "+col.gameObject.tag);
        if (col.gameObject.tag == "Lighter" )
        {
            if (lit == false)
            {
                litSound.Play();
                lit = true;
            }
            
        }
    }

    void Update()
    {
        lightSource.SetActive(lit);
    }

}
