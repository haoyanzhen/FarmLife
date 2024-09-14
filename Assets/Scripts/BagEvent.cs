using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class BagEvent : MonoBehaviour
{
    public GameObject owner;
    public string[] itemNames;
    public List<GameObject> bagGrids;
    

    void Start()
    {
        //initialize itemNames
        itemNames = new string[30];
        for (int i = 0; i < 30; i++)
        {
            itemNames[i] = ("Empty");
        }

        //initialize bagGrids
        Transform[] allChildren = GetComponentsInChildren<Transform>(true);
        foreach (Transform child in allChildren)
        {
            if (child.name.Contains("BagGrid"))
            {
                bagGrids[int.Parse(child.name.Substring(7))] = child.gameObject;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChooseTool(GameObject tool)
    {
        EquipToolkit equipTool = owner.GetComponent<EquipToolkit>();
        if (equipTool != null)
        {
            equipTool.GetToolAndEquip(tool);
        }
    }

    public bool AutoPickup(string itemName)
    {
        //find the first empty grid in bag and fill item.
        for (int i = 0; i < 30; i++)
        {
            if (itemNames[i] == "Empty")
            {
                bagGrids[i].GetComponent<BagGridEvent>().ChangeBagItemSprite(itemName);
                return true;
            }
        }
        return false;
    }


}
