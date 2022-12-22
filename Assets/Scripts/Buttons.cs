using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    bool isActivated = false;
    ButtonManager bm;

    private void Start()
    {
        bm = GameObject.Find("GameManager").GetComponent<ButtonManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isActivated)
        {
            isActivated = true;
            bm.allButtons.Add(true);
        }
    }
}

