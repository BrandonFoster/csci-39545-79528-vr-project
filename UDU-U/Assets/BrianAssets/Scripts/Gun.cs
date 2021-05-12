using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float speed = 40;
    public GameObject bullet;
    public Transform barrel;
    public Transform bulletPivot;
    public AudioClip shootSound;

    public void Fire()
    {
        AudioSource.PlayClipAtPoint(shootSound, transform.position, 0.3f);
        GameObject spawnedBullet = Instantiate(bullet, barrel.position, bulletPivot.rotation);
        spawnedBullet.GetComponent<Rigidbody>().velocity = speed * barrel.forward;
        Destroy(spawnedBullet, 2);
    }
}
