using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 500;
    public GameObject gameOverText;
    public GameObject spawner;

    // Start is called before the first frame update
    void Start()
    {
        gameOverText.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);

        health -= 100;

        if (health == 0)
        {
            gameOverText.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);

        health -= 100;

        if (health == 0)
        {
            spawner.SetActive(false);
            gameOverText.SetActive(true);
        }
    }
}
