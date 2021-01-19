using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestJoystick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {

            gameObject.GetComponent<Joystick>().ActiveNavivella();
            gameObject.GetComponent<SkyObjects>().MoveToPlayer();
            FindObjectOfType<AudioManager>().Play("Joystick");
            FindObjectOfType<AudioManager>().Pause("The darkness");
        }
        if (Input.GetKeyDown(KeyCode.M))
        {

            gameObject.GetComponent<Joystick>().Out_take();
            
        }
    }
}
