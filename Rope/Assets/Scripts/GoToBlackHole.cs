using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToBlackHole : MonoBehaviour
{
    private Vector3 ogg_interact_pos = new Vector3(0, 1.30f, 1.10f);
    public Transform focus;
    private float moveSpeed = 0.01f;
    private bool active_Hole = false;
    public GameObject XRrig;
    public LayerMask mask;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if (XRrig.GetComponent<InteractableObject>().counter == 3)
        {
            ogg_interact_pos = focus.position;
            StartCoroutine(BlackHole());
            if (gameObject.name == "palla")
            {

            }
            else
            {
                gameObject.GetComponent<SkyObjects>().enabled = false;
            }
            
            foreach (GameObject tmp in GameObject.FindGameObjectsWithTag("Inter"))
            {
                tmp.GetComponent<XRGrab>().interactionLayerMask = mask;
            }
        }
            
           
            
        

        
    }
    public IEnumerator BlackHole()
    {
        
        while (true)
        {

            transform.position = Vector3.MoveTowards(transform.position, ogg_interact_pos, Time.deltaTime * moveSpeed);
            yield return null;
        }
    }
}
