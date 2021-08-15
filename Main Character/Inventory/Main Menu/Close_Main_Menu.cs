using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close_Main_Menu : MonoBehaviour
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
            CloseInventory();
        }
    }

    void OnMouseDown() {
       CloseInventory();
    }

    void CloseInventory() {
        gameInventory.SetActive(false);
        inventoryOpenButton.SetActive(true);
    }
}
