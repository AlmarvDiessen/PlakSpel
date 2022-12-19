using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{

    GameObject fanBlades;
    float rotationSpeed = 500f;
    bool fanStuck = false;
    
    // Awake is called before the Start method is called
    void Awake()
    {
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
}
