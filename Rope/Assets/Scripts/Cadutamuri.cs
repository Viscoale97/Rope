using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cadutamuri : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject pavimento;
    public GameObject ogg;
    private bool rotate = false;
    public bool Muro_L;
    public bool Muro_R;
    public bool Muro_B;
    public bool Muro_F;
    Vector3 m_EulerAngleVelocity;
    public GameObject porta;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        m_EulerAngleVelocity = new Vector3(0, 100, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
        
        if (rotate == true)
        {
            //rb.rotation = new Quaternion(0f, 8f, 5f, 3f);
            //rb.AddForce(Vector3.right * Time.deltaTime);
            //Debug.Log("ruotare true");
            ogg.transform.Rotate(2f*Time.deltaTime, 0.2f*Time.deltaTime, 0.2f*Time.deltaTime, Space.World);
        }
    }

    public void Crollare()
    {
        if (Muro_B)
        {
            rb.AddForce(1, -20, 3);
            rb.AddTorque(transform.right * Time.deltaTime);
        }
        if (Muro_L)
        {
            rb.AddForce(-3, -20, 1);
            rb.AddTorque(transform.right * Time.deltaTime);
        } 
        if (Muro_R)
        {
            rb.AddForce(3, -20, 1);
            rb.AddTorque(transform.right * Time.deltaTime);
        }
        if (Muro_F)
        {
            rb.AddForce(1, -20, -3);
            rb.AddTorque(transform.right * Time.deltaTime);
            porta.GetComponent<Rigidbody>().AddForce(1, -20, -3);
            porta.transform.Rotate(2f * Time.deltaTime, 0.2f * Time.deltaTime, 0.2f * Time.deltaTime, Space.World);

        }
        
        rotate = true;
        
        if (gameObject.name == "Muro_L")
        {
            pavimento.GetComponent<Rigidbody>().AddForce(1, -20, 1);
            //rb.AddTorque(transform.right * Time.deltaTime);
            //pavimento.transform.Rotate(90.0f, 0.0f, 0.0f, Space.World);
        }
    }
}
