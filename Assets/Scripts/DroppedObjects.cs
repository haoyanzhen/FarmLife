using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedObjects : MonoBehaviour
{
    float autoPickupRange;
    float autoPickupCheckOK;
    float autoPickupSpeedScale;
    float autoPickupSpeedMax;
    float autoPickupSleepTime;
    GameObject bag, player;

    float sleepTime;

    // Start is called before the first frame update
    void Start()
    {
        autoPickupRange = Config.instance.autoPickupRange;
        autoPickupCheckOK = Config.instance.autoPickupCheckOK;
        autoPickupSpeedScale = Config.instance.autoPickupSpeedScale;
        autoPickupSpeedMax = Config.instance.autoPickupSpeedMax;
        autoPickupSleepTime = Config.instance.autoPickupSleepTime;

        bag = GameObject.FindWithTag("Bag");
        player = bag.GetComponent<BagEvent>().owner;

        if (player == null)
        {
            Debug.LogWarning("No player found for dropped objects");
        }

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
                if (bag.GetComponent<BagEvent>().AutoPickup(gameObject.GetComponent<SpriteRenderer>().sprite.name))
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
                float step = autoPickupSpeedScale / toPlayerDistance;
                if (step > autoPickupSpeedMax) step = autoPickupSpeedMax;
                transform.position += toPlayerDirection * step * Time.deltaTime;
            }
        }

    }
}