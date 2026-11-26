using UnityEngine;
using UnityEngine.InputSystem;

public class AimScript : MonoBehaviour
{
    public InputActionReference touchAction;

    public Vector2 aimPoint;
    public Vector2 startPoint;

    public GameObject aimJoystick;

    public float aimAngle = 0f;


    public void Start()
    {

    }

    private void OnEnable()
    {
        
    }

    public void Update()
    {

        CalcAngle();
    }

    void CalcAngle()
    {


        aimAngle = Vector2.Angle(startPoint, aimPoint);
    }
}
