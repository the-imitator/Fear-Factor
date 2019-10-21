using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// USAGE: put this on objects that players should avoid. 
// FUNCTION: players die upon touching these.
public class BlockAvoid : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            other.GetComponent<PlayerMove>().isDead = true;
        }
    
    }
}
