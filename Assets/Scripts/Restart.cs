using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    void Update() {/*
        if (Input.GetKeyDown(KeyCode.R) && transform.parent.GetComponent<PlayerMove>().isDead) {
            //private Scene thisScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }*/
        
        // Dev shortcut for now hehe
        if (Input.GetKeyDown(KeyCode.R)) {
            //private Scene thisScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
