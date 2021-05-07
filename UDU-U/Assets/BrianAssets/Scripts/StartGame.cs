using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject spawner;
    public GameObject backCube;
    public GameObject gameOver;

    Spawner spawnTimer;

    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject heart4;
    public GameObject heart5;

    private void OnCollisionEnter(Collision collision)
    {
        spawner.SetActive(true);
        gameOver.SetActive(false);
        backCube.SetActive(false);
        gameObject.SetActive(false);

        spawnTimer = FindObjectOfType<Spawner>();

        spawnTimer.startStopTimer();

        heart1.SetActive(true);
        heart2.SetActive(true);
        heart3.SetActive(true);
        heart4.SetActive(true);
        heart5.SetActive(true);
    }
}
