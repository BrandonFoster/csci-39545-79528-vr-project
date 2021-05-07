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

    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 10)
        {
            player.addPoint();
            GameObject deathEffect = Instantiate(deathFX, transform.position, transform.rotation);

            if(gameObject.name == "Glowing Rock Blue 6(Clone)")
            {
                deathEffect.GetComponent<Renderer>().material.color = Color.blue;
            }
            if (gameObject.name == "Glowing Rock Green 6(Clone)")
            {
                deathEffect.GetComponent<Renderer>().material.color = Color.green;
            }
            if (gameObject.name == "Glowing Rock Orange 6(Clone)")
            {
                deathEffect.GetComponent<Renderer>().material.color = Color.red;
            }
            if (gameObject.name == "Glowing Rock Purple 6(Clone)")
            {
                deathEffect.GetComponent<Renderer>().material.color = Color.magenta;
            }
            AudioSource.PlayClipAtPoint(deathSound, transform.position, 0.5f);

            Destroy(gameObject);
            Destroy(deathEffect, 2);
        }
    }
}
