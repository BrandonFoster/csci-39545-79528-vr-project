using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndGame : MonoBehaviour
{
    public float delayInSeconds = 2f;
    public void HubScene()
    {
        StartCoroutine(WaitAndLoad());
    }
    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("Hub");
    }
    void OnTriggerEnter(Collider col)
    {
        Debug.Log("LOOK AT COLLISSSION " + col.gameObject.name + " " + col.gameObject.tag);
        if (col.gameObject.tag == "Player")
        {

            HubScene();
        }
    }
}
