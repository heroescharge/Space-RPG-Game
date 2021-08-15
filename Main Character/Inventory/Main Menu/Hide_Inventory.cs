using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide_Inventory : MonoBehaviour
{
    public GameObject inventory_background;
    // Start is called before the first frame update
    void Start()
    {
        inventory_background.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
