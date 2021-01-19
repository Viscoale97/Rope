using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deployAsteroid : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float RespawnTime = 1f;
    public bool active = true;
    public GameObject joystick;
    // Start is called before the first frame update
    void Start()
    {
        
        //RespawnTime = 1f;
    }
    private void spawnEnemy()
    {
        GameObject a = Instantiate(asteroidPrefab) as GameObject;
        a.transform.position = new Vector3(Random.Range(-5f, 5f), Random.Range(-7f, 7f), 60f);

        
    }

    private void Update()
    {
        if (joystick.GetComponent<Joystick>().disactive_joystick == false && joystick.GetComponent<Joystick>().active_Timer == true)
        {
            if (active)
            {
                StartCoroutine(AsteroidWave());
                active = false;
            }
            
          
        }
        else if(joystick.GetComponent<Joystick>().disactive_joystick == true)
        {
            StopAllCoroutines();
            active = true;
        }
    }
    // Update is called once per frame
    IEnumerator AsteroidWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(RespawnTime);
            spawnEnemy();
        }
       
    }

    
}
