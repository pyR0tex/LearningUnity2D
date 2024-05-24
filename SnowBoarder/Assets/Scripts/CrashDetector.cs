using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CrashDetector : MonoBehaviour
{   
    // Globals
    Scene activeScene;
    [SerializeField] float invokeDelay = 2.0f;
    [SerializeField] ParticleSystem bloodEffect;
    [SerializeField] AudioSource audioSource;
    private void Start() {
        activeScene = SceneManager.GetActiveScene();
        bloodEffect = GameObject.FindWithTag("BloodEffect").GetComponent<ParticleSystem>();
        audioSource = GameObject.FindWithTag("Player").GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Head_Death"){
            Debug.Log("Ooops, you DIED!!!");
            bloodEffect.Play();
            audioSource.Play();
            Invoke("ReloadScene", invokeDelay);
        }
    }

    void ReloadScene(){
        SceneManager.LoadScene(activeScene.name);
    }
}
