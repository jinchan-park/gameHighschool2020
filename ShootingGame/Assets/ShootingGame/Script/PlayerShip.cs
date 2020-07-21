using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerShip : MonoBehaviour
{
    public float m_speed = 0f;
    public FireBall m_FireBallPrefab;
    public float m_Delay = 0.1f;
    public float m_CoolDown = 0f;

    public Transform[] m_Muzzle;

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector2.up * m_speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector2.down * m_speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * m_speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * m_speed * Time.deltaTime);
        }

        //float xAxis = Input.GetAxis("Horizontal");
        //float yAxis = Input.GetAxis("Vertical");
        //Vector2 inputvaiue = new Vector2(xAxis, yAxis).normalized;
        //Vector3 movement = inputValue * m_speed * Time.deltaTime;
        //transform.position += movement;

        if(Input.GetKey(KeyCode.Space) && m_CoolDown <= 0)
        {
            //총알 생성
            foreach (var Muzzle in m_Muzzle)
            {
                var FireBall = GameObject.Instantiate(m_FireBallPrefab, Muzzle.position, Muzzle.rotation);
            }
            m_CoolDown = m_Delay;

        }

        m_CoolDown -= Time.deltaTime;

    }
}
