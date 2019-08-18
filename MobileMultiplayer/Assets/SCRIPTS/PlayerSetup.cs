 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSetup : MonoBehaviourPunCallbacks
{
    public GameObject[] FPS_Hands_ChildGameObject;
    public GameObject[] Soldier_ChildGameObject;
    // Start is called before the first frame update
    void Start()
    {
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
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
