using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{   
    // Globals
    Rigidbody2D rb2d;
    SurfaceEffector2D se2d;
    Scene activeScene;
    [SerializeField] float torqueAmount = 10f;
    [SerializeField] float baseSpeed = 20f;
    [SerializeField] float BoostSpeed = 40f;
    [SerializeField] float SlowSpeed = 6f;
    bool disableMovement = false;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        se2d = GameObject.FindWithTag("Head_Death").GetComponent<SurfaceEffector2D>();
        activeScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {   
        if(!disableMovement){
            PlayerMovement();
        }
        else{
            disableControls();
        }
        
    }

    public void disableControls(){
        disableMovement = true;
    }
    void PlayerMovement(){
        if(Input.GetKey(KeyCode.LeftArrow)){
            rb2d.AddTorque(torqueAmount);
        }
        else if(Input.GetKey(KeyCode.RightArrow)){
            rb2d.AddTorque(-torqueAmount);
        }
        else if(Input.GetKey(KeyCode.UpArrow)){
            se2d.speed = BoostSpeed;
        }
        else if(Input.GetKey(KeyCode.DownArrow)){
            se2d.speed = SlowSpeed;
        }
        else{
            se2d.speed = baseSpeed;
        }

        if(Input.GetKey(KeyCode.Escape)){
            ReloadScene();
        }
    }

    void ReloadScene(){
        SceneManager.LoadScene(activeScene.name);
    }
}
