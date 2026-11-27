using UnityEngine;

public class JumpState : State
{

    public JumpState(PlayerScript player, PlayerStateMachine sm) : base(player, sm)
    {

    }
    //I think all the jump related stuff should be in the PS due to it being a universal thing in all states
    public override void Update()
    {
        HandleJump();
    }

    public void HandleJump()
    {

    }
}
