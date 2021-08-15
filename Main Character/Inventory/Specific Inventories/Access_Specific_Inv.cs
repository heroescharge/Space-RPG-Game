using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Access_Specific_Inv : MonoBehaviour
{
    public GameObject menuButtons;
    public GameObject specificInv;
    //public GameObject hotBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown() {
        specificInv.SetActive(true);
        menuButtons.SetActive(false);

    }
}
