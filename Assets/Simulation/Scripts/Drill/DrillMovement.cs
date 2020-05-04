using UnityEngine;

namespace Simulation
{
    public class DrillMovement : MonoBehaviour
    {
        /// <summary>
        /// The movement speed of the drill
        /// </summary>
        [Header("Movement")]
        [SerializeField] private float movementSpeed = 10f;

        private void Update()
        {
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
            {
                Move();
            }
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.LeftShift))
            {
                Move();
            }

        } 

        /// <summary>
        /// Gets the user input from the keyboard and uses that to move the drill
        /// </summary>
        private void Move()
        {
            Vector3 movement = Vector3.zero;
            movement.x += Input.GetAxisRaw("Horizontal");
            if (Input.GetKey(KeyCode.Space))
            {
                movement.y++;
            }
            else if (Input.GetKey(KeyCode.LeftShift))
            {
                movement.y--;
            }
            
            movement.z += Input.GetAxisRaw("Vertical");

            transform.Translate(movementSpeed * Time.deltaTime * movement.normalized, Space.Self);
        }

    }
}