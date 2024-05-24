using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem DustTrailEffect;
    // Start is called before the first frame update
    void Start()
    {
        DustTrailEffect = GameObject.FindWithTag("DustTrail").GetComponent<ParticleSystem>();
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.tag == "Head_Death"){
            DustTrailEffect.Play();
        }
        
    }

    void OnCollisionExit2D(Collision2D other) {
   
        if(other.collider.tag == "Head_Death"){
            DustTrailEffect.Stop();
        }
    }
}
