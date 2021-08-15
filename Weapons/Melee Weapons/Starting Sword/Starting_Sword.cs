using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starting_Sword : Sword_Class
{
    // Start is called before the first frame update
    void Start()
    {
        damage = 50;
        cooldown = 0.25f;
        attackRange = 2;
        knockback = 1000f;
        sweepAngle = 40;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void SwingSword() {
        Main_Character = GameObject.Find("Main_Character");
        if (Main_Character) {
            equippedObject = Main_Character.GetComponent<Main_Character_Movement>().equippedObject;
            playerAngle = Main_Character.GetComponent<Main_Character_Movement>().angleFacing;
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(Main_Character.transform.position, attackRange);
            foreach (Collider2D enemy in hitEnemies) {
                //check if it is mob, and if angle is within sweeping range
                if (enemy.tag == "Mob" && GetAngle(Main_Character.transform.position, enemy.transform.position) >= playerAngle - sweepAngle/2 && GetAngle(Main_Character.transform.position, enemy.transform.position) <= playerAngle + sweepAngle/2) {
                    float randomCrit = Random.Range(0f, 100f);
                    if (randomCrit <= Main_Character.GetComponent<Main_Character_Movement>().critChanceSword) {
                        damage = damage * Main_Character.GetComponent<Main_Character_Movement>().critDamageSword;
                    }
                    else {
                        damage = 50f; //CHANGE ACCORDING TO DAMAGE VALUE
                    }
                    enemy.gameObject.GetComponent<Enemy>().TakeDamage(equippedObject.GetComponent<Sword_Class>().damage, knockback);
                }
            }


        }
    }
}
