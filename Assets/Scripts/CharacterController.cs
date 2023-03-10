using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float maxSpeed = 1.0f;
    float rotation = 0.0f;
    float camRotation = 0.0f;
    GameObject cam;
    Rigidbody myRigidbody;
    public int points = 0;

    bool isOnGround;
    public GameObject groundChecker;
    public LayerMask groundLayer;
    public float jumpForce = 300.0f;

    public float rotationSpeed = 2.0f;
    public float camRotationSpeed = 1.5f;

    public GameObject endScreen;
    public int collectablesCollected;

    //public Animator myAnim;

    void Start()
    {


        //myAnim = GetComponentInChildren<Animator>();
        cam = GameObject.Find("Main Camera");
        myRigidbody = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (collectablesCollected >= 6)
        {
            endScreen.SetActive(true);
        }
        isOnGround = Physics.CheckSphere(groundChecker.transform.position, 0.1f, groundLayer);
        //myAnim.SetBool("isOnGround", isOnGround);

        if (isOnGround == true && Input.GetKeyDown(KeyCode.Space))

        {
            //myAnim.SetTrigger("jumped");
            myRigidbody.AddForce(transform.up * jumpForce);
        }

        
        Vector3 newVelocity = (transform.forward * Input.GetAxis("Vertical") * maxSpeed) + (transform.right * Input.GetAxis("Horizontal") * maxSpeed);
        myRigidbody.velocity = new Vector3(newVelocity.x, myRigidbody.velocity.y, newVelocity.z);

        //myAnim.SetFloat("speed", newVelocity.magnitude);


        rotation = rotation + Input.GetAxis("Mouse X");
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, rotation, 0.0f));

        camRotation = camRotation - Input.GetAxis("Mouse Y");
        cam.transform.localRotation = Quaternion.Euler(new Vector3(camRotation, 0.0f, 0.0f));

        camRotation = Mathf.Clamp(camRotation, -40.0f, 40.0f);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Collectible")
        {
            points++;
        }
    }

    private void OnGUI()
    {

        GUI.Label(new Rect(20, 20, 200, 40), "Score:" + points);
    }

}