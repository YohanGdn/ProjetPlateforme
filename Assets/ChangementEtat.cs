

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangementEtat : MonoBehaviour
{

    enum CharacterState { Normal, DoubleJump, Dash, Shield };
    [SerializeField]CharacterState currentCharacterState = CharacterState.Normal;
    [SerializeField] CharacterController2D Cc;
    [SerializeField] DoubleJump doubleJump;
    [SerializeField] DashMeca dash;
    [SerializeField] Shield shield;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            switch (currentCharacterState)
            {
                case CharacterState.Normal:
                    currentCharacterState = CharacterState.DoubleJump;
                    Debug.Log("EtatDoubleJump");
                    break;
                case CharacterState.DoubleJump:
                    currentCharacterState = CharacterState.Dash;
                    Debug.Log("EtatDash");
                    break;
                case CharacterState.Dash:
                    currentCharacterState = CharacterState.Shield;
                    Debug.Log("EtatShield");
                    break;
                case CharacterState.Shield:
                    currentCharacterState = CharacterState.DoubleJump;
                    Debug.Log("EtatDoubleJump");
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            switch (currentCharacterState)
            {
                case CharacterState.Normal:
                    currentCharacterState = CharacterState.DoubleJump;
                    Debug.Log("EtatDoubleJump");
                    break;
                case CharacterState.DoubleJump:
                    currentCharacterState = CharacterState.Shield;
                    Debug.Log("EtatShield");
                    break;
                case CharacterState.Shield:
                    currentCharacterState = CharacterState.Dash;
                    Debug.Log("EtatDash");
                    break;
                case CharacterState.Dash:
                    currentCharacterState = CharacterState.DoubleJump;
                    Debug.Log("EtatDoubleJump");
                    break;

            }
        }
        if (currentCharacterState == CharacterState.DoubleJump)
        {
            doubleJump.enabled = true;
            dash.colere = false;
            dash.enabled = false;
            shield.enabled = false;
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
    }
}