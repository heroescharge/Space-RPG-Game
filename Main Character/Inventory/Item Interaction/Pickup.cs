using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject itemPrefab;
    public Main_Character_Inventory inventory;

    private void Start()
    {
        inventory = GameObject.Find("Main_Character").GetComponent<Main_Character_Inventory>();
    }

    void OnTriggerEnter2D(Collider2D player){
        bool itemInHotbar = false;

        if(player.tag == "Main_Character") {
            for (int i = 0; i < inventory.slots.Length; i++) {
                if (inventory.isFull[i] != true) {
                   inventory.isFull[i] = true;
                   Instantiate(itemPrefab, inventory.slots[i].transform.position, inventory.slots[i].transform.rotation, inventory.slots[i].transform);
                   Destroy(gameObject);
                   itemInHotbar = true;
                   break; 
                }
            }
            //This part runs if hotbar is completely full
            //Check if melee weapon MAKE SURE TO CHANGE
            if (itemInHotbar == false) {
                if (gameObject.GetComponent<Sword_Class>() != null) {
                    for (int i = 0; i < inventory.meleeSlots.Length; i++) {
                        if (inventory.meleeIsFull[i] != true) {
                            inventory.meleeIsFull[i] = true;
                            GameObject instantObject = Instantiate(itemPrefab, inventory.meleeSlots[i].transform.position, inventory.meleeSlots[i].transform.rotation, inventory.meleeSlots[i].transform) as GameObject;
                            instantObject.transform.parent = inventory.meleeSlots[i].transform;
                            Destroy(gameObject);
                            break; 
                        }
                    }
                }
                //Check if ranged weapon
                if (gameObject.GetComponent<Gun_Class>() != null) {
                    for (int i = 0; i < inventory.gunSlots.Length; i++) {
                        if (inventory.gunIsFull[i] != true) {
                            inventory.gunIsFull[i] = true;
                            GameObject instantObject = Instantiate(itemPrefab, inventory.gunSlots[i].transform.position, inventory.gunSlots[i].transform.rotation, inventory.gunSlots[i].transform) as GameObject; 
                            instantObject.transform.parent = inventory.gunSlots[i].transform;
                            Destroy(gameObject);
                            break; 
                        }
                    }
                }
            }

        } //End of pickup algo


        
    }
}
