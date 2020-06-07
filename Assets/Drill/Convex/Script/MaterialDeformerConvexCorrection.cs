using System.Linq;
using Unity.Mathematics;
using UnityEngine;

namespace Simulation
{
    /// <summary>
    /// The terrain deformer which modifies the terrain
    /// </summary>
    public class MaterialDeformerConvexCorrection : MonoBehaviour
    {
        /// <summary>
        /// How fast the terrain is deformed
        /// </summary>
        private float deformSpeed = 1f;

        /// <summary>
        /// How far the deformation can reach
        /// </summary>
        private float deformRange = 1f;

        /// <summary>
        /// The world the will be deformed
        /// </summary>
        [Header("Player Settings")]
        [SerializeField] private World world;

        private void Update()
        {
            Deform();
            DrillTerrain();
        }

        /// <summary>
        /// drill the material if the drill touches some material
        /// </summary>
        private void DrillTerrain()
        {
            SphereCollider colliderOfDrill = GetComponent<SphereCollider>();
            Vector3 centerOfDrill = transform.position;
            if (!Physics.CheckSphere(centerOfDrill, colliderOfDrill.radius)) { return; }
            EditTerrainSphere(centerOfDrill, deformSpeed, deformRange);
        }

        /// <summary>
        /// Deforms the material in a spherical region around the point
        /// </summary>
        /// <param name="point">The point to modify the terrain around</param>
        /// <param name="deformSpeed">How fast the terrain should be deformed</param>
        /// <param name="range">How far the deformation can reach</param>
        private void EditTerrainSphere(Vector3 point, float deformSpeed, float range)
        {
            Transform transformDrill = GetComponent<Transform>();
            int intScaleX = Mathf.RoundToInt(transformDrill.localScale.x);
            int intScaleY = Mathf.RoundToInt(transformDrill.localScale.y);
            int intScaleZ = Mathf.RoundToInt(transformDrill.localScale.z);

            int buildModifier = -1;

            int hitX = Mathf.RoundToInt(point.x);
            int hitY = Mathf.RoundToInt(point.y);
            int hitZ = Mathf.RoundToInt(point.z);

            int intRange = Mathf.CeilToInt(range);

            for (int x = -intRange * intScaleX; x <= intRange * intScaleX; x++)
            {
                for (int y = 0; y <= intRange * intScaleY; y++)
                {
                    for (int z = -intRange * intScaleZ; z <= intRange * intScaleZ; z++)
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
        /// Gets the user input from the keyboard and uses that to rotate the drill
        /// </summary>
        /// <summary>
        /// Gets the user input from the keyboard and uses that to rotate the drill
        /// </summary>
        void Deform()
        {
            if (deformRange <= 0)
            {
                Debug.LogWarning("Deform Range must be positive");
                return;
            }

            if (deformSpeed <= 0)
            {
                Debug.LogWarning("Deform Speed must be positive!");
                return;
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (deformSpeed < 20f)
                    deformSpeed += 1f;
                else
                    deformSpeed = 20f;
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                if (deformSpeed > 1f)
                    deformSpeed -= 1f;
                else
                    deformSpeed = 1f;
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                if (deformRange < 3f)
                    deformRange += 0.1f;
                else
                    deformRange = 3f;
            }
            else if (Input.GetKeyDown(KeyCode.T))
            {
                if (deformRange > 0.1f)
                    deformRange -= 0.1f;
                else
                    deformRange = 0.1f;
            }

            PlayerPrefs.SetFloat("deformSpeed", deformSpeed);
            PlayerPrefs.SetFloat("deformRange", deformRange);
        }
    }
}

