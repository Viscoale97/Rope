using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navicella : MonoBehaviour
{
    private Rigidbody rb;
    public Transform ogg_interact_pos;
    public bool Active_navicella = false;
    public bool Active_audio = false;
    private float moveSpeed = 10f;
    public GameObject joystick;
    private Vector3 deltaValue;
    private float z_Start = 0f;
    public bool disattivo = false;
    public bool active_sound;
    public bool active_Timer_joystick = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        z_Start = transform.position.z;
        disattivo = false;
        //FindObjectOfType<AudioManager>().Play("Joystick");
    }

    // Update is called once per frame
    void Update()
    {
        /*if (gameObject.transform.position.z >= 4f)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(-(Vector3.forward));
        }
        else
        {
            rb.constraints = RigidbodyConstraints.FreezePositionZ;
        }*/

        if (transform.position != ogg_interact_pos.position && Active_navicella == false && joystick.GetComponent<Joystick>().disactive_joystick == false)
        {
            Active_Sound_navicella();
            transform.position = Vector3.MoveTowards(transform.position, ogg_interact_pos.position, Time.deltaTime * moveSpeed);
            //move_object = true;
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            disattivo = false;
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            //Destroy(gameObject.GetComponent<SkyObjects>());

        }
        else if (transform.position == ogg_interact_pos.position && joystick.GetComponent<Joystick>().disactive_joystick == false)
        {
            if (Active_navicella == false)
            {
                if (Active_audio == false)
                {
                    //FindObjectOfType<AudioManager>().Play("Joystick");
                    
                }
                //Active_navicella = true;

                //tralation = true;
                active_Timer_joystick = true;
            }
        }
        else if (joystick.GetComponent<Joystick>().disactive_joystick == true)
        {
            //Debug.Log("Navicella entrata");
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            if (transform.position.z < z_Start)
            {
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward);
            }
            else
            {
                disattivo = true;
                rb.isKinematic = true;

                gameObject.GetComponent<AudioSource>().Stop();
                gameObject.SetActive(false);
                //Active_audio = false;

            }
            
            
        }
        
    }

    public void Active_Sound_navicella()
    {
        if (active_sound == true)
        {
            gameObject.GetComponent<AudioSource>().Play();
            active_sound = false;
        }
    }

  
}
