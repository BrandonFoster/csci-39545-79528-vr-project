using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Enemy enemyScript = collision.gameObject.GetComponent<Enemy>();
        Asteroid asteroidScript = collision.gameObject.GetComponent<Asteroid>();
        if (enemyScript != null)
        {
            enemyScript.enabled = false;
            Destroy(collision.gameObject, 3);
        }
        if(asteroidScript != null)
        {
            asteroidScript.enabled = false;
            Destroy(collision.gameObject, 3);
        }
    }
}
