using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MovileFPSGameManager : MonoBehaviour
{
    [SerializeField]
    GameObject PlayerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        if(PhotonNetwork.IsConnectedAndReady)
        {
            if(PlayerPrefab!=null)
            {
                int randomPoint = Random.Range(-10, 10);
                PhotonNetwork.Instantiate(PlayerPrefab.name, new Vector3(randomPoint, 0f, randomPoint), Quaternion.identity);

            }
            else
            {
                Debug.Log("Place playerprefab");
            }
          
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
