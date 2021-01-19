using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveJoystickAudio : MonoBehaviour
{
    public bool audio_Joystick = false;
    public bool audio_Ball = false;
    public bool audio_pupazzo = false;
    // Start is called before the first frame update
public void Active_Sound_Joystick()
    {
        if (audio_Joystick == false)
        {
            FindObjectOfType<AudioManager>().Play("Joystick");
            FindObjectOfType<AudioManager>().Pause("The darkness");
            audio_Joystick = true;
        }
        
        
    }

    public void Active_Sound_Ball()
    {
        if (audio_Ball == false)
        {
            FindObjectOfType<AudioManager>().Play("Basket");
            FindObjectOfType<AudioManager>().Pause("The darkness");
            audio_Ball = true;
        }
    }

    public void Active_Pupazzo()
    {
        if (audio_pupazzo == false)
        {
            FindObjectOfType<AudioManager>().Play("Pupazzo");
            FindObjectOfType<AudioManager>().Pause("The darkness");
            audio_pupazzo = true;
        }
    }
}
