using UnityEngine;

public abstract class State
{
    protected PlayerScript player;
    protected PlayerStateMachine sm;

    public float verticalInput;
    public float horizontalInput;
    public float gravity = -9.8f;
    public bool isGrounded = false;

    // base constructor
    public State(PlayerScript player, PlayerStateMachine sm)
    {
        this.player = player;
        this.sm = sm;
    }

    //methods that can be overriden by each state
    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void FixedUpdate() { }
    public virtual void Exit() { }
    public virtual void OnCollisionEnter2D(Collision2D collision) { }
    public virtual void OnTriggerEnter2D(Collider2D collision) { }
    public virtual void OnTriggerExit2D(Collider2D collision) { }


    //Common Shared Methods
    //Put methods that you wish to share between other states here
    //Set them to be public
    public void TestMethod(string text)
    {
        Debug.Log(text);
    }

    public void ApplyGravity()
    {
    }

    public void ReadInput()
    {
    }
}
