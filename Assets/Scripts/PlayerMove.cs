using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    public ForceMode forceType;
    bool isFalling;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        //jumping
        if (Input.GetButton("Jump") && !isFalling) {
            isFalling = true;
            Jump(jumpForce, forceType);
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal"); 
        float vertical = Input.GetAxis("Vertical");
        rb.MovePosition(transform.position + transform.TransformDirection(horizontal, 0, vertical) * Time.deltaTime * speed);
    }

    private void Jump(float force, ForceMode type) {
        rb.AddForce(transform.up * force, type);
    }

    private void OnCollisionStay(Collision collision) {
        if (isFalling) {
            isFalling = false;
        }
    }


}
