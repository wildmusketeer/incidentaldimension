using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderTextureOntoSphere : MonoBehaviour {

    public GameObject mTargetSphere;


    public Camera mCurrCamera;
    public RenderTexture mCurrRenderTexture;
	// Use this for initialization
	void Start ()
    {
        //render as high as possible
        mCurrRenderTexture = new RenderTexture(4096, (int) (4096 * (Screen.height / (float)Screen.width)), 16);
        //setup rendertexture etc.
        mCurrCamera.targetTexture = mCurrRenderTexture;


    }
	
    void ApplyTextureToSphere()
    {
        mTargetSphere.GetComponent<Renderer>().material.mainTexture = mCurrRenderTexture;
    }
	// Update is called once per frame
	void Update ()
    {
        ApplyTextureToSphere();
    }
}
