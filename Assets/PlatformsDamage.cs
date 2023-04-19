using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PlatformsDamage : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector3 respawnPoint;
    public GameObject PlatformDamage;

    // Ajouter une variable bool�enne pour garder la trace de l'�tat du bouclier
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
            // V�rifier si le bouclier est activ�
            if (!isShieldActive)
            {
                transform.position = respawnPoint;
            }
        }
    }


    // Ajouter une m�thode pour activer/d�sactiver le bouclier depuis d'autres classes
    public void SetShieldActive(bool active)
    {
        isShieldActive = active;
    }
}
