using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagEvent : MonoBehaviour
{
    public GameObject owner;
    // Start is called before the first frame update
    void Start()
    {
        
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
}
