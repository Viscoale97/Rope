using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pupazzo : MonoBehaviour
{
    public bool active_teddy = false;
    private float TimePupazzo = 0;
    public GameObject nonno;
    public GameObject nonna;
    private Animator anim_nonno;
    private Animator anim_nonna;
    private bool active_hello = true;
    private bool leave_teddy = false;
    public GameObject XRrig;
    // Start is called before the first frame update
    void Start()
    {
        anim_nonna = nonna.GetComponent<Animator>();
        anim_nonno = nonno.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (active_teddy == true)
        {
            TimePupazzo += Time.deltaTime;
            if (TimePupazzo > 45)
            {

                Active_Hello();
                if (TimePupazzo > 49)
            {
                active_teddy = false;
                
                TimePupazzo = 0;
                    
                }

            }
        }else if (active_teddy == false && leave_teddy == true)
        {
            TimePupazzo = 0;
            active_hello = true;
            gameObject.GetComponent<ActiveJoystickAudio>().audio_pupazzo = false;
            gameObject.GetComponent<SkyObjects>().enabled = true;
            gameObject.GetComponent<SkyObjects>().move_object = false;
            gameObject.GetComponent<SkyObjects>().trigger = true;
            XRrig.GetComponent<InteractableObject>().counter_PUP = 1;
        }
    }

    public void Take_Teddy()
    {
        //active_lancio = true;
        //lancio = true;
        active_teddy = true;
        leave_teddy = false;
        if (gameObject.GetComponent<SkyObjects>().enabled == true)
        {
            gameObject.GetComponent<SkyObjects>().enabled = false;
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
       
        if (TimePupazzo == 0)
        {
            anim_nonno.SetTrigger("StartNonno");
            anim_nonna.SetTrigger("StartNonna");
        }

        //gameObject.GetComponent<Rigidbody>().useGravity = true;
        //count_Tiri++;
    }

    public void Leave_Teddy()
    {
        leave_teddy = true;
    }

    private void Active_Hello()
    {
        if (active_hello == true)
        {
            anim_nonno.SetTrigger("ActiveNonnoHello");
            anim_nonna.SetTrigger("ActiveNonnaHello");
            active_hello = false;
        }
        
    }

}
