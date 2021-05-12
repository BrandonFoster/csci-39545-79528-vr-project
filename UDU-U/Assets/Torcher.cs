using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torcher : MonoBehaviour
{
    private bool lit = false;
    public AudioSource litSound;
    public GameObject TorchObj;
    public GameObject BlockingWood;
    public GameObject FallingLeaves;
    void OnTriggerEnter(Collider col)
    {
        Debug.Log("LOOK AT COLLISSSION " + col.gameObject.name + " " + col.gameObject.tag);
        if (col.gameObject.tag == "Lighter")
        {
            if (lit == false)
            {
                TorchObj.SetActive(false);

                lit = true;
                StartCoroutine(Waiter());

            }

        }
    }

    IEnumerator Waiter()
    {
        litSound.Play();
        yield return new WaitForSecondsRealtime(2.5f);
        BlockingWood.SetActive(false);
        FallingLeaves.SetActive(true);
    }

}
