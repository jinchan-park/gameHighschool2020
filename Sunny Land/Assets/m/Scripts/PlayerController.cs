using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public Transform m_Sprite;

    private Rigidbody2D m_Rigidbody2D;
    private Animator m_Animator;
    public float m_XAxisSpeed = 3f;
    public float m_YJumpPower = 3f;
    public bool m_IsTouchLadder = false;
    public bool m_m_IsClimbing = false;
    public float m_ClimbSpeed = 2f;

    public bool m_IsJumping = false;
    public bool m_IsClimbing = false;

    public int m_JumpCount = 0;

    protected void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
    }

    protected void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        if(m_IsTouchLadder  == true && Mathf.Abs(yAxis) > 0.5f)
        {
            m_IsClimbing = true;
        }

        if (!m_IsClimbing)
        {

            Vector2 velocity = m_Rigidbody2D.velocity;
            velocity.x = xAxis * m_XAxisSpeed;
            m_Rigidbody2D.velocity = velocity;

            if (xAxis > 0)
                m_Sprite.localScale = new Vector3(1, 1, 1);
            else if (xAxis < 0)
                m_Sprite.localScale = new Vector3(-1, 1, 1);


            if (Input.GetKeyDown(KeyCode.UpArrow)
                && m_JumpCount <= 0)
            {
                m_Rigidbody2D.AddForce(Vector3.up
                    * m_YJumpPower);

                m_JumpCount++;
            }
            m_Animator = GetComponent<Animator>();
            var animator = GetComponent<Animator>();
            animator.SetFloat("VelocityY", velocity.y);

            m_IsJumping = Mathf.Abs(velocity.y) >= 0.1f ? true : false;

            m_Animator.SetBool("Isjumping", m_IsJumping);
            m_Animator.SetFloat("VelocityX", Mathf.Abs(xAxis));

            m_Animator.SetFloat("Velocity", velocity.y);

        }
        else
        {
            //사다리 타느 도중의 이동기능
            m_Rigidbody2D.constraints  = m_Rigidbody2D.constraints |  RigidbodyConstraints2D.FreezePosition;

            Vector3 movement = Vector3.zero;
            movement.y = yAxis * m_ClimbSpeed * Time.deltaTime;
            movement.x = xAxis * m_ClimbSpeed * Time.deltaTime;

            transform.position += movement;
            if(Input.GetKeyDown(KeyCode.Space))
            {
                ClimbingExit();
            }
            m_Animator.SetBool("IsClimbing", m_IsClimbing);
            m_Animator.SetFloat("ClimbingSpeed", 
                Mathf.Abs(xAxis) +Mathf.Abs(yAxis));
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
            if (contact.normal.y > 0.5f)
            {
                m_JumpCount = 0;
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ladder")
        {
            m_IsTouchLadder = true;
        }
    }
    private void ClimbingExit()
    {
        m_Rigidbody2D.constraints =
            m_Rigidbody2D.constraints
            & ~RigidbodyConstraints2D.FreezePosition;
        m_IsClimbing = false;

        m_Animator.SetBool("IsClimbing", m_IsClimbing);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Ladder")
        {
            m_IsTouchLadder = false;

            ClimbingExit();
        }
    }


    
}
