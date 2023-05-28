using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private GameObject shieldPrefab;
    [SerializeField] private Transform shieldSpawnPoint;
    [SerializeField] private float shieldDuration = 5f;
    [SerializeField] private float shieldCooldown = 10f;
    [SerializeField] private KeyCode shieldKey = KeyCode.E;
    /*
    [SerializeField] public bool HasShield;
    */

    private GameObject activeShield;
    private bool shieldReady = true;

    private CapsuleCollider2D capsulePlayer;
    private PhysicsMaterial2D originalMaterial;
    [SerializeField] private PhysicsMaterial2D shieldMaterial;

    bool unlockShield = false;

    private Vector3 respawnPoint;



    private void Start()
    {
        capsulePlayer = GetComponent<CapsuleCollider2D>();
        originalMaterial = capsulePlayer.sharedMaterial;


      ;
    }

    void Update()
    {
        if (Input.GetKeyDown(shieldKey) && shieldReady && unlockShield == true)
        {
            StartCoroutine(ActivateShield());
            
        }
       

        //UpdateBounciness();
    }

    private IEnumerator ActivateShield()
    {
        shieldReady = false;

        activeShield = Instantiate(shieldPrefab, shieldSpawnPoint.position, Quaternion.identity);
        activeShield.transform.SetParent(transform);

        //capsulePlayer.sharedMaterial = shieldMaterial;

        

        yield return new WaitForSeconds(shieldDuration);

        Destroy(activeShield);

        //capsulePlayer.sharedMaterial = originalMaterial;

        yield return new WaitForSeconds(shieldCooldown);

       

        shieldReady = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.CompareTag("Shield"))
        {
            unlockShield = true;
        }
        
        if (collision.tag == "PlatformDamage")
        {
            transform.position = respawnPoint;
        }
        else if (collision.tag == "Checkpoint")
        {
            respawnPoint = transform.position;
        }

        


    }


    [SerializeField] public bool HasShield()
    {
        return activeShield != null;
    }
    
}