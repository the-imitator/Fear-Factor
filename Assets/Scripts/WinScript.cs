using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScript : MonoBehaviour
{
    public GameObject winText;
    public GameObject rText;

    void Start() {
        winText.gameObject.SetActive(false);
        rText.gameObject.SetActive(false);
    }
    void OnTriggerEnter (Collider other) {
        if (other.tag == "Player") {
            winText.gameObject.SetActive(true);
            rText.gameObject.SetActive(true);
        }
    }
}
