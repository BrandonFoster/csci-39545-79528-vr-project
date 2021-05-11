using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneEnter : MonoBehaviour
{
    public float delayInSeconds = 2f;

    public void LoadScene(string name)
    {
        StartCoroutine(WaitAndLoad(name));
    }

    IEnumerator WaitAndLoad(string name)
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene(name);
    }

    private void OnCollisionEnter(Collision collision)
    {
        LoadScene(gameObject.name);
    }
}
