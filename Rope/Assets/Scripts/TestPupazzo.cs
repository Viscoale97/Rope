using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPupazzo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {

            
            //gameObject.transform.position = new Vector3(0f, 3f, 2f);
            gameObject.GetComponent<Pupazzo>().Take_Teddy();
            FindObjectOfType<AudioManager>().Play("Pupazzo");
            FindObjectOfType<AudioManager>().Pause("The darkness");

            //gameObject.GetComponent<SkyObjects>().MoveToPlayer();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            gameObject.GetComponent<Pupazzo>().Leave_Teddy();
        }

      
    }
}
