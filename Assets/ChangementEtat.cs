using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangementEtat : MonoBehaviour
{
    enum CharacterState { Normal, DoubleJump, Dash, Shield };
    [SerializeField] CharacterState currentCharacterState = CharacterState.Normal;
    [SerializeField] CharacterController2D Cc;
    [SerializeField] DoubleJump doubleJump;
    [SerializeField] DashMeca dash;
    [SerializeField] Shield shield;

   

    bool unlockDoubleJump = false;

    [SerializeField] Light auraLight;
    [SerializeField] Color doubleJumpColor;
    [SerializeField] Color dashColor;
    [SerializeField] Color shieldColor;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            switch (currentCharacterState)
            {
                case CharacterState.Normal:
                    currentCharacterState = CharacterState.DoubleJump;
                    UnityEngine.Debug.Log("EtatDoubleJump");
                   
                    break;
                case CharacterState.DoubleJump:
                    currentCharacterState = CharacterState.Dash;
                    UnityEngine.Debug.Log("EtatDash");
                    

                    break;
                case CharacterState.Dash:
                    currentCharacterState = CharacterState.Shield;
                    UnityEngine.Debug.Log("EtatShield");
                   
                    break;
                case CharacterState.Shield:
                    currentCharacterState = CharacterState.DoubleJump;
                    UnityEngine.Debug.Log("EtatDoubleJump");
                    break;
                    
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            switch (currentCharacterState)
            {
                case CharacterState.Normal:
                    currentCharacterState = CharacterState.DoubleJump;
                    UnityEngine.Debug.Log("EtatDoubleJump");
                    

                    break;
                case CharacterState.DoubleJump:
                    currentCharacterState = CharacterState.Shield;
                    UnityEngine.Debug.Log("EtatShield");
                   

                    break;
                case CharacterState.Shield:
                    currentCharacterState = CharacterState.Dash;
                    UnityEngine.Debug.Log("EtatDash");
                    
                    break;
                case CharacterState.Dash:
                    currentCharacterState = CharacterState.DoubleJump;
                    UnityEngine.Debug.Log("EtatDoubleJump");
                    break;
                  
            }
        }

        if (currentCharacterState == CharacterState.DoubleJump)
        {
            doubleJump.enabled = true;
            dash.colere = false;
            dash.enabled = false;
            shield.enabled = false;
            Cc.unlockDoubleJump = true; // Active la possibilité de double saut
        }
        else  
        {
            Cc.unlockDoubleJump = false; // Désactive la possibilité de double saut
            Cc.maxJumps = 1;
        }

        if (currentCharacterState == CharacterState.Dash)
        {
            Cc.maxJumps = 1;
            doubleJump.enabled = false;
            dash.enabled = true;
            shield.enabled = false;
        }

        if (currentCharacterState == CharacterState.Shield)
        {
            Cc.maxJumps = 1;
            doubleJump.enabled = false;
            dash.colere = false;
            dash.enabled = false;
            shield.enabled = true;
        }
        // change la couleur de l'aura du personnage en fonction de son état
        switch (currentCharacterState)
        {
            
            case CharacterState.DoubleJump:
                auraLight.color = doubleJumpColor;
                break;
            case CharacterState.Dash:
                auraLight.color = dashColor;
                break;
            case CharacterState.Shield:
                auraLight.color = shieldColor;
                break;
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        
        if (collision.gameObject.CompareTag("DoubleJump"))
        {
            unlockDoubleJump = true;
        }



    }


}