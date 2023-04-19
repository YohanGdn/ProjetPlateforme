using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PlatformsDamage : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector3 respawnPoint;
    public GameObject PlatformDamage;

    // Ajouter une variable booléenne pour garder la trace de l'état du bouclier
    private bool isShieldActive = false;

    void Start()
    {
        respawnPoint = transform.position;
    }

    // Update is called once per frame
  
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlatformDamage")
        {
            // Vérifier si le bouclier est activé
            if (!isShieldActive)
            {
                transform.position = respawnPoint;
            }
        }
    }


    // Ajouter une méthode pour activer/désactiver le bouclier depuis d'autres classes
    public void SetShieldActive(bool active)
    {
        isShieldActive = active;
    }
}
