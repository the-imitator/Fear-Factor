using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    // USAGE: Put this on the player's camera???
    // FUNCTION: When the player dies, the camera moves to spin around the player slowly.
    float counter;
    public Transform player;
    public bool playerDead;
    public float camOffset = 1.5f;

    void Start() {
        //player = GetComponent<GameObject>();
        playerDead = transform.parent.GetComponent<PlayerMove>().isDead;
        // find a way to store this and access player instead because it is not updated like this.

    }

    void Update() {
        if (playerDead) {
            //transform.parent.GetComponent<PlayerLook>().enabled = false;
            playerDead = transform.parent.GetComponent<PlayerMove>().isDead;

            transform.LookAt(player);

            // rotate camera
            counter += Time.deltaTime/5;
            float x = player.position.x + camOffset + Mathf.Cos(counter);
            float y = player.position.y + camOffset;
            float z = player.position.z + camOffset + Mathf.Sin(counter);

            transform.position = new Vector3(x, y, z);
        }    
    }



}
