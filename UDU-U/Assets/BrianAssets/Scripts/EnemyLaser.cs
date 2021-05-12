using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    public GameObject deathFX;
    public AudioClip deathSound;
    public AudioClip saberHitSound;

    private void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponent<Rigidbody>().velocity = -(4 * transform.up);
        gameObject.layer = LayerMask.NameToLayer("Weapon");
        if (other.gameObject.layer == LayerMask.NameToLayer("Sword"))
        {
            AudioSource.PlayClipAtPoint(saberHitSound, transform.position, 0.5f);
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            GameObject deathEffect = Instantiate(deathFX, transform.position, transform.rotation);
            deathEffect.GetComponent<Renderer>().material.color = other.gameObject.GetComponent<Renderer>().material.color;
            AudioSource.PlayClipAtPoint(deathSound, transform.position, 0.5f);

            Destroy(deathEffect, 2);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
