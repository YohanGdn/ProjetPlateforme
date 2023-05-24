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
        // Ne pas appliquer de dégâts si le bouclier est actif
        //if (playerShield != null && playerShield.HasShield())
        {
            return;
        }

        // Appliquer les dégâts et mettre à jour la santé actuelle
        currentHealth -= damage;

        // Vérifier si le personnage est mort
        if (currentHealth <= 0)
        {
            // Appeler une fonction pour gérer la mort du personnage (à implémenter)
            OnPlayerDeath();
        }
    }

    private void OnPlayerDeath()
    {
        // Implémentez ici ce qui doit se passer lorsque le personnage meurt
        // Par exemple, vous pouvez jouer une animation, afficher un message, etc.
        //Debug.Log("Le personnage est mort");
    }
}