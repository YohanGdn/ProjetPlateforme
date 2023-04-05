
/*

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ChangementEtat : MonoBehaviour

    enum PlayerState { DoubleJump, Dash, Shield }
    PlayerState currentState = PlayerState.DoubleJump;
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            switch (currentState)
            {
                case PlayerState.DoubleJump:
                    currentState = PlayerState.Dash;
                    break;
                case PlayerState.Dash
                    currentState = PlayerState.Shield;
                    break;
                case layerState.Shield:
                    currentState = PlayerState.DoubleJump;
                    break;
                
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            switch (currentState)
            {
                case Test.state1:
                    currentState = Test.state4;
                    break;
                case Test.state2:
                    currentState = Test.state1;
                    break;
                case Test.state3:
                    currentState = Test.state2;
                    break;
               
            }
        }
        switch (myEnum)
        {
            case Test.state1:
                Debug.Log("State1");
                break;
            case Test.state2:
                Debug.Log("State2");
                break;
            case Test.state3:
                Debug.Log("State3");
                break;
            case Test.state4:
                Debug.Log("State4");
                break;
        }
    }
}

*/