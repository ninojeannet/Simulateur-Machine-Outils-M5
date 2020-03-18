using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MillingCutterControleScript : MonoBehaviour
{

    //variable
    public float speed = 20f;
    public float speedRotator = 100f;
    public bool isDrillMachineStyle = true;
    public float maxPositionY = 10f;
    public float minPositionY = -10f;

    // Start is called before the first frame update
    void Start() { /*void*/ }

    void Update()
    {
        positionManager();
        rotationManager();
    }

    void rotationManager()
    {
        //speedRotation
        if (Input.GetKey("1"))
        {
            speedRotator += speedRotator * Time.deltaTime;
        }
        else if (Input.GetKey("2"))
        {
            speedRotator -= speedRotator * Time.deltaTime;
        }

        transform.Rotate(transform.up, speedRotator * Time.deltaTime);
    }

    void positionManager()
    {
        Vector3 pos = transform.position;

        //back/forward
        if (Input.GetKey("w"))
        {
            pos.z += speed * Time.deltaTime;
        }
        else if (Input.GetKey("s"))
        {
            pos.z -= speed * Time.deltaTime;
        }

        //left/right
        if (Input.GetKey("d"))
        {
            pos.x += speed * Time.deltaTime;
        }
        else if (Input.GetKey("a"))
        {
            pos.x -= speed * Time.deltaTime;
        }

        //up/down
        if (isDrillMachineStyle)
        {
            if (Input.GetKey("space"))
            {
                if (pos.y > minPositionY && pos.y < maxPositionY)
                {
                    pos.y -= speed * Time.deltaTime;
                }
            }
            else
            {
                if (pos.y < maxPositionY -1)
                {
                    pos.y += speed * Time.deltaTime;
                }
            }
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                if (pos.y > minPositionY && pos.y < maxPositionY)
                {
                    pos.y -= speed * Time.deltaTime;
                }
            }
            else if (Input.GetMouseButton(1))
            {
                if (pos.y < maxPositionY-1)
                {
                    pos.y += speed * Time.deltaTime;
                }
            }
        }

        transform.position = pos;
    }
}
