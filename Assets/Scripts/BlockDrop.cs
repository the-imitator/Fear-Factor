using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// USAGE: put this on platforms with NO SPRING JOINT that fall 3 seconds after player stands on it. 
// FUNCTION: cause the block to fall away after 3 seconds once the player steps on it

// process:
// 1. player collides
// 2. isCounting becomes true, timer -= Time.deltaTime
// 3. player can leave block or stay, but timer continues.
// 4. once timer hits 0, isDropping becomes true.
// 5. block drops.
public class BlockDrop : MonoBehaviour
{
    public float timer;
    bool isCounting = false;
    bool isDropping = false;
    float dropSpeed = 0;

    void Start() {
        timer = 1.0f;
    }

    void Update() {
        if (isCounting) {
            timer -= Time.deltaTime;
        }
        if (timer <= 0) {
            isDropping = true;
        }
        if (isDropping) {
            Drop();
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player" && timer > 0) {
            isCounting = true;
        }
    }

    private void Drop() {
        dropSpeed += Time.deltaTime / 10;
        transform.position = new Vector3(transform.position.x,
            transform.position.y - dropSpeed,
            transform.position.z);

        Destroy(gameObject, 5);
    }

}
