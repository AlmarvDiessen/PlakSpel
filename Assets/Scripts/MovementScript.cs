using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    private Vector3 Velocity; //Maakt een Vector3 aan voor de Velocity van de speler
    private Vector3 PlayerMovementInput; //Vector3 voor de input van de speler voor het bewegen.
    private Vector2 PlayerMouseInput; //Vector3 voor de input van de speler voor het bewegen van de muis.
    private float xRot; //Maakt een float aan voor de rotatie van de muis op de X as.

    [SerializeField] private Transform PlayerCamera; //Maakt een Transform aan voor de camera van de speler.
    [SerializeField] CharacterController Controller; //Maakt een charactercontroller aan die gelinkt moet worden in Unity.
    [Space] //Dit zorgt voor wat ruimte in de inspector.
    [SerializeField] private float Speed; //Float voor de snelheid van de speler
    [SerializeField] private float Jumpforce; //Float voor hoe hoog de speler kan springen.
    [SerializeField] private float Sensitivity; //Float voor de sens van de muis.
    [SerializeField] private float Gravity; //Float voor de gravity van de speler.


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //Zorgt er voor dat de muis vast staat in het midden van de scherm.
    }
    // Update is called once per frame
    void Update()
    {
        PlayerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")); //Vector 3 die wordt gekoppeld aan de eerder gemaakte vector3. Hier wordt het bewegen goed gemaakt.
        PlayerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")); //Vector3 die wordt gekoppeld aan de eerder gemaakte vector3. Hier wordt het muis bewegen goed gemaakt.

        MovePlayer();
        MoveCamera();
    }

    private void MovePlayer()
    {
        Vector3 MoveVector = transform.TransformDirection(PlayerMovementInput);

        if (Controller.isGrounded) //Kijkt als de speler op de grond staat.
        {
            Velocity.y = -1f; //Als dat zo is, wordt velocity.y op -1f gezet.

            if (Input.GetKeyDown(KeyCode.Space)) //Kijkt als de speler op space drukt.
            {
                Velocity.y = Jumpforce * 2; //Koppelt de velocity aan de jump force zodat de speler springt.
            }
            
        }
        else
        {
            Velocity.y -= Gravity * -2f * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftShift)) //Kijkt als de speler op de linker shift knop drukt
        {
            Controller.Move(MoveVector * (Speed + 5) * Time.deltaTime); //Als dat zo is, wordt de speed sneller
            //Controller.Move(Velocity * Time.deltaTime);
            
        }
        else
        {
            Controller.Move(MoveVector * (Speed + 2) * Time.deltaTime); //Anders blijft de speed hetzelfde.
            Controller.Move(Velocity * Time.deltaTime);
        }

        if (!Controller.isGrounded)
        {
            
        }
        
    }

    private void MoveCamera() //Method voor het bewegen van de camera
    {
        xRot -= PlayerMouseInput.y * Sensitivity; //De xRot wordt minus de MouseInput * Sens gedaan

        xRot = Mathf.Clamp(xRot, -90f, 90f); //Zorgt er voor dat de speler niet verder dan 90 graden omhoog of omlaag kan kijken.

        transform.Rotate(0f, PlayerMouseInput.x * Sensitivity, 0f); //Beweegt de camera
        PlayerCamera.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
    }
}
