using UnityEngine;

public class IdleState : State
{
    public IdleState(PlayerScript player, PlayerStateMachine sm) : base(player, sm)
    {

    }


    public override void Update()
    {
        Debug.Log("Idle");

        player.animator.Play("Idle");

        //HandleAnim();

        if (player.moveAction.action.IsPressed())
        {
            sm.ChangeState(sm.runState);
        }
    }

    void HandleAnim()
    {
        
    }
}
