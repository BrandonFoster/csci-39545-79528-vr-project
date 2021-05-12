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
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("ShooterScene");
    }

    private void OnCollisionEnter(Collision collision)
    {        
        if(collision.gameObject.layer == LayerMask.NameToLayer("SceneChanger"))
        {
            LoadScene(collision.gameObject.name);
        }
    }
}
