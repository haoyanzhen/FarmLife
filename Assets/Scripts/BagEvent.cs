using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagEvent : MonoBehaviour
{
    public GameObject owner;
    public string[] itemNames;
    public GameObject[] bagGrids;
    // Start is called before the first frame update
    void Start()
    {
        //initialize itemNames
        itemNames = new string[];
        for (int i = 0; i < 30; i++)
        {
            itemNames.Add("Empty");
        }

        //initialize bagGrids
        Transform[] allChildren = GetComponentsInChildren<Transform>(true);
        Transform[] foundBagGrids = allChildren.FindAll(this => t.name.Contains("BagGrid")).OrderBy(t => t.name);
        foreach (Transform t in foundBagGrids)
        {
            bagGrids.Add(t.gameObject);
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
