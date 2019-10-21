using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// USAGE: Put this on the player's camera???
// FUNCTION: When the player dies, the camera moves to spin around the player slowly.
public class PlayerDeath : MonoBehaviour
{
    float timer;
    public float camOffset = 1f;
    public float rotationSpeed = 0.2f;

    public Transform player;
    public bool playerDead;

    void Start() {
        playerDead = transform.parent.GetComponent<PlayerMove>().isDead; 
    }

    void Update() {
        playerDead = transform.parent.GetComponent<PlayerMove>().isDead; //checks if player is dead
        if (playerDead) {
            transform.parent.GetComponent<PlayerMove>().enabled = false; //disables movement
            gameObject.GetComponent<PlayerLook>().enabled = false; //disables mouse looking

            // Rotate camera around player once player is dead
            CamOrbit(player, camOffset); 

            transform.parent.eulerAngles = new Vector3(0, 0, 90); //offset player orientation
        } else {
            transform.parent.GetComponent<PlayerMove>().enabled = true;
        }
    }

    private void CamOrbit(Transform target, float offset) {
        transform.LookAt(target);

        timer += Time.deltaTime * rotationSpeed;
        float x = -Mathf.Cos(timer) * offset;
        float y = offset;
        float z = Mathf.Sin(timer) * offset; //coords for moving camera in circle
        transform.position = new Vector3(x, y, z) + target.position; //move camera in circle in relation to target position

    }



}
