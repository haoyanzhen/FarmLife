using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedObjects : MonoBehaviour
{
    float autoPickupRange = Config.instance.autoPickupRange;
    float autoPickupSpeedMax = Config.instance.autoPickupSpeedMax;
    GameObject player = GameObject.FindTag("Player");
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float toPlayerDistance = Vector3.Distance(transform.position, player.transform.position);
        if (toPlayerDistance < autoPickupRange)
        {
            Vector3 toPlayerDirection = player.transform.position - transform.position;
            toPlayerDirection.Normalize();
            float step = 1/toPlayerDistance;
            if (step > autoPickupSpeedMax) step = autoPickupSpeedMax;
            transform.position += toPlayerDirection * step * Time.deltaTime;
            
        }

    }

}