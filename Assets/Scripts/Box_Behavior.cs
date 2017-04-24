using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_Behavior : MonoBehaviour
{

    public GameObject box3D;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        bool hitConverter = other.gameObject.layer == LayerMask.NameToLayer("Converter");

        if (hitConverter)
        {
            Debug.Log("Box Hit Converter");
            //convert into 3D on sphere
            GameObject newBox = GameObject.Instantiate(box3D);

            newBox.GetComponent<Box3D_Behavior>().mCurrPosition = other.gameObject.transform.position;
            newBox.SetActive(true);
            GameObject.Destroy(gameObject);
            GameObject.Destroy(other.gameObject); // since this is a box...converter was also destroyed
        }

    }
}
