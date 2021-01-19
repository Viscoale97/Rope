using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveGhost : MonoBehaviour
{
    [SerializeField] private Renderer[] materiali = new Renderer[0];
    public bool cestino_active = false;
    public GameObject ogg;
    

    private float currentDissolveValue = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ogg.GetComponent<Basket>().active_Ball == true)
        {
            if (currentDissolveValue <= 1)
            {
                currentDissolveValue += Time.deltaTime * (1 / 2f);
            }
            

        }
        else if (ogg.GetComponent<Basket>().active_Ball == false)
        {

            if (currentDissolveValue >= 0)
            {
                currentDissolveValue -= Time.deltaTime * (1 / 2f);
            }
            
        }



        foreach (Renderer renderer in materiali)
        {
            renderer.material.SetFloat("_appare", currentDissolveValue);
           
        }
    }
}
