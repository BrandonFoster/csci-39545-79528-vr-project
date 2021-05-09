using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject spawner;
    public GameObject backCube;
    public GameObject gameOver;

    Spawner spawnTimer;
    Player player;

    private void OnCollisionEnter(Collision collision)
    {
        spawner.SetActive(true);
        gameOver.SetActive(false);
        backCube.SetActive(false);
        gameObject.SetActive(false);

        spawnTimer = FindObjectOfType<Spawner>();
        player = FindObjectOfType<Player>();

        spawnTimer.startStopTimer();
        player.resetGame();
    }
}
