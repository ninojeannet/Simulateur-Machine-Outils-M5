using System.Linq;
using Unity.Mathematics;
using UnityEngine;

namespace MarchingCubes.Examples
{
    /// <summary>
    /// The terrain deformer which modifies the terrain
    /// </summary>
    public class TerrainDeformer : MonoBehaviour
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
        /// How far away points the player can deform
        /// </summary>
        [SerializeField] private float maxReachDistance = Mathf.Infinity;


        /// <summary>
        /// The world the will be deformed
        /// </summary>
        [Header("Player Settings")]
        [SerializeField] private World world;

        /// <summary>
        /// The game object that the deformation raycast will be casted from
        /// </summary>
        [SerializeField] private Transform playerCamera;


        /// <summary>
        /// The point where the flattening started
        /// </summary>
        private float3 _flatteningOrigin;

        /// <summary>
        /// The normal of the flattening plane
        /// </summary>
        private float3 _flatteningNormal;

        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

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

            // If left mouse button is pressed
            if (Input.GetMouseButton(0))
            {
                RaycastToTerrain();
            }
        }

        /// <summary>
        /// Tests if the player is in the way of deforming and edits the terrain if the player is not.
        /// </summary>
        private void RaycastToTerrain()
        {
            var ray = new Ray(playerCamera.position, playerCamera.forward);

            if (!Physics.Raycast(ray, out RaycastHit hit, maxReachDistance)) { return; }
            Vector3 hitPoint = hit.point;

            EditTerrain(hitPoint, deformSpeed, deformRange);
        }

        /// <summary>
        /// Deforms the terrain in a spherical region around the point
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