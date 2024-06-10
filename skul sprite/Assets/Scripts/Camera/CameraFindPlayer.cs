using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFindPlayer : MonoBehaviour
{
    GameObject player;
    void OnEnable()
    {
        player = GameObject.Find("Idle"); 
    }

    void Start()
    {
        this.GetComponent<Cinemachine.CinemachineVirtualCamera>().Follow = player.transform;
    }

}
