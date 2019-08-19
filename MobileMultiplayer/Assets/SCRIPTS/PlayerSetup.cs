 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerSetup : MonoBehaviourPunCallbacks
{
    public GameObject[] FPS_Hands_ChildGameObject;
    public GameObject[] Soldier_ChildGameObject;
    public GameObject PlayerUIPrefab;
    private PlayerMovementController playerMovementController;
    public Camera FPSCamera;

    // Start is called before the first frame update
    void Start()
    {
        playerMovementController = GetComponent<PlayerMovementController>();
        if(photonView.IsMine)
        {
            //Activate fps soldier,deactivate hands
            foreach(GameObject gameObject in FPS_Hands_ChildGameObject)
            {
                gameObject.SetActive(true);
            }
            foreach(GameObject gameObject in Soldier_ChildGameObject )
            {
                gameObject.SetActive(false);
            }

            //Instantiate PlayerUI
            GameObject playerUIGameObject = Instantiate(PlayerUIPrefab);
            playerMovementController.joyStick = playerUIGameObject.transform.Find("Fixed Joystick").GetComponent<Joystick>();
            playerMovementController.fixedTouchField = playerUIGameObject.transform.Find("RotationTouchField").GetComponent<FixedTouchField>();


            FPSCamera.enabled = true;

        }
        else
        {
            //activate hands,deactivate soldier
            foreach (GameObject gameObject in FPS_Hands_ChildGameObject)
            {
                gameObject.SetActive(false);
            }
            foreach (GameObject gameObject in Soldier_ChildGameObject)
            {
                gameObject.SetActive(true);
            }

            playerMovementController.enabled = false;
            GetComponent<RigidbodyFirstPersonController>().enabled = false;
            FPSCamera.enabled = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
