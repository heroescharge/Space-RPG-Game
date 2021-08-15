using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float runSpeed;
    public float health;
    public float damage;
    public float minDist;
    public float kbDistance;
    public float minDistAfterDetection;
    public float paceDistanceMin;
    public float paceDistanceMax;
    public float paceSpeed;

    protected Rigidbody2D selfBody;
    public GameObject MC;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Mob";
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public virtual void Attack() {

    }

    public void TakeDamage (float dmg, float knockback) {
        health -= dmg;
        selfBody = gameObject.GetComponent<Rigidbody2D>();
        selfBody.velocity = Vector2.zero;
        Vector3 dir = new Vector3 (transform.position.x - MC.transform.position.x, transform.position.y - MC.transform.position.y);
        dir.Normalize();
		selfBody.AddForce(dir * knockback, ForceMode2D.Force);
    }
}
