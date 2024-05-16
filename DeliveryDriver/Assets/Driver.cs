using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Driver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {   
        transform.Translate(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        // rotates the car on the z axis
        transform.Rotate(0, 0, -0.2f);
        
        // moves the car forward
        transform.Translate(0, 0.01f, 0);
    }
}
