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
        [SerializeField] private float deformSpeed = 0.1f;

        /// <summary>
        /// How far the deformation can reach
        /// </summary>
        [SerializeField] private float deformRange = 3f;


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

            EditTerrain(transform.position, deformSpeed, deformRange);
        }

        /// <summary>
        /// Deforms the material in a spherical region around the point
        /// </summary>
        /// <param name="point">The point to modify the terrain around</param>
        /// <param name="deformSpeed">How fast the terrain should be deformed</param>
        /// <param name="range">How far the deformation can reach</param>
        private void EditTerrain(Vector3 point, float deformSpeed, float range)
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
    }
}