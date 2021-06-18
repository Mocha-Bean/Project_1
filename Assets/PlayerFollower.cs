using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    public Player player;
    public Vector2 cameraOffset;
    public float cameraSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var currentPosition = this.transform.position;
        var playerPosition = this.player.transform.position;
        var targetPosition = playerPosition + new Vector3(cameraOffset.x, cameraOffset.y, currentPosition.z);


        //Move the camera to the target
        var movementVector = targetPosition - currentPosition;

        //EndVector = direction * length
        movementVector = movementVector * cameraSpeed;

        this.transform.position = currentPosition + movementVector; // actually better not to normalize the movement vector here; gives you more fluid motion + movement more closely follows player speed
    }
}
