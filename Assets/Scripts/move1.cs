using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move1 : MonoBehaviour
{
    public float speed;
    public float gravity;
    public float jumpHeight;
    public Transform feet;
    public LayerMask ground;

    private int doubleJump= 0;
    private Vector3 direction;
    private Vector3 walkingVelocity;
    private Vector3 fallingVelocity;
    private CharacterController controller;
    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        speed = 5.0f;
        gravity = 9.8f;
        jumpHeight = 3.0f;
        direction = Vector3.zero;
        walkingVelocity = Vector3.zero;
        fallingVelocity = Vector3.zero;
        controller = GetComponent<CharacterController>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");
        direction = direction.normalized;

        if (direction != Vector3.zero)
            transform.forward = direction;

        walkingVelocity = direction * speed;
        controller.Move(walkingVelocity * Time.deltaTime);

        bool isGrounded()
        {
            if(Physics.CheckSphere(feet.position, 0.1f, ground))
            {
                doubleJump = 0;
                return true;
            }
            else
            {
                return false;
            }
        }

        fallingVelocity.y -= gravity * Time.deltaTime;
        
        if(Input.GetButtonDown("Jump") && (isGrounded() || doubleJump < 2))
        {
            doubleJump += 1;
            audio.Play();
            fallingVelocity.y = Mathf.Sqrt(gravity * jumpHeight);
        }

        controller.Move(fallingVelocity * Time.deltaTime);
    }
}
