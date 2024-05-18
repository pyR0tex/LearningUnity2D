using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    // Global Variables
    bool hasPackage;

    SpriteRenderer spriteRenderer;
    [SerializeField] float PackageDestroyDelay = 1f;
    [SerializeField] Color32 hasPackageColor = new Color32 (255,191,0,255); //white
    [SerializeField] Color32 NoPackageColor = new Color32 (255,0,0,255); //red

    // Methods
    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Ahhh, I'm HIIIT");
    }

    void OnTriggerEnter2D(Collider2D other) {
        // if statements for when Driver collides with other GameObjects
        if (other.tag == "Package"){
            if (!hasPackage){
                Debug.Log("Picked up the Package!");
                spriteRenderer.color = hasPackageColor;
                hasPackage = true;

                Destroy(other.gameObject, PackageDestroyDelay);
            }
            else{
                 Debug.Log("Please drop off the package at the Customer");
            }
        }
        if (other.tag == "Customer"){
            if(hasPackage){
                Debug.Log("Package Delivered!");
                hasPackage = false;
                spriteRenderer.color = NoPackageColor;
            }
            else{
                Debug.Log("Please pickup the package");
            }
        }
        else{
            Debug.Log("Ooops, wasn't supposed to drive over that");
        }
        
    }
}