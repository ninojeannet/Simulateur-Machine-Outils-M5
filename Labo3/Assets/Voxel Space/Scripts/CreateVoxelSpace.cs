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
    void Start()
    {
        for(int x = 0; x < sizeX; x++)
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
                    //genre 
                    BoxCollider bc= instance.GetComponent<BoxCollider>();
                    bc.isTrigger = true;
                    Transform tf = instance.GetComponent<Transform>();
                    tf.tag = "VoxelTag";
                }
            }
        }
    }
}
