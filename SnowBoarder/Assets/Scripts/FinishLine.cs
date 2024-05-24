using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishLine : MonoBehaviour
{
    // Globals
    [SerializeField] float invokeDelay = 3.0f;
    [SerializeField] ParticleSystem finishLineEffect;
    [SerializeField] AudioSource audioSource;

    void Start() {
        finishLineEffect = GameObject.FindWithTag("FinishLineEffect").GetComponent<ParticleSystem>();
        audioSource = GameObject.FindWithTag("FinishLine").GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        
        if(other.tag == "Player"){
            Debug.Log("Player Finished!");
            finishLineEffect.Play();
            //audioSource.Play();
            Invoke("ReloadScene", invokeDelay);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player"){
            audioSource.Play();
        }
    }

    void ReloadScene(){
        SceneManager.LoadScene("Level1");
    }
}
