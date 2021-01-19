using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class interactableObjMove : MonoBehaviour
{

    private float moveSpeed = 10f;
    public bool fatto = false;
    private Vector3 ogg_interact_pos = new Vector3(0, 1.30f, 1.10f);
    public bool center = false;
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.GetComponent<SkyObjects>().enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();

       

    }

    public void MoveToPlayer()
    {
        if (transform.position != ogg_interact_pos)
        {

            transform.position = Vector3.MoveTowards(transform.position, ogg_interact_pos, Time.deltaTime * moveSpeed);
            //move_object = true;
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            fatto = false;
            //Destroy(gameObject.GetComponent<SkyObjects>());
            center = false;
        }
        else if (transform.position == ogg_interact_pos)
        {
            if (fatto == false)
            {
                //Destroy(gameObject.GetComponent<XRSimpleInteractable>());
                //Destroy(gameObject.GetComponent<SkyObjects>());
               
                
                gameObject.GetComponent<interactableObjMove>().enabled = false;
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                

                fatto = true;
                
                //tralation = true;
            }
            center = true;
        }

    }

   
}
