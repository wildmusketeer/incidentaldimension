using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matchstick_Behavior : MonoBehaviour
{
    Camera cam2D;

    public GameObject mFireballToShoot;

    public float cFireInterval = 2.0f;
    public float mFireTimer;
    // Use this for initialization
    void Start()
    {
        mFireTimer = 0.0f;
        cam2D = GameObject.Find("2DCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPos = cam2D.WorldToScreenPoint(transform.position);
        if (screenPos.x >= 0.0f && screenPos.x <= cam2D.pixelWidth && screenPos.y >= 0.0f && screenPos.y <= cam2D.pixelHeight)
        {
            mFireTimer += Time.deltaTime;

            if (mFireTimer >= cFireInterval)
            {
                mFireTimer = 0.0f;
                GameObject currFireball = GameObject.Instantiate(mFireballToShoot, transform.position, transform.rotation);
                currFireball.GetComponent<Fireball_Behavior>().mDirection = -transform.right;
                currFireball.SetActive(true);
            }
        }        
    }
}
