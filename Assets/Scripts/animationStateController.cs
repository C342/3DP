using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isJumpingHash;

    private void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isJumpingHash = Animator.StringToHash("isJumping");
    }

    private void Update()
    {
        bool isJumping = animator.GetBool(isJumpingHash);
        bool isWalking = animator.GetBool(isWalkingHash);
        bool forwardPressed = Input.GetKey("w");
        bool JumpPressed = Input.GetKey("space");
        if (!isWalking && forwardPressed)
        {
            animator.SetBool(isWalkingHash, true);
        }

        if (isWalking && !forwardPressed)
        {
            animator.SetBool(isWalkingHash, false);
        }
        
        if (!JumpPressed && (forwardPressed && JumpPressed))
        {
            animator.SetBool(isJumpingHash, true);
        }

        if (JumpPressed && (!forwardPressed || !JumpPressed))
        {
            animator.SetBool(isJumpingHash, false);
        }
    }
}
