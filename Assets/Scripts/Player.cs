using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   private GameObject gameManager;
    KYS kys;

    private void Start() {
        gameManager = GameObject.Find("GameManager");
        kys = gameManager.GetComponent<KYS>();
    }

    private void Update() {
        PlaceBody();
    }

    private void PlaceBody() {

        if (Input.GetKeyUp(KeyCode.F)) {
            gameObject.tag = "Corpse";
            kys.Reset();
        }
    }
}
