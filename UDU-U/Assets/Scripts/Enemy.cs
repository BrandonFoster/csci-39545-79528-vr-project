using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float minSpeed = 1f;
    public float maxSpeed = 3f;
    public Transform target = null;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.LookAt(target);

            speed = Random.Range(minSpeed, maxSpeed);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }

    public void SetTarget(GameObject newTarget)
    {
        target = newTarget.transform;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
