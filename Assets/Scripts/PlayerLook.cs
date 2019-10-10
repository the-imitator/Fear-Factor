using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private float mouseXSensitivity;
    [SerializeField] private float mouseYSensitivity;
    private float verticalAngle = 0.0f;
    private float clampAngle = 90.0f;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        CamRotate();

        if (Input.GetKeyDown(KeyCode.R)) {
            //private Scene thisScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        // Checkpoints?
    }

    private void CamRotate() {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.parent.Rotate(0f, mouseX * mouseXSensitivity, 0f);
        verticalAngle -= mouseY * mouseYSensitivity;
        verticalAngle = Mathf.Clamp(verticalAngle, -clampAngle, clampAngle);

        transform.localEulerAngles = new Vector3(verticalAngle, transform.localEulerAngles.y, 0f);

    }
}
