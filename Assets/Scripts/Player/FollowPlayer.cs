using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;  // Reference to the player's transform
    public Vector3 offset;    // Offset distance between the player and camera

    // Update is called once per frame
    void LateUpdate()
    {
        // Update the position of the camera to follow the player
        transform.position = player.position + offset;
    }
}
