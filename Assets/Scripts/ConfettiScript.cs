using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfettiScript : MonoBehaviour {
    private ParticleSystem win;

    void Start() {
        win = GetComponent<ParticleSystem>();
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            win.Play();
        }
    }
}
