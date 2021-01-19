using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Rope1 : MonoBehaviour
{
    public event Action StringMoved;
    public float deltaMovement = 5;
    public bool activeMura = false;
    // Start is called before the first frame update


        public void StartCalculatingDistance()
        {
        StartCoroutine(CalculateDistance());
        }


        public void StopCalculattingDistance()
        {
            StopAllCoroutines();
        }


   public IEnumerator CalculateDistance()
    {
        float yStartPos = transform.position.y;
        while (true)
        {
            if ((transform.position.y - yStartPos) > deltaMovement)
            {
                activeMura = true;
                yield break;
            }

            yield return null;
        }
    }
}
