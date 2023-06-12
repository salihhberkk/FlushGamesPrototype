using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoSingleton<PlayerAnimator>
{
    private Animator animator;
    CharacterState characterState;
    enum CharacterState
    {
        Idle = 0,
        Run = 1,
        FallBack = 2,
        StandUp = 3
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
        SetIdleAnim();
    }
    public void SetRunAnim()
    {
        SetState(CharacterState.Run);
    }
    public void SetIdleAnim()
    {
        SetState(CharacterState.Idle);
    }
    private void SetState(CharacterState state)
    {
        characterState = state;
        animator.SetInteger("state", (int)state);
    }
}
