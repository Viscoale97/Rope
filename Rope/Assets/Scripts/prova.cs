using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prova : MonoBehaviour
{
    public Animator anim;
    public GameObject porta;
    public Animator anim_Go;
    
    //public Material bianco;
    //private bool Time_togo;
    private Color color;
    private float Time_togo;
    private bool Time_togo_bool = false;
    public Transform from;
    public Transform to;
    private float timeCount = 0.0f;
    private AudioSource flash;


    public bool open_Door = false;
    // Start is called before the first frame update
    void Start()
    {
        to.rotation = porta.transform.rotation;
        FindObjectOfType<AudioManager>().Play("Appare_porta");
        flash = gameObject.GetComponent<AudioSource>();
        //Color color = bianco.color;
        //color.a = 0f;
        //bianco.color = color;

    }

    // Update is called once per frame
    void Update()
    {
        //from.rotation = porta.transform.rotation;
        //Debug.Log(porta.transform.transform.eulerAngles.y);
        if (Input.GetKeyDown(KeyCode.F)|| (porta.transform.transform.eulerAngles.y < 40 && porta.transform.transform.eulerAngles.y > 30) || (porta.transform.transform.eulerAngles.y < 320 && porta.transform.transform.eulerAngles.y > 310))
        {
            
            open_Door = true;

            ActiveLightInRoom();
            FindObjectOfType<AudioManager>().Pause("Porta");
        }
        
        /*timeCount = timeCount + Time.deltaTime;
        if (open_Door == true)
        {
            transform.rotation = Quaternion.Slerp(from.rotation, to.rotation, timeCount);
        }

        Debug.Log("porta_start " + from.eulerAngles.y);
        Debug.Log("porta_end " + to.eulerAngles.y);*/
    }
    public void ActiveGo()
    {
        anim_Go.SetTrigger("Go");

        Destroy(GameObject.Find("Porta").GetComponent<HingeJoint>());
        Destroy(GameObject.Find("Porta").GetComponent<HingeJointListener>());

        porta.transform.eulerAngles = to.transform.eulerAngles;
        porta.transform.position = to.position;



        /*if ((porta.transform.transform.eulerAngles.y < 90 && porta.transform.transform.eulerAngles.y > 80))
        {
            porta.transform.rotation = Quaternion.Euler(0f, -36f, 0f);
        }
        else if ((porta.transform.transform.eulerAngles.y < 280 && porta.transform.transform.eulerAngles.y > 245))
        {
            porta.transform.rotation = Quaternion.Euler(0f, 36f, 0f);
        }*/

        //transform.rotation = Quaternion.Slerp(from.rotation, to.rotation, timeCount);
        //activeLight = 1;
    }
    public void ActiveLightInRoom()
    {
       
         //color.a += 1f * Time.deltaTime;
        //bianco.color = color;
        //Time_togo_bool = true;
        anim.SetTrigger("Active");
        //activeLight = 2;
    }

    public void ActiveFlash()
    {
        flash.Play();
    }
}
