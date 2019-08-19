using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerMovementController : MonoBehaviour
{
    public Joystick joyStick;
    public FixedTouchField fixedTouchField;


    private RigidbodyFirstPersonController rigidBodyController;
    // Start is called before the first frame update
    void Start()
    {
        rigidBodyController = GetComponent < RigidbodyFirstPersonController >();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rigidBodyController.joystickInputAxis.x = joyStick.Horizontal;
        rigidBodyController.joystickInputAxis.y = joyStick.Vertical;
        rigidBodyController.mouseLook.lookInputAxis = fixedTouchField.TouchDist;
    }
}
