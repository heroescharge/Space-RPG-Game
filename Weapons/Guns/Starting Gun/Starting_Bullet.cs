using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starting_Bullet : Bullet_Class
{
    

    // Start is called before the first frame update
    void Start()
    {
       GameObject Main_Character = GameObject.Find("Main_Character");
       bulletSpeed = 800f;
       damage = 50f;
       attackRange = 200f;
       knockback = 1000f;
       accuracy = 90f;

      float randomCrit = Random.Range(0f, 100f);
       if (randomCrit <= Main_Character.GetComponent<Main_Character_Movement>().critChanceGun) {
         damage = damage * Main_Character.GetComponent<Main_Character_Movement>().critDamageGun;
       }
       else {
         damage = 50f; //CHANGE ACCORDING TO DAMAGE VALUE
       }
        //Sets initial velocity of bullet based on user direction
        float horizontal = Mathf.Cos(Main_Character.GetComponent<Main_Character_Movement>().angleFacing * Mathf.PI/180) * bulletSpeed;
        float vertical = Mathf.Sin(Main_Character.GetComponent<Main_Character_Movement>().angleFacing * Mathf.PI/180) * bulletSpeed;
        if (vertical == 0 && horizontal == 0) {
            Vector3 v = transform.right * bulletSpeed * Time.fixedDeltaTime;
            float ang = (Random.Range(0.7f * accuracy - 70f,70f - 0.7f * accuracy)) * Mathf.PI/180;
            rb.velocity = new Vector3(v.x * Mathf.Cos(ang) - v.y * Mathf.Sin(ang), v.x * Mathf.Sin(ang) + v.y * Mathf.Cos(ang));
        }
        else {
            Vector3 v = new Vector2(horizontal * Time.fixedDeltaTime, vertical * Time.fixedDeltaTime);
            float ang = (Random.Range(0.7f * accuracy - 70f,70f - 0.7f * accuracy)) * Mathf.PI/180;
            rb.velocity = new Vector3(v.x * Mathf.Cos(ang) - v.y * Mathf.Sin(ang), v.x * Mathf.Sin(ang) + v.y * Mathf.Cos(ang));
        }
        t = Time.time;
    }

    void Update() {

      if (Time.time - t >= attackRange/bulletSpeed) {
        Destroy(gameObject);
      }

    }

    //Destroys bullet once it leaves screen
    void OnBecameInvisible() {
         Destroy(gameObject);
     }

    //Check if collision with enemy has occurred, break and do dmg, don't break bullet if it hits player
    void OnTriggerEnter2D (Collider2D target) {
      if (target.gameObject.tag.Equals("Main_Character") == false) {
        Destroy(gameObject);
      }
      if(target.gameObject.tag == "Mob"){
        target.gameObject.GetComponent<Enemy>().TakeDamage(damage, knockback);
      }
    }


}
