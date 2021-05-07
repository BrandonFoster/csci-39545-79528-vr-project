using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Enemy enemyPrefab;
    public Asteroid rock1;
    public Asteroid rock2;
    public Asteroid rock3;
    public Asteroid rock4;
    private GameObject player;

    public float minXpos = -8f;
    public float maxXpos = 7.5f;
    public float minYpos = 2f;
    public float maxYpos = 5f;
    private float spawnXpos;
    private float spawnYpos;

    public float minTime = 1f;
    public float maxTime = 4f;
    private float timer = 0f;
    private float spawnCounter;

    bool mediumSpeedUp = false;
    bool hardSpeedUp = false;
    bool finalSpeedUp = false;
    private float finalSpeedUpCountdown = 10f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!mediumSpeedUp || !hardSpeedUp || !finalSpeedUp)
        {
            timer += Time.deltaTime;
        }
        
        SpeedUp();
        CountdownAndSpawn();
    }

    private void CountdownAndSpawn()
    {
        spawnCounter -= Time.deltaTime;
        if(spawnCounter <= 0f)
        {
            SpawnEnemy();
            spawnCounter = Random.Range(minTime, maxTime);
        }
    }

    private void SpawnEnemy()
    {
        spawnXpos = Random.Range(minXpos, maxXpos);
        spawnYpos = Random.Range(minYpos, maxYpos);

        int randNum = Random.Range(0, 3);
        if(randNum == 0)
        {
            (Instantiate(enemyPrefab, new Vector3(spawnXpos, spawnYpos, transform.position.z), Quaternion.identity)).SetTarget(player);
        }
        else
        {
            if (finalSpeedUp)
            {
                (Instantiate(rock4, new Vector3(spawnXpos, spawnYpos, transform.position.z), Quaternion.identity)).SetTarget(player);
            }
            else if (hardSpeedUp)
            {
                (Instantiate(rock3, new Vector3(spawnXpos, spawnYpos, transform.position.z), Quaternion.identity)).SetTarget(player);
            }
            else if (mediumSpeedUp)
            {
                (Instantiate(rock2, new Vector3(spawnXpos, spawnYpos, transform.position.z), Quaternion.identity)).SetTarget(player);
            }
            else
            {
                (Instantiate(rock1, new Vector3(spawnXpos, spawnYpos, transform.position.z), Quaternion.identity)).SetTarget(player);
            }
        }
    }

    private void SpeedUp()
    {
        if(timer >= 60f)
        {
            finalSpeedUp = true;
            finalSpeedUpCountdown -= Time.deltaTime;
            if(finalSpeedUpCountdown <= 0f)
            {
                finalSpeedUpCountdown = 10f;
                if (minTime >= 0f)
                {
                    minTime -= 0.1f;
                }
                if (maxTime >= 1.5f)
                {
                    maxTime -= 0.1f;
                }
            }
        }
        else if (timer >= 45f)
        {
            hardSpeedUp = true;
            minTime = 0.2f;
            maxTime = 1.5f;
        }
        else if (timer >= 15f)
        {
            mediumSpeedUp = true;
            minTime = 0.5f;
            maxTime = 3f;
        }
    }

    public bool getFinal()
    {
        return finalSpeedUp;
    }

    public float getTime()
    {
        return timer;
    }
}
