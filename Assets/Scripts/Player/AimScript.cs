using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.InputSystem.OnScreen;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class AimScript : MonoBehaviour
{
    public InputActionReference aimAction;
    public GameObject aimJoystick;

    public Vector2 aimPoint;
    public Vector2 startPoint;

    bool validPosition = false;

    public float aimAngle = 0f;

    void Awake()
    {
        EnhancedTouchSupport.Enable();
    }

    public void Start()
    {
       
    }

    private void OnEnable()
    {
        
    }

    public void Update()
    {
        foreach (var touch in Touch.activeTouches)
        {
            if ((touch.screenPosition.x <= 2200 && touch.screenPosition.x >= 1400) && (touch.screenPosition.y >= 200 && touch.screenPosition.y <= 1000))
            {
                if(!validPosition)
                {
                    aimJoystick.transform.position = touch.screenPosition;
                    aimJoystick.gameObject.SetActive(true);

                    startPoint = touch.screenPosition;

                    validPosition = true;
                    break;
                }
            }
        }

        if (validPosition)
        {
            CalcAngle();

            if(aimAngle == 0)
            {
                validPosition = false;
                aimJoystick.SetActive(false);
            }
        }

        /* DISABLE JOYSTICK
         * You find the X and Y locaqtion of where the player touches the screen DONE
         * You move the transform position of the joystick and ENABLE IT
        */

    }

    void CalcAngle()
    {
        aimPoint = aimAction.action.ReadValue<Vector2>();
        aimAngle = Vector2.Angle(startPoint, aimPoint);

        Debug.Log("Aim Angle; " + aimAngle);
    }
}
