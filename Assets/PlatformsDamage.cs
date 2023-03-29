using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PlatformsDamage : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector3 respawnPoint;
    public GameObject PlatformDamage;

    void Start()
    {
        respawnPoint = transform.position;
    }

    // Update is called once per frame
  
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PlatformDamage")
        {
            transform.position = respawnPoint;
        }
    }
}
