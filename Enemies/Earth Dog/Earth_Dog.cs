using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth_Dog : Enemy
{
    Vector3 mainCharacterPos;
    public Rigidbody2D body;
    public Animator Run_Attack;
    
    private SpriteRenderer DogSprite;

    //For pacing
    private float tPace = 0f;
    private float absDistPace = 0f;
    private Vector3 distPace;
    private float anglePace = 0f;
    private bool donePacing = true;
    private Vector3 positionPace;


    // Start is called before the first frame updates
    void Start()
    {  
        donePacing = true;
        runSpeed = 1.5f;
        health = 100f;
        damage = 20f;
        minDist = 3f;
        kbDistance = 800;
        body.freezeRotation = true;
        minDistAfterDetection = 100f;
        paceDistanceMin = 0.5f;
        paceDistanceMax = 1f;
        paceSpeed = 0.5f;
        DogSprite = GetComponent<SpriteRenderer>();

    }
    // Update is called once per frame
    void Update() {
        //Kills mob when health is zero
        if (health <= 0) {
             Destroy(gameObject);
        }
        //Find main character and go towards it
        if (GameObject.Find("Main_Character") != null) {
            mainCharacterPos = GameObject.Find("Main_Character").transform.position;
             if (Vector3.Distance(transform.position, mainCharacterPos) <= minDist) {
                donePacing = true;
                minDist = minDistAfterDetection;
                body.velocity = Vector3.zero;
                //Flip model if character is to the right
                if (mainCharacterPos.x >= transform.position.x) {
                    DogSprite.flipX = true;
                }
                else {
                    DogSprite.flipX = false;
                }
                //Start running animation
                Run_Attack.SetBool("found_Main_Character", true);
                transform.position = Vector3.MoveTowards(transform.position, mainCharacterPos, runSpeed*Time.deltaTime);
            }
            else {
                //Start idle animation
                Run_Attack.SetBool("found_Main_Character", false);
                body.velocity = Vector3.zero;
                Pace();
            }
        }
        else {
            //Start idle animation
            Run_Attack.SetBool("found_Main_Character", false);
            body.velocity = Vector3.zero;
            Pace();
        }
     }

     void Pace() {
        if (donePacing == true || tPace >= absDistPace/paceSpeed) {
            tPace = 0;
            positionPace = transform.position;
            absDistPace = Random.Range(paceDistanceMin, paceDistanceMax);
            anglePace = Random.Range(0, 2 * Mathf.PI);
            distPace = new Vector3(absDistPace * Mathf.Cos(anglePace), absDistPace * Mathf.Sin(anglePace), 0);
            donePacing = false;
            //Flip model if character is to the right
        }
        else {
            if (distPace.x >= 0) {
                DogSprite.flipX = true;
            }
            else {
                DogSprite.flipX = false;
            }
            tPace += Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, positionPace + distPace, paceSpeed*Time.deltaTime);        }
     }
    
     public override void Attack () {
        body.velocity = Vector2.zero;
        Vector3 dir = new Vector3 (transform.position.x - mainCharacterPos.x, transform.position.y - mainCharacterPos.y);
        dir.Normalize();
		body.AddForce(dir * kbDistance, ForceMode2D.Force);
     }
     
}
