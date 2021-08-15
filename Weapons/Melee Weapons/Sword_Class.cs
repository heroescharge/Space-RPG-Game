using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_Class : MonoBehaviour
{
    public float damage;
    public float cooldown;
    public float attackRange;
    public float knockback;
    public float sweepAngle;

    public GameObject equippedObject;
    protected GameObject Main_Character;
    protected float playerAngle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void SwingSword() {

    }

    public float GetAngle(Vector3 MC, Vector3 enemy) {
        float signedAng = Mathf.Atan2((enemy - MC).y, (enemy - MC).x) * 180/Mathf.PI;
        if (signedAng < 0) {
            signedAng += 360;
        }
        return signedAng;
    }

}
