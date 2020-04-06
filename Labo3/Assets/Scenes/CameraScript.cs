using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    //Variable
    public float speedH = 2.0f;
    public float speedV = 2.0f;
    public float zoom = 100.0f;
    public float zoomSpeed = 20.0f;


    //https://www.youtube.com/watch?v=pQ24NtnaLl8
    private float yaw = 0.0f;
    private float pitch = 0.0f;

    void Start() { /*void*/}

    void Update()
    {
        cameraPosition();
        cameraZoom();
    }
    void cameraPosition()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }


    void cameraZoom()
    {
        Vector3 pos = transform.position;
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            pos = pos - transform.forward;
            transform.position = pos;
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            pos = pos + transform.forward;
            transform.position = pos;
        }
    }
    void MouseWheeling()
    {
        Vector3 pos = transform.position;
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            pos = pos - transform.forward;
            transform.position = pos;
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            pos = pos + transform.forward;
            transform.position = pos;
        }
    }
}

