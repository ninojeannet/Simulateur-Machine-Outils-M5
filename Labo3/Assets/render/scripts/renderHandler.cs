using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class renderHandler : MonoBehaviour
{

    GameObject[] tabVoxels = new GameObject[4];
    public Texture baseTexture;
    public Texture workedTexture;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.childCount);
        int i=0;
        foreach (Transform child in transform)
        {
            Debug.Log(child.position);
            tabVoxels[i] = child.gameObject;
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void UpdateRender(float x,float y,float z)
    {
        Debug.Log("Bloc détruit à la position : x "+x+" y "+y+" z "+z);
        GameObject voxel = tabVoxels[0];
        foreach(Transform child in voxel.transform)
        {
            child.gameObject.GetComponent<Renderer>().material.mainTexture = workedTexture;
            Debug.Log(child.gameObject);
        }
    }
}
