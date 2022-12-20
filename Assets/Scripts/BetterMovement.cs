using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class BetterMovement : MonoBehaviour
    {
        // class for the 3d first person platformer movement using keyboard and mouse
        public float speed = 10f;
        Rigidbody rb;
        Vector3 PlayerMovementInput;
        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            PlayerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

            Vector3 movement = transform.TransformDirection(PlayerMovementInput) * speed;
            rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
        }
    }
}
