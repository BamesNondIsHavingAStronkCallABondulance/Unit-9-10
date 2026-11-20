using UnityEngine;

public class RunState : State
{
    public RunState(PlayerScript enemy, PlayerStateMachine sm) : base(enemy, sm)
    {

    }

    public override void Update()
    {
        Debug.Log("running");

        Vector2 moveVector = player.moveAction.ReadValue<Vector2>();

        if (player.moveAction.IsPressed())
        {
            HandleMovement(moveVector);
        }
    }

    private void HandleMovement(Vector2 moveVector)
    {
        Vector2 playerMovement = new Vector2();

        Vector2 newSpeed = new Vector2(moveVector.y * player.currentMoveSpeed, moveVector.x * player.currentMoveSpeed);
        playerMovement.x = newSpeed.x;

        playerMovement = player.moveAction.ReadValue<Vector2>() * player.currentMoveSpeed;

        player.rb.linearVelocityX = playerMovement.x;
    }
}
