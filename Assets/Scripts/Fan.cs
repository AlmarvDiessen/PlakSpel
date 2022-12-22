using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{

    GameObject fanBlades;
    float rotationSpeed = 500f;
    bool fanStuck = false;
    KYS _kys;

    // Awake is called before the Start method is called
    void Awake()
    {
        _kys = FindObjectOfType<KYS>();
        fanBlades = GameObject.FindGameObjectWithTag("FanBlades");
    }

    // Update is called once per frame
    void Update()
    {
        if (!fanStuck)
            fanBlades.transform.Rotate((rotationSpeed * Time.deltaTime), 0, 0);
        else
            return;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag != "Player" || fanStuck == true)
            return;
        else
            fanStuck = true;
            _kys.Reset();
    }
}
