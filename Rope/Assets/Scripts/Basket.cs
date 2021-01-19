using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Basket : MonoBehaviour
{

    public bool lancio = false;
    private float temposcad = 0f;
    private Vector3 ogg_interact_pos = new Vector3(0, 0.7f, 0.4f);
    private bool endInteraction = false;
    private bool tot_tiri = false;
    private float TimerActivity = 0f;
    public bool active_lancio = true;
    public int count_Tiri = 0;
    public GameObject XRrig;
    private float Timer_Active_event;
    private bool end_Soundtrack_ball = false;
    public enum ElementState { Start, Medio, End, Caduta}
    public ElementState currentState = ElementState.Start;
    
    public LayerMask mask_not;
    public LayerMask mask_eve;
    public bool active_Ball = false;
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.GetComponent<XRGrab>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (active_lancio == false && currentState == ElementState.Medio)
        {
            temposcad += Time.deltaTime;
            //Debug.Log(temposcad);
            if (temposcad > 7f)
            {
                temposcad = 0f;
                count_Tiri++;
                gameObject.GetComponent<interactableObjMove>().enabled = true;
                //gameObject.GetComponent<SkyObjects>().enabled = true;
                currentState = ElementState.Start;
                lancio = false;
                //gameObject.GetComponent<TestBasket>().enabled = false;


            }
            
        }

        if (active_Ball == true)
        {
            Timer_Active_event += Time.deltaTime;
            if (Timer_Active_event > 53f)
            {
                end_Soundtrack_ball = true;
            }
        }


        /*if (currentState == ElementState.Medio)
        {
            TimerActivity += Time.deltaTime;
            Debug.Log("Tempo palla " + TimerActivity);
            if (TimerActivity > 30f && gameObject.GetComponent<interactableObjMove>().fatto == false)
            {
                gameObject.GetComponent<XRGrab>().interactionLayerMask = mask_not;
                currentState = ElementState.End;
                TimerActivity = 0f;
            }
        }*/


        /*if (gameObject.GetComponent<interactableObjMove>().center == true && gameObject.GetComponent<interactableObjMove>().enabled == false && lancio == false && currentState == ElementState.Caduta)
            {
                currentState = ElementState.Start;
            }
            else if (gameObject.GetComponent<interactableObjMove>().enabled == true && count_Tiri > 0)
            {
                currentState = ElementState.Caduta;
            }*/
        





        if (count_Tiri >= 4 && gameObject.GetComponent<interactableObjMove>().center == false && end_Soundtrack_ball == true)
        {
            tot_tiri = true;
            count_Tiri++;
        }

        


        if (tot_tiri == true)
        {
            
            if (gameObject.GetComponent<interactableObjMove>().center == true && currentState == ElementState.Start && tot_tiri == true)
            {

            currentState = ElementState.End;
                if (currentState == ElementState.End)
                {
                //endInteraction = false;
                gameObject.GetComponent<SkyObjects>().enabled = true;
                gameObject.GetComponent<SkyObjects>().move_object = false;
                gameObject.GetComponent<SkyObjects>().trigger = true;
                currentState = ElementState.Start;
                end_Soundtrack_ball = false;
                count_Tiri = 0;
                tot_tiri = false;
                //gameObject.GetComponent<XRGrab>().interactionLayerMask = mask_eve;
                    XRrig.GetComponent<InteractableObject>().counter_P = 1;
                    active_lancio = true;
                //Debug.Log("Palla entrata");
                    active_Ball = false;
                    gameObject.GetComponent<ActiveJoystickAudio>().audio_Ball = false;
                }
            }
        }

        

        /*if (active_lancio == true)
        {
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            //currentState = ElementState.Medio;
        }*/
        //Debug.Log("Tiri " + count_Tiri);
    }
    public void Gravity()
    {
        //active_lancio = true;
        //lancio = true;
        active_Ball = true;
        if (gameObject.GetComponent<SkyObjects>().enabled == true)
        {
            gameObject.GetComponent<SkyObjects>().enabled = false;
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
        
        
        //gameObject.GetComponent<Rigidbody>().useGravity = true;
        //count_Tiri++;
    }
    public void Lancio()
    {
        //active_lancio = false;
        currentState = ElementState.Medio;
        //gameObject.GetComponent<Rigidbody>().useGravity = true;
        //lancio = true;
        //gameObject.GetComponent<XRGrab>().enabled = false;
    }
}
