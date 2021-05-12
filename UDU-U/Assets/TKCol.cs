using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TKCol : MonoBehaviour
{
    private bool click = false;
    public GameObject statueKey;
    public GameObject statueAppear;
    public AudioSource clickSound;
    public GameObject leftDoor;
    public GameObject rightDoor;
    public GameObject InvisWall;
    public GameObject glow;
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == statueKey.name)
        {
            if (click == false)
            {
                statueKey.SetActive(false);
                statueAppear.SetActive(true);
                leftDoor.SetActive(false);
                rightDoor.SetActive(false);
                InvisWall.SetActive(false);
                glow.SetActive(false);
                click = true;
                clickSound.Play();
            }

        }
    }
}

