using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn3D_Behavior : MonoBehaviour
{
    public Transform sphereTransform;
    public Camera camera2D;

    public GameObject prefab3D;

    public GameObject instance3D;
    public float object3DHeight = 80.0f;

    // Use this for initialization
    void Start()
    {
        if(sphereTransform == null)
        {
            sphereTransform = GameObject.Find("WorldSphere").transform;
        }

        if(camera2D == null)
        {
            camera2D = GameObject.Find("2DCamera").GetComponent<Camera>();
        }
        
        if(instance3D == null)
        {
            instance3D = GameObject.Instantiate(prefab3D);
        }
       

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPos = camera2D.WorldToScreenPoint(transform.position);
        bool withinBounds = screenPos.x >= 0.0f && screenPos.x <= camera2D.pixelWidth && screenPos.y >= 0.0f && screenPos.y <= camera2D.pixelHeight;
        if(withinBounds)
        {
            instance3D.transform.position = WorldConverter.Convert2DMapToSpherePosition(sphereTransform, transform.position, camera2D, object3DHeight);
            instance3D.transform.rotation = WorldConverter.Convert2DMapToSphereRotation(sphereTransform, transform.position, camera2D);
        }
        else
        {
            instance3D.transform.position = new Vector3(8000, 8000, 8000);
        }
    }
}
