using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public float delayInSeconds = 2f;

    public void LoadScene(string name)
    {
        StartCoroutine(WaitAndLoad(name));
    }

    IEnumerator WaitAndLoad(string name)
    {
        Debug.Log(name);
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene(name);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.layer);
        if(collision.gameObject.layer == 15)
        {
            LoadScene(collision.gameObject.name);
        }
    }
}
