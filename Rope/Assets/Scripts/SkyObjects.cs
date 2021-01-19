using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SkyObjects : MonoBehaviour
{
    private Rigidbody rb;
    private float gravityScale = 0f;
    public static float globalGravity = -9.81f;
    private float maxvalue;
    private float maxvaluey;
    [SerializeField] float a;
    [SerializeField] float b;
    float c = 0f;
    [SerializeField] float alpha;
    [SerializeField] float beta;
    [SerializeField] float gamma;
    [SerializeField] float deltaGamma;
    [SerializeField] float deltaAlpha;
    private Vector3 center;
    public Transform focus;
    private float transx;
    private float transy;
    private float clato;
    private float angle_y;
    private float angle_z;
    public bool trigger = true;
    public bool anim = false;
    public bool rotatey;
    private float valore_x;
    private float valore_y;
    private float valore_z;
    private float valore_z2;
    public bool interact_object = false; 
    public bool move_object = false;
    private float moveSpeed = 1f;
    private Vector3 ogg_interact_pos = new Vector3(0, 0.7f, 0.4f);
    private bool fatto = false;
    private bool tralation = false;
    public LayerMask mask;
    //public GameObject obj;

    // Start is called before the first frame update
    void Start()
    {

       if (interact_object == true)
        {
            maxvalue = Random.Range(.7f, .9f);
            maxvaluey = transform.position.x + Random.Range(-1f, 1f);
            //Debug.Log(gameObject.name + "entrato" + maxvalue);
            gameObject.GetComponent<XRGrab>().interactionLayerMask = mask;
            center = new Vector3(0f, 0f, 0f);
        }
        else
        {
            maxvalue = Random.Range(7f, 13f);
            //center = new Vector3(focus.position.x, focus.position.y, focus.position.z);
        }
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        gravityScale = Random.Range(-0.1f, -0.01f);
        center = new Vector3(0f, 0f, 0f);
        //maxvalue = Random.Range(3f, 7f);
        //a = Random.Range(15f, 30f);
        //b = Random.Range(10f, 14f);
        a = 2f;
        b = 2f;
        angle_y = 0f;
        angle_z = 0f;
        deltaAlpha = Random.Range(0.0001f, 0.001f);
        valore_x = Random.Range(1f, 1.5f);
        valore_y = Random.Range(1f, 1.5f);
        valore_z = Random.Range(0f, 2f);
        valore_z2 = 2 - valore_z;
        //Debug.Log("valori " + valore_x + " " + valore_y);
        
    }

    void Update()
    {
        if (Input.GetKeyDown("g") || GameObject.Find("GameObject").GetComponent<PlayerMovement>().ogg_transf == true)
        {
            anim = true;
        }
        if (anim==true)
        {
            
            clato = Mathf.Sqrt((transform.position.x * transform.position.x) + (transform.position.z * transform.position.z));

            



            if (Mathf.Abs(transform.position.x) < maxvalue && trigger == true && move_object == false && Mathf.Abs(transform.position.y) < maxvalue && interact_object == false)
            {
                Vector3 gravity = globalGravity * gravityScale * Vector3.up;
                rb.AddForce(gravity, ForceMode.Acceleration);
                if (transform.position.x >= 0)
                {
                    rb.AddForce(Vector3.right * valore_x* (Time.deltaTime + 1));
                    rb.AddForce(Vector3.forward * valore_x * (Time.deltaTime + 1));
                    rb.AddForce(-(Vector3.forward) * valore_y * (Time.deltaTime + 1));
                }
                else if (transform.position.x < 0)
                {
                    rb.AddForce(Vector3.left * valore_y);
                    rb.AddForce(-(Vector3.forward) * valore_y);
                    rb.AddForce(Vector3.forward * valore_x);
                }
                
                


                Vector3 latox = new Vector3(clato, 0f, 0f);
                Vector3 lato_fory = new Vector3(transform.position.x, 0f, transform.position.z);
                Vector3 lato_forz = new Vector3(transform.position.x, transform.position.y, 0f);

                angle_y = Vector3.Angle(lato_fory, latox);
                angle_z = Vector3.Angle(lato_forz, latox);


                //c = Mathf.Atan2(clato, transz) * Mathf.Rad2Deg;

                if (transform.position.z < 0f)
                {
                    alpha = (-angle_y) * Mathf.Deg2Rad;
                }
                else
                {
                    alpha = angle_y * Mathf.Deg2Rad;
                }
                if (transform.position.x < 0f)
                {
                    beta = (angle_z - 90f) * Mathf.Deg2Rad;
                }
                else
                {
                    beta = angle_z * Mathf.Deg2Rad;
                }
                //Debug.Log(gameObject.name + " angolo y: " + angle_z);




            }
            else if (Mathf.Abs(transform.position.x) > maxvalue && trigger == true && move_object == false && Mathf.Abs(transform.position.y) < maxvaluey && interact_object == true)
            {
                if (maxvaluey < 0)
                {
                    Vector3 gravity = globalGravity * (-gravityScale) * Vector3.up;
                    rb.AddForce(gravity, ForceMode.Acceleration);
                }
                else if (maxvaluey >=0)
                {
                    Vector3 gravity = globalGravity * gravityScale * Vector3.up;
                    rb.AddForce(gravity, ForceMode.Acceleration);
                }
                //Vector3 gravity = globalGravity * gravityScale * Vector3.up;
                //rb.AddForce(gravity, ForceMode.Acceleration);
                if (transform.position.x >= 0)
                {
                    rb.AddForce((-Vector3.right) * valore_x);
                    rb.AddForce(Vector3.forward * valore_x);
                    rb.AddForce(-(Vector3.forward) * valore_y);
                }
                else if (transform.position.x < 0)
                {
                    rb.AddForce(Vector3.left * valore_y);
                    rb.AddForce(-(Vector3.forward) * valore_y);
                    rb.AddForce(Vector3.forward * valore_x);
                }

                transform.position = Vector3.MoveTowards(transform.position, focus.position, Time.deltaTime * moveSpeed);


                Vector3 latox = new Vector3(clato, 0f, 0f);
                Vector3 lato_fory = new Vector3(transform.position.x, 0f, transform.position.z);
                Vector3 lato_forz = new Vector3(transform.position.x, transform.position.y, 0f);

                angle_y = Vector3.Angle(lato_fory, latox);
                angle_z = Vector3.Angle(lato_forz, latox);


                if (transform.position.z < 0f)
                {
                    alpha = (-angle_y) * Mathf.Deg2Rad;
                }
                else
                {
                    alpha = angle_y * Mathf.Deg2Rad;
                }
                if (transform.position.x < 0f)
                {
                    beta = (angle_z - 90f) * Mathf.Deg2Rad;
                }
                else
                {
                    beta = angle_z * Mathf.Deg2Rad;
                }
                //Debug.Log(gameObject.name + " angolo y: " + angle_z);
            }
            else if(move_object == false)
            {
                if (rotatey == true)
                {
                    transy = center.y + clato * Mathf.Cos(beta);
                }
                else
                {
                    transy = transform.position.y;
                }

                trigger = false;
                rb.isKinematic = true;
                transform.position = new Vector3(( clato * Mathf.Cos(alpha)), transy, clato * Mathf.Sin(alpha));
                beta += deltaAlpha;
                alpha += deltaAlpha;
                c = alpha * Mathf.Rad2Deg;
                //Debug.Log(gameObject.name + " angolo y: " + beta * Mathf.Rad2Deg);
                //Debug.Log("Angolo orbit " + gameObject.name + ":" + c);
                
            }
            else if (move_object == true)
            {
                //MoveToPlayer();
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                gameObject.GetComponent<SkyObjects>().enabled = false;

            }

            /*if (interact_object == true && Input.GetKeyDown("h") && gameObject.name == "Palla")
            {
                move_object = true;
                gameObject.GetComponent<interactableObjMove>().enabled = true;
            }
            if (interact_object == true && Input.GetKeyDown("j") && gameObject.name == "joystick")
            {
                move_object = true;
                gameObject.GetComponent<interactableObjMove>().enabled = true;
            }*/
        }

    }
    
    public void MoveToPlayer()
    {
        /*if (transform.position != ogg_interact_pos && tralation == false)
        {
            
                transform.position = Vector3.MoveTowards(transform.position, ogg_interact_pos, Time.deltaTime * moveSpeed);
                move_object = true;
            
            
                //Destroy(gameObject.GetComponent<SkyObjects>());
            
        }
        else if (transform.position == ogg_interact_pos)
        {
            if (fatto == false)
            {
                Destroy(gameObject.GetComponent<XRSimpleInteractable>());
                //Destroy(gameObject.GetComponent<SkyObjects>());
                gameObject.AddComponent<XRGrabInteractable>();
                fatto = true;
                tralation = true;
            }
        }*/
        move_object = true;
        //gameObject.GetComponent<interactableObjMove>().enabled = true;

    } 

    public void takeBall()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        gameObject.GetComponent<SkyObjects>().enabled = false;
    }



    // Update is called once per frame
    /*void Update()
    {
        clato = Mathf.Sqrt((transform.position.x * transform.position.x) + (transform.position.z * transform.position.z));
       
        center = new Vector3(focus.position.x, focus.position.y, focus.position.z);
        


        if (transform.position.y < maxvalue && trigger==true )
        {
            Vector3 gravity = globalGravity * gravityScale * Vector3.up;
            rb.AddForce(gravity, ForceMode.Acceleration);
            rb.AddForce(Vector3.right * valore_x);
            rb.AddForce(Vector3.left * valore_y );
            
            
            Vector3 latox = new Vector3(clato, 0f, 0f);
            Vector3 lato_fory = new Vector3(transform.position.x, 0f, transform.position.z);
            Vector3 lato_forz = new Vector3(transform.position.x, transform.position.y, 0f);

            angle_y = Vector3.Angle(lato_fory, latox);
            angle_z = Vector3.Angle(lato_forz, latox);


            //c = Mathf.Atan2(clato, transz) * Mathf.Rad2Deg;
            
            if (transform.position.z < 0f)
            {
                alpha = (-angle_y) * Mathf.Deg2Rad;
            }
            else{
                alpha = angle_y * Mathf.Deg2Rad;
            }
            if (transform.position.x < 0f)
            {
                beta = (angle_z - 90f) * Mathf.Deg2Rad;
            }
            else{
                beta = angle_z * Mathf.Deg2Rad;
            }
            Debug.Log(gameObject.name+" angolo y: " + angle_z);
            
          
            

        }
        else
        {
            if (rotatey == true)
            {
                transy = center.y + clato * Mathf.Cos(beta);
            }
            else
            {
                transy = transform.position.y;
            }

            trigger = false;
            rb.isKinematic = true;
            transform.position = new Vector3((center.x + clato * Mathf.Cos(alpha)), transy, center.z + clato * Mathf.Sin(alpha));
            beta += deltaAlpha;
            alpha += deltaAlpha;
            c = alpha * Mathf.Rad2Deg;
            Debug.Log(gameObject.name + " angolo y: " + beta * Mathf.Rad2Deg);
            //Debug.Log("Angolo orbit " + gameObject.name + ":" + c);
        }
        


    }*/
}
