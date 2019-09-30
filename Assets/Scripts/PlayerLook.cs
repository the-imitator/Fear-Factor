using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
