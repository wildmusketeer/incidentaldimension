using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box3D_Behavior : MonoBehaviour
{
    public Camera camera2D;
    public Transform worldSphereTransform;

    public Vector3 mCurrPosition;

    public GameObject playerObject;


    public Vector3 mDirection;
    public const float cMovementSpeed = 35.0f;
    // Use this for initialization
    void Start()
    {
        playerObject = GameObject.Find("2DPlayer");
        worldSphereTransform = GameObject.Find("WorldSphere").transform;
        camera2D = GameObject.Find("2DCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = WorldConverter.Convert2DMapToSpherePosition(worldSphereTransform, mCurrPosition, camera2D);
        transform.rotation = WorldConverter.Convert2DMapToSphereRotation(worldSphereTransform, mCurrPosition, camera2D);
    }

    private void OnCollisionEnter(Collision collision)
    {
        bool hitButton = collision.collider.gameObject.layer == LayerMask.NameToLayer("Button");

        if (hitButton)
        {
            Debug.Log("Box3D Hit Buton");
            //trigger it
            collision.collider.gameObject.GetComponent<Button3D_Behavior>().collisionCount++;
        }
    }

    private void OnCollisionExit(Collision collision)
    {

        bool hitButton = collision.collider.gameObject.layer == LayerMask.NameToLayer("Button");
        Debug.Log("Box3D Leave Buton");
        if (hitButton)
        {
            //trigger it
            collision.collider.gameObject.GetComponent<Button3D_Behavior>().collisionCount--;
        }
    
    }
}
