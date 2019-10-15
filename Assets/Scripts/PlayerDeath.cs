using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    // USAGE: Put this on the player's camera???
    // FUNCTION: When the player dies, the camera moves to spin around the player slowly.
    float timer;
    public float camOffset = 1f;
    float rotationSpeed = 0.2f;

    public Transform player;
    public bool playerDead;

    void Start() {
        playerDead = transform.parent.GetComponent<PlayerMove>().isDead;

    }

    void Update() {
        playerDead = transform.parent.GetComponent<PlayerMove>().isDead;
        if (playerDead) {
            transform.parent.GetComponent<PlayerMove>().enabled = false;

            transform.LookAt(player);

            // rotate camera
            timer += Time.deltaTime * rotationSpeed;
            //float x = player.position.x + camOffset + Mathf.Cos(counter);
            //float y = player.position.y + camOffset;
            //float z = player.position.z + camOffset + Mathf.Sin(counter);
            // this only rotates about a specific other position and not around the player....
            // nvm i was just dumb and forgot to add the player.position to the new position.
            float x = -Mathf.Cos(timer) * camOffset;
            float y = camOffset;
            float z = Mathf.Sin(timer) * camOffset;
            transform.position = new Vector3(x, y, z) + player.position;

            transform.parent.eulerAngles = new Vector3(0, 0, 90);
        } else {
            transform.parent.GetComponent<PlayerMove>().enabled = true;
        }
    }



}
