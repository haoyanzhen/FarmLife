using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BagGridEvent : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    GameObject bagItemPrefab, bagItem, bagItemDrag;
    string currentToolName;
    private Vector2 bagItemDraggingShift = new Vector2(30, 250);
    int selfIndex;
    // Start is called before the first frame update
    void Start()
    {
        //Click
        //Clean all sub objects and Add empty sub object
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        bagItemPrefab = Resources.Load<GameObject>("Prefab/FarmToolUI");
        bagItem = Instantiate(bagItemPrefab, Vector3.zero, Quaternion.identity);
        bagItem.GetComponent<RectTransform>().SetParent(this.GetComponent<RectTransform>(), false);
        // toolUI.transform.position = transform.position;
        // toolUI.GetComponent<RectTransform>().sizeDelta = new Vector2(80, 80);
        bagItem.name = "BagItem";

        Transform bagTransform = transform.parent.parent;
        if (bagTransform != null)
        {
            Button button = GetComponent<Button>();

            button.onClick.AddListener(() => {
                bagTransform.GetComponent<BagEvent>().ChooseTool(bagItem);
            });
        }

        selfIndex = int.Parse(gameObject.name.Substring(7));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //save and change tool image sprite
        currentToolName = bagItem.GetComponent<Image>().sprite.name;
        ChangeBagItemSprite("Empty");

        //create a new tool ui at right down of mouse
        RectTransform canvasRect = GameObject.Find("Canvas").GetComponent<RectTransform>();
        Vector2 mousePosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, eventData.position, eventData.pressEventCamera, out mousePosition);

        // Vector2 mousePosition = eventData.position;
        Debug.Log("OnBeginDrag: " + mousePosition);
        Vector3 bagItemDragPosition = new Vector3(mousePosition.x + bagItemDraggingShift.x, mousePosition.y + bagItemDraggingShift.y, 0);
        Debug.Log("bagItemDragPosition: " + bagItemDragPosition);
        bagItemDrag = Instantiate(bagItemPrefab, bagItemDragPosition, Quaternion.identity);
        bagItemDrag.GetComponent<RectTransform>().SetParent(transform.parent.parent.GetComponent<RectTransform>(), false);
        bagItemDrag.GetComponent<Image>().sprite = Resources.Load<Sprite>("Pictures/self/" + currentToolName);
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        //make the new tool ui following mouse
        bagItemDrag.GetComponent<RectTransform>().anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //check Ray cast
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        if (results.Count > 0) 
        {
            //check if raycast to baggrid
            bool ifRaycastBaggrid = false;
            foreach (RaycastResult hitResult in results)
            {
                if (hitResult.gameObject.GetComponent<BagGridEvent>() != null)
                {
                    GameObject hitObject = hitResult.gameObject;
                    string targetToolName = hitObject.GetComponent<BagGridEvent>().SearchBagItem().GetComponent<Image>().sprite.name;
                    //change tool sprite of original baggrid first
                    ChangeBagItemSprite(targetToolName);
                    //change tool sprite of target baggrid last
                    hitObject.GetComponent<BagGridEvent>().ChangeBagItemSprite(currentToolName);
                    ifRaycastBaggrid = true;
                    break;
                }
            }
            if (!ifRaycastBaggrid) ChangeBagItemSprite(currentToolName);
        } else ChangeBagItemSprite(currentToolName);
        
        Destroy(bagItemDrag);

    }

    public void ChangeBagItemSprite(string toolName)
    {
        // Debug.Log("Change: " + this.gameObject.name + "-" + toolName);
        bagItem.GetComponent<Image>().sprite = Resources.Load<Sprite>("Pictures/self/" + toolName);
        
        //change self item name in bag event.
        transform.parent.parent.GetComponent<BagEvent>().itemNames[selfIndex] = toolName;
    }

    public GameObject SearchBagItem()
    {
        if (transform.childCount == 1)
        {
            GameObject bagItem = transform.GetChild(0).gameObject;
            return bagItem;
        }
        else
        {
            Debug.LogWarning("BagGrid: "+this.gameObject.name+" has more than one child!");
            return null;
        }
    }

        
}
