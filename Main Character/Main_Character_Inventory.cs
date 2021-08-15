using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Character_Inventory : MonoBehaviour
{
    //Hotbar
	public bool[] isFull;
   	public GameObject[] slots;

    //Specific inventories
	//Melee
	public bool[] meleeIsFull;
	public GameObject[] meleeSlots;

    public bool[] gunIsFull;
    public GameObject[] gunSlots;

    void Start()
    {
        isFull = new bool[5];
		slots = new GameObject[5];
		for (int i = 0; i < 5; i++) {
			slots[i] = GameObject.Find("Hotbar" + (i+1).ToString());
		}

        meleeIsFull = new bool[64];
        meleeSlots = new GameObject[64];


        gunIsFull = new bool[64];
        gunSlots = new GameObject[64];
        for (int i = 0; i < 64; i++) {
            gunSlots[i] = GameObject.Find("Melee" + (i+1).ToString()); //CHANGE FROM GUN TO MELEE AFTER TESTING
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
