using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpadaLaser : MonoBehaviour
{
    public GameObject spada;
    // Start is called before the first frame update
    void Start()
    {
        spada.SetActive(false);
    }

    // Update is called once per frame
    public void triggerBean()
    {
        spada.SetActive(true);
    }
}
