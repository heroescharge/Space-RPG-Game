using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Access_Main_Menu : MonoBehaviour
{
    public GameObject gameInventory;
    public GameObject inventoryOpenButton;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            OpenInventory();
        }
    }

    void OnMouseDown() {
        OpenInventory();
    }

    void OpenInventory () {
        gameInventory.SetActive(true);
        inventoryOpenButton.SetActive(false);
        
    }
}
