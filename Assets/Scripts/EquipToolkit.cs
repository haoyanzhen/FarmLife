using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipToolkit : MonoBehaviour
{
    Animator animator;
    enum toolTypeEnum {Empty, Axe, Pickaxe, ReapingHook, Hoe, WateringCan, Hammer, Sword}

    public Dictionary<string, Vector3> toolNameToPosition = new Dictionary<string, Vector3>();

    GameObject toolGO;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        //initialize toolNameToPosition dictionary
        toolNameToPosition.Add("Empty", new Vector3(-0.32f, -0.19f, 0));
        toolNameToPosition.Add("Axe", new Vector3(-0.32f, -0.19f, 0));
        toolNameToPosition.Add("Pickaxe", new Vector3(-0.37f, -0.1f, 0));
        toolNameToPosition.Add("ReapingHook", new Vector3(-0.37f, -0.1f, 0));
        toolNameToPosition.Add("Hoe", new Vector3(-0.32f, -0.11f, 0));
        toolNameToPosition.Add("WateringCan", new Vector3(0.57f, -0.02f, 0));
        toolNameToPosition.Add("Hammer", new Vector3(-0.35f, -0.04f, 0));
        toolNameToPosition.Add("Sword", new Vector3(-0.39f, 0.06f, 0));

        //clean all sub objects
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }


        //Add sub object - tool
        GameObject toolGOPrefab = Resources.Load<GameObject>("Prefab/FarmToolGO");
        toolGO = Instantiate(toolGOPrefab, Vector3.zero, Quaternion.identity);
        toolGO.transform.parent = transform;
        toolGO.transform.localScale = new Vector3(3, 3, 3);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetToolAndEquip(string toolName)
    {
        toolGO.transform.localPosition = toolNameToPosition[toolName];
        SpriteRenderer toolSpriteRenderer = toolGO.GetComponent<SpriteRenderer>();
        Sprite newToolSprite = Resources.Load<Sprite>("Pictures/self/"+toolName);
        toolSpriteRenderer.sprite = newToolSprite;

        switch (toolName) {
            case "Empty":
                animator.SetInteger("ToolType", (int)toolTypeEnum.Empty);
                break;
            case "Axe":
                animator.SetInteger("ToolType", (int)toolTypeEnum.Axe);
                break;
            case "Pickaxe":
                animator.SetInteger("ToolType", (int)toolTypeEnum.Pickaxe);
                break;
            case "ReapingHook":
                animator.SetInteger("ToolType", (int)toolTypeEnum.ReapingHook);
                break;
            case "Hoe":
                animator.SetInteger("ToolType", (int)toolTypeEnum.Hoe);
                break;
            case "WateringCan":
                animator.SetInteger("ToolType", (int)toolTypeEnum.WateringCan);
                break;
            case "Hammer":
                animator.SetInteger("ToolType", (int)toolTypeEnum.Hammer);
                break;
            case "Sword":
                animator.SetInteger("ToolType", (int)toolTypeEnum.Sword);
                break;
        }
    }
}
