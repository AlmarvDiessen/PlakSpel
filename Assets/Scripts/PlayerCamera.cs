using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    // public class for the first person platformer camera that doesn't rotate 360 degrees
    public class PlayerCamera : MonoBehaviour
    {
        // public variables
        public float mouseSensitivity = 100f;
        public Transform playerBody;
        public float xRotation = 0f;

        // Start is called before the first frame update
        void Start()
        {
            // lock the cursor to the center of the screen
            Cursor.lockState = CursorLockMode.Locked;
        }

        // Update is called once per frame
        void Update()
        {
            // get the mouse input
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            // rotate the camera
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}
