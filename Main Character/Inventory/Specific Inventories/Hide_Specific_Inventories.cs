using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide_Specific_Inventories : MonoBehaviour
{
    public GameObject[] specificInventories = new GameObject[6];
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 6; i++) {
            if (specificInventories[i]) {
                specificInventories[i].SetActive(false); 
            }
        }   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
