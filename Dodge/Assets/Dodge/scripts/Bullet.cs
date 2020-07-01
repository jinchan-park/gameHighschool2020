using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public float m_speed = 13f;

    public float m_Destroy = 5f;


    // Update is called once per frame
    void Update()
    {
        Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();

        rigidbody.AddForce(transform.forward * m_speed);

        m_Destroy -= Time.deltaTime;

        if (m_Destroy <= 0)
        {
            gameObject.SetActive(false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.tag != null && other.attachedRigidbody.tag ==  "Player")
        {
            var player = other.attachedRigidbody.GetComponent<playerController>();
                player.Die();
        }
    }

}
