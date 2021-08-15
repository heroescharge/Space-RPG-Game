using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Make sword collider not sphere, should only point in front

public class Attack : MonoBehaviour
{
    public GameObject Main_Character;
    
    private float t = 0f;
    private GameObject equippedObject = null;


    // Update is called once per frame
    
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0) && Main_Character.GetComponent<Main_Character_Movement>().equippedObject.tag == "Weapon")
        {
            PlayerAttack();     
        }
    }
    
    void PlayerAttack() {

        if (Main_Character) {
            equippedObject = Main_Character.GetComponent<Main_Character_Movement>().equippedObject;
        }
        if (equippedObject.GetComponent<Gun_Class>() != null) {
             if (Time.time - t >= equippedObject.GetComponent<Gun_Class>().cooldown) {
                equippedObject.GetComponent<Gun_Class>().FireGun();
                t = Time.time;
            }
        }
        else if (equippedObject.GetComponent<Sword_Class>() != null) {
            if (Time.time - t >= equippedObject.GetComponent<Sword_Class>().cooldown) {
                equippedObject.GetComponent<Sword_Class>().SwingSword();
                t = Time.time;
            }
        }

    }

   
    
}
