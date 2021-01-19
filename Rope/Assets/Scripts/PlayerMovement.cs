using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{

    //public CharacterController controller;
    public float speed = 0.5f;
    public Transform trans;
    //public Rigidbody rb;
    public Vector3 movement;
    public Transform porta;
    private int trigger = 0;
    public Material sky;
    public Animator animator;
    public Animator stanza;
    public GameObject luce;
    public GameObject ogg;
    private Vector3 ogg_pos;
    public bool ogg_transf = false;
    private bool activeAudio = true;
    public LayerMask mask;
    private bool entrato = true;
    private float TimerCubo = 0f;
    public bool CuboUscito = false;
    public GameObject Cubo;

    private void Start()
    {
        //rb = this.GetComponent<Rigidbody>();
        luce.SetActive(false);
        ogg_pos = ogg.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        /*if (SceneManager.GetActiveScene().name == "Bedroom")
        {
            movement = trans.position;
            movement.x = 0;
            movement.y = 0;
        }*/
        //transform.Translate(trans.position * Time.deltaTime);
        /*float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);*/
    }
    private void FixedUpdate()
    {

        /*if (SceneManager.GetActiveScene().name == "Bedroom")
        {
            if (transform.position.z < 2f || porta.transform.transform.eulerAngles.y > 275f)
            {
                moveCharacther(movement);
                rb.isKinematic = false;
                trigger++;
            }
            else
            {
                rb.isKinematic = true;
                trigger++;
            }
            if (trigger > 3 && transform.position.z > 20.1f)
            {
                rb.isKinematic = true;
                RenderSettings.skybox = sky;
            }

        }*///PROVA MOVIMENTO PERSONAGGIO

        
            /*if (porta.transform.eulerAngles.y < 100)
            {
                animator.SetTrigger("Go");
            }*/
            if ((Input.GetKey("g") || ogg_pos != ogg.transform.position) && ogg_transf == false)
            {
                ActiveAudio();
                //GameObject.Find("CubeobJ").GetComponent<SkyObjects>().anim = true;
                luce.SetActive(true);
                
            foreach (GameObject tmp in GameObject.FindGameObjectsWithTag("muro"))
            {
                tmp.GetComponent<Animator>().SetTrigger("free");
            }

            foreach (GameObject tmp in GameObject.FindGameObjectsWithTag("Inter"))
            {
                tmp.GetComponent<XRGrab>().interactionLayerMask = mask;
            }
            //GameObject.Find("Muro_R").GetComponent<Animator>().SetTrigger("free");
            //GameObject.Find("Muro_L").GetComponent<Animator>().SetTrigger("free");
            //GameObject.Find("Muro_B").GetComponent<Animator>().SetTrigger("free");
            //GameObject.Find("Muro_F").GetComponent<Animator>().SetTrigger("free");
            //GameObject.Find("Soffitto").GetComponent<Animator>().SetTrigger("free");
            
            //Destroy(GameObject.Find("Porta").GetComponent<Rigidbody>());
            

            //GameObject.Find("mura").GetComponent<Rigidbody>().useGravity = true;
            ogg_transf = true;

                RenderSettings.skybox = sky;
            }


        /*if (CuboUscito == true && Cubo.GetComponent<Cubo_prova>().fine_interazione == false)
        {
            //TimerCubo += Time.deltaTime;
            //Debug.Log("Attivato tempo " + TimerCubo);
            if (Vector3.Distance(gameObject.transform.position, Cubo.transform.position) > 5f)
            {
                CuboUscito = false;
                TimerCubo = 0f;
                Cubo.GetComponent<Cubo_prova>().counterCube++;
                Cubo.GetComponent<interactableObjMove>().enabled = true;
                entrato = true;
            }
        }*/
        
        
        if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }

        

    }
    void moveCharacther(Vector3 direction)
    {
        //rb.AddForce(direction * speed);
        //Debug.Log(direction);
    }
    void ActiveAudio()
    {
        if (activeAudio == true)
        {
            FindObjectOfType<AudioManager>().Play("Sky");
            FindObjectOfType<AudioManager>().Play("Pareti");
            FindObjectOfType<AudioManager>().Play("The darkness");
            activeAudio = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.name == "Palla" )
        {
            //other.GetComponent<Basket>().lancio = false;
            if (entrato == true)
            {
                //other.GetComponent<Basket>().count_Tiri++;
                entrato = false;
            }
            
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.name == "Palla")
        {
            other.GetComponent<Basket>().active_lancio = false;
        }

        if (other.name == "CubeProva")
        {
            if (entrato == true)
            {
                CuboUscito = true;
                entrato = false;
            }
            
        }
            //sentrato = true;
        //Debug.Log("Uscito " + other.name);

    }
}
