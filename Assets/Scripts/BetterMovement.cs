using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts {
    public class BetterMovement : MonoBehaviour {
        // class for the 3d first person platformer movement using keyboard and mouse
        public float speed = 10f;
        private float jumpPower = 50f;
        public bool grounded;
        Rigidbody rb;
        Vector3 PlayerMovementInput;
        private KYS kysScript;

        private float fallMultiplier = 2.5f;
        private float lowJumpMuliplier = 2f;
        private void Start() {
            rb = GetComponent<Rigidbody>();
            kysScript = GameObject.Find("GameManager").GetComponent<KYS>();
        }

        private void Update() {
            Movement();
            Jumping();  
        }


        private void Movement() {
            PlayerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

            Vector3 movement = transform.TransformDirection(PlayerMovementInput) * speed;
            rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
        }

        private void Jumping() {
            if (Input.GetButtonDown("Jump") && grounded == true) {
                rb.AddForce(Vector3.up * jumpPower);
            }

            if (rb.velocity.y < 0f) {
                rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }
            else if (rb.velocity.y > 0 && !Input.GetButton("Jump")) {
                rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMuliplier - 1) * Time.deltaTime;
            }

        }
        private void OnCollisionEnter(Collision collision) {
            if (collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Corpse")) {
                grounded = true;
            }

            if (collision.gameObject.CompareTag("EndBox"))
            {
                kysScript.goal = true;
            }
        }


        private void OnCollisionExit(Collision collision) {
            if (collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Corpse")) {
                grounded = false;
            }
        }

        private void OnCollisionStay(Collision collision) {
            if (collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Corpse")) {
                grounded = true;
            }
        }
    }
}
