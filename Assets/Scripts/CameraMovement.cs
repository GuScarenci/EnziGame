using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        this.transform.position = new Vector3(player.transform.position.x,player.transform.position.y,-10);
    }
}
