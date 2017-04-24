using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball3D_Behavior : MonoBehaviour
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
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = WorldConverter.Convert2DMapToSpherePosition(worldSphereTransform, mCurrPosition, camera2D);

        mCurrPosition += mDirection * Time.deltaTime * cMovementSpeed - playerObject.GetComponent<CharacterController2D>().mMovementThisFrame;
    }

    private void OnCollisionEnter(Collision collision)
    {
        bool hitBox = collision.collider.gameObject.layer == LayerMask.NameToLayer("Box");
        bool hitWall = collision.collider.gameObject.layer == LayerMask.NameToLayer("Wall");
        bool hitButton = collision.collider.gameObject.layer == LayerMask.NameToLayer("Button");
        if (hitBox)
        {
            Debug.Log("Fireball3D Hit Box");
            collision.collider.gameObject.GetComponent<Rigidbody>().AddForce(mDirection * 500.0f, ForceMode.Impulse);
            GameObject.Destroy(gameObject);
        }
        else if (hitWall)
        {
            Debug.Log("Fireball Hit Wall");
            GameObject.Destroy(gameObject);
        }
        else if (hitButton)
        {
            Debug.Log("Fireball3D  Hit Button");
            collision.collider.gameObject.GetComponent<Button3D_Behavior>().collisionCount++;
            GameObject.Destroy(gameObject);
        }
    }


}
