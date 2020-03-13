using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Creates a naive voxel space size^3 using cube as a voxel
/// </summary>
public class CreateVoxelSpace : MonoBehaviour
{
    public GameObject cube;
    public int size;
    void Start()
    {
        for(int x = 0; x < size; x++)
        {
            for(int y = 0; y < size; y++)
            {
                for(int z = 0; z < size; z++)
                {
                    Vector3 position = cube.transform.position;
                    position.x += x;
                    position.y += y;
                    position.z += z;

                    Quaternion rotation = cube.transform.rotation;

                    GameObject instance = Instantiate(cube, position, rotation);
                    instance.transform.parent = this.transform;
                }
            }
        }
    }
}
