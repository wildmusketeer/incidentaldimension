using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChase2D : MonoBehaviour
{

    const float cDistanceThreshold = 5.0f;
    const float cChaseSpeed = 20.0f;
    public GameObject mChaseTarget;
    bool mShouldChaseUntilCentered = true;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        float xDiff = Mathf.Abs(transform.position.x - mChaseTarget.transform.position.x);
        float yDiff = Mathf.Abs(transform.position.y - mChaseTarget.transform.position.y);
        float distSqr = xDiff * xDiff + yDiff * yDiff;

        if(distSqr >= cDistanceThreshold * cDistanceThreshold)
        {
            mShouldChaseUntilCentered = true;
        }


        //chase
        if(mShouldChaseUntilCentered)
        {
            ChaseTarget(cChaseSpeed);
        }
    }
    
    void ChaseTarget(float chaseSpeed)
    {
        Vector3 target = mChaseTarget.transform.position;
        Vector3 source = transform.position;
        target.z = 0;
        source.z = 0;
        
       
        transform.position += (target - source) * cChaseSpeed * Time.deltaTime;
    }
}
