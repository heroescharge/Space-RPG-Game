using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Switch_Item : MonoBehaviour
{
    public GameObject Main_Character;
    public Sprite Selected_Inventory_Square;
    public Sprite Inventory_Square;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(gameObject.name[6].ToString())) {
            Switch();
        }
    }

    void OnMouseDown () {
        Switch();
    }


    void Switch() {
        if (gameObject.transform.childCount > 0 && Main_Character != null) {
            Main_Character.GetComponent<Main_Character_Movement>().equippedObject = GameObject.Find(gameObject.transform.GetChild(0).gameObject.name);
            GetComponent<SpriteRenderer>().sprite = Selected_Inventory_Square;
            
            for (int i = 1; i <= 5; i++) {
                if (i != Convert.ToInt32(gameObject.name[6]) - 48) { //Check hotbar number, -48 converts ASCII to actual number of hotbar
                    GameObject.Find("Hotbar" + i.ToString()).GetComponent<SpriteRenderer>().sprite = Inventory_Square;
                }
            }
            
        }
    }
}
