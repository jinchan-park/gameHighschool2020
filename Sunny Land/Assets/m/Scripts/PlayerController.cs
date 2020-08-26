using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D m_RigidBody2D;

    public float m_XAxisSpeed = 3f;
    public float m_YJumpPower = 3f;
    void Start()
    {
        m_RigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float xAis = Input.GetAxis("Horizontal");
        float yAis = Input.GetAxis("Vertical");

        Vector2 velocity = m_RigidBody2D.velocity;
        velocity.x = xAis * m_XAxisSpeed;
        m_RigidBody2D.velocity = velocity;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_RigidBody2D.AddForce(Vector3.up * m_YJumpPower);
        }



    }


}
