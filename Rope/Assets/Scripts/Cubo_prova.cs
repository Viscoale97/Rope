using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubo_prova : MonoBehaviour
{
    private Vector3 ogg_interact_pos = new Vector3(0, 1f, 3f);
    private float moveSpeed = 2f;
    public bool lanciata = false;
    public bool lanciataVR = false;
    private float Timear = 0f;
    private Rigidbody rb;
    public int counterCube = 0;
    public GameObject player;
    public bool first_lancio = true;
    public bool fine_interazione = false; 
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<SkyObjects>().enabled == false)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
        /*if (lanciata == true)
        {
            Timear += Time.deltaTime;
            if (Timear < 1f)
            {
                rb.AddForce(Vector3.forward);
            }
            else if (Timear >= 1f)
            {
                lanciata = false;
                Timear = 0;
            }

            if (first_lancio == true)
            {
                if (gameObject.GetComponent<SkyObjects>().move_object == true)
                {
                    Destroy(gameObject.GetComponent<SkyObjects>());
                    first_lancio = false;
                }

            }

        }

        if (lanciataVR == true)
        {
            if (first_lancio == true)
            {
                if (gameObject.GetComponent<SkyObjects>().move_object == true)
                {
                    Destroy(gameObject.GetComponent<SkyObjects>());
                    first_lancio = false;
                }

            }
        }

        /*if (player.GetComponent<PlayerMovement>().CuboUscito == true)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        else if (player.GetComponent<PlayerMovement>().CuboUscito == false)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }*/

        if (Input.GetKeyDown(KeyCode.T))
        {

            lanciata = true;
            if (first_lancio == true)
            {
                takeBall();
            }
            
            //gameObject.transform.position = new Vector3(0f, 3f, 2f);

        }

        
        

        if (counterCube == 4 && gameObject.GetComponent<interactableObjMove>().enabled == false)
        {
            //gameObject.AddComponent<SkyObjects>();
            fine_interazione = true;
            gameObject.GetComponent<SkyObjects>().enabled = true;
            gameObject.GetComponent<SkyObjects>().move_object = false;
            gameObject.GetComponent<SkyObjects>().trigger = true;
            counterCube = 0;
        }

    }

    public void takeBall()
    {
        
            //gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.GetComponent<SkyObjects>().enabled = false;
          
    }

    public void activeCube() {
        
        if (first_lancio == true)
        {
            gameObject.GetComponent<SkyObjects>().MoveToPlayer();
        }
    }
    public void DeactiveCube()
    {
        lanciataVR = true;
    }
}
