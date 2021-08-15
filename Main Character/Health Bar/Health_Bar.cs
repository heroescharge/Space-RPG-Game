using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Bar : MonoBehaviour
{
    public Transform Health_Slider;
    public GameObject Main_Character;

    private float Main_Character_Health;
    private float Main_Character_MaxHealth;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Main_Character) {
            Main_Character_Health = Main_Character.GetComponent<Main_Character_Movement>().health;
            Main_Character_MaxHealth = Main_Character.GetComponent<Main_Character_Movement>().maxHealth;
            Health_Slider.transform.localScale = new Vector3(0.3603f * Main_Character_Health/Main_Character_MaxHealth, 0.1604f, 1);
        }
        else {
            Health_Slider.transform.localScale = new Vector3(0, 0.1604f, 1);
        }
    }
}
