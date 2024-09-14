using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIControl : MonoBehaviour
{
    public GameObject menu, help;

    public UIAction uiAction;

    private void Awake()
    {
        uiAction = new UIAction();
    }

    private void OnEnable() {
        uiAction.Enable();
        uiAction.UI.CallMenu.performed += OnCallMenu;
    }

    private void OnDisable() {
        uiAction.Disable();
        uiAction.UI.CallMenu.performed -= OnCallMenu;
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
