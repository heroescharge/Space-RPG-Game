using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starting_Gun : Gun_Class
{
    public GameObject Bulletprefab;
    // Start is called before the first frame update
    void Start()
    {
        cooldown = 0.5f;
        damage = 10;
        accuracy = 90f;
        attackRange = 20f;
        bulletSpeed = 800;
        knockback = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void FireGun() {
        Main_Character = GameObject.Find("Main_Character");
        Instantiate(Bulletprefab, Main_Character.transform.position, Main_Character.transform.rotation);
    }


}
