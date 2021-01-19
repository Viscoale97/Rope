using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBasket : MonoBehaviour
{
    private Vector3 ogg_interact_pos = new Vector3(0, 1f, 3f);
    private float moveSpeed = 2f;
    public bool lanciata = false;
    private float Timear = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lanciata == true)
        {
            Timear += Time.deltaTime;
            if (Timear < 3f)
            {
                transform.position = Vector3.MoveTowards(transform.position, ogg_interact_pos, Time.deltaTime * moveSpeed);
            }else if (Timear >= 3f)
            {
                lanciata = false;
                Timear = 0;
            }
            
        }
        

        if (Input.GetKeyDown(KeyCode.B))
        {

            lanciata = true;
            //gameObject.transform.position = new Vector3(0f, 3f, 2f);
            gameObject.GetComponent<Basket>().Gravity();
            
            //gameObject.GetComponent<SkyObjects>().MoveToPlayer();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            gameObject.GetComponent<Basket>().Lancio();
            //lanciata = false;
        }

    }
}
