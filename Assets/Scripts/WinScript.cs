using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScript : MonoBehaviour
{
    public MeshRenderer winText;

    void Start() {
        winText = GetComponent<MeshRenderer>();
        winText.GetComponent<MeshRenderer>().enabled = false;
    }
    void OnTriggerEnter (Collider other) {
        if (other.tag == "Player") { 
            winText.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
