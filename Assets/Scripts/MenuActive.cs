using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuActive : MonoBehaviour
{
    public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menu.activeInHierarchy)
            {
                menu.SetActive(false);
            }
            else if (!menu.activeInHierarchy)
            {
                menu.SetActive(true);
            }
        }
    }
}
