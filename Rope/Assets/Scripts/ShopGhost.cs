using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopGhost : MonoBehaviour
{
    [SerializeField] private GameObject[] componenti = new GameObject[0];
    [SerializeField] private GameObject[] nonni = new GameObject[0];
    private float currentDissolveValue = 0f;
    public GameObject pupazzo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (pupazzo.GetComponent<Pupazzo>().active_teddy == true)
        {
            if (currentDissolveValue <= 1)
            {
                currentDissolveValue += Time.deltaTime * (1 / 2f);
            }


        }
        else if (pupazzo.GetComponent<Pupazzo>().active_teddy == false)
        {

            if (currentDissolveValue >= 0)
            {
                currentDissolveValue -= Time.deltaTime * (1 / 2f);
            }

        }




        foreach (GameObject ogg in componenti)
        {
            for (int i = 0; i < ogg.GetComponent<MeshRenderer>().materials.Length; i++)
            {
                ogg.GetComponent<MeshRenderer>().materials[i].SetFloat("_appare", currentDissolveValue);
            }
            
        }

        foreach (GameObject ogg in nonni)
        {
            for (int i = 0; i < ogg.GetComponent<SkinnedMeshRenderer>().materials.Length; i++)
            {
                ogg.GetComponent<SkinnedMeshRenderer>().materials[i].SetFloat("_appare", currentDissolveValue);
            }

        }
    }
}
