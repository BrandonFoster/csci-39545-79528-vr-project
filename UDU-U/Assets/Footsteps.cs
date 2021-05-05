using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController CController;
    public AudioSource footSound;

    // Update is called once per frame
    void Update()
    {
        if (CController.isGrounded == true && CController.velocity.magnitude > 2f && footSound.isPlaying == false)
        {
            footSound.volume = Random.Range(0.6f, 0.8f);
            footSound.pitch = Random.Range(0.8f, 1.1f);
            footSound.Play();
        }
    }
}
