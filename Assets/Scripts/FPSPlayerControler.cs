using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSPlayerControler : MonoBehaviour {
    public bool isActive = false;
    public float speed = 2.0f;
    public float rotationSpeed = 50.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    private Vector3 moveDirection = Vector3.zero;
    public Camera playerCamera;
    public float cameraAngle = 0;
    CharacterController controller;
    // Use this for initialization
    void Start() {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update() {
        if (isActive)
        {
            //postion axis
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            Debug.Log(x);
            Debug.Log(y);  //rotation axis
            float rx = Input.GetAxis("HorizontalRight");
            float ry = Input.GetAxis("VerticalRight");

            if (controller.isGrounded)
            {
                //move players postion
                moveDirection = new Vector3(x, 0, y);
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;
                //Jump
                if (Input.GetButton("Jump"))
                    moveDirection.y = jumpSpeed;
            }
            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);
            //move players rotation
            transform.Rotate(0, rx * rotationSpeed * Time.deltaTime, 0);
            
            playerCamera.transform.Rotate(ry * rotationSpeed * Time.deltaTime, 0, 0);

            //cameraAngle = playerCamera.transform.rotation.x;
            // cameraAngle = Mathf.Clamp(ry, -60f, 60f);
            //playerCamera.transform.rotation = new Quaternion(cameraAngle, 0, 0,0);
            /*
            if (playerCamera.transform.rotation.x > 60)
            {
                playerCamera.transform.SetPositionAndRotation(playerCamera.transform.position, new Quaternion(60, playerCamera.transform.rotation.y, playerCamera.transform.rotation.z, playerCamera.transform.rotation.w));
            }
            if (playerCamera.transform.rotation.x < -60)
            {
                playerCamera.transform.SetPositionAndRotation(playerCamera.transform.position, new Quaternion(-60, playerCamera.transform.rotation.y, playerCamera.transform.rotation.z, playerCamera.transform.rotation.w));
            }
             */
        }
    }
}
