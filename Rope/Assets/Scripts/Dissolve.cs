using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    
    [SerializeField] private Renderer[] materiali = new Renderer[0];
    public bool cestino_active = false;
    public GameObject ogg;
    [SerializeField] private GameObject[] oggetti = new GameObject[0];
    private AudioSource fischi;

    private float currentDissolveValue = 0f;

    void Start()
    {
        fischi = gameObject.GetComponent<AudioSource>();
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
            foreach (GameObject oggetto in oggetti)
            {
                oggetto.SetActive(true);
            }

            if (fischi.volume <= 0.5)
            {
                fischi.volume += Time.deltaTime * (1 / 2f);
            }

        }
        else if (ogg.GetComponent<Basket>().active_Ball == false)
        {
            
            if (currentDissolveValue >= 0)
            {
                currentDissolveValue -= Time.deltaTime * (1 / 2f);
            }
            foreach (GameObject oggetto in oggetti)
            {
                oggetto.SetActive(false);
            }
            
            if (fischi.volume >= 0)
            {
                fischi.volume -= Time.deltaTime * (1 / 2f);
            }
        }
        
        

        foreach(Renderer renderer in materiali)
        {
            renderer.material.SetFloat("_appear", currentDissolveValue);
        }
    }
}
