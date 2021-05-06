using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float minSpeed = 1f;
    public float maxSpeed = 3f;
    public Transform target = null;

    public GameObject deathFX;
    public AudioClip deathSound;

    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(target);
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            float speed = Random.Range(minSpeed, maxSpeed);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }

    public void SetTarget(GameObject newTarget)
    {
        target = newTarget.transform;
    }
}
