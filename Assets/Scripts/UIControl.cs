using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIControl : MonoBehaviour
{
    public GameObject menu, help, bag;

    public UIAction uiAction;

    private void Awake()
    {
        uiAction = new UIAction();
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable() {
        uiAction.Enable();
        uiAction.UI.CallMenu.performed += OnCallMenu;
        uiAction.UI.ChangeBagSlice.performed += bag.GetComponent<BagEvent>().ShiftBagSlice;
        uiAction.UI.ScrollItem.performed += bag.GetComponent<BagEvent>().OnScrollItem;
        uiAction.UI.UseItem1.performed += keyid => bag.GetComponent<BagEvent>().OnUseItem(1);
        uiAction.UI.UseItem2.performed += keyid => bag.GetComponent<BagEvent>().OnUseItem(2);
        uiAction.UI.UseItem3.performed += keyid => bag.GetComponent<BagEvent>().OnUseItem(3);
        uiAction.UI.UseItem4.performed += keyid => bag.GetComponent<BagEvent>().OnUseItem(4);
        uiAction.UI.UseItem5.performed += keyid => bag.GetComponent<BagEvent>().OnUseItem(5);
        uiAction.UI.UseItem6.performed += keyid => bag.GetComponent<BagEvent>().OnUseItem(6);
        uiAction.UI.UseItem7.performed += keyid => bag.GetComponent<BagEvent>().OnUseItem(7);
        uiAction.UI.UseItem8.performed += keyid => bag.GetComponent<BagEvent>().OnUseItem(8);
        uiAction.UI.UseItem9.performed += keyid => bag.GetComponent<BagEvent>().OnUseItem(9);
        uiAction.UI.UseItem10.performed += keyid => bag.GetComponent<BagEvent>().OnUseItem(10);
    }

    private void OnDisable() {
        uiAction.Disable();
        uiAction.UI.CallMenu.performed -= OnCallMenu;
        uiAction.UI.ChangeBagSlice.performed -= bag.GetComponent<BagEvent>().ShiftBagSlice;
        uiAction.UI.ScrollItem.performed -= bag.GetComponent<BagEvent>().OnScrollItem;
        uiAction.UI.UseItem1.performed -= keyid => bag.GetComponent<BagEvent>().OnUseItem(1);
        uiAction.UI.UseItem2.performed -= keyid => bag.GetComponent<BagEvent>().OnUseItem(2);
        uiAction.UI.UseItem3.performed -= keyid => bag.GetComponent<BagEvent>().OnUseItem(3);
        uiAction.UI.UseItem4.performed -= keyid => bag.GetComponent<BagEvent>().OnUseItem(4);
        uiAction.UI.UseItem5.performed -= keyid => bag.GetComponent<BagEvent>().OnUseItem(5);
        uiAction.UI.UseItem6.performed -= keyid => bag.GetComponent<BagEvent>().OnUseItem(6);
        uiAction.UI.UseItem7.performed -= keyid => bag.GetComponent<BagEvent>().OnUseItem(7);
        uiAction.UI.UseItem8.performed -= keyid => bag.GetComponent<BagEvent>().OnUseItem(8);
        uiAction.UI.UseItem9.performed -= keyid => bag.GetComponent<BagEvent>().OnUseItem(9);
        uiAction.UI.UseItem10.performed -= keyid => bag.GetComponent<BagEvent>().OnUseItem(10);
    }

    void Start()
    {
        //initialize Menu and Help UI
        if (menu.activeInHierarchy) menu.SetActive(false);
        if (help.activeInHierarchy) help.SetActive(false);
    }

    public void OnCallMenu(InputAction.CallbackContext context)
    {
        if (menu.activeInHierarchy)
        {
            menu.SetActive(false);
        }
        else if (!menu.activeInHierarchy)
        {
            if (help.activeInHierarchy) help.SetActive(false);
            menu.SetActive(true);
        }
    }
    
    public void OnOpenControlHelp()
    {
        help.SetActive(true);
        if (menu.activeInHierarchy)
        {
            menu.SetActive(false);
        }

    }

    public void OnQuitGame()
    {
        Application.Quit();
    }
}
