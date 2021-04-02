using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Enemy enemyPrefab;
    private GameObject player;

    public float minXpos = -8f;
    public float maxXpos = 7.5f;
    public float minYpos = 2f;
    public float maxYpos = 5f;
    private float spawnXpos;
    private float spawnYpos;

    public float minTime = 1f;
    public float maxTime = 5f;
    private float timer = 0f;
    private float spawnCounter;

    bool firstSpeedUp = false;
    bool secondSpeedUp = false;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
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

        (Instantiate(enemyPrefab, new Vector3(spawnXpos, spawnYpos, transform.position.z), Quaternion.identity)).SetTarget(player);

    }
}
