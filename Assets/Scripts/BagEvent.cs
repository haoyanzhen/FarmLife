using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class BagEvent : MonoBehaviour
{
    public GameObject owner;
    public string[] toolNameList;
    public string[] itemNames;
    public int currentBagSlice;
    public GameObject[] bagGrids, bagSlices;
    public GameObject menu, help;

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
        bagGrids = new GameObject[30];
        foreach (Transform child in allChildren)
        {
            if (child.name.Contains("BagGrid"))
            {
                int index = int.Parse(child.name.Substring(7));
                index--;
                if (index >= 0 && index < bagGrids.Length)
                {
                    bagGrids[index] = child.gameObject;
                }
            }
        }
        //check if all bagGrids are assigned
        for (int i = 0; i < bagGrids.Length; i++)
        {
            if (bagGrids[i] == null)
            {
                Debug.LogWarning("bagGrids[" + i + "] is null");
            }
        }
        //give player basic tools
        toolNameList = Config.instance.tools;
        for (int i = 0; i < 6; i++)
        {
            bagGrids[i].GetComponent<BagGridEvent>().ChangeBagItemSprite(toolNameList[i]);
        }

        //initialize bagSlices
        bagSlices = new GameObject[3];
        foreach (Transform child in allChildren)
        {
            if (child.name.Contains("BagSlice"))
            {
                Debug.Log(child.name);
                int index = (int)child.name[8]-'0';
                index--;
                Debug.Log(index);
                if (index >= 0 && index < bagSlices.Length)
                {
                    bagSlices[index] = child.gameObject;
                }
            }
        }
        //check if all bagSlices are assigned
        for (int i = 0; i < bagSlices.Length; i++)
        {
            if (bagSlices[i] == null)
            {
                Debug.LogWarning("bagSlices[" + i + "] is null");
            }
        }
        //active first bag slice
        currentBagSlice = 0;
        for (int i = 0; i < bagSlices.Length; i++)
        {
            bagSlices[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 40);
            if (i != currentBagSlice)
            {
                bagSlices[i].SetActive(false);
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
                Debug.Log("AutoPickup: "+ bagGrids[i].name);
                bagGrids[i].GetComponent<BagGridEvent>();
                bagGrids[i].GetComponent<BagGridEvent>().ChangeBagItemSprite(itemName);
                return true;
            }
        }
        return false;
    }

    public void ShiftBagSlice(InputAction.CallbackContext context)
    {
        bool shiftDirection = context.ReadValueAsButton();
        if (shiftDirection)
        {
            bagSlices[currentBagSlice].SetActive(false);
            currentBagSlice = (currentBagSlice + 1) % 3;
            bagSlices[currentBagSlice].SetActive(true);
        } else
        {
            bagSlices[currentBagSlice].SetActive(false);
            currentBagSlice = (currentBagSlice + 2) % 3;
            bagSlices[currentBagSlice].SetActive(true);
        }
    }


}
