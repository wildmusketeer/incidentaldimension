using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Behavior : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip pressSFX;
  
    PlaySpriteAnimation spriteAnimComp;
    public bool isPressed = false;
    bool startedAnimation = false;

    int colCount = 0;

    int fireballContribCount = 0;
    const float cFireBallCounter = 0.3f;
    
    float currFireballCounter;
    // Use this for initialization
    void Start()
    {
        currFireballCounter = 0.0f;
        spriteAnimComp = GetComponent<PlaySpriteAnimation>(); ;
        audioSource = GameObject.Find("CameraSFX").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
      
        if (startedAnimation)
        {
            if(!spriteAnimComp.isAnimating)
            {
                isPressed = !isPressed;
                startedAnimation = false;
            }
        }

        if(colCount + fireballContribCount > 0)
        {
            if (!isPressed)
            {
                spriteAnimComp.mStartFrame = 0;
                spriteAnimComp.mEndFrame = 7;
                spriteAnimComp.isAnimating = true;
                startedAnimation = true;



            }
        }
        else
        {
            if (isPressed)
            {
                spriteAnimComp.mStartFrame = 7;
                spriteAnimComp.mEndFrame = 0;
                spriteAnimComp.isAnimating = true;
                startedAnimation = true;

            }
        }

        if(currFireballCounter > 0)
        {
            currFireballCounter -= Time.deltaTime;
            
        }
        else
        {
            fireballContribCount = 0; 
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        colCount++;           
    }

    private void OnCollisionExit(Collision collision)
    {
        colCount--;        
    }

    public void FireballHitButton()
    {
        currFireballCounter = cFireBallCounter;
        fireballContribCount = 1;
    }
}
