using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Creates a naive voxel space size^3 using cube as a voxel
/// </summary>
public class CreateVoxelSpace : MonoBehaviour
{
    public GameObject cube;
    [Range(1, 100)]
    public int sizeX;
    [Range(1, 100)]
    public int sizeY;
    [Range(1, 100)]
    public int sizeZ;

    public Texture baseTexture;
    public Texture workedTexture;



    void Start()
    {

        GameObject go1 = GameObject.Find("SimulatorSettings");
        scriptSimulatorSettings ss1 = go1.GetComponent<scriptSimulatorSettings>();

      

        for (int x = 0; x < sizeX; x++)
        {
            for(int y = 0; y < sizeY; y++)
            {
                for(int z = 0; z < sizeZ; z++)
                {

                    Vector3 position = cube.transform.position;
                    position.x += x;
                    position.y += y;
                    position.z += z;
                    Quaternion rotation = cube.transform.rotation;

                    GameObject instance = Instantiate(cube, position, rotation);
                    instance.transform.parent = this.transform;

                    foreach(Transform child in instance.transform)
                    {
                        child.gameObject.GetComponent<Renderer>().material.mainTexture = workedTexture;
                    }

                    if(x==0)
                    {                    
                        GameObject plane = instance.transform.Find("Left").gameObject;
                        plane.GetComponent<Renderer>().material.mainTexture = baseTexture;
                    }
                    else if(x==sizeX-1)
                    {
                        GameObject plane = instance.transform.Find("Right").gameObject;
                        plane.GetComponent<Renderer>().material.mainTexture = baseTexture;
                    }
                    if(y==0)
                    {
                        GameObject plane = instance.transform.Find("Bottom").gameObject;
                        plane.GetComponent<Renderer>().material.mainTexture = baseTexture;
                    }
                    if(y==sizeY-1)
                    {
                        GameObject plane = instance.transform.Find("Top").gameObject;
                        plane.GetComponent<Renderer>().material.mainTexture = baseTexture;
                    }
                    if(z==0)
                    {
                        GameObject plane = instance.transform.Find("Front").gameObject;
                        plane.GetComponent<Renderer>().material.mainTexture = baseTexture;
                    }
                    else if(z==sizeZ-1)
                    {
                        GameObject plane = instance.transform.Find("Back").gameObject;
                        plane.GetComponent<Renderer>().material.mainTexture = baseTexture;
                    }

                }
            }
        }
    }

/*
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
*/
}
