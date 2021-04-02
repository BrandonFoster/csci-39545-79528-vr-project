using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    public GameObject door;
    public GameObject key;
    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Test SHOULD BE TRIGGER, colliding with: " + col.gameObject.name);
        if (col.gameObject.name == key.name)
        {
            door.SetActive(false);
            key.SetActive(false);
        }
    }
}
