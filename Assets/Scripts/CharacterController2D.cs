using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    const float cMovementSpeed = 20.0f;
    public Vector3 mMovementThisFrame;

    public Vector3 previosPos;
    public Vector3 currPos;
    // Use this for initialization
    void Start()
    {
        previosPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        //movementDetection
        Vector3 movementChange = Vector3.zero;
        if(Input.GetKey(KeyCode.W))
        {
            movementChange += new Vector3(0, Time.deltaTime * cMovementSpeed, 0 );
        }
        if (Input.GetKey(KeyCode.S))
        {
            movementChange += new Vector3(0, -Time.deltaTime * cMovementSpeed, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            movementChange += new Vector3(-Time.deltaTime * cMovementSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            movementChange += new Vector3(Time.deltaTime * cMovementSpeed, 0, 0);
        }

       

        //move
        GetComponent<Rigidbody>().AddForce(movementChange * 1000.0f , ForceMode.Impulse);
      //  transform.position += movementChange;

        mMovementThisFrame = movementChange;
        mMovementThisFrame.x *= -1;

        previosPos = currPos;
        currPos = transform.position;

        mMovementThisFrame = currPos - previosPos;
       // mMovementThisFrame.x *= -1;
    }
}
