using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldConverter : MonoBehaviour
{
    public Transform sTrans;
    public Vector3 pos2D;
    public Camera mCam2d;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       // transform.position = WorldConverter.Convert2DMapToSpherePosition(sTrans, pos2D, mCam2d);
      //  pos2D.x += Time.deltaTime * 800.0f;
    }

    public static Vector3 Convert2DMapToSpherePosition(Transform sphereTransform, Vector3 mapPos, Camera cam2D, float sphereDistance = 80.0f)
    {
        Vector3 screenPointPos2D = cam2D.WorldToScreenPoint(mapPos);

        float xMid = cam2D.pixelWidth / 2.0f;
        float yMid = cam2D.pixelHeight / 2.0f;
        float xPosPerc = 2 * (screenPointPos2D.x / cam2D.pixelWidth   - 0.5f);
        float yPosPerc = 2 * (screenPointPos2D.y / cam2D.pixelHeight  - 0.5f);  //conver 0~1 t0 -1 to 1

        float angleonAxis = 90.0f;
        float xAngle = -angleonAxis * cam2D.aspect * xPosPerc;
        float yAngle = angleonAxis * yPosPerc;

       Vector3 newUpVector =  Quaternion.Euler(yAngle, xAngle, 0) * -Vector3.forward;

        Vector3 resultPos = sphereTransform.position + sphereDistance * newUpVector;
        return resultPos;
    }

    public static Quaternion Convert2DMapToSphereRotation(Transform sphereTransform, Vector3 mapPos, Camera cam2D)
    {
        Vector3 screenPointPos2D = cam2D.WorldToScreenPoint(mapPos);

        float xMid = cam2D.pixelWidth / 2.0f;
        float yMid = cam2D.pixelHeight / 2.0f;
        float xPosPerc = 2 * (screenPointPos2D.x / cam2D.pixelWidth - 0.5f);
        float yPosPerc = 2 * (screenPointPos2D.y / cam2D.pixelHeight - 0.5f);  //conver 0~1 t0 -1 to 1

        float angleonAxis = 90.0f;
        float xAngle = -angleonAxis * cam2D.aspect * xPosPerc;
        float yAngle = angleonAxis * yPosPerc;
        return Quaternion.Euler(yAngle, xAngle, 0);
    }
}
