using UnityEngine;

public class IdleState : State
{
    public IdleState(PlayerScript enemy, PlayerStateMachine sm) : base(enemy, sm)
    {

    }


    public override void Update()
    {
        if (player.moveAction.IsPressed())
        {
            sm.ChangeState(sm.runState);
        }
    }


}
