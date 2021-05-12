using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int health = 500;
    public int points = 0;
    public GameObject gameOver;
    public Text gameOverText;
    public Text timerText;

    public GameObject spawner;
    public GameObject startCube;
    public GameObject backCube;

    private Spawner spawnTimer;

    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject heart4;
    public GameObject heart5;

    // Start is called before the first frame update
    void Start()
    {
        gameOver.SetActive(false);
        spawnTimer = FindObjectOfType<Spawner>();
    }

    private void Update()
    {
        if (!spawnTimer)
        {
            spawnTimer = FindObjectOfType<Spawner>();
        }
        if (spawnTimer)
        {
            float timer = spawnTimer.getTime();
            int sec = (int)(timer / 1);
            int min = sec / 60;
            sec = sec % 60;
            if (sec > 9)
            {
                timerText.text = (min) + ":" + (sec) + "  " + points;
            }
            else
            {
                timerText.text = (min) + ":0" + (sec) + "  " + points;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);

        health -= 100;

        if (health == 0)
        {
            spawnTimer.startStopTimer();

            gameOverText.text = "GAME OVER\nSURVIVED: " + timerText.text.Substring(0, 4) + "\nPOINTS: " + points;

            spawner.SetActive(false);
            gameOver.SetActive(true);
            heart1.SetActive(false);

            StartCoroutine(WaitAndReset());
        }
        else if(health == 100)
        {
            heart2.SetActive(false);
        }
        else if (health == 200)
        {
            heart3.SetActive(false);
        }
        else if (health == 300)
        {
            heart4.SetActive(false);
        }
        else if (health == 400)
        {
            heart5.SetActive(false);
        }
    }

    IEnumerator WaitAndReset()
    {
        yield return new WaitForSeconds(5);
        startCube.SetActive(true);
        backCube.SetActive(true);
    }

    public void addPoint()
    {
        points += 100;
    }

    public void resetGame()
    {
        spawnTimer = FindObjectOfType<Spawner>();
        spawnTimer.resetTimer();

        health = 500;
        points = 0;
        heart1.SetActive(true);
        heart2.SetActive(true);
        heart3.SetActive(true);
        heart4.SetActive(true);
        heart5.SetActive(true);
    }
}
