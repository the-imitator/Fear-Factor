using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBlink : MonoBehaviour
{
    float timer;

    void Update() {
        timer += Time.deltaTime;
        if (timer >= 0.4) {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        } 
        if (timer >= 1) {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            timer = 0;
        }
    }
}
