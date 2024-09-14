using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    public static Config instance;
    public string[] tools = new string[] {"Axe", "Pickaxe", "ReapingHook", "Hoe", "WateringCan", "Hammer", "Sword"};
    public Vector2 bagItemDraggingShift = new Vector2(30, 250);
    public float autoPickupRange = 3f;
    public float autoPickupCheckOK = 1f;
    public float autoPickupSpeedScale = 15f;
    public float autoPickupSpeedMax = 5f;
    public float autoPickupSleepTime = 2f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }
}
