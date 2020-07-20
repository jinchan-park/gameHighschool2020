using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public Animator m_Animator;
    public Rigidbody2D m_Rigidbody2D;
    public AudioSource m_AudioSource;

    public AudioClip m_Jump;
    public AudioClip m_Die;

    public bool m_isGround;
    public bool m_isDead;

    public int m_JumpCount = 0;

    void Update()
    {
        if (m_isDead) return;
        
        m_Animator.SetBool("isGround", m_isGround);

        if (Input.GetKeyDown(KeyCode.Space) && m_JumpCount<2)
        {
            Jump();
        }

           
    }
    public void Jump()
    {
        m_Rigidbody2D.velocity = m_Rigidbody2D.velocity * 0.5f;
        m_Rigidbody2D.AddForce(Vector2.up * 200);
        m_JumpCount++;

        m_AudioSource.clip = m_Jump;
        m_AudioSource.Play();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag == "Ground")
        {
            m_JumpCount = 0;
            m_isGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
            m_isGround = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DeadZone")
        {
            m_isDead = true;
            m_Animator.SetBool("isDead", m_isDead);

            m_AudioSource.clip = m_Die;
            m_AudioSource.Play();

            GameManager_UniRun.Instance.OnPlayerDead();
        }

    }
}
