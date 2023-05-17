

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangementEtat : MonoBehaviour
{
    enum CharacterState { Normal, DoubleJump, Dash, Shield };
    CharacterState currentCharacterState = CharacterState.Normal;

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
    }
}