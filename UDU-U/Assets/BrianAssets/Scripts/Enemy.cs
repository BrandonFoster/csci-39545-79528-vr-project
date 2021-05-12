using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float minSpeed = 1f;
    public float maxSpeed = 3f;
    public Transform target = null;

    public GameObject laser;
    public GameObject laserPivot;
    public GameObject deathFX;
    public AudioClip deathSound;
    Spawner spawner;
    Player player;
    private bool finalSpeedUp = false;

    // Start is called before the first frame update
    void Start()
    {
        if (target != null)
        {
            transform.LookAt(target);
        }

        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<Spawner>();
        if (spawner)
        {
            finalSpeedUp = spawner.getFinal();
            if (finalSpeedUp)
            {
                GameObject spawnedBullet = Instantiate(laser, transform.position, laserPivot.transform.rotation);
                spawnedBullet.GetComponent<Rigidbody>().velocity = 4 * transform.forward;
                Destroy(spawnedBullet, 5);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.LookAt(target);

            float speed = Random.Range(minSpeed, maxSpeed);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }

    public void SetTarget(GameObject newTarget)
    {
        target = newTarget.transform;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Weapon"))
        {
            if (player)
            {
                player.addPoint();
            }
            GameObject deathEffect = Instantiate(deathFX, transform.position, transform.rotation);
            deathEffect.GetComponent<Renderer>().material.color = gameObject.GetComponent<Renderer>().material.color;
            AudioSource.PlayClipAtPoint(deathSound, transform.position, 0.5f);

            Destroy(gameObject);
            Destroy(deathEffect, 2);
        }
    }
}
