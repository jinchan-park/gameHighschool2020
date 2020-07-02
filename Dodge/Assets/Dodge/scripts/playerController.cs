using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float m_speed = 13f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();

        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        rigidbody.AddForce(new Vector3(xAxis, 0, yAxis) * m_speed);

        float fireAxis = Input.GetAxis("Fire1");

        //if (fireAxis > 0.95f)
        //    Die();

         /*if (Input.GetKey(KeyCode.LeftArrow))
         {
             //transform.position += Vector3.left * m_speed * Time.deltaTime;
             rigidbody.AddForce(Vector3.left * m_speed);
             Debug.Log("좌");
         }
         else if (Input.GetKey(KeyCode.RightArrow))
         {
             //transform.position += Vector3.right * m_speed * Time.deltaTime;
             rigidbody.AddForce(Vector3.right * m_speed);
             Debug.Log("우");
         }
         else if (Input.GetKey(KeyCode.UpArrow))
         {
             //transform.position += Vector3.forward * m_speed * Time.deltaTime;
             rigidbody.AddForce(Vector3.forward * m_speed);
             Debug.Log("위");
         }
         else if (Input.GetKey(KeyCode.DownArrow))
         {
             //transform.position += Vector3.back * m_speed * Time.deltaTime;
             rigidbody.AddForce(Vector3.back * m_speed);
             Debug.Log("아래");
         }*/

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("사망");
        gameObject.SetActive(false);
    }
}
