using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Behavior : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip openSFX;

    public bool isDoorClosed;
    PlaySpriteAnimation playSpriteComponent;
    public Button_Behavior[] mConditionalButtons;

    public Button3D_Behavior[] mConditional3DButtons;

    public bool hackedDoorOpen;
    // Use this for initialization
    void Start()
    {
        hackedDoorOpen = false;
        isDoorClosed = true;
        playSpriteComponent = GetComponent<PlaySpriteAnimation>();

        audioSource = GameObject.Find("DoorSFX").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {


        if(Input.GetKeyUp(KeyCode.V))
        {
            OpenDoor();
            hackedDoorOpen = !hackedDoorOpen;
        }
        if(hackedDoorOpen)
        {
            return;
        }

        if (isDoorClosed)
        {
            if (allLinkedButtonsPressed() && allLinked3DButtonsPressed())
            {
                OpenDoor();
            }
            if (!playSpriteComponent.isAnimating)
            {
                GetComponent<Collider>().enabled = true;
            }
        }
        else
        {
            if ((mConditionalButtons.Length > 0 && !allLinkedButtonsPressed()) || (mConditional3DButtons.Length > 0 && !allLinked3DButtonsPressed()))
            {
                CloseDoor();                
            }
            if (!playSpriteComponent.isAnimating)
            {
                GetComponent<Collider>().enabled = false;
            }
        }

    }

    bool allLinkedButtonsPressed()
    {
        bool pressed = true;
        for(int i =0; i < mConditionalButtons.Length; ++i)
        {
            pressed = pressed && mConditionalButtons[i].isPressed;
        }
        return pressed;
    }

    bool allLinked3DButtonsPressed()
    {
        bool pressed = true;
        for (int i = 0; i < mConditional3DButtons.Length; ++i)
        {
            pressed = pressed && mConditional3DButtons[i].isPressed;
        }
        return pressed;
    }

    void OpenDoor()
    {
        if(isDoorClosed)
        {
            playSpriteComponent.isAnimating = true;
            playSpriteComponent.mStartFrame = 0;
            playSpriteComponent.mEndFrame = 9;
        }
        isDoorClosed = false;
        audioSource.pitch = 1.0f;
        audioSource.PlayOneShot(openSFX);
    }

    void CloseDoor()
    {
        if (!isDoorClosed)
        {
            playSpriteComponent.isAnimating = true;
            playSpriteComponent.mStartFrame = 9;
            playSpriteComponent.mEndFrame = 0;
        }
        isDoorClosed = true;
    }
}
