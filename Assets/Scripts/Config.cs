using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    public static Config instance;
    public Vector2 bagItemDraggingShift = new Vector2(30, 250);
    public float autoPickupRange = 5f;
    public float autoPickupSpeedMax = 3f;

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
