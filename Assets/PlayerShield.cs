using System.Collections;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    [SerializeField] private GameObject shieldPrefab;
    [SerializeField] private Transform shieldSpawnPoint;
    [SerializeField] private float shieldDuration = 5f;
    [SerializeField] private float shieldCooldown = 10f;
    [SerializeField] private KeyCode shieldKey = KeyCode.E;

    private GameObject activeShield;
    private bool shieldReady = true;

    private CapsuleCollider2D capsulePlayer;
    private PhysicsMaterial2D originalMaterial;
    [SerializeField] private PhysicsMaterial2D shieldMaterial;

    private PlatformsDamage platformsDamage; // Ajouter une r�f�rence � la classe PlatformsDamage

    private void Start()
    {
        capsulePlayer = GetComponent<CapsuleCollider2D>();
        originalMaterial = capsulePlayer.sharedMaterial;


        // Obtenir la r�f�rence � la classe PlatformsDamage
        platformsDamage = GetComponent<PlatformsDamage>();
    }

    void Update()
    {
        if (Input.GetKeyDown(shieldKey) && shieldReady)
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

        capsulePlayer.sharedMaterial = shieldMaterial;

        platformsDamage.SetShieldActive(true); // Activer le bouclier dans la classe PlatformsDamage

        yield return new WaitForSeconds(shieldDuration);

        Destroy(activeShield);

        capsulePlayer.sharedMaterial = originalMaterial;

        yield return new WaitForSeconds(shieldCooldown);

        platformsDamage.SetShieldActive(false); // D�sactiver le bouclier dans la classe PlatformsDamage

        shieldReady = true;
    }
    /*
    private void UpdateBounciness()
    {
        if (HasShield())
        {
            capsulePlayer.sharedMaterial.bounciness = 1f;
        }
        else
        {
            capsulePlayer.sharedMaterial.bounciness = 0f;
        }
    }

     */
    public bool HasShield()
    {
        return activeShield != null;
    }
    
}