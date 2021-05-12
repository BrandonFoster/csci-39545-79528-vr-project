using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    public GameObject invisWall;
    public GameObject LeftDoor;
    public GameObject rightDoor;
    public GameObject door;
    public GameObject key;
    public AudioSource breaking;
    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Test SHOULD BE TRIGGER, colliding with: " + col.gameObject.name);
        if (col.gameObject.name == key.name)
        {
            door.SetActive(false);
            key.SetActive(false);
            LeftDoor.SetActive(false);
            rightDoor.SetActive(false);
            invisWall.SetActive(false);
            breaking.Play();
        }
    }
}
