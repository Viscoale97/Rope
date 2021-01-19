using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    private float speed = 0.1f;
    public ParticleSystem particle;
    private bool asteroidi;
    public GameObject navicella;
    public Transform navicellaTarget;
    public Vector3 pos;
    public bool active_Timer;
    private float Timer = 0f;
    public bool disactive_joystick = false;
    private float Emissioner = 0f;
    public enum ElementState { Start, Medio, End }
    public ElementState currentState = ElementState.Start;
    public LayerMask mask_not;
    public LayerMask mask_eve;
    public bool take_Object;
    public bool take_interrat = false;
    public GameObject XRrig;
    // Start is called before the first frame update
    void Start()
    {
        particle.Pause();
        //emission = particle.emission.rateOverTime;
    }

    // Update is called once per frame
    void Update()
    {
        var emission = particle.emission;

        if (gameObject.GetComponent<SkyObjects>().trigger == false)
        {
            currentState = ElementState.Start;


            if (gameObject.transform.localScale.x <= 2f)
            {
                gameObject.transform.localScale += new Vector3(1f, 1f, 1f) * Time.deltaTime * speed;

            }
        }



        if (navicella.GetComponent<Navicella>().Active_navicella == false)
        {
            navicellaTarget.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, navicellaTarget.transform.position.z);
            //navicellaTarget.transform.position.Set(transform.position.x, transform.position.y + 5f, transform.position.z + 5f);
            //navicella.transform.position = navicellaTarget.transform.position;

        }

        if (take_Object == true)
        {
            active_Timer = true;
        }
        else if (take_Object == false)
        {
            Timer = 0f;
            active_Timer = false;
        }

        if (active_Timer == true)
        {
            Timer += Time.deltaTime;
            emission.rateOverTime = Emissioner + 138f;
            if (Timer > 40f)
            {
                emission.rateOverTime = Emissioner;
                disactive_joystick = true;
                navicella.GetComponent<Navicella>().active_Timer_joystick = false;
                
                
                
            }else if (Timer <= 40f)
            {
                particle.Play();
                currentState = ElementState.Medio;
                gameObject.GetComponent<deployAsteroid>().enabled = true;
                //gameObject.GetComponent<Rotate>().enabled = false;
                navicella.SetActive(true);
                disactive_joystick = false;
            }
        }
        

        //Debug.Log("Entrato Timer Joystick " + Timer);
        if (disactive_joystick == true && currentState == ElementState.Medio)
        {

            
            currentState = ElementState.End;
            //gameObject.GetComponent<XRGrab>().interactionLayerMask = mask_not;
            //gameObject.GetComponent<deployAsteroid>().enabled = false;
        }

        if (navicella.GetComponent<Navicella>().disattivo == true && take_Object == false)
        {
            gameObject.GetComponent<SkyObjects>().enabled = true;
            gameObject.GetComponent<SkyObjects>().move_object = false;
            gameObject.GetComponent<SkyObjects>().trigger = true;
            emission.rateOverTime = Emissioner;
            XRrig.GetComponent<InteractableObject>().counter_J = 1;
            gameObject.GetComponent<ActiveJoystickAudio>().audio_Joystick = false;
            //currentState = ElementState.Start;
            //disactive_joystick = false;
            //gameObject.GetComponent<XRGrab>().interactionLayerMask = mask_eve;
        }
        /*else if (navicella.GetComponent<Navicella>().disattivo == false)
        {
            gameObject.GetComponent<SkyObjects>().enabled = false;
        }

        /* if (currentState == ElementState.End)
         {
             //gameObject.GetComponent<XRGrab>().interactionLayerMask = mask_not;
         }
         else if (gameObject.GetComponent<SkyObjects>().trigger == false && currentState == ElementState.Start)
         {

         }*/

        if (take_interrat == false)
        {
            if (Timer > 40f)
            {
                take_Object = false;
            }
        }

        Debug.Log("take_Object " + take_Object);
    }

    public void ActiveNavivella()
    {
        
        //active_Timer = true;
        take_Object = true;
        take_interrat = true;
        
    }
    public void Out_take ()
    {
        if (Timer > 40f)
        {
            take_Object = false;
        }
        take_interrat = false;
    }
}
