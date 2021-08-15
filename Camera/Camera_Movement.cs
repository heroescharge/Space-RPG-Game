using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    public Camera mainCamera;
    public Transform mainCharacter;
    private float minCamX = -6;
    private float maxCamX = 6;
    private float minCamY = -6;
    private float maxCamY = 6;
    
    public float camWidth;
    public float camHeight;
    // Start is called before the first frame update
    void Start() {
        mainCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //Change 4f to change scaling ratio 
        mainCamera.orthographicSize = (Screen.height/100f)/4f;
        camHeight = 2f * mainCamera.orthographicSize;
        camWidth = camHeight * mainCamera.aspect;

        //Follow character without going out of bounds
        if (mainCharacter) {
            transform.position = new Vector3(
                Mathf.Clamp(mainCharacter.position.x, minCamX + camWidth/2, maxCamX - camWidth/2),
                Mathf.Clamp(mainCharacter.position.y, minCamY + camHeight/2, maxCamY - camHeight/2),
                transform.position.z
            );
        }
    

    }
}
