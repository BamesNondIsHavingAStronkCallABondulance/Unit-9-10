using UnityEngine;

public class RunState : State
{
    public RunState(PlayerScript player, PlayerStateMachine sm) : base(player, sm)
    {

    }
    Vector2 moveVector;

    public override void Update()
    {
        moveVector = player.moveAction.action.ReadValue<Vector2>();
        player.rb.linearVelocityX = moveVector.x * player.currentMoveSpeed;

        if (moveVector.x > 0)
        {
            player.animator.Play("RunRight-NoAim");
        }
        else if (moveVector.x < 0)
        {
            player.animator.Play("RunLeft-NoAim");
        }

        HandleStates();

    }

    void HandleStates()
    {
        if(moveVector.x < 0.01 && moveVector.x > -0.01)
        {
            sm.ChangeState(sm.idleState);
        }
        else if(player.jumpAction.IsPressed())
        {
            sm.ChangeState(sm.jumpState);
        }
    }
}
