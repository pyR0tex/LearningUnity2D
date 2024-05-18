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
    [SerializeField] float slowSpeed = 20f;
    [SerializeField] float boostSpeed = 60f;
    // Start is called before the first frame update
    void Start()
    {   
        Debug.Log("Driver Start");
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

    void OnTriggerEnter2D(Collider2D other) {
        // Boost and Bump speed adjustments
        if (other.tag == "Boost"){
            // Speeds driver up
            Debug.Log("Booost!");
            moveSpeedScale = boostSpeed;
        }
        if(other.tag == "Obstacle"){
            // Slows Driver Down
            Debug.Log("This message should not print");
        }
    }
    void OnCollisionEnter2D(Collision2D other) {
        // Boost and Bump Adjustments
        moveSpeedScale = slowSpeed;
    }
}
