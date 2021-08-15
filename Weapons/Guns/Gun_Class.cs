using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Class : MonoBehaviour
{
    public float damage;
    public float cooldown;
    public float attackRange;
    public float accuracy; //express as percentage
    public float bulletSpeed;
    public float knockback;

    public GameObject equippedObject;
    protected GameObject Main_Character;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void FireGun () {

    }
}
