using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform; //Player objects Transform component
    

    private void Update()
    {
        float playerXPos = playerTransform.position.x; //player's x position
        float playerYPos = playerTransform.position.y; //player's y position
        transform.position = new Vector3(playerXPos, playerYPos, transform.position.z);
    }
}
