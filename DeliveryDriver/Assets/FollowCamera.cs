using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject toFollow;
    // Camera Position should be the same as the Driver's Position

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = toFollow.transform.position + new Vector3 (0,0,-10);
    }
}
