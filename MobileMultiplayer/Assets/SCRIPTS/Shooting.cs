﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Shooting : MonoBehaviourPunCallbacks
{
    public Camera FPS_Camera;
    public GameObject hitEffectPrefab;

    [Header("Health Related Stuff")]
    public float startHealth = 100;
    private float health;
    public Image healthBar;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        health = startHealth;
        healthBar.fillAmount = health / startHealth;

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire()
    {
        RaycastHit _hit;
        Ray ray = FPS_Camera.ViewportPointToRay(new Vector3(0.5f,0.5f));
        if(Physics.Raycast(ray,out _hit,100))
        {
            Debug.Log(_hit.collider.gameObject.name);

            photonView.RPC("CreateHitEffect",RpcTarget.All,_hit.point);
            if(_hit.collider.gameObject.CompareTag("Player")&&!_hit.collider.gameObject.GetComponent<PhotonView>().IsMine)
            {
                _hit.collider.gameObject.GetComponent<PhotonView>().RPC("TakeDamage",RpcTarget.AllBuffered,10f);


            }
        }
    }

    [PunRPC]

    public void TakeDamage(float _damage,PhotonMessageInfo info)
    {
        health -= _damage;
        Debug.Log(health);

        healthBar.fillAmount = health / startHealth;

        if(health<=0f)
        {
            Die();
            Debug.Log(info.Sender.NickName+"killed"+info.photonView.Owner.NickName);
        }
    }
    [PunRPC]
    public void CreateHitEffect(Vector3 position)
    {
        GameObject hitEffectGameobject = Instantiate(hitEffectPrefab, position, Quaternion.identity);
        Destroy(hitEffectGameobject, 0.5f);
    }

    void Die()
    {
        if(photonView.IsMine)
        {
            animator.SetBool("IsDead",true);
        }
    }
}
