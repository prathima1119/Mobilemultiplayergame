 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;


public class PlayerSetup : MonoBehaviourPunCallbacks
{
    public GameObject[] FPS_Hands_ChildGameObject;
    public GameObject[] Soldier_ChildGameObject;
    public GameObject PlayerUIPrefab;
    private PlayerMovementController playerMovementController;
    public Camera FPSCamera;
    private Animator animator;
    private Shooting shooter;

    // Start is called before the first frame update
    void Start()
    {
        shooter = GetComponent<Shooting>();
        animator = GetComponent<Animator>();
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

            playerUIGameObject.transform.Find("FireButton").GetComponent<Button>().onClick.AddListener(()=>shooter.Fire());
            FPSCamera.enabled = true;
            animator.SetBool("IsSoldier", false);

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
            animator.SetBool("IsSoldier", true);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
