using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Driver : MonoBehaviour
{
    // Global Class Variables
    [SerializeField] float steerSpeedScale = 1f;
    [SerializeField] float moveSpeedScale = 0.1f;

    // Start is called before the first frame update
    void Start()
    {   
        transform.Translate(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {   
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeedScale;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeedScale;

        // rotates the car on the z axis
        transform.Rotate(0, 0, -steerAmount);
        
        // moves the car forward
        transform.Translate(0, moveAmount, 0);
    }
}
