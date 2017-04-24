using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button3D_Behavior : MonoBehaviour
{

    public bool isPressed = false;
    public int collisionCount = 0;

    Animation myAnimation;
    bool startedAnimation = false;
    // Use this for initialization
    void Start()
    {
        collisionCount = 0;

        myAnimation = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {

        if (collisionCount > 0)
        {
            if (!isPressed)
            {
                Debug.Log("press");
                GetComponent<Renderer>().material.color = Color.green;
                isPressed = true;
            }
        }
        else
        {
            if (isPressed)
            {
                //animate it unpressing
                GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }


}
