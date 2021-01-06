using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move2 : MonoBehaviour
{
    public float speed;
    public Transform feet;
    public LayerMask ground;
    private Rigidbody rbody;
    private float jumpHeight;
    private int doubleJump;
    private Vector3 direction;
    private float rotationSpeed;
    private float rotationX;
    private float rotationY;
    public GameObject ammoPrefab;
    public Transform ammoSpawn;
    private AudioSource audio;
    private AudioSource audio2;

    // Start is called before the first frame update
    void Start()
    {
        speed = 3.0f;
        rotationSpeed = 1f;
        rotationX = 0;
        rotationY = 10f;
        jumpHeight = 5.0f;
        doubleJump = 0;
        rbody = GetComponent<Rigidbody>();
        audio = GetComponents<AudioSource>()[0];
        audio2 = GetComponents<AudioSource>()[1];
    }

    // Update is called once per frame
    void Update()
    {
        direction = Vector3.zero;
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");
        direction = direction.normalized;

        if(direction.x != 0)
        {
            rbody.MovePosition(rbody.position + transform.right * direction.x * speed * Time.deltaTime);
        }
        if(direction.z != 0)
        {
            rbody.MovePosition(rbody.position + transform.forward * direction.z * speed * Time.deltaTime); 
        }
        rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * rotationSpeed;
        rotationY += Input.GetAxis("Mouse Y") * rotationSpeed;
        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);

        bool isGrounded()
        {
            if (Physics.CheckSphere(feet.position, 0.1f, ground))
            {
                doubleJump = 0;
                return true;
            }
            else
            {
                return false;
            }
        }
            if(Input.GetButtonDown("Jump") && (isGrounded() || doubleJump < 2))
            {
                doubleJump += 1;
                audio.Play();
                rbody.AddForce(Vector3.up * jumpHeight, ForceMode.VelocityChange);
            }

            if(Input.GetButtonDown("Fire1"))
        {
            audio2.Play();
            Fire();
        }
            void Fire()
        {
            var ammo = (GameObject)Instantiate(ammoPrefab, ammoSpawn.position, ammoSpawn.rotation);
            ammo.GetComponent<Rigidbody>().velocity = ammo.transform.forward * 9;
            Destroy(ammo, 2.0f);
        }
        
    }
}
