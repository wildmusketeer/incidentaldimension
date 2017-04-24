using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySpriteAnimation : MonoBehaviour
{
    public int mCurrFrame;
    public int mStartFrame;
    public int mEndFrame;
    Renderer rend;

    public float mTimePerFrame;
    float mCurrTime;
    public bool isAnimating;
    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        mCurrFrame = mStartFrame;
        isAnimating = false;

        rend.material.SetTextureOffset("_MainTex", new Vector2(0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        if(isAnimating)
        {
            if (mCurrTime < mTimePerFrame)
            {
                mCurrTime += Time.deltaTime;
            }
            else
            {
                if(mEndFrame >= mStartFrame)
                {
                    mCurrFrame++;
                }
                else
                {
                    mCurrFrame--;
                }
                mCurrTime = 0.0f;
                if (mCurrFrame == mEndFrame)
                {
                    isAnimating = false;
                }
                PlayAnimation();
            }
        }
        
       
    }

    void PlayAnimation()
    {
        float xOffest = 1.0f / (float)( Mathf.Abs(mEndFrame - mStartFrame) + 1) * (float)mCurrFrame;
        Debug.Log("X " + xOffest);
        rend.material.SetTextureOffset("_MainTex", new Vector2(xOffest, 0));
    }
}
