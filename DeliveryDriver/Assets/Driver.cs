using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Driver : MonoBehaviour
{
    // Global Class Variables
    [SerializeField] float steerSpeedScale = 360f;
    [SerializeField] float moveSpeedScale = 30f;

    // Start is called before the first frame update
    void Start()
    {   
        transform.Translate(0,0,0);
    }
    

    // Update is called once per frame
    void Update()
    {   
        // Input.GetAxis receives a value from -1:1
        // scales used to make it 'feel' better
        // Time.deltaTime makes the input framerate INDEPENDENT!
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeedScale * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeedScale * Time.deltaTime;
        // rotates the car on the z axis
        transform.Rotate(0, 0, -steerAmount);
        
        // moves the car forward
        transform.Translate(0, moveAmount, 0);
    }

}
