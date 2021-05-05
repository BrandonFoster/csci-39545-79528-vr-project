using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSaber : MonoBehaviour
{

    private GameObject laser;
    private GameObject slicer;
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
        laser = transform.Find("SingleLine-LightSaber").gameObject;
        slicer = transform.Find("Slicer").gameObject;
        fullSize = laser.transform.localScale;
        laser.transform.localScale = new Vector3(fullSize.x, 0, fullSize.z);
    }

    // Update is called once per frame
    void Update()
    {
        laserControl();

        var velocity = gameObject.GetComponent<Rigidbody>().velocity;
        if(activate && velocity.magnitude > 6)
        {
            source.PlayOneShot(saberMovingSound);
        }
        if (!source.isPlaying)
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
            laser.transform.localScale += new Vector3(0, 0.001f, 0);
        }
        else if (!activate && laser.transform.localScale.y > 0)
        {
            laser.transform.localScale += new Vector3(0, -0.001f, 0);
        }
        else if (activate == false)
        {
            laser.SetActive(false);
            slicer.SetActive(false);
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
}
