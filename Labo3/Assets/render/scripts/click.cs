using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class click : MonoBehaviour
{

    public GameObject voxelSpace;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    
    void OnMouseDown()
    {
        Vector3 position =transform.position;
        //renderHandler script = voxelSpace.GetComponent<renderHandler>();
        Debug.Log(position);
        //script.UpdateRender(Mathf.Round(position.x),Mathf.Round(position.y),Mathf.Round(position.z));
        Destroy(gameObject);
    }
}
