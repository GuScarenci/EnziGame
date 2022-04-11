using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    float parallax = 0.3f;
    Vector3 startPosition;
    public Transform cam;

    void Start()
    {
        cam = GameObject.FindGameObjectsWithTag("Camera")[0].transform;

        this.transform.parent = cam;

        startPosition = this.transform.position;

    }
    void Update()
    {
        if(cam != null){
            float distanceX = cam.position.x * parallax;
            float distanceY = cam.position.y * parallax;
            transform.position = new Vector3(startPosition.x + distanceX,startPosition.y + distanceY,transform.position.z);
            //Debug.Log(startPosition.position.y + distanceY);
        }
    }
}
