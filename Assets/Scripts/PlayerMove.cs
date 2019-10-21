using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    public float gravMult;
    public float lowJumpMult;
    bool onGround;
    public bool isDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {

        //Movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        rb.MovePosition(transform.position + transform.TransformDirection(horizontal, 0, vertical) * Time.deltaTime * speed);

        //RayCast
        Ray myRay = new Ray(transform.position, Vector3.down);
        float myRayDist = 1.7f;
        Debug.DrawRay(myRay.origin, myRay.direction * myRayDist, Color.yellow);

        //SphereCast to check if onGround
        if (Physics.SphereCast(myRay, 0.01f, myRayDist)) {
            onGround = true;
        } else {
            onGround = false;
        }

        //Jumping
        if (Input.GetButton("Jump") && onGround) {
            Jump(jumpForce);
        }

        if (transform.position.y < 13) {
            isDead = true;
        }

    }

    private void Jump(float force) {
        rb.AddForce(transform.up * force, ForceMode.Impulse);
        // Better Jump by Board to Bits Games
        /*if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space)) {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMult - 1) * Time.deltaTime;
        } else */
        if (rb.velocity.y < 0) {
            rb.velocity += Vector3.up * Physics.gravity.y * (gravMult - 1) * Time.deltaTime;
        }
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