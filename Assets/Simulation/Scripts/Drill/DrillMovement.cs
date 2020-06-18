using UnityEngine;

namespace Simulation
{
    public class DrillMovement : MonoBehaviour
    {
        /// <summary>
        /// The movement speed of the drill
        /// </summary>
        [Header("Movement")]
        [SerializeField] public float movementSpeed = 10f;
        private float speedRotator = 1f;

        private void Awake()
        {
            speedRotator = 1f;
        }

        private void Update()
        {
            Move();
            Rotation();
        } 

        /// <summary>
        /// Gets the user input from the keyboard and uses that to move the drill
        /// </summary>
        private void Move()
        {
            Vector3 pos = transform.position;

            //back/forward
            if (Input.GetKey(KeyCode.UpArrow))
            {
                pos.z += movementSpeed * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                pos.z -= movementSpeed * Time.deltaTime;
            }

            //left/right
            if (Input.GetKey(KeyCode.RightArrow))
            {
                pos.x += movementSpeed * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                pos.x -= movementSpeed * Time.deltaTime;
            }

            //up/down
            if (Input.GetKey(KeyCode.LeftShift))
            {
                pos.y += movementSpeed * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.Space))
            {
                pos.y -= movementSpeed * Time.deltaTime;
            }

            transform.position = pos;
        }


        /// <summary>
        /// Gets the user input from the keyboard and uses that to rotate the drill
        /// </summary>
        void Rotation()
        {
            //speedRotation
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (speedRotator < 20f)
                    speedRotator += 1f;
                else
                    speedRotator = 20f;
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                if (speedRotator > 1f)
                    speedRotator -= 1f;
                else
                    speedRotator = 1f;
            }
            transform.Rotate(transform.up, speedRotator);
        }

    }
}