using UnityEngine;
using UnityEngine.Events;

public class Main_Character_Movement : MonoBehaviour
{
	public float horizontal = 0f;
	public float vertical = 0f;
	public float health = 100f;
	public float maxHealth = 100f;
	public float angleFacing = 0f;
	public float critChanceGun = 10f;
	public float critDamageGun = 1.15f;
	public float critChanceSword = 15f;
	public float critDamageSword = 1.25f;

    public Rigidbody2D body;

	public float runSpeed = 20.0f;
	public GameObject equippedObject;

	void Start() {
		
		health = maxHealth;
		gameObject.tag = "Main_Character";
		body.freezeRotation = true;
	}

	void Update () {
		if (health <= 0) {
			Destroy(gameObject);
		}
		horizontal = Input.GetAxisRaw("Horizontal") * runSpeed;
		vertical = Input.GetAxisRaw("Vertical") * runSpeed;
		if (horizontal != 0 || vertical != 0) {
			angleFacing = Mathf.Atan2(vertical, horizontal) * 180/Mathf.PI;
			if (angleFacing < 0) {
				angleFacing += 360;
			}
		}
	}


	private void FixedUpdate() {
		body.velocity = new Vector2(horizontal * Time.fixedDeltaTime, vertical * Time.fixedDeltaTime);
        
	}

	void OnCollisionEnter2D (Collision2D target) {
		Enemy enemy = target.gameObject.GetComponent<Enemy>();
		if(target.gameObject.tag == "Mob") {
			health -= enemy.damage;
			enemy.Attack();

			Vector3 dir = new Vector3 (transform.position.x - enemy.transform.position.x, transform.position.y - enemy.transform.position.y);
			dir.Normalize();
			body.AddForce(dir * enemy.kbDistance, ForceMode2D.Force);
			
			

		}
	}



}
