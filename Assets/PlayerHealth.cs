using System.Diagnostics;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;

    private int currentHealth;
    private Shield playerShield;

    void Start()
    {
        currentHealth = maxHealth;
        playerShield = GetComponent<Shield>();
    }

    public void TakeDamage(int damage)
    {
        // Ne pas appliquer de d�g�ts si le bouclier est actif
        //if (playerShield != null && playerShield.HasShield())
        {
            return;
        }

        // Appliquer les d�g�ts et mettre � jour la sant� actuelle
        currentHealth -= damage;

        // V�rifier si le personnage est mort
        if (currentHealth <= 0)
        {
            // Appeler une fonction pour g�rer la mort du personnage (� impl�menter)
            OnPlayerDeath();
        }
    }

    private void OnPlayerDeath()
    {
        // Impl�mentez ici ce qui doit se passer lorsque le personnage meurt
        // Par exemple, vous pouvez jouer une animation, afficher un message, etc.
        //Debug.Log("Le personnage est mort");
    }
}