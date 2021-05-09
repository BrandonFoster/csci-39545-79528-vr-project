using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponent<Rigidbody>().velocity = -(4 * transform.up);
        other.gameObject.layer = LayerMask.NameToLayer("Weapon");
        gameObject.GetComponent<Collider>().isTrigger = false;
    }
}
