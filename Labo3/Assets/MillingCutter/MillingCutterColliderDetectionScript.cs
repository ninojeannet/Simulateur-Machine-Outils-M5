using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MillingCutterColliderDetectionScript : MonoBehaviour
{

    public string targetTag = "";
    public bool isDestroyOnCollision = false;
    private Renderer render;
    // Start is called before the first frame update
    void Start()
    {
        if (targetTag.Equals(""))
        {
            targetTag = "VoxelTag";
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (targetTag.Equals(other.gameObject.tag))
        {
            Debug.Log("OnTriggerStay dans Voxels");
            render = other.gameObject.GetComponent<Renderer>();
            render.material.color = Color.red;
        }
        else
        {
            //Debug.Log(other.gameObject.tag);
            //Debug.Log("OnTriggerEnter");
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (targetTag.Equals(other.gameObject.tag))
        {
            //Debug.Log("OnTriggerStay dans Voxels");
            render = other.gameObject.GetComponent<Renderer>();
            render.material.color = Color.blue;
        }
        else
        {
           // Debug.Log(other.gameObject.tag);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (targetTag.Equals(other.gameObject.tag))
        {
            Debug.Log("OnTriggerStay dans Voxels");
            render = other.gameObject.GetComponent<Renderer>();
            render.material.color = Color.red;
            if (isDestroyOnCollision)
            {
                render.enabled = false;
                //Destroy(other.gameObject);
            }


        }
        else
        {
           //Debug.Log(other.gameObject.tag);

            //Debug.Log("OnTriggerExit");
        }


    }

    void OnCollisionEnter()
    {

    }
    void OnCollisionStay()
    {

    }
    void OnCollisionExit()
    {

    }

}
