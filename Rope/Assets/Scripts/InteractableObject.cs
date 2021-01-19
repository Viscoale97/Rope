using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public GameObject joystick;
    public GameObject palla;
    public GameObject pupazzo;
    public int counter; 
    public int counter_J;
    public int counter_P;
    public int counter_PUP;
    public LayerMask mask_not;
    public LayerMask mask_eve;
    public GameObject black_Hole;
    public Animator image_black;
    // Start is called before the first frame update
    void Start()
    {
        black_Hole.transform.localScale = new Vector3(0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        counter = counter_J + counter_P + counter_PUP;

        if (gameObject.GetComponent<PlayerMovement>().ogg_transf == true && counter != 3)
        {
            if (joystick.GetComponent<Joystick>().take_Object == true)
            {
                palla.GetComponent<XRGrab>().interactionLayerMask = mask_not;
                pupazzo.GetComponent<XRGrab>().interactionLayerMask = mask_not;
                //counter_P = 1;
            }
            else if (joystick.GetComponent<Joystick>().take_Object == false && pupazzo.GetComponent<Pupazzo>().active_teddy == false && palla.GetComponent<Basket>().active_Ball == false)
            {
                palla.GetComponent<XRGrab>().interactionLayerMask = mask_eve;
                pupazzo.GetComponent<XRGrab>().interactionLayerMask = mask_eve;
                joystick.GetComponent<XRGrab>().interactionLayerMask = mask_eve;
            }

            if (palla.GetComponent<Basket>().active_Ball == true)
            {
                joystick.GetComponent<XRGrab>().interactionLayerMask = mask_not;
                pupazzo.GetComponent<XRGrab>().interactionLayerMask = mask_not;
                //counter_J = 1;
            }
           /* else if (palla.GetComponent<Basket>().active_Ball == false)
            {
                joystick.GetComponent<XRGrab>().interactionLayerMask = mask_eve;
                pupazzo.GetComponent<XRGrab>().interactionLayerMask = mask_eve;
            }*/

            if (pupazzo.GetComponent<Pupazzo>().active_teddy == true)
            {
                joystick.GetComponent<XRGrab>().interactionLayerMask = mask_not;
                palla.GetComponent<XRGrab>().interactionLayerMask = mask_not;
                
            }
            /*else if (pupazzo.GetComponent<Pupazzo>().active_teddy == false)
            {
                joystick.GetComponent<XRGrab>().interactionLayerMask = mask_eve;
                palla.GetComponent<XRGrab>().interactionLayerMask = mask_eve;
            }*/
        }
        

        if (counter == 3)
        {
            black_Hole.transform.localScale += new Vector3(1f * Time.deltaTime, 1f * Time.deltaTime, 1f * Time.deltaTime) * 5f;
            if (black_Hole.transform.localScale.x > 80f)
            {
                image_black.SetTrigger("Black_Hole");
            }
        }
        
    }
}
