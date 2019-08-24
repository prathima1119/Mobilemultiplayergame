using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerMovementController : MonoBehaviour
{
    public Joystick joyStick;
    public FixedTouchField fixedTouchField;


    private RigidbodyFirstPersonController rigidBodyController;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidBodyController = GetComponent < RigidbodyFirstPersonController >();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
     
        rigidBodyController.joystickInputAxis.y = joyStick.Vertical;
        rigidBodyController.mouseLook.lookInputAxis = fixedTouchField.TouchDist;

        Debug.Log("Horizontal" + joyStick.Horizontal);
        Debug.Log("Vertical" + joyStick.Vertical);

        animator.SetFloat("Horizontal", joyStick.Horizontal);
        animator.SetFloat("Vertical", joyStick.Vertical);

        if (Mathf.Abs(joyStick.Horizontal) > 0.9f || Mathf.Abs(joyStick.Vertical) > 0.9f)
        {
            //running
            rigidBodyController.movementSettings.ForwardSpeed = 16;
            animator.SetBool("Horizontal", true);

        }
        else
        {
            //not running
            rigidBodyController.movementSettings.ForwardSpeed = 8;
            animator.SetBool("Horizontal", false);
        }
    }

    private void NewMethod()
    {
        rigidBodyController.joystickInputAxis.x = joyStick.Horizontal;
    }
}
