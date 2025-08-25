using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Photon.Voice;

public class AdvancedEnableDisable : MonoBehaviourPunCallbacks
{
    [Header("How To Trigger?")]
    public bool OnCollide;
    public bool OnStart;
    public bool OnJoiningLobby;
    [Header("Experimental (Use Unity Events To Trigger)")]
    public bool Custom;
    [Header("Objects To Enable")]
    public GameObject[] ToEnable;
    [Header("Objects To Disable")]
    public GameObject[] ToDisable;
    [Header("Setup")]
    public string HandTag = "HandTag";

    private void OnTriggerEnter(Collider buttcheekhand)
    {
        if (OnCollide == true)
        {
            if (buttcheekhand.gameObject.CompareTag(HandTag))
            {
                foreach (GameObject objectsd in ToDisable)
                {
                    objectsd.SetActive(false);
                }
                foreach (GameObject objectse in ToEnable)
                {
                    objectse.SetActive(true);
                }
            }
        }
    }

    private void Start()
    {
        if (OnStart == true)
        {
            foreach (GameObject objectsd in ToDisable)
            {
                objectsd.SetActive(false);
            }
            foreach (GameObject objectse in ToEnable)
            {
                objectse.SetActive(true);
            }
        }
    }

    public void CustomEnableDisable()
    {
        if (Custom == true)
        {
            foreach (GameObject objectsd in ToDisable)
            {
                objectsd.SetActive(true);
            }
            foreach (GameObject objectse in ToEnable)
            {
                objectse.SetActive(false);
            }
        }
    }

    public override void OnJoinedRoom()
    {
        if (OnJoiningLobby == true)
        {
            foreach (GameObject objectsd in ToDisable)
            {
                objectsd.SetActive(false);
            }
            foreach (GameObject objectse in ToEnable)
            {
                objectse.SetActive(true);
            }
        }
    }

    public override void OnLeftRoom()
    {
        if (OnJoiningLobby == true)
        {
            foreach (GameObject objectsd in ToDisable)
            {
                objectsd.SetActive(true);
            }
            foreach (GameObject objectse in ToEnable)
            {
                objectse.SetActive(false);
            }
        }
    }
}

