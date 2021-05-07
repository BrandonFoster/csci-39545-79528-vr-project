using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSaber : MonoBehaviour
{

    public GameObject laser;
    private GameObject slicer;
    public GameObject laserCollider;
    private Vector3 fullSize;
    public bool activate = false;

    private AudioSource source;
    public AudioClip saberMovingSound;
    public AudioClip saberHum;
    public AudioClip saberStart;
    public AudioClip saberEnd;

    // Start is called before the first frame update
    void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
        source.spatialBlend = 1;
        source.volume = 0.3f;
        slicer = transform.Find("Slicer").gameObject;
        fullSize = laser.transform.localScale;
        laser.transform.localScale = new Vector3(fullSize.x, 0, fullSize.z);
    }

    // Update is called once per frame
    void Update()
    {
        laserControl();

        var velocity = gameObject.GetComponent<Rigidbody>().velocity;
        if(activate && velocity.magnitude > 1)
        {
            source.PlayOneShot(saberMovingSound, 0.1f);
        }
        if (activate && !source.isPlaying)
        {
            source.PlayOneShot(saberHum);
        }
    }

    private void laserControl()
    {
        if (activate && laser.transform.localScale.y < fullSize.y)
        {
            laser.SetActive(true);
            slicer.SetActive(true);
            laserCollider.SetActive(true);
            laser.transform.localScale += new Vector3(0, 0.05f, 0);
        }
        else if (!activate && laser.transform.localScale.y > 0)
        {
            laser.transform.localScale += new Vector3(0, -0.05f, 0);
        }
        else if (activate == false)
        {
            laser.SetActive(false);
            slicer.SetActive(false);
            laserCollider.SetActive(false);
        }
    }

    public void ActivateChange()
    {
        if (!activate)
        {
            source.PlayOneShot(saberStart);
        }
        else if (activate)
        {
            source.PlayOneShot(saberEnd);
        }
        activate = !activate;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("EnemyLaser"))
        {
            Destroy(collision.gameObject, 2);
        }
    }
}
