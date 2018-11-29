using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed = 18;
    //public Vector3 jump;
    public float jumpForce = 2.0f;
    //public bool isGrounded;
    public CharacterController controller;
    //https://youtu.be/IeuqDVKfJag?list=PLiyfvmtjWC_V_H-VMGGAZi7n5E0gyhc37&t=543
    //Rigidbody rb;
    public float gravityScale;

    private Vector3 moveDirection;
    //private Rigidbody rig;

    void Start () {
        //rig = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
	}

    void OnCollisionStay()
    {
        //isGrounded = true;
    }

    void OnCollisionExit()
    {
        //isGrounded = false;
    }

    void Update()
    {
        /*
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);

        Vector3 movement = new Vector3(hAxis, 0, vAxis) * speed * Time.deltaTime;
        rig.MovePosition(transform.position + movement);
        */


        //moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);
        float yStore = moveDirection.y;
        moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
        moveDirection = moveDirection.normalized * moveSpeed;
        moveDirection.y = yStore;
        if (controller.isGrounded)
        {
            moveDirection.y = 0f;
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);

        //https://youtu.be/bJ6pbT3RzLA?t=812
    }
}
