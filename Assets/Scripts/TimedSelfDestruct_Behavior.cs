using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSelfDestruct_Behavior : MonoBehaviour
{
    public float mTimeToSelfDestruct = 5.0f;
    public float mExistenceTimer;
    // Use this for initialization
    void Start()
    {
        mExistenceTimer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        mExistenceTimer += Time.deltaTime;

        if (mExistenceTimer >= mTimeToSelfDestruct)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
