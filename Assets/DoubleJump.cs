using System.Collections;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    [SerializeField] CharacterController2D cc;

    private void FixedUpdate()
    {
        cc.maxJumps = 2;
    }
}
