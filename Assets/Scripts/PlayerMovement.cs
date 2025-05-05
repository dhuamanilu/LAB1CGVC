using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    Vector3 velocity;
    public float gravity = -9.81f;
    public bool isGrounded;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position,groundDistance,groundMask);
        
        Debug.Log("isGrounded: " + isGrounded); // Ver si está tocando el suelo
        Debug.DrawRay(groundCheck.position, Vector3.down * groundDistance, Color.red);

        if (controller.isGrounded && velocity.y < 0 )
        {
            velocity.y = -2f;
            Debug.Log("Reset velocity.y to -2");
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        //Debug.Log("x: " + x + ", z: " + z); 
        Vector3 move = (transform.right * x) + (transform.forward*z);
        controller.Move(move*speed*Time.deltaTime);
        //velocity.y += gravity * Time.deltaTime;
        Debug.Log("Updated velocity.y (with gravity): " + velocity.y);
        controller.Move(velocity * Time.deltaTime);
        if(Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            Debug.Log("Jump! velocity.y = " + velocity.y);
        }

    }
}
