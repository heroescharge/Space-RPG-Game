using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit_Specific_Inventory : MonoBehaviour
{
    public GameObject specificInventory;
    public GameObject menuButtons;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            CloseSpecificInventory();
        }
    }

    void OnMouseDown() {
        CloseSpecificInventory();
    }

    void CloseSpecificInventory() {
        menuButtons.SetActive(true);
        specificInventory.SetActive(false);
    }
}
