using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public SpriteRenderer sr;
    public Rigidbody2D rb;
    public Animator animator;
    PlayerStateMachine sm;

    //define the actions
    //public InputAction crouchAction;
    public InputAction jumpAction;
    public InputAction interactAction;
    public InputAction resetAction;

    public InputActionReference moveAction;

    public float walkSpeed = 6f;
    public float currentMoveSpeed;



    private void Start()
    {
        sm = new PlayerStateMachine(this); //"this" means - pass a reference of this script (player script) to the statemachine
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        sm.Init(sm.runState); //this will be the first state to run 

        //initialise the actions
        //moveAction = InputSystem.actions.FindAction("Move");
        //crouchAction = InputSystem.actions.FindAction("Crouch");
        interactAction = InputSystem.actions.FindAction("Interact");
        jumpAction = InputSystem.actions.FindAction("Jump");
        resetAction = InputSystem.actions.FindAction("Next");

        currentMoveSpeed = walkSpeed;
    }

    private void Update()
    {
        //do not put any of your own methods here - they go in the individual state files
        sm.Update();

        //UIscript.ui.DrawText("Current state= " + sm.currentState + "  Last state= " + sm.lastState);

    }

    private void FixedUpdate()
    {
        //do not put any of your own methods here - they go in the state files
        sm.FixedUpdate();
    }

    //add your additional collision handling here
    void OnCollisionEnter2D(Collision2D collision)
    {
        sm.currentState.OnCollisionEnter2D(collision);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        sm.currentState.OnTriggerEnter2D(collision);
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        sm.currentState.OnTriggerExit2D(collision);
    }
}
