using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedObjects : MonoBehaviour
{
    float autoPickupRange;
    float autoPickupCheckOK;
    float autoPickupSpeedMax;
    float autoPickupSleepTime;
    GameObject[] UIs;
    GameObject bag;
    GameObject player;

    float sleepTime;

    // Start is called before the first frame update
    void Start()
    {
        autoPickupRange = Config.instance.autoPickupRange;
        autoPickupCheckOK = Config.instance.autoPickupCheckOK;
        autoPickupSpeedMax = Config.instance.autoPickupSpeedMax;
        autoPickupSleepTime = Config.instance.autoPickupSleepTime;

        UIs = GameObject.FindGameObjectsWithTag("UI");
        foreach (GameObject i in UIs)
        {
            if (i.name == "Bag")
            {
                bag = i;
                break;
            }
        }
        player = bag.GetComponent<BagEvent>().owner;

        sleepTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //wait for 2 seconds before checking for auto pickup
        if (sleepTime < autoPickupSleepTime)
        {
            sleepTime += Time.deltaTime;
            return;
        }

        float toPlayerDistance = Vector3.Distance(transform.position, player.transform.position);
        if (toPlayerDistance < autoPickupRange)
        {
            if (toPlayerDistance < autoPickupCheckOK)
            {
                //auto pick up
                if (bag.GetComponent<BagEvent>().AutoPickup(this.GetComponent<Image>.sprite.name))
                {
                    Destroy(this.gameObject);
                }
                else
                {
                    sleepTime = 0f;
                }
            } else
            {
                //move towards player
                Vector3 toPlayerDirection = player.transform.position - transform.position;
                toPlayerDirection.Normalize();
                float step = 1 / toPlayerDistance;
                if (step > autoPickupSpeedMax) step = autoPickupSpeedMax;
                transform.position += toPlayerDirection * step * Time.deltaTime;
            }
        }

    }

}