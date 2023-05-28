using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetPortail : MonoBehaviour
{

    public Shield playerShield;
    private BoxCollider2D platformCollider;

    // Start is called before the first frame update
    void Start()
    {
        platformCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (playerShield.HasShield())
        {
            // Désactivez le collider de la plateforme
            platformCollider.enabled = false;
        }
        else
        {
            // Activez le collider de la plateforme
            platformCollider.enabled = true;
        }
    }
}
