using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneSwitchNapat : MonoBehaviour
{
    public GameObject lightSource;
    private bool lit = false;
    public AudioSource litSound;
    public float delayInSeconds = 2f;
    void OnTriggerEnter(Collider col)
    {
        Debug.Log("LOOK AT COLLISSSION " + col.gameObject.name + " " + col.gameObject.tag);
        if (col.gameObject.tag == "Lighter")
        {
            if (lit == false)
            {
                litSound.Play();
                lit = true;
                LoadScene("VR Napat Scene");
            }

        }
    }

    void Update()
    {
        lightSource.SetActive(lit);
    }
    
    public void LoadScene(string name)
    {
        StartCoroutine(WaitAndLoad(name));
    }

    IEnumerator WaitAndLoad(string name)
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene(name);
    }
}