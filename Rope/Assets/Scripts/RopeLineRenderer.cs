using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeLineRenderer : MonoBehaviour
{
    public LineRenderer line;
    public GameObject Element1;
    public GameObject Element2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        line.SetPosition(0, Element1.transform.position);
        line.SetPosition(1, Element2.transform.position);
    }
}
