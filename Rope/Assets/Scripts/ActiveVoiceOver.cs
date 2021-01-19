using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveVoiceOver : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject image;
    private Animator Anim_Image;
    private int activeLight = 0;
    public Light light1;
    public Light light2;
    public Material bianco;

    void Start()
    {
        Anim_Image = image.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (activeLight == 1)
        {
            //Color color = bianco.color;
            //color.a -= 1f * Time.deltaTime;
            //bianco.color = color;
            //light1.intensity = Time.deltaTime * 100;
            //light2.intensity = Time.deltaTime * 100;
        }
        else if (activeLight == 2)
        {
            //light1.intensity -= Time.deltaTime * 100;
            //light2.intensity -= Time.deltaTime * 100;
        }
    }

    public void PlaySoundVoiceStart()
    {
        FindObjectOfType<AudioManager>().Play("Porta");
    }
    
    public void PlaySoundVoiceStanza()
    {
        FindObjectOfType<AudioManager>().Play("Stanza");
    }

    public void DeActiveLightInRoom()
    {
        //activeLight = 1;
        Anim_Image.SetTrigger("ActiveInRoom");
        //activeLight = 2;
        
    }
}
