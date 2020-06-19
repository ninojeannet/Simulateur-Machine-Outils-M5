using System.Linq;
using Unity.Mathematics;
using UnityEngine;

namespace Simulation
{
    /// <summary>
    /// The terrain deformer which modifies the terrain
    /// </summary>
    public class MaterialDeformer : MonoBehaviour
    {
        /// <summary>
        /// How fast the terrain is deformed
        /// </summary>
        [SerializeField] private float deformSpeed = 1000f;//0.1f;

        /// <summary>
        /// How far the deformation can reach
        /// </summary>
        [SerializeField] private float deformRange = 0.1f;//3f;


        /// <summary>
        /// The world the will be deformed
        /// </summary>
        [Header("Player Settings")]
        [SerializeField] private World world;

        private void Update()
        {
            if (deformSpeed <= 0)
            {
                Debug.LogWarning("Deform Speed must be positive!");
                return;
            }

            if (deformRange <= 0)
            {
                Debug.LogWarning("Deform Range must be positive");
                return;
            }

            DrillTerrain();
        }


        /// <summary>
        /// drill the material if the drill touches some material
        /// </summary>
        private void DrillTerrain()
        {
            if (!Physics.CheckSphere(transform.position, 0.5f)) { return; }
            EditTerrainSphere(transform.position, deformSpeed, deformRange);
            /*
            Vector3 colliderOfMilling = GetComponent<BoxCollider>().size;
            Vector3 centerOfMilling = transform.position;
           // Vector3 centerOfMiddleTopMilling = new Vector3(transform.position.x, transform.position.y + 2 * colliderOfMilling.radius, transform.position.z);
           // Vector3 centerOfTopMilling = new Vector3(transform.position.x, transform.position.y + 4 * colliderOfMilling.radius, transform.position.z);
           // Vector3 centerOfMiddleBottomMilling = new Vector3(transform.position.x, transform.position.y - 2 * colliderOfMilling.radius, transform.position.z);
           // Vector3 centerOfBottomMilling = new Vector3(transform.position.x, transform.position.y - 4 * colliderOfMilling.radius, transform.position.z);

            if (!Physics.CheckBox(centerOfMilling / 2, centerOfMilling)) { return; }
            */
            //EditTerrain(centerOfTopMilling, deformSpeed, deformRange);
            //EditTerrain(centerOfMiddleTopMilling, deformSpeed, deformRange);
           // EditTerrainCube(centerOfMilling, deformSpeed, deformRange);
           //EditTerrain(centerOfMiddleBottomMilling, deformSpeed, deformRange);
            //EditTerrainSphere(centerOfBottomMilling, deformSpeed, deformRange);
        }

        /// <summary>
        /// Deforms the material in a spherical region around the point
        /// </summary>
        /// <param name="point">The point to modify the terrain around</param>
        /// <param name="deformSpeed">How fast the terrain should be deformed</param>
        /// <param name="range">How far the deformation can reach</param>
        private void EditTerrainSphere(Vector3 point, float deformSpeed, float range)
        {
            int buildModifier = -1;

            int hitX = Mathf.RoundToInt(point.x);
            int hitY = Mathf.RoundToInt(point.y);
            int hitZ = Mathf.RoundToInt(point.z);

            int intRange = Mathf.CeilToInt(range);

            for (int x = -intRange; x <= intRange; x++)
            {
                for (int y = -intRange; y <= intRange; y++)
                {
                    for (int z = -intRange; z <= intRange; z++)
                    {
                        int offsetX = hitX - x;
                        int offsetY = hitY - y;
                        int offsetZ = hitZ - z;

                        var offsetPoint = new int3(offsetX, offsetY, offsetZ);
                        float distance = math.distance(offsetPoint, point);
                        if (distance > range)
                        {
                            continue;
                        }

                        float modificationAmount = deformSpeed / distance * buildModifier;

                        float oldDensity = world.GetDensity(offsetPoint);
                        float newDensity = Mathf.Clamp(oldDensity - modificationAmount, -1, 1);

                        world.SetDensity(newDensity, offsetPoint);
                    }
                }
            }
        }


        /// <summary>
        /// Deforms the material in a cube region around the point
        /// </summary>
        /// <param name="point">The point to modify the terrain around</param>
        /// <param name="deformSpeed">How fast the terrain should be deformed</param>
        /// <param name="range">How far the deformation can reach</param>
        private void EditTerrainCube(Vector3 point, float deformSpeed, float range)
        {
            int buildModifier = -1;

            int hitX = Mathf.RoundToInt(point.x);
            int hitY = Mathf.RoundToInt(point.y);
            int hitZ = Mathf.RoundToInt(point.z);

            int intRange = Mathf.CeilToInt(range);

            for (int x = -intRange; x <= intRange; x++)
            {
                for (int y = -intRange/2; y <= intRange/2; y++)
                {
                    for (int z = -intRange; z <= intRange; z++)
                    {
                        int offsetX = hitX - x;
                        int offsetY = hitY - y;
                        int offsetZ = hitZ - z;

                        var offsetPoint = new int3(offsetX, offsetY, offsetZ);
                        float distance = math.distance(offsetPoint, point);
                        /*
                        if (distance > range)
                        {
                            continue;
                        }
                        */
                        //float modificationAmount = deformSpeed / distance * buildModifier;

                        float oldDensity = world.GetDensity(offsetPoint);
                        float newDensity = Mathf.Clamp(0, -1, 1);

                        world.SetDensity(newDensity, offsetPoint);
                    }
                }
            }
        }

        /// <summary>
        /// Deforms the material in a T^-1 region around the point
        /// </summary>
        /// <param name="point">The point to modify the terrain around</param>
        /// <param name="deformSpeed">How fast the terrain should be deformed</param>
        /// <param name="range">How far the deformation can reach</param>
        private void EditTerrainT(Vector3 point, float deformSpeed, float range)
        {
            int buildModifier = -1;

            int hitX = Mathf.RoundToInt(point.x);
            int hitY = Mathf.RoundToInt(point.y);
            int hitZ = Mathf.RoundToInt(point.z);

            int intRange = Mathf.CeilToInt(range);

            for (int y = -intRange+1; y <= 0; y++)
            {
                for (int x = -intRange/2; x <= (intRange+1)/2; x++)
                {
                    for (int z = -intRange; z <= intRange; z++)
                    {
                        int offsetX = hitX - x;
                        int offsetY = hitY - y;
                        int offsetZ = hitZ - z;

                        var offsetPoint = new int3(offsetX, offsetY, offsetZ);
                        float distance = math.distance(offsetPoint, point);
                        
                        if (distance > range)
                        {
                            continue;
                        }
                        
                        float modificationAmount = deformSpeed / distance * buildModifier;

                        float oldDensity = world.GetDensity(offsetPoint);
                        float newDensity = Mathf.Clamp(oldDensity - modificationAmount, -1, 1);

                        world.SetDensity(newDensity, offsetPoint);
                    }
                }
            }

            for (int y = 0; y <= intRange-3; y++)
            {
                for (int x = -intRange+1; x <= intRange-1; x++)
                {
                    for (int z = -intRange; z <= intRange; z++)
                    {
                        int offsetX = hitX - x;
                        int offsetY = hitY - y;
                        int offsetZ = hitZ - z;

                        var offsetPoint = new int3(offsetX, offsetY, offsetZ);
                        float distance = math.distance(offsetPoint, point);
                        /*
                        if (distance > range)
                        {
                            continue;
                        }
                        */
                        float modificationAmount = deformSpeed / distance * buildModifier;

                        float oldDensity = world.GetDensity(offsetPoint);
                        float newDensity = Mathf.Clamp(oldDensity - modificationAmount, -1, 1);

                        world.SetDensity(newDensity, offsetPoint);
                    }
                }
            }
        }
    }
}