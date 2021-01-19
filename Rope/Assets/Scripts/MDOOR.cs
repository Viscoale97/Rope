using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MDOOR : MonoBehaviour
{
    public LayerMask draggableMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}
