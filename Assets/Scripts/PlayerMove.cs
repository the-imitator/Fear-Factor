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
    public bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {

        //RayCast
        Ray myRay = new Ray(transform.position, Vector3.down);
        float myRayDist = 0.7f;
        Debug.DrawRay(myRay.origin, myRay.direction * myRayDist, Color.yellow);

        //if (Physics.Raycast(myRay, myRayDist)) {
        //    isFalling = false;
        //} else {
        //    isFalling = true;
        //}

        if (Physics.SphereCast(myRay, 0.01f, myRayDist)) {
            isFalling = false;
        } else {
            isFalling = true;
        }

        //jumping
        if (Input.GetButton("Jump") && !isFalling) {
            Jump(jumpForce, forceType);
        }

        //Debug.Log(isFalling);
        // okay fix up this mess here smh


        if (transform.position.y < 15) {
            isDead = true;
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

/*    private void OnCollisionStay(Collision collision) {
        if (isFalling) {
            isFalling = false;
        }
        // CharController - has isGrounded and also can check if only the bottom side is colliding rather
        // than the sides
        // Can also check contact point and if the y of contact is lower than the object, then it is
        // near the bottom
    }*/


}






















// Acacia Developer